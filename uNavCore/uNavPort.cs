using System;
using UCNLDrivers;
using UCNLNMEA;

namespace uNav.uNavCore
{
    #region Miscelaneous EventArgs

    public class ACKReceivedEventArgs : EventArgs
    {
        // $PUNA0,[cmdID],result

        #region Properties
        public ICs SentenceID { get; private set; }
        public IC_RESULT_Enum ResultID { get; private set; }

        #endregion

        #region Constructor

        public ACKReceivedEventArgs(ICs sntID, IC_RESULT_Enum resID)
        {
            SentenceID = sntID;
            ResultID = resID;
        }

        #endregion
    }

    public class DeviceSettingsReceivedEventArgs : EventArgs
    {
        // $PUNA1,[sty_PSU],[wtmp_C],[sos_mps],[max_tspd_mps],[sf_FIFO_size],[sf_rthld_m],[dhf_FIFO_size],[dhf_rthld],[ce_FIFO_size],[int_brate],[rwlt_mode],[rwlt_drating]

        #region Properties

        public double Sty_PSU { get; private set; }
        public double Wtmp_C { get; private set; }
        public double Sos_mps { get; private set; }
        public double Max_tsps_mps { get; private set; }
        public int Sf_FIFO_size { get; private set; }
        public double Sf_rthld_m { get; private set; }
        public int Dhf_FIFO_size { get; private set; }
        public double Dhf_rthld_m { get; private set; }
        public int Ce_FIFO_size { get; private set; }
        public int Int_brate { get; private set; }

        public int RWLT_Mode { get; private set; }
        public int RWLT_DRating { get; private set; }

    #endregion

        #region Constructor

        public DeviceSettingsReceivedEventArgs(double sty_psu, double wtmp_c, double sos_mps, double max_tsps_mps,
                int sf_FIFO_size, double sf_rthld_m, int dhf_FIFO_size, double dhf_rthld_m, int ce_FIFO_size, int int_brate, int rwlt_mode, int rwlt_drating)
            {
                Sty_PSU = sty_psu;
                Wtmp_C = wtmp_c; 
                Sos_mps = sos_mps;
                Max_tsps_mps = max_tsps_mps;
                Sf_FIFO_size = sf_FIFO_size;
                Sf_rthld_m = sf_rthld_m;
                Dhf_FIFO_size = dhf_FIFO_size;
                Dhf_rthld_m = dhf_rthld_m;
                Ce_FIFO_size = ce_FIFO_size;
                Int_brate = int_brate;
                RWLT_Mode = rwlt_mode;
                RWLT_DRating = rwlt_drating;
        }


        #endregion
    }

    public class RefPointReceivedEventArgs : EventArgs
    {
        #region Properties
        public REF_POINT_TYPE_Enum RefPoint_Type { get; private set; }
        public double RefPoint_Lat { get; private set; }
        public double RefPoint_Lon { get; private set; }

        #endregion

        #region Constructor

        public RefPointReceivedEventArgs(REF_POINT_TYPE_Enum rpType, double rpLat, double rpLon)
        {
            RefPoint_Type  = rpType;
            RefPoint_Lat = rpLat;
            RefPoint_Lon = rpLon;
        }

        #endregion
    }

    public class TargetDepthAndWaterTemperatureEventArgs : EventArgs
    {
        #region Properties

        public double TargetDepth_m { get; private set; }
        public double WaterTemperature_C { get; private set; }

        #endregion

        #region Constructor

        public TargetDepthAndWaterTemperatureEventArgs(double tDpt_m, double wtm_C)
        {
            TargetDepth_m = tDpt_m;
            WaterTemperature_C = wtm_C;
        }

        #endregion
    }

    public class NavigationDataEventArgs : EventArgs
    {
        #region Properties

        public int TID { get; private set; }
        public double TLt { get; private set; }
        public double TLn { get; private set; }
        public double TDpt { get; private set; }
        public double TCrs { get; private set; }
        public double TRer { get; private set; }
        public double Age { get; private set; }
        public double RPLt { get; private set; }
        
        public double RPLn { get; private set; }
        public double Dst2RP { get; private set; }
        public double Crs2RP { get; private set; }
        public double Crs4RP { get; private set; }
        public double ALt { get; private set; }
        public double ALn { get; private set; }
        public double ACrs { get; private set; }
        public double ASpd { get; private set; }
        public double AAge { get; private set; }

        #endregion

        #region Constructor

