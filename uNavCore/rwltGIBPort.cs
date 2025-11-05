using System;
using System.Collections.Generic;
using System.Net.Configuration;
using UCNLDrivers;
using UCNLNMEA;

namespace uNav.uNavCore
{
    public enum RWL_ICs
    {
        RWL0,
        RWL1,
        RWL2,
        RWL_EXCL,
        RWL_QUEST,
        ANY,
        INVALID
    }

    public static class RWL
    {
        static readonly Dictionary<string, RWL_ICs> ICsIdxArray = new Dictionary<string, RWL_ICs>()
        {
            { "0", RWL_ICs.RWL0 },
            { "1", RWL_ICs.RWL1 },
            { "2", RWL_ICs.RWL2 },
            { "!", RWL_ICs.RWL_EXCL },
            { "?", RWL_ICs.RWL_QUEST },
            { "-", RWL_ICs.ANY },
        };

        public static RWL_ICs ICsByID(string msgID)
        {
            if (ICsIdxArray.ContainsKey(msgID))
                return ICsIdxArray[msgID];
            else
                return RWL_ICs.INVALID;
        }
    }

    public class RWLACKReceivedEventArgs : EventArgs
    {
        // $PRWL0,bID,cmdID,result

        #region Properties
        public RWL_ICs SentenceID { get; private set; }
        public IC_RESULT_Enum ResultID { get; private set; }

        #endregion

        #region Constructor

        public RWLACKReceivedEventArgs(RWL_ICs sntID, IC_RESULT_Enum resID)
        {
            SentenceID = sntID;
            ResultID = resID;
        }

        #endregion
    }


    public class rwltGIBPort : uSerialPort
    {
        static bool nmeaSingleton = false;

        RWL_ICs lastQueryID = RWL_ICs.INVALID;

        bool isWaitingLocal = false;
        public bool IsWaitingLocal
        {
            get { return isWaitingLocal; }
            private set
            {
                isWaitingLocal = value;
                IsWaitingLocalChangedEventHandler?.Invoke(this, new EventArgs());
            }
        }

        public string SerialNumber { get; private set; }
        public int BaseID { get; private set; }

        public int RxChID { get; private set; }
        public string SystemInfo { get; private set; }
        public string SystemVersion { get; private set; }

        bool isDeviceInfoUpdated = false;
        public bool IsDeviceInfoUpdated
        {
            get { return isDeviceInfoUpdated; }
            private set
            {
                isDeviceInfoUpdated = value;
                DeviceInfoChangedEventHandler?.Invoke(this, new EventArgs());
            }
        }
        

        public rwltGIBPort(BaudRate baudRate)
            : base(baudRate)
        {
            base.PortDescription = "RWLT_GIB";
            base.IsLogIncoming = true;
            base.IsTryAlways = true;

            if (!nmeaSingleton)
            {
                NMEAParser.AddProprietarySentenceDescription(ManufacturerCodes.RWL, "0", "x,x,x");
                NMEAParser.AddProprietarySentenceDescription(ManufacturerCodes.RWL, "1", "x,x,x");
                NMEAParser.AddProprietarySentenceDescription(ManufacturerCodes.RWL, "?", "x,x");
                NMEAParser.AddProprietarySentenceDescription(ManufacturerCodes.RWL, "!", "x,c--c,c--c,x,x");
                nmeaSingleton = true;
            }
        }

        public void Query_SETTINGS_WRITE(int rxID, int newbID)
        {
            var msg = NMEAParser.BuildProprietarySentence(ManufacturerCodes.RWL,
                "1",
                new object[] { BaseID, rxID, newbID });

            TrySend(msg, RWL_ICs.RWL1);
        }

        private bool TrySend(string message, RWL_ICs queryID)
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
        
        private void Parse_RWL0(object[] parameters)
        {
            // #define IC_D2H_ACK              '0'        // $PRWL0,bID,cmdID,errCode
            bool isOk = false;
            int bID = -1;
            RWL_ICs cmdID = RWL_ICs.INVALID;
            IC_RESULT_Enum errCOde = IC_RESULT_Enum.IC_RES_INVALID;

            try
            {
                bID = uNav.O2S32(parameters[0]);
                cmdID = RWL.ICsByID(parameters[1].ToString());
                errCOde = uNav.O2_IC_RESULT_Enum(parameters[2]);

                isOk = true;

            }
            catch (Exception ex)
            {
                LogEventHandler?.Invoke(this, new LogEventArgs(LogLineType.ERROR, ex));
            }

            if (isOk)
            {
                StopTimer();
                IsWaitingLocal = false;
                ACKReceivedEventHandler?.Invoke(this, new RWLACKReceivedEventArgs(cmdID, errCOde));
            }
        }  

        private void Parse_RWL_EXCL(object[] parameters)
        {
            // $PRWL!,bID,serial_number,sys_moniker,sys_version,rxChID
            bool isOk = false;

            try
            {
                BaseID = uNav.O2S32(parameters[0]);
                SerialNumber = uNav.O2S(parameters[1]);
                SystemInfo = uNav.O2S(parameters[2]);
                SystemVersion = uNav.BCDVersionToStr(uNav.O2S32(parameters[3]));
                RxChID = uNav.O2S32(parameters[4]);                

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
                IsDeviceInfoUpdated = !string.IsNullOrEmpty(SerialNumber);                
            }
        }


        #region uSerialPort

        public override void InitQuerySend()
        {
            var msg = NMEAParser.BuildProprietarySentence(ManufacturerCodes.RWL, "?", new object[] { null, null });
            Send(msg);
        }

        public override void OnClosed()
        {
            StopTimer();
            isWaitingLocal = false;
        }

        public override void ProcessIncoming(NMEASentence sentence)
        {
            if (sentence is NMEAProprietarySentence)
            {
                NMEAProprietarySentence pSentence = (sentence as NMEAProprietarySentence);

                if (pSentence.Manufacturer == ManufacturerCodes.RWL)
                {
                    if (!detected)
                        detected = true;

                        if (pSentence.SentenceIDString == "0")
                            Parse_RWL0(pSentence.parameters);
                        else if (pSentence.SentenceIDString == "!")
                            Parse_RWL_EXCL(pSentence.parameters);                        
                }
            }
            
        }

        #endregion


        public EventHandler IsWaitingLocalChangedEventHandler;
        public EventHandler DeviceInfoChangedEventHandler;
        public EventHandler<RWLACKReceivedEventArgs> ACKReceivedEventHandler;
    }
}
