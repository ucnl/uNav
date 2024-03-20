using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Text;
using UCNLDrivers;
using UCNLNav;
using UCNLNMEA;

namespace uNav.uNavCore
{
    public class uNavBase
    {
        #region Properties

        uNavPort uPort;
        NMEASerialPort serialBypassPort;
        UDPTranslator udpOutput;

        #region uPort
        public bool IsWaitingLocal { get => uPort.IsWaitingLocal; }
        public bool PortDetected { get => uPort.Detected; }
        public string PortStatus { get => uPort.ToString(); }
        public string PortName { get => uPort.PortName; }
        public bool IsActive { get => uPort.IsActive; }
        public bool IsDeviceInfoValid { get => uPort.IsDeviceInfoValid; }

        public string DeviceInfo { get => string.Format("{0} v{1}", uPort.SystemInfo, uPort.SystemVersion); }
        public string DeviceSerialNumber { get => uPort.SerialNumber; }

        public bool TargetLocationPresent
        {
            get => TLt.IsInitialized && TLn.IsInitialized;
        }

        #endregion

        #region serialBypassPort

        public bool SerialBypassActive { get => (serialBypassPort != null) && (serialBypassPort.IsOpen); }

        public bool SerialBypassEnabled { get; private set; }

        #endregion

        #region udpOutput

        public bool UDPOutputEnabled { get; private set; }

        #endregion

        REF_POINT_TYPE_Enum refPointType = REF_POINT_TYPE_Enum.INVALID;

        StatHelper statHelper;
        public bool StatHelperActive { get => statHelper.IsActive; }

        #region AgingValues

        AgingValue<double> TLt;
        AgingValue<double> TLn;
        AgingValue<double> TDpt;
        AgingValue<double> TCrs;
        AgingValue<double> TRer;
        AgingValue<double> RPLt;

        AgingValue<double> RPLn;
        AgingValue<double> Dst2RP;
        AgingValue<double> Crs2RP;
        AgingValue<double> Crs4RP;
        AgingValue<double> ALt;
        AgingValue<double> ALn;
        AgingValue<double> ACrs;
        AgingValue<double> ASpd;

        AgingValue<double> statCEP;
        AgingValue<double> statDRMS;

        Dictionary<int, AgingValue<GeoPoint3D>> bLocs;
        Dictionary<int, AgingValue<double>> bBats;

        AgingValue<string> lastECode;
        AgingValue<double> rtmp;
        AgingValue<double> rprs;
        AgingValue<double> rbat;

        #endregion

        readonly string[] llSeparators = new string[] { ">>", " " };

        #endregion

        #region Constructor