        public NavigationDataEventArgs(int tID, double tLt, double tLn, double tDpt, double tCrs, double tRer, double age, double rPLt,
            double rPLn, double dst2RP, double crs2RP, double crs4RP, double aLt, double aLn, double aCrs, double aSpd, double aAge)
        {
            TID = tID;
            TLt = tLt;
            TLn = tLn;
            TDpt = tDpt;
            TCrs = tCrs;
            TRer = tRer;
            Age = age;
            RPLt = rPLt;
            RPLn = rPLn;
            Dst2RP = dst2RP;
            Crs2RP = crs2RP;
            Crs4RP = crs4RP;
            ALt = aLt;
            ALn = aLn;
            ACrs = aCrs;
            ASpd = aSpd;
            AAge = aAge;
        }

        #endregion
    }

    public class TrackPointEventArgs : EventArgs
    {
        #region Properties

        public string TrackID { get; private set; }
        public double Latitude_deg { get; private set; }

        public double Longitude_deg { get; private set; }

        public double RadialError_m { get; private set; }

        public double Depth_m { get; private set; }

        public double Course_deg { get; private set; }

        public DateTime TimeStamp { get; private set; }

        public bool IsRadialError { get => !double.IsNaN(RadialError_m); }
        public bool IsCourse { get => !double.IsNaN(Course_deg); }
        public bool IsDepth { get => !double.IsNaN(Depth_m); }

        #endregion

        #region Constructor

        public TrackPointEventArgs(string trackID, double lat_deg, double lon_deg, double dpt_m, DateTime tStamp)
            : this(trackID, lat_deg, lon_deg, dpt_m, double.NaN, double.NaN, tStamp)
        {

        }

        public TrackPointEventArgs(string trackID, double lat_deg, double lon_deg, double dpt_m, double rerr_m, double crs_deg, DateTime timeStamp)
        {
            TrackID = trackID;
            Latitude_deg = lat_deg;
            Longitude_deg = lon_deg;
            Depth_m = dpt_m;
            RadialError_m = rerr_m;
            Course_deg = crs_deg;
            TimeStamp = timeStamp;
        }

        #endregion
    }

    public class RelativeParametersReceivedEventArgs : EventArgs
    {
        #region Properties

        public int TID { get; private set; }
        public double RPLt { get; private set; }
        public double RPLn { get; private set; }
        public double Dst2RP { get; private set; }
        public double Crs2RP { get; private set; }
        public double Crs4RP { get; private set; }
        public double Age { get; private set; }

        #endregion

        #region Constructor

        public RelativeParametersReceivedEventArgs(int tid, double rpLt, double rpLn, double dst2rp, double crs2rp, double crs4rp, double age)
        {
            TID = tid;
            RPLt = rpLt;
            RPLn = rpLn;
            Dst2RP = dst2rp;
            Crs2RP = crs2rp;
            Crs4RP = crs4rp;
            Age = age;
        }

        #endregion
    }

    public class AUXGNSSFixReceivedEventArgs : EventArgs
    {
        #region Properties

        public double Lt { get; private set; }
        public double Ln { get; private set; }
        public double Crs { get; private set; }
        public double Spd { get; private set; }

        #endregion

        #region Constructor

        public AUXGNSSFixReceivedEventArgs(double lt, double ln, double crs, double spd)
        {
            Lt = lt;
            Ln = ln;
            Crs = crs;
            Spd = spd;
        }

        #endregion
    }

    public class RemoteValueReceivedEventArgs : EventArgs
    {
        #region Properties

        public DID_Enum DID { get; private set; }
        public double Value { get; private set; }

        #endregion

        #region Constructor

        public RemoteValueReceivedEventArgs(DID_Enum dID, double value)
        {
            DID = dID;
            Value = value;
        }

        #endregion
    }

    public class RemoteECodeReceivedEventArgs : EventArgs
    {
        #region Properties

        public ECodes_Enum ECode { get; private set; }

        #endregion

        #region Constructor

        public RemoteECodeReceivedEventArgs(ECodes_Enum eCode)
        {
            ECode = eCode;
        }

        #endregion
    }

    public class BaseDataReceivedEventArgs : EventArgs
    {
        #region Properties

        public int BaseID { get; private set; }
        public double BatV { get; private set; }

        public bool IsBatV { get => !double.IsNaN(BatV); }

        #endregion

        #region Constructor

        public BaseDataReceivedEventArgs(int baseID, double batV)
        {
            BaseID = baseID;
            BatV = batV;
        }

        #endregion
    }

    #endregion

    public class uNavPort : uSerialPort
    {
        #region Properties

        static bool nmeaSingleton = false;

