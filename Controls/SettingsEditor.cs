using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UCNLDrivers;
using UCNLUI;
using UCNLUI.Dialogs;

namespace uNav.Controls
{
    public partial class SettingsEditor : Form
    {
        #region Properties

        #region mainTab

        BaudRate inportBaudrate
        {
            get => (BaudRate)Enum.Parse(typeof(BaudRate), inportBaudrateCbx.SelectedItem.ToString());
            set => UIHelpers.TrySetCbxItem(inportBaudrateCbx, value.ToString());
        }

        BaudRate outportBaudrate
        {
            get => (BaudRate)Enum.Parse(typeof(BaudRate), outportBaudrateCbx.SelectedItem.ToString());
            set => UIHelpers.TrySetCbxItem(outportBaudrateCbx, value.ToString());
        }

        #endregion

        #region physics tab

        bool isSalinityAuto
        {
            get => isAutoSalinityChb.Checked;
            set => isAutoSalinityChb.Checked = value;
        }

        bool isSpeedOfSoundAuto
        {
            get => isAutoSoundSpeedChb.Checked;
            set => isAutoSoundSpeedChb.Checked = value;
        }

        double salinity_PSU
        {
            get => Convert.ToDouble(salinityEdit.Value);
            set => UIHelpers.SetNumericEditValue(salinityEdit, value);
        }

        double speedOfSound
        {
            get => Convert.ToDouble(speedOfSoundEdit.Value);
            set => UIHelpers.SetNumericEditValue(speedOfSoundEdit, value);
        }

        double waterTemperature
        {
            get => Convert.ToDouble(waterTemperatureEdit.Value);
            set => UIHelpers.SetNumericEditValue(waterTemperatureEdit, value);
        }

        double targetMaxSpeed
        {
            get => Convert.ToDouble(targetMaxSpeedEdit.Value);
            set => UIHelpers.SetNumericEditValue(targetMaxSpeedEdit, value);
        }

        double sFilterRangeThreshold
        {
            get => Convert.ToDouble(sThresholdEdit.Value);
            set => UIHelpers.SetNumericEditValue(sThresholdEdit, value);
        }

        int sFilterFIFOSize
        {
            get => Convert.ToInt32(sFIFOSizeEdit.Value);
            set => UIHelpers.SetNumericEditValue(sFIFOSizeEdit, value);
        }

        double dhFilterRangeThreshold
        {
            get => Convert.ToDouble(dhThresholdEdit.Value);
            set => UIHelpers.SetNumericEditValue(dhThresholdEdit, value);
        }

        int dhFilterFIFOSize
        {
            get => Convert.ToInt32(dhFIFOSizeEdit.Value);
            set => UIHelpers.SetNumericEditValue(dhFIFOSizeEdit, value);
        }

        int ceFIFOSize
        {
            get => Convert.ToInt32(cFIFOSizeEdit.Value);
            set => UIHelpers.SetNumericEditValue(cFIFOSizeEdit, value);
        }



        #endregion

        #region Extra tab

        int numberOfTrackPointsToShow
        {
            get => Convert.ToInt32(numberOfPointsToShowEdit.Value);
            set => UIHelpers.SetNumericEditValue(numberOfPointsToShowEdit, value);
        }

        int tileSize
        {
            get => Convert.ToInt32(tileSizeEdit.Value);
            set => UIHelpers.SetNumericEditValue(tileSizeEdit, value);
        }

        string[] tileServers
        {
            get => tileServersTxb.Lines;
            set => tileServersTxb.Lines = value;
        }

        bool enableTilesDownloading
        {
            get => enableTileDonwloadChb.Checked;
            set => enableTileDonwloadChb.Checked = value;
        }

        int rwlt_mode
        {
            get => rwlt_modeCbx.SelectedIndex;
            set => rwlt_modeCbx.SelectedIndex = value;
        }

        int rwlt_drating
        {
            get => rwlt_dratingCbx.SelectedIndex;
            set => rwlt_dratingCbx.SelectedIndex = value;
        }

        #endregion


