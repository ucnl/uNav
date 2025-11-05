using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using UCNLDrivers;
using UCNLKML;
using UCNLNav;
using UCNLNav.TrackFilters;
using UCNLUI;
using UCNLUI.Dialogs;
using uNav.Controls;
using uNav.Controls.Specific;
using uNav.uNavCore;
using uOSM;

namespace uNav
{
    public partial class MainForm : Form
    {
        #region Properties

        static readonly string appicon = "💧";
        bool isRestart = false;

        string logPath;
        string logFileName;
        string settingsFileName;
        string uiSettingsFileName;
        string snapshotsPath;
        string tileDBPath;

        int autoscreenshot_idx = 0;
        string autoscreenshots_path;
        PrecisionTimer uTimer;

        readonly uNavBase uBase;

        readonly TSLogProvider logger;
        readonly UIAutomation uiAutomation;
        readonly uOSMTileProvider tProvider;
        readonly LogPlayer lPlayer;
        readonly TrackManager tManager;
        readonly WPManager wpManager;

        readonly SimpleSettingsProvider<usContainer> usProvider;
        readonly SimpleSettingsProvider<sContainer> sProvider;

        #region uiAutomated items

        #region uiAutomation

        bool markedPointsVisible
        {
            get => markedPointsVisibleBtn.Checked;
            set
            {
                markedPointsVisibleBtn.Checked = value;
                usProvider.Data.MarkedPointsVisible = value;
                //plot.SetTracksVisibility(APL.APL.MarkedPointsTrackID, value);
                uPlot.Invalidate();
            }
        }

        bool basePointsVisible
        {
            get => basePointsVisibleBtn.Checked;
            set
            {
                basePointsVisibleBtn.Checked = value;
                usProvider.Data.BasePointsVisible = value;
                uPlot.SetTracksVisibility(uNavCore.uNav.BaseTracksIDs, value);
                uPlot.Invalidate();
            }
        }

        bool historyVisible
        {
            get => historyLogVisibleBtn.Checked;
            set
            {
                historyLogVisibleBtn.Checked = value;
                usProvider.Data.HistoryVisible = value;
                uPlot.HistoryVisible = value;
                uPlot.Invalidate();
            }
        }

        bool legendVisible
        {
            get => legendVisibleBtn.Checked;
            set
            {
                legendVisibleBtn.Checked = value;
                usProvider.Data.LegendVisible = value;
                uPlot.LegendVisible = value;
                uPlot.Invalidate();
            }
        }

        bool notesVisible
        {
            get => notesVisibleBtn.Checked;
            set
            {
                notesVisibleBtn.Checked = value;
                usProvider.Data.NotesVisible = value;
                uPlot.RightUpperTextVisible = value;
                uPlot.Invalidate();
            }
        }

        bool extraInfoVisible
        {
            get => extraInfoVisibleBtn.Checked;
            set
            {
                extraInfoVisibleBtn.Checked = value;
                usProvider.Data.ExtraInfoVisible = value;
                uPlot.LeftUpperTextVisible = value;
                uPlot.Invalidate();
            }
        }

        bool followTarget
        {
            get => followTargetBtn.Checked;
            set
            {
                followTargetBtn.Checked = value;
                usProvider.Data.FollowTarget = value;

                if (value && (uBase != null) && uBase.TargetLocationPresent)
                {
                    var location = uBase.GetCurrentTargetLocation();
                    uPlot.SetCenter(location.Latitude, location.Longitude);
                }                
            }
        }

        bool showMapTiles
        {
            get => showMapTilesBtn.Checked;
            set
            {
                showMapTilesBtn.Checked = value;
                usProvider.Data.ShowMapTiles = value;
                uPlot.TilesEnabled = value;
            }
        }

        #endregion

        bool refPointTypeChangedByDevice = false;
        REF_POINT_TYPE_Enum refPointType
        {
            get => (REF_POINT_TYPE_Enum)Enum.Parse(typeof(REF_POINT_TYPE_Enum), refPointCbx.SelectedItem.ToString());
            set => UIHelpers.TrySetCbxItem(refPointCbx, value.ToString());
        }

        double refPointUserLat, refPointUserLon;

        bool serialBypass
        {
            get => serialBypassBtn.Checked;
            set
            {
                serialBypassBtn.Checked = value;
                usProvider.Data.SerialBypass = value;                
            }
        }

        string serialBypassPortName
        {
            get => serialBypassPortCbx.SelectedItem == null ? string.Empty : serialBypassPortCbx.SelectedItem.ToString();
            set 
            {
                UIHelpers.TrySetCbxItem(serialBypassPortCbx, value);
                usProvider.Data.SerialOutputPortName = value;
            }
        }

        bool udpBypass
        {
            get => udpBypassBtn.Checked;
            set
            {
                udpBypassBtn.Checked = value;
                usProvider.Data.UDPBypass = value;
            }
        }

        string udpBypassAddrAndPort
        {
            get => udpBypassAddrPortTxb.Text;
            set
            {
                udpBypassAddrPortTxb.Text = value;
                usProvider.Data.UDPOutputAddressAndPort = value;
            }
        }

        IPAddress udpBypassAddr
        {
            get
            {
                var splits = udpBypassAddrPortTxb.Text.Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (IPAddress.TryParse(splits[0], out var ipAddress))
                    return ipAddress;
                else
                    return null;
            }
        }

        int udpBypassPort
        {
            get
            {
                var splits = udpBypassAddrPortTxb.Text.Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if ((splits.Length == 2) && (ushort.TryParse(splits[1], out var val)))
                    return val;
                else
                    return -1;
                
            }
        }

        #endregion

        bool autoscreenshotEnabled
        {
            get => autoscreenShotBtn.Checked;
            set => autoscreenShotBtn.Checked = value;
        }

        bool settingsUpdated = false;

        bool needSettingsUpdate = false;

        #endregion       

        #region Constuctor

        public MainForm()
        {
            #region App title init

            string vString = string.Format("{0} {1} v{2} {3}",
                appicon,
                Application.ProductName,
                Assembly.GetExecutingAssembly().GetName().Version.ToString(),
                MDates.GetReferenceNote());

            #endregion

            #region paths & filenames

            DateTime startTime = DateTime.Now;
            settingsFileName = Path.ChangeExtension(Application.ExecutablePath, "settings");
            uiSettingsFileName = Path.ChangeExtension(Application.ExecutablePath, "uisettings");
            logPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "LOG");
            logFileName = StrUtils.GetTimeDirTreeFileName(startTime, Application.ExecutablePath, "LOG", "log", true);
            snapshotsPath = StrUtils.GetTimeDirTree(startTime, Application.ExecutablePath, "SNAPSHOTS", false);
            tileDBPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Cache\\Tiles\\");

            #endregion

            #region logger

            logger = new TSLogProvider(logFileName);
            logger.WriteStart();
            logger.Write(vString);
            logger.TextAddedEvent += (o, e) => InvokeAppendHistoryLine(e.Text);

            #endregion

            InitializeComponent();

            this.Text = vString;

            #region sProvider

            sProvider = new SimpleSettingsProviderXML<sContainer>();
            sProvider.isSwallowExceptions = false;

            logger.Write(string.Format("Loading settings from {0}", settingsFileName));

            try
            {
                sProvider.Load(settingsFileName);
            }
            catch (Exception ex)
            {
                ProcessException(ex, true);
            }

            logger.Write("Current application settings:");
            logger.Write(sProvider.Data.ToString());

            #endregion

            #region uiAutomation