        bool isWaitingLocal = false;
        public bool IsWaitingLocal
        {
            get { return isWaitingLocal; }
            private set
            {
                isWaitingLocal = value;
                IsWaitingLocalChangedEventHandler.Rise(this, new EventArgs());
            }
        }

        ICs lastQueryID = ICs.INVALID;

        public bool IsDeviceInfoValid { get; private set; }
        public string SerialNumber { get; private set; }
        public string SystemInfo { get; private set; }
        public string SystemVersion { get; private set; }

        double tlt = double.NaN;
        double tln = double.NaN;
        double tdpt = double.NaN;
        double tcrs = double.NaN;
        double trer = double.NaN;

        bool is_tloc = false;

        #endregion

        #region Constructor

        public uNavPort(BaudRate baudRate) 
            : base(baudRate) 
        {
            base.PortDescription = "uNav";
            base.IsLogIncoming = true;
            base.IsTryAlways = true;            

            if (!nmeaSingleton)
            {
                NMEAParser.AddManufacturerToProprietarySentencesBase(ManufacturerCodes.APL);
                // $PAPLA,[bID],[bLat_deg],[bLon_deg],[bDpt_m],[bBat],[pTOA_s]
                NMEAParser.AddProprietarySentenceDescription(ManufacturerCodes.APL, "A", "x,x.x,x.x,x.x,x.x,x.x");

                NMEAParser.AddManufacturerToProprietarySentencesBase(ManufacturerCodes.RWL);
                // $PRWLA,[bID],[bLat_deg],[bLon_deg],[bDpt_m],[bBat],[pData],[pTOA_s],[bMSR_dB]
                NMEAParser.AddProprietarySentenceDescription(ManufacturerCodes.RWL, "A", "x,x.x,x.x,x.x,x.x,x,x.x,x.x");

                NMEAParser.AddManufacturerToProprietarySentencesBase(ManufacturerCodes.UNV);
                // $PUNV0,[sty_PSU],[wtmp_C],[sos_mps],[max_tspd_mps],[sf_FIFO_size],[sf_rthld_m],[dhf_FIFO_size],[dhf_rthld],[ce_FIFO_size],[int_brate]
                NMEAParser.AddProprietarySentenceDescription(ManufacturerCodes.UNV, "0", "x.x,x.x,x.x,x.x,x,x.x,x,x.x,x,x,x,x");
                // $PUNV?,reserved
                NMEAParser.AddProprietarySentenceDescription(ManufacturerCodes.UNV, "?", "x");
                // $PUNV!,sys_moniker,sys_version,serial_number
                NMEAParser.AddProprietarySentenceDescription(ManufacturerCodes.UNV, "!", "c--c,x,c--c");
                // $PUNV1,[ref_point_type:0-AUX GNSS,1-4 base points,empty - user defined],[ref_point_lat],[ref_point_lon]
                NMEAParser.AddProprietarySentenceDescription(ManufacturerCodes.UNV, "1", "x,x.x,x.x");
                // $PUNV2,[tDpt_m],[wTmp_celsius]
                NMEAParser.AddProprietarySentenceDescription(ManufacturerCodes.UNV, "2", "x.x,x.x");
                // $PUNV3,tID,tLt,tLn,tDpt,tCrs,tRer,Age
                NMEAParser.AddProprietarySentenceDescription(ManufacturerCodes.UNV, "3", "x,x.x,x.x,x.x,x.x,x.x,x.x");
                // $PUNV4,tID,rpLt,prLn,dst2rp,crs2rp,Crs4rp,age
                NMEAParser.AddProprietarySentenceDescription(ManufacturerCodes.UNV, "4", "x,x.x,x.x,x.x,x.x,x.x,x.x");
                // $PUNV5,gnssLt,gnssLn,gnssCrs,gnssSog
                NMEAParser.AddProprietarySentenceDescription(ManufacturerCodes.UNV, "5", "x.x,x.x,x.x,x.x");
                // $PUNV6,dataID,dataValue
                NMEAParser.AddProprietarySentenceDescription(ManufacturerCodes.UNV, "6", "x,x.x");

                nmeaSingleton = true;
            }            
        }

        #endregion

        #region Methods

        #region Private

        #region Parsers