        public uNavBase(BaudRate uNavPortBaudrate)
        {
            #region statHelper

            statHelper = new StatHelper(4096);
            statHelper.IsActiveChanged += (o, e) => StatHelperActiveChanged.Rise(this, EventArgs.Empty);
            statHelper.IsAutoStop = true;

            #endregion

            #region AgingValues

            TLt = new AgingValue<double>(3, 60, uNav.latlon_fmtr);
            TLn = new AgingValue<double>(3, 60, uNav.latlon_fmtr);
            TDpt = new AgingValue<double>(3, 600, uNav.meters1dec_fmtr);
            TCrs = new AgingValue<double>(3, 60, uNav.degrees1dec_fmtr);
            TRer = new AgingValue<double>(3, 600, uNav.meters1dec_fmtr);
            RPLt = new AgingValue<double>(3, 30000, uNav.latlon_fmtr);
            RPLn = new AgingValue<double>(3, 30000, uNav.latlon_fmtr);

            Dst2RP = new AgingValue<double>(3, 600, uNav.meters1dec_fmtr);
            Crs2RP = new AgingValue<double>(3, 60, uNav.degrees1dec_fmtr);
            Crs4RP = new AgingValue<double>(3, 60, uNav.degrees1dec_fmtr);
            ALt = new AgingValue<double>(3, 60, uNav.latlon_fmtr);
            ALn = new AgingValue<double>(3, 60, uNav.latlon_fmtr);
            ACrs = new AgingValue<double>(3, 60, uNav.degrees1dec_fmtr);
            ASpd = new AgingValue<double>(3, 60, uNav.kmh_mps_fmtr);

            statCEP = new AgingValue<double>(4, 300, uNav.meters3dec_fmtr);
            statDRMS = new AgingValue<double>(4, 300, uNav.meters3dec_fmtr);

            bLocs = new Dictionary<int, AgingValue<GeoPoint3D>>();
            bBats = new Dictionary<int, AgingValue<double>>();

            for (int bID = 0; bID < 4;  bID++)
            {
                bBats.Add(bID, new AgingValue<double>(30, 60, uNav.v1dec_fmtr));
                bLocs.Add(bID, new AgingValue<GeoPoint3D>(3, 60, x => x.ToString()));
            }

            lastECode = new AgingValue<string>(3, 600, x => x.ToString());
            rtmp = new AgingValue<double>(3, 60, uNav.degC_fmtr);
            rprs = new AgingValue<double>(3, 60, uNav.mBar_fmtr);
            rbat = new AgingValue<double>(3, 60, uNav.v1dec_fmtr);

            #endregion

            #region uPort

            uPort = new uNavPort(uNavPortBaudrate);

            uPort.IsLogIncoming = true;
            uPort.IsTryAlways = true;

            uPort.LogEventHandler += (o, e) => LogEventHandler.Rise(this, e);
            uPort.DetectedChanged += (o, e) =>
            {
                DetectedChanged.Rise(this, e);

                if (SerialBypassEnabled)
                {
                    if (uPort.Detected)
                        SerialBypassOpen();
                    else
                        SerialOutputClose();
                }
            };
            uPort.IsActiveChanged += (o, e) => IsActiveChanged.Rise(this, e);
            uPort.RawDataReceived += (o, e) =>
            {
                if (SerialBypassActive)
                {
                    try
                    {
                        serialBypassPort.SendRaw(e.Data);
                    }
                    catch (Exception ex)
                    {
                        LogEventHandler.Rise(this, new LogEventArgs(LogLineType.ERROR, ex));
                    }
                }

                if (UDPOutputEnabled)
                {
                    try
                    {
                        udpOutput.Send(e.Data);
                    }
                    catch (Exception ex)
                    {
                        LogEventHandler.Rise(this, new LogEventArgs(LogLineType.ERROR, ex));
                    }
                }
            };

            uPort.DeviceSettingsReceived += (o, e) => DeviceSettingsReceived.Rise(this, e);
            uPort.DeviceInfoValidChanged += (o, e) => DeviceInfoValidChanged.Rise(this, e);
            uPort.TrackPointReceived += (o, e) =>
            {
                if (e.TrackID == uNav.TargetTrackID)
                {
                    if (statHelper.IsActive)
                    {
                        statHelper.AddPoint(new GeoPoint(e.Latitude_deg, e.Longitude_deg));
                        statCEP.Value = statHelper.CEP;
                        statDRMS.Value = statHelper.DRMS;
                    }

                    TLt.Value = e.Latitude_deg;
                    TLn.Value = e.Longitude_deg;                    

                    if (e.IsRadialError)
                        TRer.Value = e.RadialError_m;

                    if (e.IsDepth)
                        TDpt.Value = e.Depth_m;

                    if (e.IsCourse)
                        TCrs.Value = e.Course_deg;

                    NavigationDataUpdated.Rise(this, EventArgs.Empty);
                }                

                TrackPointReceived.Rise(this, e);
            };
            uPort.AUXGNSSFixReceived += (o, e) =>
            {
                if (!double.IsNaN(e.Crs))
                    ACrs.Value = e.Crs;

                if (!double.IsNaN(e.Spd))
                    ASpd.Value = e.Spd;

                if (!double.IsNaN(e.Lt) && !double.IsNaN(e.Ln))
                {
                    ALt.Value = e.Lt;
                    ALn.Value = e.Ln;
                }
                NavigationDataUpdated.Rise(this, EventArgs.Empty);
            };
            uPort.RelativeParametersReceived += (o, e) =>
            {
                if (!double.IsNaN(e.RPLt) && 
                    !double.IsNaN(e.RPLn) &&
                    !double.IsNaN(e.Dst2RP) &&
                    !double.IsNaN(e.Crs2RP) &&
                    !double.IsNaN(e.Crs4RP) &&
                    (e.Age <= 4))
                {
                    RPLt.Value = e.RPLt;
                    RPLn.Value = e.RPLn;
                    Dst2RP.Value = e.Dst2RP;
                    Crs2RP.Value = e.Crs2RP;
                    Crs4RP.Value = e.Crs4RP;
                }
                NavigationDataUpdated.Rise(this, EventArgs.Empty);
            };

            uPort.RefPointReceived += (o, e) =>
            {
                refPointType = e.RefPoint_Type;
                Dst2RP = new AgingValue<double>(3, 600, uNav.meters1dec_fmtr);
                Crs2RP = new AgingValue<double>(3, 60, uNav.degrees1dec_fmtr);
                Crs4RP = new AgingValue<double>(3, 60, uNav.degrees1dec_fmtr);
                RefPointReceived.Rise(this, e);
            };
            uPort.TargetDepthAndWaterTemperatureReceived += (o, e) =>
            {
                if (!double.IsNaN(e.TargetDepth_m))
                    TDpt.Value = e.TargetDepth_m;

                TargetDepthAndWaterTemperatureReceived.Rise(this, e);
            };
            uPort.IsWaitingLocalChangedEventHandler += (o, e) => IsWaitingLocalChangedEventHandler.Rise(this, e);

            uPort.RemoteECodeReceived += (o, e) =>
            {
                lastECode.Value = e.ECode.ToString();
            };

            uPort.RemoteValueReceived += (o, e) =>
            {
                if (e.DID == DID_Enum.DID_TMP)
                    rtmp.Value = e.Value;
                else if (e.DID == DID_Enum.DID_PRS)
                    rprs.Value = e.Value;
                else if (e.DID == DID_Enum.DID_BAT)
                    rbat.Value = e.Value;
            };

            uPort.BaseDataReceived += (o, e) =>
            {
                if (e.IsBatV && bBats.ContainsKey(e.BaseID))
                {
                    bBats[e.BaseID].Value = e.BatV;
                }
            };

            #endregion
        }

