using System;
using System.Collections.Generic;
using System.Globalization;
using UCNLDrivers;

namespace uNav.uNavCore
{
    #region Custom enums
    public enum ICs
    {
        UNV0,
        UNV1,
        UNV2,
        UNV3,
        UNV4,
        UNV5,
        UNV6,
        UNV_EXCL,
        UNV_QUEST,
        ANY,
        INVALID
    }

    public enum IC_RESULT_Enum
    {
        IC_RES_OK = 0,
        IC_RES_INVALID_SYNTAX = 1,
        IC_RES_UNSUPPORTED_CMD = 2,
        IC_RES_ARGUMENT_OUT_OF_RANGE = 3,
        IC_RES_INVALID_OPERATION = 4,
        IC_RES_VALUE_UNAVAILABLE = 5,
        IC_RES_TX_BUSY = 6,
        IC_RES_RX_BUSY = 7,
        IC_RES_INVALID
    }

    public enum REF_POINT_TYPE_Enum
    {
        AUX_GNSS = 0,
        BASE_1 = 1,
        BASE_2 = 2,
        BASE_3 = 3,
        BASE_4 = 4,
        USER_DEFINED = 5,
        INVALID
    }

    public enum DID_Enum
    {
        DID_PRS = 0,
        DID_TMP = 1,
        DID_BAT = 2,
        DID_CODE = 3,
        DID_INVALID
    }

    public enum DeviceBaudrateEnum : int
    {
        DC_BAUDRATE_1200 = 0,
        DC_BAUDRATE_2400 = 1,
        DC_BAUDRATE_4800 = 2,
        DC_BAUDRATE_9600 = 3,
        DC_BAUDRATE_19200 = 4,
        DC_BAUDRATE_38400 = 5,
        DC_BAUDRATE_57600 = 6,
        DC_BAUDRATE_115200 = 7,
        DC_BAUDDRATE_INVALID
    }

    public enum ECodes_Enum : int
    {
         RE_RESERVED_1 = 1010,
         RE_RESERVED_2 = 1011,
         RE_RESERVED_3 = 1012,
         RE_RESERVED_4 = 1013,
         RE_RESERVED_5 = 1014,
         RE_RESERVED_6 = 1015,
         RE_PTS_FAILURE = 1016,
         RE_NOT_AVAILABLE = 1017,
         RE_PRS_OVRF = 1018,
         RE_BAT_LOW = 1019,
         RE_TMP_LOW = 1020,
         RE_TMP_HIGH = 1021,
         RE_INVALID_CODE1 = 1022,
         RE_INVALID_CODE = 1023,         
         INVALID
    }

    #endregion

    public static class uNav
    {
        static readonly Dictionary<string, ICs> ICsIdxArray = new Dictionary<string, ICs>()
        {
            { "0", ICs.UNV0 },
            { "1", ICs.UNV1 },
            { "2", ICs.UNV2 },
            { "3", ICs.UNV3 },
            { "!", ICs.UNV_EXCL },
            { "?", ICs.UNV_QUEST },
            { "-", ICs.ANY },
        };

        public static readonly string BaseIDStr = "Base #";
        public static readonly string[] BaseTracksIDs = new string[] { "Base #1", "Base #2", "Base #3", "Base #4" };

        public static readonly string AUXGNSSTrackID = "AUX GNSS";
        public static readonly string TargetTrackID = "Target";
        public static readonly string MarkedPointsTrackID = "Marked";
        public static readonly string RefPointTrackID = "Ref. point";

        public static readonly Func<object, string> O2S = o => o == null ? string.Empty : (string)o;
        public static readonly Func<object, double> O2D = o => o == null ? double.NaN : (double)o;
        public static readonly Func<object, int> O2S32 = o => o == null ? -1 : (int)o;
        public static readonly Func<object, ushort> O2U16 = o => o == null ? ushort.MinValue : (ushort)(int)o;

        public static readonly Func<object, DID_Enum> O2_DID_Enum = o => o == null ? DID_Enum.DID_INVALID : (DID_Enum)(int)o;
        public static readonly Func<object, IC_RESULT_Enum> O2_IC_RESULT_Enum = o => o == null ? IC_RESULT_Enum.IC_RES_INVALID : (IC_RESULT_Enum)(int)o;
        public static readonly Func<object, REF_POINT_TYPE_Enum> O2_REF_POINT_TYPE_Enum = o => o == null ? REF_POINT_TYPE_Enum.INVALID : (REF_POINT_TYPE_Enum)(int)o;