        private void Parse_UNV0(object[] parameters)
        {
            // $PUNV0,[sty_PSU],[wtmp_C],[sos_mps],[max_tspd_mps],[sf_FIFO_size],[sf_rthld_m],[dhf_FIFO_size],[dhf_rthld],[ce_FIFO_size],[int_brate],[rwlt_drating]   
            double sty_PSU = double.NaN;
            double wtmp_C = double.NaN;
            double sos_mps = double.NaN;
            double max_tspd_mps = double.NaN;
            int sf_FIFO_size = -1;
            double sf_rthld_m = double.NaN;
            int dhf_FIFO_size = -1;
            double dhf_rthld = double.NaN;
            int ce_FIFO_size = -1;
            int int_brate = -1;
            int rwlt_mode = -1;
            int rwlt_drating = -1;
            bool isOk = false;

            try
            {
                sty_PSU = uNav.O2D(parameters[0]);
                wtmp_C = uNav.O2D(parameters[1]);
                max_tspd_mps = uNav.O2D(parameters[2]);
                sos_mps = uNav.O2D(parameters[3]);
                sf_FIFO_size = uNav.O2S32(parameters[4]);
                sf_rthld_m = uNav.O2D(parameters[5]);
                dhf_FIFO_size = uNav.O2S32(parameters[6]);
                dhf_rthld = uNav.O2D(parameters[7]);
                ce_FIFO_size = uNav.O2S32(parameters[8]);
                int_brate = uNav.O2S32(parameters[9]);
                rwlt_mode = uNav.O2S32(parameters[10]);
                rwlt_drating = uNav.O2S32(parameters[11]);

                isOk = true;
            }
            catch (Exception ex)
            {
                LogEventHandler.Rise(this, new LogEventArgs(LogLineType.ERROR, ex));
            }

            if (isOk)
            {
                StopTimer();
                IsWaitingLocal = false;

                DeviceSettingsReceived.Rise(this,
                    new DeviceSettingsReceivedEventArgs(
                        sty_PSU,
                        wtmp_C,
                        sos_mps,
                        max_tspd_mps,
                        sf_FIFO_size,
                        sf_rthld_m,
                        dhf_FIFO_size,
                        dhf_rthld,
                        ce_FIFO_size,
                        int_brate,
                        rwlt_mode,
                        rwlt_drating));
            }
        }

        private void Parse_UNV1(object[] parameters)
        {
            // $PUNV1,[ref_point_type:0-AUX GNSS,1-4 base points,empty - user defined],[ref_point_lat],[ref_point_lon]

            REF_POINT_TYPE_Enum rpType = REF_POINT_TYPE_Enum.INVALID;
            double rpLt = double.NaN;
            double rpLn = double.NaN;
            bool isOK = false;

            try
            {
                rpType = uNav.O2_REF_POINT_TYPE_Enum(parameters[0]);
                rpLt = uNav.O2D(parameters[1]);
                rpLn = uNav.O2D(parameters[2]);
                isOK = true;
            }
            catch (Exception ex)
            {
                LogEventHandler.Rise(this, new LogEventArgs(LogLineType.ERROR, ex));
            }

            if (isOK)
            {
                StopTimer();
                IsWaitingLocal = false;

                RefPointReceived.Rise(this, new RefPointReceivedEventArgs(rpType, rpLt, rpLn));
            }
        }

        private void Parse_UNV2(object[] parameters)
        {
            // $PUNV2,[tDpt_m],[wTmp_celsius]
            double tDepth_m = double.NaN;
            double wtm_c = double.NaN;
            bool isOk = false;

            try
            {                
                tDepth_m = uNav.O2D(parameters[0]);
                wtm_c = uNav.O2D(parameters[1]);
                isOk = true;                
            }
            catch (Exception ex)
            {
                LogEventHandler.Rise(this, new LogEventArgs(LogLineType.ERROR, ex));
            }

            if (isOk)
            {
                StopTimer();
                IsWaitingLocal = false;

                TargetDepthAndWaterTemperatureReceived.Rise(this,
                    new TargetDepthAndWaterTemperatureEventArgs(tDepth_m, wtm_c));
            }
        }

        private void Parse_UNV3(object[] parameters)
        {
            // $PUNV3,tID,tLt,tLn,tDpt,tCrs,tRer,Age
            int tID = -1;
            double tLt = double.NaN;
            double tLn = double.NaN;
            double tDpt = double.NaN;
            double tCrs = double.NaN;
            double tRer = double.NaN;
            double Age = double.NaN;
            
            bool isOk = false;            

            try
            {
                tID = uNav.O2S32(parameters[0]);
                tLt = uNav.O2D(parameters[1]);
                tLn = uNav.O2D(parameters[2]);
                tDpt = uNav.O2D(parameters[3]);
                tCrs = uNav.O2D(parameters[4]);
                tRer = uNav.O2D(parameters[5]);
                Age = uNav.O2D(parameters[6]);
              
                isOk = true;                
            }
            catch (Exception ex)
            {
                LogEventHandler.Rise(this, new LogEventArgs(LogLineType.ERROR, ex));
            }

            if (isOk)
            {
                if (!isWaitingLocal)
                {
                    StopTimer();
                    if (IsActive)
                        StartTimer(2000);
                }

                if ((tID >= 0) && !double.IsNaN(tLt) && !double.IsNaN(tLn))
                {
                    TrackPointReceived.Rise(this,
                        new TrackPointEventArgs(string.Format("#{0}", tID), tLt, tLn, tDpt, tRer, tCrs, DateTime.Now));
                }
            }
        }