        #endregion

        #region Methods

        public void AccuracyEstimationStart()
        {
            AccuracyEstimationDiscard();
            statHelper.Start();
        }

        public void AccuracyEstimationStop()
        {
            statHelper.Stop();
        }

        public void AccuracyEstimationDiscard()
        {
            statHelper.Reset();
            statCEP = new AgingValue<double>(4, 300, uNav.meters3dec_fmtr);
            statDRMS = new AgingValue<double>(4, 300, uNav.meters3dec_fmtr);
        }

        public void Emulate(string eString)
        {
            string str = eString.Trim() + NMEAParser.SentenceEndDelimiter;

            var splits = str.Split(llSeparators, StringSplitOptions.RemoveEmptyEntries);
            if (splits.Length == 3)
            {
                if (splits[1] == "(uNav)")
                {
                    uPort.EmulateInput(splits[2]);
                }
            }
        }

        public string GetTargetDescription(bool isRP, bool isBBats, bool isAUXGNSS)
        {
            StringBuilder sb = new StringBuilder();

            if (TLt.IsInitialized && TLn.IsInitialized 
                && TRer.IsInitialized && TCrs.IsInitialized)
            {
                sb.AppendFormat(CultureInfo.InvariantCulture,
                    "TGT\r\n LAT: {0}\r\n LON: {1}\r\n RER: {2}\r\n CRS: {3}\r\n",
                    TLt.ToString(),
                    TLn.ToString(),
                    TRer.ToString(),
                    TCrs.ToString());
            }

            if (TDpt.IsInitialized)
                sb.AppendFormat(" DPT: {0}\r\n", TDpt.ToString());

            if (lastECode.IsInitialized)
                sb.AppendFormat("LEC: {0}\r\n", lastECode.ToString());

            if (rtmp.IsInitialized)
                sb.AppendFormat("RTM: {0}\r\n", rtmp.ToString());

            if (rprs.IsInitialized)
                sb.AppendFormat("RPR: {0}\r\n", rprs.ToString());

            if (rbat.IsInitialized)
                sb.AppendFormat("RBT: {0}\r\n", rbat.ToString());

            if (isRP)
            {
                sb.AppendFormat("\r\nREF: {0}\r\n", refPointType.ToString().Replace('_', ' '));

                if (Dst2RP.IsInitialized)
                    sb.AppendFormat(CultureInfo.InvariantCulture, " DST: {0}\r\n", Dst2RP.ToString());
                if (Crs2RP.IsInitialized)
                    sb.AppendFormat(CultureInfo.InvariantCulture, " AZM: {0}\r\n", Crs2RP.ToString());
                if (Crs4RP.IsInitialized)
                    sb.AppendFormat(CultureInfo.InvariantCulture, " RAZ: {0}\r\n", Crs4RP.ToString());

                sb.Append("\r\n");
            }

            if (isBBats)
            {
                foreach (var item in bBats)
                {
                    if (item.Value.IsInitialized)
                    {
                        sb.AppendFormat("{0}: {1}\r\n", uNav.BaseID2Str(item.Key), item.Value.ToString());
                    }
                }

                sb.Append("\r\n");
            }

            if (isAUXGNSS)
            {
                if (ALt.IsInitialized && ALn.IsInitialized &&
                    ACrs.IsInitialized && ASpd.IsInitialized)
                {
                    sb.AppendFormat(CultureInfo.InvariantCulture,
                        "\r\nGNSS\r\n LAT: {0}\r\n LON: {1}\r\n CRS: {2}\r\n SPD: {3}\r\n",
                        ALt.ToString(),
                        ALn.ToString(),
                        ACrs.ToString(),
                        ASpd.ToString());

                    sb.Append("\r\n");
                }
            }

            if (statCEP.IsInitialized && statDRMS.IsInitialized)
            {
                sb.AppendFormat("\r\nStats (by {0} points)\r\n", statHelper.RingCount);
                sb.AppendFormat(CultureInfo.InvariantCulture,
                    "  CEP: {0}\r\n DRMS: {1}\r\n2DRMS: {2:F03} m\r\n3DRMS: {3:F03} m\r\n",
                    statCEP.ToString(),
                    statDRMS.ToString(),
                    statDRMS.Value * 2,
                    statDRMS.Value * 3);
            }

            return sb.ToString();
        }