            uiAutomation = new UIAutomation();
            uiAutomation.InitBoolProperty<MainForm>(this, nameof(markedPointsVisible));
            uiAutomation.InitBoolProperty<MainForm>(this, nameof(basePointsVisible));
            uiAutomation.InitBoolProperty<MainForm>(this, nameof(historyVisible));
            uiAutomation.InitBoolProperty<MainForm>(this, nameof(legendVisible));
            uiAutomation.InitBoolProperty<MainForm>(this, nameof(notesVisible));
            uiAutomation.InitBoolProperty<MainForm>(this, nameof(extraInfoVisible));
            uiAutomation.InitBoolProperty<MainForm>(this, nameof(followTarget));
            uiAutomation.InitBoolProperty<MainForm>(this, nameof(showMapTiles));
            uiAutomation.InitBoolProperty<MainForm>(this, nameof(serialBypass));
            uiAutomation.InitBoolProperty<MainForm>(this, nameof(udpBypass));

            #endregion

            #region UI Settings

            usProvider = new SimpleSettingsProviderXML<usContainer>();

            usProvider.isSwallowExceptions = true;
            usProvider.Load(uiSettingsFileName);

            markedPointsVisible = usProvider.Data.MarkedPointsVisible;
            basePointsVisible = usProvider.Data.BasePointsVisible;
            historyVisible = usProvider.Data.HistoryVisible;
            legendVisible = usProvider.Data.LegendVisible;
            notesVisible = usProvider.Data.NotesVisible;
            extraInfoVisible = usProvider.Data.ExtraInfoVisible;
            followTarget = usProvider.Data.FollowTarget;
            showMapTiles = usProvider.Data.ShowMapTiles;

            if ((usProvider.Data.WindowSize.Width >= this.MinimumSize.Width) &&
                (usProvider.Data.WindowSize.Height >= this.MinimumSize.Height))
                this.Size = usProvider.Data.WindowSize;

            this.Location = usProvider.Data.WindowLocation;
            this.WindowState = usProvider.Data.WindowState;


            if (usProvider.Data.RefPointTypeToNavigate == REF_POINT_TYPE_Enum.USER_DEFINED)
                usProvider.Data.RefPointTypeToNavigate = REF_POINT_TYPE_Enum.AUX_GNSS;

            refPointType = usProvider.Data.RefPointTypeToNavigate;

            #endregion

            #region tProvider

            if ((sProvider.Data.TileServers != null) &&
                (sProvider.Data.TileServers.Length > 0))
            {
                tProvider = new uOSMTileProvider(1024,
                    19,
                    new Size(sProvider.Data.TileSizePx, sProvider.Data.TileSizePx),
                    tileDBPath,
                    sProvider.Data.TileServers);

                tProvider.DownloadingEnabled = sProvider.Data.EnableTilesDownloading;
            }

            #endregion

            #region tManager

            tManager = new TrackManager();
            tManager.IsEmptyChanged += (o, e) =>
            {
                UIHelpers.InvokeSetEnabledState(primaryToolStrip, tracksExportAsBtn, !tManager.IsEmpty);
                UIHelpers.InvokeSetEnabledState(primaryToolStrip, tracksClearAllBtn, !tManager.IsEmpty);
            };
            tManager.IsEmptyChanged(this, EventArgs.Empty);

            #endregion

            #region wpManager

            wpManager = new WPManager();
            wpManager.IsAutoSalinity = sProvider.Data.IsAutoSalinity;
            wpManager.IsAutoSoundSpeed = sProvider.Data.IsAutoSoundSpeed;

            wpManager.SoundSpeedChanged += (o, e) => { needSettingsUpdate = true; };
            wpManager.SalinityChanged += (o, e) => { needSettingsUpdate = true; };

            #endregion

            #region lPlayer

            lPlayer = new LogPlayer();
            lPlayer.NewLogLineHandler += (o, e) =>
            {
                if (e.Line.StartsWith("INFO"))
                {
                    int idx = e.Line.IndexOf(' ');
                    if (idx >= 0)
                    {
                        uBase.Emulate(e.Line.Substring(idx).Trim());
                    }
                }
                else if (e.Line.StartsWith("NOTE"))
                {
                    var match = Regex.Match(e.Line, "\"[^\" ][^\"]*\"");
                    if (match.Success)
                        InvokeSetNoteText(match.ToString().Trim('"'));
                }
                else if (e.Line.StartsWith(UIAutomation.LogID))
                {
                    int idx = e.Line.IndexOf(' ');
                    if (idx >= 0)
                        InvokePerformUIAction(e.Line.Substring(idx).Trim());
                }
            };