        private void Parse_UNV4(object[] parameters)
        {
            // $PUNV4,tID,rpLt,prLn,dst2rp,crs2rp,Crs4rp,age
            int tID = -1;
            double rpLt = double.NaN;
            double rpLn = double.NaN;
            double dst2rp = double.NaN;
            double crs2rp = double.NaN;
            double crs4rp = double.NaN;
            double age = double.NaN;
            bool isOk = false;

            try
            {
                tID = uNav.O2S32(parameters[0]);
                rpLt = uNav.O2D(parameters[1]);
                rpLn = uNav.O2D(parameters[2]);
                dst2rp = uNav.O2D(parameters[3]);
                crs2rp = uNav.O2D(parameters[4]);
                crs4rp = uNav.O2D(parameters[5]);
                age = uNav.O2D(parameters[6]);
                
                isOk = true;
            }
            catch (Exception ex)
            {
                LogEventHandler.Rise(this, new LogEventArgs(LogLineType.ERROR, ex));
            }

            if (isOk)
            {
                if (!isWaitingLocal)
                {
                    StopTimer();
                    if (IsActive)
                        StartTimer(2000);
                }

                if (!double.IsNaN(rpLt) && !double.IsNaN(rpLn) &&
                    !double.IsNaN(dst2rp) && !double.IsNaN(crs2rp) &&
                    !double.IsNaN(crs4rp) && (age < 60))
                {
                    RelativeParametersReceived.Rise(this,
                        new RelativeParametersReceivedEventArgs(tID, rpLt, rpLn, dst2rp, crs2rp, crs4rp, age));
                }
            }
        }

        private void Parse_UNV5(object[] parameters)
        {
            // $PUNV5,gnssLt,gnssLn,gnssCrs,gnssSog
            double lt = double.NaN;
            double ln = double.NaN;
            double crs = double.NaN;
            double spd = double.NaN;
            bool isOk = false;

            try
            {
                lt = uNav.O2D(parameters[0]);
                ln = uNav.O2D(parameters[1]);
                crs = uNav.O2D(parameters[2]);
                spd = uNav.O2D(parameters[3]);

                isOk = true;
            }
            catch (Exception ex)
            {
                LogEventHandler.Rise(this, new LogEventArgs(LogLineType.ERROR, ex));
            }

            if (isOk)
            {
                if (!isWaitingLocal)
                {
                    StopTimer();
                    if (IsActive)
                        StartTimer(2000);
                }

                if (!double.IsNaN(lt) && !double.IsNaN(ln) &&
                    !double.IsNaN(crs) && !double.IsNaN(spd))
                {
                    AUXGNSSFixReceived.Rise(this,
                        new AUXGNSSFixReceivedEventArgs(lt, ln, crs, spd));
                    TrackPointReceived.Rise(this,
                        new TrackPointEventArgs(uNav.AUXGNSSTrackID, lt, ln, 0.0, DateTime.Now));
                }
            }
        }

        private void Parse_UNV6(object[] parameters)
        {
            // $PUNV6,dID,pVal
            DID_Enum dID = DID_Enum.DID_INVALID;
            double pval = 0;
            bool isOk = false;

            try
            {
                dID = uNav.O2_DID_Enum(parameters[0]);
                pval = uNav.O2D(parameters[1]);
                
                isOk = true;
            }
            catch (Exception ex)
            {
                LogEventHandler.Rise(this, new LogEventArgs(LogLineType.ERROR, ex));
            }

            if (isOk)
            {
                if (!isWaitingLocal)
                {
                    StopTimer();
                    if (IsActive)
                        StartTimer(2000);
                }

                if (dID != DID_Enum.DID_INVALID)
                {
                    if (dID == DID_Enum.DID_CODE)
                    {
                        RemoteECodeReceived.Rise(this,
                            new RemoteECodeReceivedEventArgs((ECodes_Enum)Convert.ToInt32(pval)));
                    }
                    else
                    {
                        RemoteValueReceived.Rise(this, 
                            new RemoteValueReceivedEventArgs(dID, pval));
                    }
                }                
            }
        }