        public void Start()
        {            
            if (!uPort.IsActive)
            {
                uPort.Start();
            }
        }

        public void Stop()
        {
            if (uPort.IsActive)
            {
                uPort.Stop();                

                if (SerialBypassActive)
                    SerialOutputClose();
            }
        }

        public void SerialOutputInit(string portName, BaudRate baudrate)
        {
            if (SerialBypassActive)
                SerialOutputClose();

            SerialBypassEnabled = true;

            serialBypassPort = new NMEASerialPort(
                new SerialPortSettings(portName,
                baudrate,
                System.IO.Ports.Parity.None,
                DataBits.dataBits8,
                System.IO.Ports.StopBits.One,
                System.IO.Ports.Handshake.None));            

            LogEventHandler.Rise(this, new LogEventArgs(LogLineType.INFO,
                    string.Format("Initalizing serial bypass connection on {0} ({1})", portName, baudrate)));
        }

        private void SerialBypassOpen()
        {
            if (serialBypassPort != null)
            {
                try
                {
                    serialBypassPort.Open();
                    LogEventHandler.Rise(this, new LogEventArgs(LogLineType.INFO,
                        string.Format("Initalizing serial bypass connection on {0} ({1})", 
                        serialBypassPort.PortName, serialBypassPort.PortBaudRate)));
                }
                catch (Exception ex)
                {
                    LogEventHandler.Rise(this, new LogEventArgs(LogLineType.ERROR, ex));
                }

                SerialBypassIsActiveChanged.Rise(this, new EventArgs());
            }
        }


        private void SerialOutputClose()
        {
            try
            {
                serialBypassPort.Close();
                LogEventHandler.Rise(this, new LogEventArgs(LogLineType.INFO,
                    string.Format("Output via serial connection on {0} ({1}) is closed", serialBypassPort.PortName, serialBypassPort.PortBaudRate)));
            }
            catch (Exception ex)
            {
                LogEventHandler.Rise(this, new LogEventArgs(LogLineType.ERROR, ex));
            }

            SerialBypassIsActiveChanged.Rise(this, new EventArgs());
        }