            lPlayer.LogPlaybackFinishedHandler += (o, e) =>
            {
                uBase.Stop();

                if (InvokeRequired)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        settingsBtn.Enabled = true;
                        linkBtn.Enabled = true;
                        logPlaybackBtn.Text = string.Format("▶ {0}", LocalisedStrings.MainForm_Playback);
                        MessageBox.Show(
                            string.Format("{0} \"{1}\" {2}", 
                            LocalisedStrings.MainForm_LogFile, 
                            lPlayer.LogFileName, LocalisedStrings.MainForm_PlaybackIsFinished),
                            string.Format("{0} {1} - {2}",
                            appicon,
                            Application.ProductName, LocalisedStrings.MainForm_Information),
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    });
                }
                else
                {
                    settingsBtn.Enabled = true;
                    linkBtn.Enabled = true;
                    logPlaybackBtn.Text = string.Format("▶ {0}", LocalisedStrings.MainForm_Playback);
                    MessageBox.Show(
                         string.Format("{0} \"{1}\" {2}",
                         LocalisedStrings.MainForm_LogFile,
                         lPlayer.LogFileName, LocalisedStrings.MainForm_PlaybackIsFinished),
                         string.Format("{0} {1} - {2}",
                         appicon,
                         Application.ProductName, LocalisedStrings.MainForm_Information),
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Information);
                }
            };

            #endregion

            #region Misc. init

            moonPhaseLbl.Text = AstroAndTimeUtils.MoonPhaseIcon(DateTime.Now);
            moonPhaseLbl.ToolTipText = AstroAndTimeUtils.MoonPhaseDescription(DateTime.Now);

            refPointCbx.Items.Clear();
            refPointCbx.Items.AddRange(Enum.GetNames(typeof(REF_POINT_TYPE_Enum)));

            SwitchOutputPortUIEnabledState(false);

            uPlot.InitTrack(uNavCore.uNav.AUXGNSSTrackID, 64, Color.Blue, 8, 1, true);
            uPlot.InitTrack(uNavCore.uNav.TargetTrackID, sProvider.Data.TrackPointsToShow, Color.Red, 8, 1, true);
            uPlot.InitTrack(uNavCore.uNav.BaseID2Str(0), 4, Color.DarkRed, 8, 1, false);
            uPlot.InitTrack(uNavCore.uNav.BaseID2Str(1), 4, Color.DarkOrange, 8, 1, false);
            uPlot.InitTrack(uNavCore.uNav.BaseID2Str(2), 4, Color.Green, 8, 1, false);
            uPlot.InitTrack(uNavCore.uNav.BaseID2Str(3), 4, Color.Purple, 8, 1, false);
            uPlot.InitTrack(uNavCore.uNav.MarkedPointsTrackID, 256, Color.Black, 8, 1, false);
            uPlot.InitTrack(uNavCore.uNav.RefPointTrackID, 2, Color.Yellow, 8, 1, false);

            if (tProvider != null)
                uPlot.ConnectTileProvider(tProvider);

            #endregion

            #region uBase

            uBase = new uNavBase(sProvider.Data.InPortBaudrate);
            uBase.LogEventHandler += (o, e) => logger.Write(string.Format("{0}: {1}", e.EventType, e.LogString));
            
            uBase.IsActiveChanged += (o, e) =>
            {
                UIHelpers.InvokeSetCheckedState(primaryToolStrip, linkBtn, uBase.IsActive);
                UIHelpers.InvokeSetEnabledState(primaryToolStrip, settingsBtn, !uBase.IsActive);
                UIHelpers.InvokeSetEnabledState(primaryToolStrip, logPlaybackBtn, !uBase.IsActive);
                UIHelpers.InvokeSetEnabledState(secondaryToolStrip, refPointCbx, false);
                InvokeUpdatePortStatusLbl(mainStatusStrip, connectionStatusLbl, uBase.IsActive, uBase.PortDetected, uBase.PortStatus);
                logger.Write(string.Format("{0}={1}", nameof(uBase.IsActive), uBase.IsActive));
            };            
            uBase.SerialBypassIsActiveChanged += (o, e) => 
            {
                // ??
            };
            uBase.DetectedChanged += (o, e) =>
            {
                InvokeUpdatePortStatusLbl(mainStatusStrip, connectionStatusLbl, uBase.IsActive, uBase.PortDetected, uBase.PortStatus);
                UIHelpers.InvokeSetEnabledState(secondaryBottomToolStrip, serialBypassPortRefreshBtn, uBase.PortDetected);
                settingsUpdated = false;                
            };
            uBase.DeviceInfoValidChanged += (o, e) =>
            {
                UIHelpers.InvokeSetEnabledState(primaryToolStrip, deviceInfoViewBtn, uBase.PortDetected);
                
                if (uBase.IsDeviceInfoValid)
                {
                    if (!settingsUpdated)
                    {
                        uBase.DeviceSettingsQuerySet(
                            sProvider.Data.Salinity_PSU,
                            sProvider.Data.WaterTemperature_C,
                            sProvider.Data.IsAutoSoundSpeed ? double.NaN : sProvider.Data.SoundSpeed_mps,
                            sProvider.Data.TargetMaxSpeed_mps,
                            sProvider.Data.TrackSmootherFIFOSize,
                            sProvider.Data.TrackSmootherRangeThreshold_m,
                            sProvider.Data.DHFilterFIFOSize,
                            sProvider.Data.DHFilterRangeThreshold_m,
                            sProvider.Data.CourseEstimatorFIFOSize,
                            BaudRate.baudRate38400,
                            sProvider.Data.RWLT_Mode,
                            sProvider.Data.RWLT_DRating);
                    }
                }
            };
            uBase.DeviceSettingsReceived += (o, e) =>
            {
                settingsUpdated = true;                
                uBase.RefPointQuery();
            };
            uBase.NavigationDataUpdated += (o, e) =>
            {
                InvokeSetLeftUpperText(uBase.GetTargetDescription(true, true, true));

                if (needSettingsUpdate)
                {
                    needSettingsUpdate = false;
                    uBase.DeviceSettingsQuerySet(
                        wpManager.Salinity,
                        wpManager.Temperature,
                        sProvider.Data.IsAutoSoundSpeed ? double.NaN : wpManager.SoundSpeed);
                }

            };
            uBase.RefPointReceived += (o, e) =>
            {
                UIHelpers.InvokeSetEnabledState(secondaryToolStrip, refPointCbx, true);

                refPointTypeChangedByDevice = true;
                InvokeSetRefPoint(e.RefPoint_Type);
                refPointTypeChangedByDevice = false;

                if (e.RefPoint_Type == REF_POINT_TYPE_Enum.USER_DEFINED)
                {
                    InvokeAddPoint(new TrackPointEventArgs(
                        uNavCore.uNav.RefPointTrackID, 
                        e.RefPoint_Lat, 
                        e.RefPoint_Lon, 
                        double.NaN, 
                        DateTime.Now));                        
                }

                InvokeSetTrackVisibility(uNavCore.uNav.RefPointTrackID, e.RefPoint_Type == REF_POINT_TYPE_Enum.USER_DEFINED);
            };
            uBase.TrackPointReceived += (o, e) =>
            {
                tManager.AddPoint(e.TrackID, e.Latitude_deg, e.Longitude_deg, e.Depth_m, DateTime.Now);
                InvokeAddPoint(e);

                if ((e.TrackID == uNavCore.uNav.TargetTrackID) || (e.TrackID == uNavCore.uNav.AUXGNSSTrackID))
                {
                    wpManager.UpdateLocation(e.Latitude_deg, e.Longitude_deg);

                    if (e.TrackID == uNavCore.uNav.TargetTrackID)
                        InvokeCheckAutocenterCenterPlot(e.Latitude_deg, e.Longitude_deg);
                }
            };
            uBase.IsWaitingLocalChangedEventHandler += (o, e) =>
            {
                UIHelpers.InvokeSetEnabledState(secondaryToolStrip, setTargetDepthBtn, uBase.PortDetected);
                UIHelpers.InvokeSetEnabledState(secondaryToolStrip, setwTmpBtn, uBase.PortDetected);
                UIHelpers.InvokeSetEnabledState(secondaryToolStrip, refPointCbx, uBase.PortDetected);                
            };
            uBase.StatHelperActiveChanged += (o, e) =>
            {
                if (uBase.StatHelperActive)
                    InvokeSetText(secondaryToolStrip, statStartStopBtn, string.Format("⏹ {0}", LocalisedStrings.MainForm_Stop));
                else
                    InvokeSetText(secondaryToolStrip, statStartStopBtn, string.Format("⏺ {0}", LocalisedStrings.MainForm_Start));

                InvokeSetCheckedState(secondaryToolStrip, statStartStopBtn, uBase.StatHelperActive);
            };

            #endregion

            #region uTimer

            uTimer = new PrecisionTimer();
            uTimer.Period = 1000;
            uTimer.Mode = Mode.Periodic;
            uTimer.Tick += (o, e) => InvokeSaveAutoscreenshot();

            #endregion           
        }


        #endregion

        #region Handlers

        #region UI

        #region mainToolStrip
        private void linkBtn_Click(object sender, EventArgs e)
        {
            if (uBase.IsActive)
                uBase.Stop();
            else
                uBase.Start();
        }

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            bool isSaved = false;

            using (SettingsEditor sEditor = new SettingsEditor())
            {
                sEditor.Text = string.Format("{0} {1} - Settings editor",
                    appicon, Application.ProductName);
                sEditor.Value = sProvider.Data;
                sEditor.SpecControlsEnalbed = sProvider.Data.SpecControlsEnabled;

                if (sEditor.ShowDialog() == DialogResult.OK)
                {
                    sProvider.Data = sEditor.Value;

                    try
                    {
                        sProvider.Save(settingsFileName);
                        isSaved = true;
                    }
                    catch (Exception ex)
                    {
                        ProcessException(ex, true);
                    }
                }
            }

            if (isSaved &&
                MessageBox.Show("Settings has been updated, restart application to apply new settings?",
                string.Format("{0} {1} - {2}",
                appicon, Application.ProductName, LocalisedStrings.MainForm_Question),
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                isRestart = true;
                Application.Restart();
            }
        }

        #region LOG

        private void logOpenCurrentBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(logger.FileName);
            }
            catch (Exception ex)
            {
                ProcessException(ex, true);
            }
        }

        private void logPlaybackBtn_Click(object sender, EventArgs e)
        {
            if (lPlayer.IsRunning)
            {
                if (MessageBox.Show("log is currently playing, abort?",
                    string.Format("{0} {1} - {2}",
                    appicon, Application.ProductName, LocalisedStrings.MainForm_Question),
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    lPlayer.RequestToStop();
            }
            else
            {
                using (OpenFileDialog oDialog = new OpenFileDialog())
                {
                    oDialog.Title = string.Format("{0} {1}",
                        appicon, "Select a log file to playback");
                    oDialog.DefaultExt = "log";
                    oDialog.Filter = "Log files (*.log)|*.log";

                    if (oDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        lPlayer.Playback(oDialog.FileName);

                        logPlaybackBtn.Text = string.Format("⏹ {0}", "Stop playback");
                        settingsBtn.Enabled = false;
                        linkBtn.Enabled = false;
                    }
                }
            }
        }

        private void logClearEmptyEntriesBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("All log files less than 2 kb will be deleted, Ok?",
                string.Format("{0} {1} - {2}",
                appicon,
                Application.ProductName, LocalisedStrings.MainForm_Question),
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.OK)
            {
                var fNum = RemoveEmptyEntries(logPath, logger.FileName, 2048);

                MessageBox.Show(string.Format("{0} {1}", fNum, "files was/were deleted"),
                    string.Format("{0} {1} - {2}",
                    appicon,
                    Application.ProductName, LocalisedStrings.MainForm_Information),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void logArchiveAllItemsBtn_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sDialog = new SaveFileDialog())
            {
                sDialog.Title = string.Format("{0} {1}",
                    appicon, "Select a file name to compress all log files to");
                sDialog.Filter = "Zip-archives (*.zip)|*.zip";
                sDialog.DefaultExt = "zip";
                sDialog.FileName = string.Format("LOG_Archive_{0}", StrUtils.GetYMDString());

                if (sDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ZipFile.CreateFromDirectory(logPath, sDialog.FileName);
                        StatusHintLinkUpdate(string.Format("{0} {1}",
                           "All log files comressed to", Path.GetFileName(sDialog.FileName)), sDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        ProcessException(ex, true);
                    }
                }
            }
        }

        private void logDeleteAllEntriesBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete all log files (action cannot be undone)?",
                                string.Format("{0} {1} - {2}",
                                appicon, Application.ProductName, LocalisedStrings.MainForm_Warning),

                                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {

                var dirNum = ClearAllEntries(logPath);

                MessageBox.Show(string.Format("{0} {1}",
                    dirNum, "entries was/were deleted"),
                    string.Format("{0} {1} - {2}",
                    appicon, Application.ProductName, LocalisedStrings.MainForm_Information),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void logDoThemAllBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Move all log files to an archive?",
                               string.Format("{0} {1} - {2}",
                                appicon, Application.ProductName, LocalisedStrings.MainForm_Warning),
                               MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                RemoveEmptyEntries(logPath, logFileName, 2048);

                bool archived = false;
                using (SaveFileDialog sDialog = new SaveFileDialog())
                {
                    sDialog.Title = string.Format("{0} {1}",
                        appicon, 
                        "Select a name of archive to compress all log files to");
                    sDialog.Filter = "Zip-archives (*.zip)|*.zip";
                    sDialog.DefaultExt = "zip";
                    sDialog.FileName = string.Format("LOG_Archive_{0}", StrUtils.GetYMDString());

                    if (sDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            ZipFile.CreateFromDirectory(logPath, sDialog.FileName);
                            StatusHintLinkUpdate(string.Format("{0} {1}",
                           "All log files moved to", Path.GetFileName(sDialog.FileName)), sDialog.FileName);

                            archived = true;
                        }
                        catch (Exception ex)
                        {
                            ProcessException(ex, true);
                        }
                    }
                }

                if (!archived)
                {
                    MessageBox.Show("Some errors occured moving log files to an archive. The archive was not created.",
                        string.Format("{0} {1} - {2}",
                        appicon, Application.ProductName, LocalisedStrings.MainForm_Error),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    ClearAllEntries(logPath);
                }
            }
        }

        #endregion

        #region UTILS

        private void tracksExportAsBtn_Click(object sender, EventArgs e)
        {
            bool saved = false;
            using (SaveFileDialog sDialog = new SaveFileDialog())
            {
                sDialog.Title = string.Format("{0} {1}", appicon, LocalisedStrings.MainForm_ExportingTracks);
                sDialog.Filter = "KML (*.kml)|*.kml|CSV (*.csv)|*.csv";
                sDialog.FileName = StrUtils.GetHMSString();

                if (sDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // KML
                        if (sDialog.FilterIndex == 1)
                        {
                            tManager.ExportToKML(sDialog.FileName);
                            saved = true;
                        }
                        // CSV
                        else if (sDialog.FilterIndex == 2)
                        {
                            tManager.ExportToCSV(sDialog.FileName);
                            saved = true;
                        }

                        StatusHintLinkUpdate(string.Format("{0} {1}",
                           LocalisedStrings.MainForm_AllTracksWereSavedTo, Path.GetFileName(sDialog.FileName)), sDialog.FileName);

                    }
                    catch (Exception ex)
                    {
                        ProcessException(ex, true);
                    }
                }
            }

            if (saved)
            {
                if (MessageBox.Show(string.Format("{0} {1}", LocalisedStrings.MainForm_TracksSuccessfullySaved, LocalisedStrings.MainForm_ClearAllTracksDataPrompt),
                    string.Format("{0} {1} - {2}", appicon, Application.ProductName, LocalisedStrings.MainForm_Question),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                    tManager.Clear();

            }
        }

        private void tracksClearAllBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(LocalisedStrings.MainForm_ClearAllTracksDataPrompt,
                string.Format("{0} {1} - {2}", appicon, Application.ProductName, LocalisedStrings.MainForm_Question),
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
                tManager.Clear();
        }

        #region Track utils

        private void utilsTrackUtilsSmoothMAVBtn_Click(object sender, EventArgs e)
        {
            using (NumDialog nDialog = new NumDialog())
            {
                nDialog.Text = LocalisedStrings.MainForm_MovingAverageSmoothing;
                nDialog.ValueCaption = LocalisedStrings.MainForm_WindowSize;
                nDialog.MaxValue = 64;
                nDialog.MinValue = 2;
                nDialog.Value = 4;
                nDialog.DecimalPlaces = 0;

                if (nDialog.ShowDialog() == DialogResult.OK)
                {
                    using (OpenFileDialog oDialog = new OpenFileDialog())
                    {
                        oDialog.Title = LocalisedStrings.MainForm_SelectATrackToFilter;
                        oDialog.Multiselect = false;
                        oDialog.Filter = "KML-files|*.kml";

                        if (oDialog.ShowDialog() == DialogResult.OK)
                        {
                            bool isLoaded = false;
                            KMLData kmlData = null;
                            try
                            {
                                kmlData = TinyKML.Read(oDialog.FileName);
                                isLoaded = true;
                            }
                            catch (Exception ex)
                            {
                                ProcessException(ex, true);
                            }

                            if (isLoaded)
                            {

                                TrackMovingAverageSmoother tFilter = new TrackMovingAverageSmoother(Convert.ToInt32(nDialog.Value), 50);

                                for (int i = 0; i < kmlData.Count; i++)
                                {
                                    if (kmlData[i].PlacemarkItem.Count > 1)
                                    {
                                        tFilter.Reset();
                                        for (int j = 0; j < kmlData[i].PlacemarkItem.Count; j++)
                                        {
                                            double lat_rad = Algorithms.Deg2Rad(kmlData[i].PlacemarkItem[j].Latitude);
                                            double lon_rad = Algorithms.Deg2Rad(kmlData[i].PlacemarkItem[j].Longitude);
                                            double dpt = kmlData[i].PlacemarkItem[j].Altitude;

                                            tFilter.Process(lat_rad, lon_rad, dpt, DateTime.Now, out lat_rad, out lon_rad, out _, out _);

                                            kmlData[i].PlacemarkItem[j].Latitude = Algorithms.Rad2Deg(lat_rad);
                                            kmlData[i].PlacemarkItem[j].Longitude = Algorithms.Rad2Deg(lon_rad);
                                        }
                                    }
                                }

                                using (SaveFileDialog sDialog = new SaveFileDialog())
                                {
                                    sDialog.Title = LocalisedStrings.MainForm_SelectFilenameToSaveFilteredTrack;
                                    sDialog.DefaultExt = "kml";
                                    sDialog.Filter = "KML files (*.kml)|*.kml";

                                    var fName = string.Format("FLT_{0}", Path.GetFileName(oDialog.FileName));
                                    var fPath = Path.GetDirectoryName(oDialog.FileName);

                                    sDialog.FileName = Path.Combine(fPath, fName);

                                    if (sDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                    {
                                        bool isSaved = false;
                                        try
                                        {
                                            TinyKML.Write(kmlData, sDialog.FileName);
                                            isSaved = true;
                                        }
                                        catch (Exception ex)
                                        {
                                            ProcessException(ex, true);
                                        }

                                        if (isSaved)
                                            MessageBox.Show(LocalisedStrings.MainForm_TracksSuccessfullySaved,
                                                string.Format("{0} {1} - {2}",
                                                appicon, Application.ProductName, LocalisedStrings.MainForm_Information),
                                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void utilsTrackUtilsMedianBtn_Click(object sender, EventArgs e)
        {
            using (NumDialog nDialog = new NumDialog())
            {
                nDialog.Text = LocalisedStrings.MainFrom_MedianSmoothing;
                nDialog.ValueCaption = LocalisedStrings.MainForm_WindowSize;
                nDialog.MaxValue = 21;
                nDialog.MinValue = 3;
                nDialog.Value = 5;
                nDialog.DecimalPlaces = 0;

                if (nDialog.ShowDialog() == DialogResult.OK)
                {
                    int wsize = Convert.ToInt32(nDialog.Value);
                    if (wsize % 2 == 0) wsize++;


                    using (OpenFileDialog oDialog = new OpenFileDialog())
                    {
                        oDialog.Title = LocalisedStrings.MainForm_SelectATrackToFilter;
                        oDialog.Multiselect = false;
                        oDialog.Filter = "KML-files|*.kml";

                        if (oDialog.ShowDialog() == DialogResult.OK)
                        {
                            bool isLoaded = false;
                            KMLData kmlData = null;
                            try
                            {
                                kmlData = TinyKML.Read(oDialog.FileName);
                                isLoaded = true;
                            }
                            catch (Exception ex)
                            {
                                ProcessException(ex, true);
                            }

                            if (isLoaded)
                            {

                                TrackMedianFilter medianFilter = new TrackMedianFilter(wsize);

                                for (int i = 0; i < kmlData.Count; i++)
                                {
                                    if (kmlData[i].PlacemarkItem.Count > 1)
                                    {
                                        medianFilter.Reset();
                                        for (int j = 0; j < kmlData[i].PlacemarkItem.Count; j++)
                                        {
                                            double lat_rad = Algorithms.Deg2Rad(kmlData[i].PlacemarkItem[j].Latitude);
                                            double lon_rad = Algorithms.Deg2Rad(kmlData[i].PlacemarkItem[j].Longitude);
                                            double dpt = kmlData[i].PlacemarkItem[j].Altitude;

                                            medianFilter.Process(lat_rad, lon_rad, dpt, DateTime.Now, out lat_rad, out lon_rad, out _, out _);

                                            kmlData[i].PlacemarkItem[j].Latitude = Algorithms.Rad2Deg(lat_rad);
                                            kmlData[i].PlacemarkItem[j].Longitude = Algorithms.Rad2Deg(lon_rad);
                                        }
                                    }
                                }

                                using (SaveFileDialog sDialog = new SaveFileDialog())
                                {
                                    sDialog.Title = LocalisedStrings.MainForm_SelectFilenameToSaveFilteredTrack;
                                    sDialog.DefaultExt = "kml";
                                    sDialog.Filter = "KML files (*.kml)|*.kml";

                                    var fName = string.Format("FLT_{0}", Path.GetFileName(oDialog.FileName));
                                    var fPath = Path.GetDirectoryName(oDialog.FileName);

                                    sDialog.FileName = Path.Combine(fPath, fName);

                                    if (sDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                    {
                                        bool isSaved = false;
                                        try
                                        {
                                            TinyKML.Write(kmlData, sDialog.FileName);
                                            isSaved = true;
                                        }
                                        catch (Exception ex)
                                        {
                                            ProcessException(ex, true);
                                        }

                                        if (isSaved)
                                            MessageBox.Show(LocalisedStrings.MainForm_TracksSuccessfullySaved, 
                                                string.Format("{0} {1} - {2}",
                                                appicon, Application.ProductName, LocalisedStrings.MainForm_Information), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        
        private void utilsTrackUtilsShiftByXYBtn_Click(object sender, EventArgs e)
        {
            using (Num2Dialog nDialog = new Num2Dialog())
            {
                nDialog.Text = LocalisedStrings.MainForm_TrackOffset;
                nDialog.Value1Caption = LocalisedStrings.MainForm_XOffset_Longitude_m;
                nDialog.Value1MaxValue = 999;
                nDialog.Value1MinValue = -999;
                nDialog.Value1 = 0;
                nDialog.Value1DecimalPlaces = 1;

                nDialog.Value2Caption = LocalisedStrings.MainForm_YOffset_Latitude_m;
                nDialog.Value2MaxValue = 999;
                nDialog.Value2MinValue = -999;
                nDialog.Value2 = 0;
                nDialog.Value2DecimalPlaces = 1;

                if (nDialog.ShowDialog() == DialogResult.OK)
                {
                    using (OpenFileDialog oDialog = new OpenFileDialog())
                    {
                        oDialog.Title = LocalisedStrings.MainForm_SelectATrackToFilter;
                        oDialog.Multiselect = false;
                        oDialog.Filter = "KML-files|*.kml";

                        if (oDialog.ShowDialog() == DialogResult.OK)
                        {
                            bool isLoaded = false;
                            KMLData kmlData = null;
                            try
                            {
                                kmlData = TinyKML.Read(oDialog.FileName);
                                isLoaded = true;
                            }
                            catch (Exception ex)
                            {
                                ProcessException(ex, true);
                            }

                            if (isLoaded)
                            {

                                TrackOffset tFilter = new TrackOffset(nDialog.Value1, nDialog.Value2);
                                

                                for (int i = 0; i < kmlData.Count; i++)
                                {
                                    if (kmlData[i].PlacemarkItem.Count > 1)
                                    {
                                        
                                        for (int j = 0; j < kmlData[i].PlacemarkItem.Count; j++)
                                        {
                                            double lat_rad = Algorithms.Deg2Rad(kmlData[i].PlacemarkItem[j].Latitude);
                                            double lon_rad = Algorithms.Deg2Rad(kmlData[i].PlacemarkItem[j].Longitude);
                                            double dpt = kmlData[i].PlacemarkItem[j].Altitude;

                                            tFilter.Process(lat_rad, lon_rad, dpt, DateTime.Now, out lat_rad, out lon_rad, out _, out _);

                                            kmlData[i].PlacemarkItem[j].Latitude = Algorithms.Rad2Deg(lat_rad);
                                            kmlData[i].PlacemarkItem[j].Longitude = Algorithms.Rad2Deg(lon_rad);
                                        }
                                    }
                                }

                                using (SaveFileDialog sDialog = new SaveFileDialog())
                                {
                                    sDialog.Title = LocalisedStrings.MainForm_SelectFilenameToSaveFilteredTrack;
                                    sDialog.DefaultExt = "kml";
                                    sDialog.Filter = "KML files (*.kml)|*.kml";

                                    var fName = string.Format("FLT_{0}", Path.GetFileName(oDialog.FileName));
                                    var fPath = Path.GetDirectoryName(oDialog.FileName);

                                    sDialog.FileName = Path.Combine(fPath, fName);

                                    if (sDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                    {
                                        bool isSaved = false;
                                        try
                                        {
                                            TinyKML.Write(kmlData, sDialog.FileName);
                                            isSaved = true;
                                        }
                                        catch (Exception ex)
                                        {
                                            ProcessException(ex, true);
                                        }

                                        if (isSaved)
                                            MessageBox.Show(LocalisedStrings.MainForm_TracksSuccessfullySaved,
                                               string.Format("{0} {1} - {2}",
                                               appicon, Application.ProductName, LocalisedStrings.MainForm_Information), 
                                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #endregion

        private void infoBtn_Click(object sender, EventArgs e)
        {
            using (AboutBox aDialog = new AboutBox())
            {
                aDialog.ApplyAssembly(Assembly.GetExecutingAssembly());
                aDialog.Weblink = "https://docs.unavlab.com";
                aDialog.StartPosition = FormStartPosition.CenterParent;
                aDialog.ShowDialog();
            }
        }


        #endregion

        #region secondaryToolStrip

        private void markCurrentLocationBtn_Click(object sender, EventArgs e)
        {
            uBase.MarkCurrentTargetLocation();
        }

        private void markedPointsVisibleBtn_Click(object sender, EventArgs e)
        {
            markedPointsVisible = !markedPointsVisible;
            logger.Write(uiAutomation.GetBoolPropertyStateLogString<MainForm>(this, nameof(markedPointsVisible)));
        }

        private void basePointsVisibleBtn_Click(object sender, EventArgs e)
        {
            basePointsVisible = !basePointsVisible;
            logger.Write(uiAutomation.GetBoolPropertyStateLogString<MainForm>(this, nameof(basePointsVisible)));
        }

        private void historyLogVisibleBtn_Click(object sender, EventArgs e)
        {
            historyVisible = !historyVisible;
            logger.Write(uiAutomation.GetBoolPropertyStateLogString<MainForm>(this, nameof(historyVisible)));
        }

        private void legendVisibleBtn_Click(object sender, EventArgs e)
        {
            legendVisible = !legendVisible;
            logger.Write(uiAutomation.GetBoolPropertyStateLogString<MainForm>(this, nameof(legendVisible)));
        }

        private void notesVisibleBtn_Click(object sender, EventArgs e)
        {
            notesVisible = !notesVisible;
            logger.Write(uiAutomation.GetBoolPropertyStateLogString<MainForm>(this, nameof(notesVisible)));
        }

        private void extraInfoVisibleBtn_Click(object sender, EventArgs e)
        {
            extraInfoVisible = !extraInfoVisible;
            logger.Write(uiAutomation.GetBoolPropertyStateLogString<MainForm>(this, nameof(extraInfoVisible)));
        }

        private void clearViewBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(LocalisedStrings.MainForm_ClearCurrentPlotPrompt,
                string.Format("{0} {1} - {2}", appicon, Application.ProductName, LocalisedStrings.MainForm_Question),
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                uPlot.Clear();
                uPlot.Invalidate();
            }
        }

        #region Statistics

        private void statStartStopBtn_Click(object sender, EventArgs e)
        {
            if (uBase.StatHelperActive)
                uBase.AccuracyEstimationStop();
            else
                uBase.AccuracyEstimationStart();
        }

        private void statResetBtn_Click(object sender, EventArgs e)
        {
            uBase.AccuracyEstimationDiscard();
        }

        #endregion

        private void refPointCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((!refPointTypeChangedByDevice) && (uBase != null))
            {
                bool isOk = true;

                if (refPointType == REF_POINT_TYPE_Enum.USER_DEFINED)
                {
                    using (SelectLocationDialog sDialog = new SelectLocationDialog())
                    {
                        sDialog.Text = LocalisedStrings.MainForm_SpecifyAPointToUseAsAReference;
                        sDialog.SetPoints(tManager.GetTrack2D(uNavCore.uNav.MarkedPointsTrackID));

                        var currentLocation = uBase.GetCurrentTargetLocation();

                        sDialog.Latitude = currentLocation.Latitude;
                        sDialog.Longitude = currentLocation.Longitude;

                        if (sDialog.ShowDialog() == DialogResult.OK)
                        {
                            refPointUserLat = sDialog.Latitude;
                            refPointUserLon = sDialog.Longitude;
                        }
                        else
                        {
                            isOk = false;
                        }
                    }
                }

                if (!isOk)
                    uBase.RefPointQuery();
                else
                {
                    if (refPointType == REF_POINT_TYPE_Enum.USER_DEFINED)
                        uBase.RefPointSetQuery(refPointType, refPointUserLat, refPointUserLon);
                    else
                        uBase.RefPointSetQuery(refPointType, double.NaN, double.NaN);
                }

            }
        }

        private void followTargetBtn_Click(object sender, EventArgs e)
        {
            followTarget = !followTarget;
            logger.Write(uiAutomation.GetPropertyStateLogString<MainForm>(this, nameof(followTarget)));
        }

        private void showMapTilesBtn_Click(object sender, EventArgs e)
        {
            showMapTiles = !showMapTiles;
            logger.Write(uiAutomation.GetPropertyStateLogString<MainForm>(this, nameof(showMapTiles)));
        }

        private void setTargetDepthBtn_Click(object sender, EventArgs e)
        {
            using (NumDialog nDialog = new NumDialog())
            {
                nDialog.Text = string.Format("{0} {1} - {2}",
                   appicon, Application.ProductName, LocalisedStrings.MainForm_OverrideTargetDepth);
                nDialog.DecimalPlaces = 1;
                nDialog.ValueCaption = LocalisedStrings.MainForm_TargetDepthM;
                nDialog.MaxValue = 1000;
                nDialog.MinValue = 0;
                nDialog.Value = 0;
                
                if (nDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        uBase.DepthAndTemperatureSetQuery(nDialog.Value, double.NaN);
                    }
                    catch (Exception ex)
                    {
                        ProcessException(ex, true);
                    }
                }
            }
        }

        private void setwTmpBtn_Click(object sender, EventArgs e)
        {
            using (NumDialog nDialog = new NumDialog())
            {
                nDialog.Text = nDialog.Text = string.Format("{0} {1} - {2}",
                   appicon, Application.ProductName, LocalisedStrings.MainForm_OverrideWaterTemperature);
                nDialog.DecimalPlaces = 1;
                nDialog.ValueCaption = string.Format("{0}, °C", LocalisedStrings.MainForm_WaterTemperature); ;
                nDialog.MaxValue = 46;
                nDialog.MinValue = -4;
                nDialog.Value = 17;

                if (nDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {                        
                        uBase.DepthAndTemperatureSetQuery(double.NaN, nDialog.Value);
                        wpManager.Temperature = nDialog.Value;
                    }
                    catch (Exception ex)
                    {
                        ProcessException(ex, true);
                    }
                }
            }
        }


        #endregion

        #region secondaryBottomToolStrip

        private void serialBypassBtn_Click(object sender, EventArgs e)
        {
            serialBypass = !serialBypass;            
            logger.Write(uiAutomation.GetBoolPropertyStateLogString<MainForm>(this, nameof(serialBypass)));

            if (serialBypass)
                uBase.SerialOutputInit(serialBypassPortName, BaudRate.baudRate9600);
            else
                uBase.SerialOutputDeInit();
         
            serialBypassPortCbx.Enabled = !serialBypass;
            serialBypassPortRefreshBtn.Enabled = !serialBypass;
        }        

        private void serialBypassPortRefreshBtn_Click(object sender, EventArgs e)
        {
            serialBypassBtn.Enabled = false;
            serialBypassPortCbx.Enabled = false;
            serialBypassPortCbx.Items.Clear();

            var portNames = uNavUtils.GetSerialPortNamesExcept(uBase.PortName); //SerialPort.GetPortNames();
            if (portNames.Length > 0)
            {
                serialBypassPortCbx.Items.AddRange(portNames);
                serialBypassPortCbx.SelectedIndex = 0;

                serialBypassBtn.Enabled = true;
                serialBypassPortCbx.Enabled = true;
            }
        }

        private void udpBypassBtn_Click(object sender, EventArgs e)
        {
            udpBypass = !udpBypass;
            logger.Write(uiAutomation.GetBoolPropertyStateLogString<MainForm>(this, nameof(udpBypass)));

            if (udpBypass)
                uBase.UDPOutputInit(udpBypassAddr, udpBypassPort);
            else
                uBase.UDPOutputDeInit();

            udpBypassAddrPortTxb.Enabled = !udpBypass;
        }

        private void udpBypassAddrPortTxb_TextChanged(object sender, EventArgs e)
        {
            udpBypassBtn.Enabled = !uNavUtils.IsValidIPandPort(udpBypassAddrPortTxb.Text, out string ipaddr, out ushort port);
        }

        private void zoomOutBtn_Click(object sender, EventArgs e)
        {
            uPlot.ZoomOut();
        }

        private void zoomInBtn_Click(object sender, EventArgs e)
        {
            uPlot.ZoomIn();
        }


        #endregion

        #region bottomToolStrip

        private void noteTxb_TextChanged(object sender, EventArgs e)
        {
            addnoteBtn.Enabled = !string.IsNullOrWhiteSpace(noteTxb.Text);
        }

        private void noteTxb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                addnoteBtn_Click(null, null);
        }

        private void addnoteBtn_Click(object sender, EventArgs e)
        {
            logger.Write(string.Format("NOTE: \"{0}\"", noteTxb.Text));
            uPlot.RightUpperTextSet(noteTxb.Text);
            noteTxb.Clear();
        }

        private void screenShotBtn_Click(object sender, EventArgs e)
        {
            var res = SaveFullScreenshot();
            var splits = res.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            if (splits.Length >= 2)
                StatusHintLinkUpdate(splits[0], splits[1]);
        }

        private void autoscreenShotBtn_Click(object sender, EventArgs e)
        {
            if (!autoscreenshotEnabled)
            {
                if (MessageBox.Show(
                    LocalisedStrings.MainForm_EnableAutomaticScreenShotEvery1SecondQuestion,
                    string.Format("{0} {1} - {2}", appicon, Application.ProductName, LocalisedStrings.MainForm_Question),
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    autoscreenshotEnabled = true;
                    StartAutoscreenShots();
                }
            }
            else
            {
                if (MessageBox.Show(
                    string.Format("{0} {1} {2} {3}",
                    LocalisedStrings.MainForm_StopAutomaticScreenshotEvery1SecondQuestion,
                    autoscreenshot_idx,
                    LocalisedStrings.MainForm_FramesAreSavedTo,
                    autoscreenshots_path),
                    string.Format("{0} {1} - {2}", appicon, Application.ProductName, LocalisedStrings.MainForm_Question),
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    autoscreenshotEnabled = false;
                    StopAutoscreenShots();
                }
            }
        }

        #endregion

        #region mainStatusStrip

        private void bottomLinkLbl_Click(object sender, EventArgs e)
        {
            try
            {
                if (bottomLinkLbl.Tag != null)
                {
                    var fpath = (string)bottomLinkLbl.Tag;
                    if (!string.IsNullOrEmpty(fpath))
                        Process.Start(fpath);
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex, true);
            }
        }

        #endregion

        #region mainForm

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tManager.Changed)
            {
                DialogResult dResult = DialogResult.Yes;
                while (tManager.Changed && (dResult == DialogResult.Yes))
                {
                    dResult = MessageBox.Show(LocalisedStrings.MainForm_TracksSavePrompt,
                    string.Format("{0} {1} - {2}", appicon, Application.ProductName, LocalisedStrings.MainForm_Question),
                    isRestart ? MessageBoxButtons.YesNo : MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (dResult == DialogResult.Yes)
                        tracksExportAsBtn_Click(tracksExportAsBtn, EventArgs.Empty);
                }

                if (dResult == DialogResult.Cancel)
                    e.Cancel = true;
            }
            else
            {
                e.Cancel = !isRestart &&
                    (MessageBox.Show(LocalisedStrings.MainForm_ApplicationClosePrompt,
                    string.Format("{0} {1} - {2}", appicon, Application.ProductName, LocalisedStrings.MainForm_Question),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes);
            }

            if (!e.Cancel)
            {
                if (uBase.IsActive)
                    uBase.Stop();

                if (autoscreenshotEnabled)
                {
                    autoscreenshotEnabled = false;
                    StopAutoscreenShots();
                }
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            logger.FinishLog();
            logger.Flush();

            #region UISettings

            usProvider.Data.WindowState = this.WindowState;

            if (this.WindowState == FormWindowState.Normal)
            {
                usProvider.Data.WindowSize = this.Size;
                usProvider.Data.WindowLocation = this.Location;
            }

            usProvider.Save(uiSettingsFileName);

            #endregion
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.P)
                {
                    screenShotBtn_Click(screenShotBtn, null);
                    e.SuppressKeyPress = true;
                }
                else if (e.KeyCode == Keys.L)
                {
                    if (linkBtn.Enabled)
                        linkBtn_Click(linkBtn, null);
                    e.SuppressKeyPress = true;
                }
                else if (e.KeyCode == Keys.H)
                {
                    logOpenCurrentBtn_Click(logOpenCurrentBtn, EventArgs.Empty);
                    e.SuppressKeyPress = true;
                }
                else if (e.KeyCode == Keys.Add)
                {
                    zoomInBtn_Click(zoomInBtn, null);
                    e.SuppressKeyPress = true;
                }
                else if (e.KeyCode == Keys.Subtract)
                {
                    zoomOutBtn_Click(zoomOutBtn, null);
                    e.SuppressKeyPress = true;
                }
                else if (e.KeyCode == Keys.O)
                {
                    if (settingsBtn.Enabled)
                        settingsBtn_Click(settingsBtn, null);
                    e.SuppressKeyPress = true;
                }
                else if (e.KeyCode == Keys.D)
                {
                    if (setTargetDepthBtn.Enabled)
                        setTargetDepthBtn_Click(setTargetDepthBtn, null);
                    e.SuppressKeyPress = true;
                }
                else if (e.KeyCode == Keys.T)
                {
                    if (setwTmpBtn.Enabled)
                        setwTmpBtn_Click(setwTmpBtn, null);
                    e.SuppressKeyPress = true;
                }
                else if (e.KeyCode == Keys.F)
                {
                    if (followTargetBtn.Enabled)
                        followTargetBtn_Click(followTargetBtn, null);
                    e.SuppressKeyPress = true;
                }
                else if (e.KeyCode == Keys.M)
                {
                    if (markCurrentLocationBtn.Enabled)
                        markCurrentLocationBtn_Click(markCurrentLocationBtn, null);
                    e.SuppressKeyPress = true;
                }
            }

            if (!e.SuppressKeyPress)
            {
                if (!noteTxb.Focused && !udpBypassAddrPortTxb.Focused)
                    noteTxb.Focus();
            }
        }


        #endregion

        #endregion

        #endregion

        #region Methods

        private void JustSaveFullScreenshot()
        {
            Bitmap target = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(target, this.DisplayRectangle);

            try
            {
                if (!Directory.Exists(snapshotsPath))
                    Directory.CreateDirectory(snapshotsPath);

                var fName = string.Format("{0}.{1}", StrUtils.GetHMSString(), ImageFormat.Png);
                var path = Path.Combine(snapshotsPath, fName);
                target.Save(path, ImageFormat.Png);
            }
            catch
            {
            }
        }

        private void SaveAutoscreenShot()
        {
            Bitmap target = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(target, this.DisplayRectangle);

            try
            {
                if (!Directory.Exists(autoscreenshots_path))
                    Directory.CreateDirectory(autoscreenshots_path);

                var fName = string.Format("{0:000000}.{1}", autoscreenshot_idx++, ImageFormat.Png);
                var path = Path.Combine(autoscreenshots_path, fName);
                target.Save(path, ImageFormat.Png);
            }
            catch { }
        }

        private string SaveFullScreenshot()
        {
            Bitmap target = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(target, this.DisplayRectangle);

            try
            {
                if (!Directory.Exists(snapshotsPath))
                    Directory.CreateDirectory(snapshotsPath);

                var fName = string.Format("{0}.{1}", StrUtils.GetHMSString(), ImageFormat.Png);
                var path = Path.Combine(snapshotsPath, fName);
                target.Save(path, ImageFormat.Png);

                return string.Format("{0} {1}|{2}", LocalisedStrings.MainForm_ScreenshotSavedTo, fName, path);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private void StatusHintLinkUpdate(string text, string linkText)
        {
            bottomLinkLbl.Text = text;
            bottomLinkLbl.Tag = linkText;
        }

        #region log utils

        private int RemoveEmptyEntries(string rootPath, string exclude, int minSize)
        {
            var dirs = Directory.GetDirectories(rootPath);
            int fNum = 0;
            foreach (var item in dirs)
            {
                var fNames = Directory.GetFiles(item);

                foreach (var fName in fNames)
                {
                    if (fName != exclude)
                    {
                        FileInfo fInfo = new FileInfo(fName);
                        if (fInfo.Length <= minSize)
                        {
                            try
                            {
                                File.Delete(fName);
                                fNum++;
                            }
                            catch { }
                        }
                    }
                }

                fNames = Directory.GetFiles(item);
                if (fNames.Length == 0)
                {
                    try
                    {
                        Directory.Delete(item);
                    }
                    catch { }
                }
            }

            return fNum;
        }

        private int ClearAllEntries(string rootPath)
        {
            var dirs = Directory.GetDirectories(rootPath);
            int dirNum = 0;
            foreach (var item in dirs)
            {
                try
                {
                    Directory.Delete(item, true);
                    dirNum++;
                }
                catch (Exception ex)
                {
                    ProcessException(ex, true);
                }
            }

            return dirNum;
        }

        #endregion

        #region UI Invokers

        private void InvokeSetRefPoint(REF_POINT_TYPE_Enum rpType)
        {
            if (secondaryToolStrip.InvokeRequired)
                secondaryToolStrip.Invoke((MethodInvoker)delegate
                {
                    refPointType = rpType;
                });
            else
            {
                refPointType = rpType;
            }
        }

        private void InvokeSetTrackVisibility(string tID, bool visible)
        {
            if (uPlot.InvokeRequired)
            {
                uPlot.Invoke((MethodInvoker)delegate { uPlot.SetTracksVisibility(tID, visible); });
            }
            else
            {
                uPlot.SetTracksVisibility(tID, visible);
            }
        }

        private void InvokeSaveFullScreenshot()
        {
            if (this.InvokeRequired)
                this.Invoke((MethodInvoker)delegate { SaveFullScreenshot(); });
            else
                SaveFullScreenshot();
        }
        private void InvokeSaveAutoscreenshot()
        {
            if (InvokeRequired)
                Invoke((MethodInvoker)delegate { SaveAutoscreenShot(); });
            else
                SaveAutoscreenShot();
        }

        private void CheckAutocenterPlot(double lat, double lon)
        {
            if (followTarget)
            {
                uPlot.SetCenter(lat, lon);
            }
        }

        private void InvokeUpdatePortStatusLbl(StatusStrip strip, ToolStripStatusLabel lbl, bool active, bool detected, string text)
        {
            Color backColor = Color.FromKnownColor(KnownColor.Control);
            Color foreColor = Color.FromKnownColor(KnownColor.ControlText);

            if (active)
            {
                foreColor = Color.Yellow;
                if (!detected)
                    backColor = Color.Red;
                else
                    backColor = Color.Green;
            }

            UIHelpers.InvokeSetText(strip, lbl, text, foreColor, backColor);
        }

        private void InvokeSwitchOutputPortUIEnabledState(bool enabled)
        {
            if (secondaryBottomToolStrip.InvokeRequired)
                secondaryBottomToolStrip.Invoke((MethodInvoker)delegate { SwitchOutputPortUIEnabledState(enabled); });
            else
                SwitchOutputPortUIEnabledState(enabled);
        }

        private void SwitchOutputPortUIEnabledState(bool enabled)
        {
            serialBypassPortCbx.Enabled = enabled;
            serialBypassBtn.Enabled = enabled;
            serialBypassPortRefreshBtn.Enabled = enabled;
        }

        private void InvokeSetLeftUpperText(string text)
        {
            if (uPlot.InvokeRequired)
                uPlot.Invoke((MethodInvoker)delegate
                {
                    uPlot.LeftUpperText = text;
                    uPlot.Invalidate();
                });
            else
            {
                uPlot.LeftUpperText = text;
                uPlot.Invalidate();
            }
        }

        private void InvokeSetNoteText(string text)
        {
            if (uPlot.InvokeRequired)
                uPlot.Invoke((MethodInvoker)delegate
                {
                    uPlot.RightUpperTextSet(text);
                    uPlot.Invalidate();
                });
            else
            {
                uPlot.RightUpperTextSet(text);
                uPlot.Invalidate();
            }
        }

        private void InvokePerformUIAction(string uiActionName)
        {
            if (this.InvokeRequired)
                this.Invoke((MethodInvoker)delegate { uiAutomation.PerformUIAction(uiActionName); });
            else
                uiAutomation.PerformUIAction(uiActionName);
        }

        private void InvokeSetCheckedState(ToolStrip strip, ToolStripMenuItem item, bool checkedState)
        {
            if (strip.InvokeRequired)
                strip.Invoke((MethodInvoker)delegate
                {
                    item.Checked = checkedState;
                });
            else
                item.Checked = checkedState;
        }

        private void InvokeSetText(ToolStrip strip, ToolStripMenuItem item, string text)
        {
            if (strip.InvokeRequired)
                strip.Invoke((MethodInvoker)delegate
                {
                    item.Text = text;
                });
            else
                item.Text = text;
        }

        private void InvokeAddPoint(TrackPointEventArgs e)
        {
            if (uPlot.InvokeRequired)
                uPlot.Invoke((MethodInvoker)delegate
                {
                    AddPoint(e);
                });
            else
                AddPoint(e);
        }

        private void AddPoint(TrackPointEventArgs e)
        {
            if (e.IsCourse)
                uPlot.AddPoint(e.TrackID, e.Latitude_deg, e.Longitude_deg, e.Course_deg);
            else
                uPlot.AddPoint(e.TrackID, e.Latitude_deg, e.Longitude_deg);

            uPlot.Invalidate();
        }


        private void InvokeCheckAutocenterCenterPlot(double lat, double lon)
        {
            if (InvokeRequired)
                Invoke((MethodInvoker)delegate { CheckAutocenterPlot(lat, lon); });
            else
                CheckAutocenterPlot(lat, lon);
        }
        private void InvokeAppendHistoryLine(string line)
        {
            if (uPlot == null)
                return;

            if (uPlot.InvokeRequired)
                uPlot.Invoke((MethodInvoker)delegate
                {
                    uPlot.AppendHistoryLine(line);
                    uPlot.Invalidate();
                });
            else
            {
                uPlot.AppendHistoryLine(line);
                uPlot.Invalidate();
            }
        }

        #endregion

        private void StartAutoscreenShots()
        {
            if (uTimer.IsRunning)
                uTimer.Stop();

            autoscreenshot_idx = 0;
            autoscreenshots_path = StrUtils.GetTimeDirTree(DateTime.Now, Application.ExecutablePath, "AUTOSNAPSHOTS", false);

            uTimer.Start();
        }

        private void StopAutoscreenShots()
        {
            uTimer.Stop();
        }

        private void ProcessException(Exception ex, bool isMsgBox)
        {
            logger.Write(ex);

            if (isMsgBox)
                MessageBox.Show(ex.Message,
                    string.Format("{0} {1} - {2}", appicon, Application.ProductName, LocalisedStrings.MainForm_Error),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void rwltGIBSettingsEditorBtn_Click(object sender, EventArgs e)
        {
            using (BuoyConfig bDialog = new BuoyConfig())
            {
                bDialog.ShowDialog();
            }
        }

        private void deviceInfoViewBtn_Click(object sender, EventArgs e)
        {
            using (TextViewDialog tDialog = new TextViewDialog())
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendFormat(
                    "System: {0}\r\n   S/N: {1}\r\n",
                    uBase.DeviceInfo, uBase.DeviceSerialNumber);

                tDialog.TextContent = sb.ToString();
                tDialog.Text = string.Format("{0} {1} - {2}", appicon, Application.ProductName, LocalisedStrings.MainForm_DeviceInformation);

                tDialog.EditorEnabled = false;
                tDialog.ShowDialog();
            }
        }

        #endregion        
    }
}