        public static readonly Func<double, object> D2O = d => double.IsNaN(d) ? null : (object)d;
        public static readonly Func<int, object> I2O_NEG2NULL = i => (i < 0) ? null : (object)i;
        public static readonly Func<REF_POINT_TYPE_Enum, object> REF_POINT_TYPE_Enum_2O = r => r == REF_POINT_TYPE_Enum.INVALID ? null : (object)r;

        public static readonly Func<double, string> meters1dec_fmtr = o => string.Format(CultureInfo.InvariantCulture, "{0:F01} m", o);
        public static readonly Func<double, string> meters3dec_fmtr = o => string.Format(CultureInfo.InvariantCulture, "{0:F03} m", o);
        public static readonly Func<double, string> degrees1dec_fmtr = o => string.Format(CultureInfo.InvariantCulture, "{0:F01} °", o);
        public static readonly Func<double, string> latlon_fmtr = o => string.Format(CultureInfo.InvariantCulture, "{0:F06} °", o);
        public static readonly Func<double, string> db_fmtr = o => string.Format(CultureInfo.InvariantCulture, "{0:F01} dB", o);
        public static readonly Func<double, string> degC_fmtr = o => string.Format(CultureInfo.InvariantCulture, "{0:F01} °C", o);
        public static readonly Func<double, string> mBar_fmtr = o => string.Format(CultureInfo.InvariantCulture, "{0:F01} mBar", o);
        public static readonly Func<double, string> v1dec_fmtr = o => string.Format(CultureInfo.InvariantCulture, "{0:F01} V", o);
        public static readonly Func<double, string> kmh_mps_fmtr = o => string.Format(CultureInfo.InvariantCulture, "{0:F01} km/h ({1:F01} m/s)", o, o / 3.6);


        public static string BaseID2Str(int bID)
        {
            return string.Format("{0}{1}", BaseIDStr, bID + 1);
        }

        public static ICs ICsByID(string msgID)
        {
            if (ICsIdxArray.ContainsKey(msgID))
                return ICsIdxArray[msgID];
            else
                return ICs.INVALID;
        }

        public static BaudRate D2H_BaudrateConverter(DeviceBaudrateEnum brate)
        {
            if (brate == DeviceBaudrateEnum.DC_BAUDRATE_1200)
                return BaudRate.baudRate1200;
            else if (brate == DeviceBaudrateEnum.DC_BAUDRATE_2400)
                return BaudRate.baudRate2400;
            else if (brate == DeviceBaudrateEnum.DC_BAUDRATE_4800)
                return BaudRate.baudRate4800;
            else if (brate == DeviceBaudrateEnum.DC_BAUDRATE_9600)
                return BaudRate.baudRate9600;
            else if (brate == DeviceBaudrateEnum.DC_BAUDRATE_19200)
                return BaudRate.baudRate19200;
            else if (brate == DeviceBaudrateEnum.DC_BAUDRATE_38400)
                return BaudRate.baudRate38400;
            else if (brate == DeviceBaudrateEnum.DC_BAUDRATE_57600)
                return BaudRate.baudRate57600;
            else if (brate == DeviceBaudrateEnum.DC_BAUDRATE_115200)
                return BaudRate.baudRate115200;
            else
                return BaudRate.baudRate9600;
        }

        public static DeviceBaudrateEnum H2D_BaudrateConvert(BaudRate brate)
        {
            if (brate == BaudRate.baudRate1200)
                return DeviceBaudrateEnum.DC_BAUDRATE_1200;
            else if (brate == BaudRate.baudRate2400)
                return DeviceBaudrateEnum.DC_BAUDRATE_2400;
            else if (brate == BaudRate.baudRate4800)
                return DeviceBaudrateEnum.DC_BAUDRATE_4800;
            else if (brate == BaudRate.baudRate9600)
                return DeviceBaudrateEnum.DC_BAUDRATE_9600;
            else if (brate == BaudRate.baudRate19200)
                return DeviceBaudrateEnum.DC_BAUDRATE_19200;
            else if (brate == BaudRate.baudRate38400)
                return DeviceBaudrateEnum.DC_BAUDRATE_38400;
            else if (brate == BaudRate.baudRate57600)
                return DeviceBaudrateEnum.DC_BAUDRATE_57600;
            else if (brate == BaudRate.baudRate115200)
                return DeviceBaudrateEnum.DC_BAUDRATE_115200;
            else
                return DeviceBaudrateEnum.DC_BAUDDRATE_INVALID;
        }

        public static string BCDVersionToStr(int versionData)
        {
            return string.Format("{0}.{1}", (versionData >> 0x08).ToString(), (versionData & 0xff).ToString("X2"));
        }
    }
}