        public void SerialOutputDeInit()
        {
            SerialOutputClose();
            SerialBypassEnabled = false;
        }

        public void UDPOutputInit(IPAddress ipAddress, int port)
        {
            try
            {
                udpOutput = new UDPTranslator(port, ipAddress);
                UDPOutputEnabled = true;

                LogEventHandler.Rise(this, new LogEventArgs(LogLineType.INFO,
                    string.Format("Initalizing output via UDP on {0}:{1}", ipAddress, port)));
            }
            catch (Exception ex)
            {
                LogEventHandler.Rise(this, new LogEventArgs(LogLineType.ERROR, ex));
            }
        }

        public void UDPOutputDeInit()
        {
            if (UDPOutputEnabled)
            {
                UDPOutputEnabled = false;
                LogEventHandler.Rise(this, new LogEventArgs(LogLineType.INFO,
                    string.Format("Output via UDP on {0}:{1} is closed", udpOutput.Address, udpOutput.Port)));
            }
        }


        public void DeviceInfoQuery()
        {
            uPort.InitQuerySend();
        }

        public void DeviceSettingsQuery()
        {
            uPort.Query_SettingsRead();
        }

        public void DeviceSettingsQuerySet(double sty_psu, double wtmp_C, double sos_mps,
            double max_tspd_mps, int sf_FIFO_size, double sf_rthld_m, int dhf_FIFO_size,
            double dhf_rthld_m, int ce_FIFO_size, BaudRate int_brate, int rwlt_mode, int rwlt_drating)
        {
            uPort.Query_SettingsWrite(sty_psu, wtmp_C, sos_mps,
            max_tspd_mps, sf_FIFO_size, sf_rthld_m, dhf_FIFO_size,
            dhf_rthld_m, ce_FIFO_size, int_brate, rwlt_mode, rwlt_drating);
        }

        public void DeviceSettingsQuerySet(double sty_psu, double wtmp_C, double sos_mps)
        {
            uPort.Query_SettingsWrite(sty_psu, wtmp_C, sos_mps);
        }

        public void RefPointQuery()
        {
            uPort.Query_ReferencePointSet(REF_POINT_TYPE_Enum.INVALID, double.NaN, double.NaN);
        }

        public void RefPointSetQuery(REF_POINT_TYPE_Enum refPointType, double refLat, double refLon)
        {
            uPort.Query_ReferencePointSet(refPointType, refLat, refLon);
        }

        public void DepthAndTemperatureSetQuery(double depth, double temperature)
        {
            uPort.Query_DepthAndTemperatureSet(depth, temperature);
        }


        public GeoPoint GetCurrentTargetLocation()
        {
            if (TLt.IsInitialized && TLn.IsInitialized)
                return new GeoPoint(TLt.Value, TLn.Value);
            else
                return new GeoPoint();
        }

        public void MarkCurrentTargetLocation()
        {
            if (TLt.IsInitialized && TLn.IsInitialized)
            {
                TrackPointReceived.Rise(this,
                    new TrackPointEventArgs(uNav.MarkedPointsTrackID,
                    TLt.Value,
                    TLn.Value,
                    TDpt.IsInitialized ? TDpt.Value : double.NaN,
                    DateTime.Now));
            }

        }


        #endregion

        #region Handlers


        #endregion

        #region Events

        public EventHandler<LogEventArgs> LogEventHandler;
        public EventHandler DetectedChanged;
        public EventHandler IsActiveChanged;

        public EventHandler SerialBypassIsActiveChanged;

        public EventHandler NavigationDataUpdated;
        public EventHandler<RefPointReceivedEventArgs> RefPointReceived;
        public EventHandler<TargetDepthAndWaterTemperatureEventArgs> TargetDepthAndWaterTemperatureReceived;

        public EventHandler<DeviceSettingsReceivedEventArgs> DeviceSettingsReceived;
        public EventHandler DeviceInfoValidChanged;

        public EventHandler<TrackPointEventArgs> TrackPointReceived;

        public EventHandler IsWaitingLocalChangedEventHandler;

        public EventHandler StatHelperActiveChanged;

        #endregion
    }
}