        private void Parse_UNV_EXCL(object[] parameters)
        {
            // $PUNV!,sys_moniker,sys_version,serial_number
            bool isOk = false;

            try
            {
                SystemInfo = uNav.O2S(parameters[0]);
                SystemVersion = uNav.BCDVersionToStr(uNav.O2S32(parameters[1]));
                SerialNumber = uNav.O2S(parameters[2]);

                isOk = true;                
            }
            catch (Exception ex)
            {
                LogEventHandler.Rise(this, new LogEventArgs(LogLineType.ERROR, ex));
            }

            if (isOk)
            {               
                StopTimer();
                IsWaitingLocal = false;

                IsDeviceInfoValid = !string.IsNullOrEmpty(SerialNumber);
                DeviceInfoValidChanged.Rise(this, EventArgs.Empty);
            }
        }


        private void Parse_APLA(object[] parameters)
        {
            // Incoming APLA sentence received
            // $PAPLA,bID,bLat,bLon,bDpt,bBat,bTOA

            int baseID = -1;
            double bLat = double.NaN; 
            double bLon = double.NaN; 
            double bDpt = double.NaN; 
            double bBat = double.NaN;
            double bTOA = double.NaN;
            bool isOk = false;

            try
            {
                baseID = uNav.O2S32(parameters[0]);
                bLat = uNav.O2D(parameters[1]);
                bLon = uNav.O2D(parameters[2]);
                bDpt = uNav.O2D(parameters[3]);
                bBat = uNav.O2D(parameters[4]);
                bTOA = uNav.O2D(parameters[5]);
                isOk = (baseID >= 0) && (baseID <= 4) && (!double.IsNaN(bLat)) && (!double.IsNaN(bLon)) && (!double.IsNaN(bDpt));
            }
            catch (Exception ex)
            {
                LogEventHandler.Rise(this, new LogEventArgs(LogLineType.ERROR, ex));
            }
            
            if (isOk)
            {
                BaseDataReceived.Rise(this, new BaseDataReceivedEventArgs(baseID, bBat));
                TrackPointReceived.Rise(this, new TrackPointEventArgs(uNav.BaseID2Str(baseID), bLat, bLon, bDpt, DateTime.Now));
            }
        }
        
        private void Parse_RWLA(object[] parameters)
        {
            // $PRWLA,bID,baseLat,baseLon,[baseDpt],baseBat,pingerData,TOAsecond,MSR_dB
            int baseID = -1;
            double bLat = double.NaN;
            double bLon = double.NaN;
            double bDpt = double.NaN;
            double bBat = double.NaN;
            double bTOA = double.NaN;
            double bMSR = double.NaN;
            bool isOk = false;

            try
            {
                baseID = uNav.O2S32(parameters[0]);
                bLat = uNav.O2D(parameters[1]);
                bLon = uNav.O2D(parameters[2]);
                bDpt = uNav.O2D(parameters[3]);
                bBat = uNav.O2D(parameters[4]);
                bTOA = uNav.O2D(parameters[6]);
                bMSR = uNav.O2D(parameters[7]);
                isOk = (baseID >= 0) && (!double.IsNaN(bLat)) && (!double.IsNaN(bLon)) && (!double.IsNaN(bDpt));
            }
            catch (Exception ex)
            {
                LogEventHandler.Rise(this, new LogEventArgs(LogLineType.ERROR, ex));
            }

            if (isOk)
            {

                BaseDataReceived.Rise(this, new BaseDataReceivedEventArgs(baseID, bBat));
                TrackPointReceived.Rise(this, new TrackPointEventArgs(uNav.BaseID2Str(baseID), bLat, bLon, bDpt, DateTime.Now));
            }
        }

        private void Parse_GGA(object[] parameters)
        {
            DateTime tStamp = DateTime.Now;
            double lat = double.NaN;
            double lon = double.NaN;
            string qind = string.Empty;
            double hdop = double.NaN;
            double alt = double.NaN;
            bool isOk = false;

            try
            {
                tStamp = parameters[0] == null ? DateTime.MinValue : (DateTime)parameters[0];
                lat = uNav.O2D(parameters[1]);
                lon = uNav.O2D(parameters[3]);
                qind = parameters[5].ToString();
                hdop = uNav.O2D(parameters[7]);
                alt = uNav.O2D(parameters[8]);

                if (!double.IsNaN(lat) && 
                    !double.IsNaN(lon) && 
                    !string.IsNullOrEmpty(qind) &&
                    (qind != "N") && (qind != "V"))
                {
                    if (parameters[2].ToString() == "S") lat = -lat;
                    if (parameters[4].ToString() == "W") lon = -lon;

                    isOk = true;
                }
            }
            catch (Exception ex)
            {
                LogEventHandler.Rise(this, new LogEventArgs(LogLineType.ERROR, ex));
            }

            if (isOk)
            {
                tlt = lat;
                tln = lon;
                tdpt = -alt;
                trer = hdop;
                is_tloc = true;
            }
        }