        public sContainer Value
        {
            get
            {
                sContainer result = new sContainer();

                result.InPortBaudrate = inportBaudrate;
                result.SerialBypassBaudrate = outportBaudrate;

                result.IsAutoSalinity = isSalinityAuto;
                result.Salinity_PSU = salinity_PSU;

                result.IsAutoSoundSpeed = isSpeedOfSoundAuto;
                result.SoundSpeed_mps = speedOfSound;
                result.WaterTemperature_C = waterTemperature;
                result.TargetMaxSpeed_mps = targetMaxSpeed;
                result.TrackSmootherRangeThreshold_m = sFilterRangeThreshold;
                result.TrackSmootherFIFOSize = sFilterFIFOSize;
                result.DHFilterRangeThreshold_m = dhFilterRangeThreshold;
                result.DHFilterFIFOSize = dhFilterFIFOSize;
                result.CourseEstimatorFIFOSize = ceFIFOSize;

                result.TrackPointsToShow = numberOfTrackPointsToShow;
                result.TileSizePx = tileSize;
                result.TileServers = tileServers;
                result.EnableTilesDownloading = enableTilesDownloading;

                result.RWLT_Mode = rwlt_mode;
                result.RWLT_DRating = rwlt_drating;

                return result;
            }
            set
            {

                inportBaudrate = value.InPortBaudrate;
                outportBaudrate = value.SerialBypassBaudrate;

                targetMaxSpeed = value.TargetMaxSpeed_mps;
                sFilterRangeThreshold = value.TrackSmootherRangeThreshold_m;
                sFilterFIFOSize = value.TrackSmootherFIFOSize;
                dhFilterRangeThreshold = value.DHFilterRangeThreshold_m;
                dhFilterFIFOSize = value.DHFilterFIFOSize;
                ceFIFOSize = value.CourseEstimatorFIFOSize;

                numberOfTrackPointsToShow = value.TrackPointsToShow;
                tileSize = value.TileSizePx;
                tileServers = value.TileServers;
                enableTilesDownloading = value.EnableTilesDownloading;

                rwlt_mode = value.RWLT_Mode;
                rwlt_drating = value.RWLT_DRating;
            }
        }


        #endregion

        #region Constructor

        public SettingsEditor()
        {
            InitializeComponent();

            var bRates = Enum.GetNames(typeof(BaudRate));
            inportBaudrateCbx.Items.Clear();
            inportBaudrateCbx.Items.AddRange(bRates);
            outportBaudrateCbx.Items.Clear();
            outportBaudrateCbx.Items.AddRange(bRates);

            inportBaudrate = BaudRate.baudRate9600;
            outportBaudrate = BaudRate.baudRate9600;

            rwlt_mode = 0;
            rwlt_drating = 0;
        }

        #endregion

        #region Methods


        #endregion

        #region Handlers


        #endregion

        private void isAutoSalinityChb_CheckedChanged(object sender, EventArgs e)
        {
            salinityEdit.Enabled = !isSalinityAuto;
            salinityFromDbBtn.Enabled = !isSalinityAuto;
        }

        private void isAutoSoundSpeedChb_CheckedChanged(object sender, EventArgs e)
        {
            speedOfSoundEdit.Enabled = !isSpeedOfSoundAuto;

        }

        private void salinityFromDbBtn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (SalinityDialog sDialog = new SalinityDialog())
            {
                sDialog.Text = "Water salinity";
                sDialog.SalinityCaption = "Salinity, PSU";
                sDialog.LatCaption = "Lat";
                sDialog.LonCaption = "Lon";
                sDialog.CancelBtnCaption = "CANCEL";
                sDialog.OkBtnCaption = "OK";
                sDialog.NearestPntMsg = "Nearest known point";

                if (sDialog.ShowDialog() == DialogResult.OK)
                {
                    salinity_PSU = sDialog.Salinity;
                }
            }
        }

        private void setDefaultsBtn_Click(object sender, EventArgs e)
        {
            Value = new sContainer();
        }

        private void SettingsEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.Tab)
                {
                    mainTabControl.SelectedIndex = (mainTabControl.SelectedIndex + 1) % mainTabControl.TabCount;
                    e.SuppressKeyPress = true;
                }
                else if (e.KeyCode == Keys.D)
                {
                    setDefaultsBtn_Click(setDefaultsBtn, EventArgs.Empty);
                    e.SuppressKeyPress = true;
                }
            }
        }
    }
}
