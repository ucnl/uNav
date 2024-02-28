using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UCNLDrivers;
using uNav.uNavCore;

namespace uNav
{
    public class usContainer : SimpleSettingsContainer
    {
        #region Properties

        public string SerialOutputPortName;
        public string UDPOutputAddressAndPort;

        public bool MarkedPointsVisible;
        public bool BasePointsVisible;
        public bool HistoryVisible;
        public bool LegendVisible;
        public bool NotesVisible;
        public bool ExtraInfoVisible;
        public bool FollowTarget;
        public bool ShowMapTiles;

        public REF_POINT_TYPE_Enum RefPointTypeToNavigate;

        public bool SerialBypass;
        public bool UDPBypass;

        public Size WindowSize;
        public Point WindowLocation;
        public FormWindowState WindowState;

        #endregion

        public override void SetDefaults()
        {
            SerialOutputPortName = "COM1";
            UDPOutputAddressAndPort = "255.255.255.255:28128";

            MarkedPointsVisible = true;
            BasePointsVisible = true;
            HistoryVisible = true;
            LegendVisible = true;
            NotesVisible = true;
            ExtraInfoVisible = true;
            FollowTarget = true;
            ShowMapTiles = true;

            RefPointTypeToNavigate = REF_POINT_TYPE_Enum.AUX_GNSS;

            SerialBypass = false;
            UDPBypass = false;
            
            WindowState = FormWindowState.Normal;
            WindowSize = new Size(800, 600);
            WindowLocation = new Point(0, 0);
        }
    }
}