        private void Parse_RMC(object[] parameters)
        {
            double crs = double.NaN;
            bool isOk = false;

            try
            {
                crs = uNav.O2D(parameters[7]);
                isOk = parameters[11].ToString() != "N";
            }
            catch (Exception ex)
            {
                LogEventHandler.Rise(this, new LogEventArgs(LogLineType.ERROR, ex));
            }

            if (isOk)
            {
                tcrs = crs;

                if (is_tloc)
                    TrackPointReceived.Rise(this,
                        new TrackPointEventArgs(uNav.TargetTrackID, tlt, tln, tdpt, trer, tcrs, DateTime.Now));

                is_tloc = false;
            }
        }

        #endregion

        private bool TrySend(string message, ICs queryID)
        {
            bool result = detected && !IsWaitingLocal;

            if (result)
            {
                try
                {
                    Send(message);

                    StartTimer(4000);

                    IsWaitingLocal = true;

                    lastQueryID = queryID;
                    result = true;
                }
                catch (Exception ex)
                {
                    LogEventHandler.Rise(this, new LogEventArgs(LogLineType.ERROR, ex));
                }
            }

            return result;
        }

        #endregion

        #region Public

        public void Query_SettingsWrite(double sty_psu, double wtmp_C, double sos_mps, 
            double max_tspd_mps, int sf_FIFO_size, double sf_rthld_m, int dhf_FIFO_size, 
            double dhf_rthld_m, int ce_FIFO_size, BaudRate int_brate, int rwlt_mode, int rwlt_drating)
        {
            // $PUNV0,[sty_PSU],[wtmp_C],[sos_mps],[max_tspd_mps],[sf_FIFO_size],[sf_rthld_m],[dhf_FIFO_size],[dhf_rthld],[ce_FIFO_size],[int_brate],[rwlt_mode],[rwlt_drating]

            var msg = NMEAParser.BuildProprietarySentence(ManufacturerCodes.UNV, "0",
                new object[] { uNav.D2O(sty_psu),
                               uNav.D2O(wtmp_C),
                               uNav.D2O(sos_mps),
                               uNav.D2O(max_tspd_mps),
                               uNav.I2O_NEG2NULL(sf_FIFO_size),
                               uNav.D2O(sf_rthld_m),
                               uNav.I2O_NEG2NULL(dhf_FIFO_size),
                               uNav.D2O(dhf_rthld_m),
                               uNav.I2O_NEG2NULL(ce_FIFO_size),
                               null,/*uNav.H2D_BaudrateConvert(int_brate)*/
                               uNav.I2O_NEG2NULL(rwlt_mode),
                               uNav.I2O_NEG2NULL(rwlt_drating)
                               });
            TrySend(msg, ICs.UNV0);
        }

        public void Query_SettingsWrite(double sty_psu, double wtmp_C, double sos_mps)
        {
            // $PUNV0,[sty_PSU],[wtmp_C],[sos_mps],[max_tspd_mps],[sf_FIFO_size],[sf_rthld_m],[dhf_FIFO_size],[dhf_rthld],[ce_FIFO_size],[int_brate]

            var msg = NMEAParser.BuildProprietarySentence(ManufacturerCodes.UNV, "0",
                new object[] { uNav.D2O(sty_psu),
                               uNav.D2O(wtmp_C),
                               uNav.D2O(sos_mps),
                               null,
                               null,
                               null,
                               null,
                               null,
                               null,
                               null,
                               null, // rwlt_mode
                               null  // rwlt_drating
                               });
            TrySend(msg, ICs.UNV0);
        }

        public void Query_SettingsRead()
        {
            var msg = NMEAParser.BuildProprietarySentence(ManufacturerCodes.UNV, "0",
                new object[] { null,
                               null,
                               null,
                               null,
                               null,
                               null,
                               null,
                               null,
                               null,
                               null
                               });
            TrySend(msg, ICs.UNV0);
        }

        public void Query_ReferencePointSet(REF_POINT_TYPE_Enum rpType, double lat, double lon)
        {
            // $PUNV1,[ref_point_type:0-AUX GNSS,1-4 base points,empty - user defined],[ref_point_lat],[ref_point_lon]
            var msg = NMEAParser.BuildProprietarySentence(ManufacturerCodes.UNV, "1", new object[]
            {
                uNav.REF_POINT_TYPE_Enum_2O(rpType),
                uNav.D2O(lat),
                uNav.D2O(lon)
            });
            TrySend(msg, ICs.UNV1);
        }

        public void Query_DepthAndTemperatureSet(double tDpt_m, double wTmp_C)
        {
            // $PUNV2,[tDpt_m],[wTmp_celsius]
            var msg = NMEAParser.BuildProprietarySentence(ManufacturerCodes.UNV, "2", new object[]
            {
                uNav.D2O(tDpt_m),
                uNav.D2O(wTmp_C)
            });
            TrySend(msg, ICs.UNV2);
        }

        #region uSerialPort

        public override void InitQuerySend()
        {
            var msg = NMEAParser.BuildProprietarySentence(ManufacturerCodes.UNV, "?", new object[] { 0 });
            Send(msg);
        }

        public override void OnClosed()
        {
            StopTimer();
            isWaitingLocal = false;
            IsDeviceInfoValid = false;
        }

        public override void ProcessIncoming(NMEASentence sentence)
        {
            if (sentence is NMEAProprietarySentence)
            {
                NMEAProprietarySentence pSentence = (sentence as NMEAProprietarySentence);

                if ((pSentence.Manufacturer == ManufacturerCodes.UNV) ||
                    (pSentence.Manufacturer == ManufacturerCodes.RWL) ||
                    (pSentence.Manufacturer == ManufacturerCodes.APL))
                {
                    if (!detected)
                        detected = true;

                    if (pSentence.Manufacturer == ManufacturerCodes.UNV)
                    {
                        if (pSentence.SentenceIDString == "0")
                            Parse_UNV0(pSentence.parameters);
                        else if (pSentence.SentenceIDString == "1")
                            Parse_UNV1(pSentence.parameters);
                        else if (pSentence.SentenceIDString == "2")
                            Parse_UNV2(pSentence.parameters);
                        else if (pSentence.SentenceIDString == "3")
                            Parse_UNV3(pSentence.parameters);
                        else if (pSentence.SentenceIDString == "4")
                            Parse_UNV4(pSentence.parameters);
                        else if (pSentence.SentenceIDString == "5")
                            Parse_UNV5(pSentence.parameters);
                        else if (pSentence.SentenceIDString == "6")
                            Parse_UNV6(pSentence.parameters);
                        else if (pSentence.SentenceIDString == "!")
                            Parse_UNV_EXCL(pSentence.parameters);
                    }
                    else if (pSentence.Manufacturer == ManufacturerCodes.APL)
                    {
                        if (pSentence.SentenceIDString == "A")
                            Parse_APLA(pSentence.parameters);
                    }
                    else if (pSentence.Manufacturer == ManufacturerCodes.RWL)
                    {
                        if (pSentence.SentenceIDString == "A")
                            Parse_RWLA(pSentence.parameters);
                    }
                }
            } 
            else
            {
                NMEAStandartSentence sSentence = (sentence as NMEAStandartSentence);

                if (sSentence.SentenceID == SentenceIdentifiers.RMC)
                    Parse_RMC(sSentence.parameters);
                else if (sSentence.SentenceID == SentenceIdentifiers.GGA)
                    Parse_GGA(sSentence.parameters);
            }
        }

        #endregion

        #endregion

        #endregion

        #region Events

        public EventHandler IsWaitingLocalChangedEventHandler;
        public EventHandler<ACKReceivedEventArgs> ACKReceived;
        public EventHandler<DeviceSettingsReceivedEventArgs> DeviceSettingsReceived;
        public EventHandler<RefPointReceivedEventArgs> RefPointReceived;
        public EventHandler<TargetDepthAndWaterTemperatureEventArgs> TargetDepthAndWaterTemperatureReceived;
        public EventHandler<TrackPointEventArgs> TrackPointReceived;
        public EventHandler<RelativeParametersReceivedEventArgs> RelativeParametersReceived;
        public EventHandler<AUXGNSSFixReceivedEventArgs> AUXGNSSFixReceived;

        public EventHandler<RemoteValueReceivedEventArgs> RemoteValueReceived;
        public EventHandler<RemoteECodeReceivedEventArgs> RemoteECodeReceived;
        public EventHandler<BaseDataReceivedEventArgs> BaseDataReceived;

        public EventHandler DeviceInfoValidChanged;

        #endregion
    }
}
