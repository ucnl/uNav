namespace uNav
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.uPlot = new UCNLUI.Controls.uPlot.uGeoPlot();
            this.primaryToolStrip = new System.Windows.Forms.ToolStrip();
            this.linkBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.logBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.logOpenCurrentBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.logPlaybackBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
            this.logClearEmptyEntriesBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.logArchiveAllItemsBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator22 = new System.Windows.Forms.ToolStripSeparator();
            this.logDeleteAllEntriesBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.logDoThemAllBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.utilsBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator24 = new System.Windows.Forms.ToolStripSeparator();
            this.deviceInfoViewBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.infoBtn = new System.Windows.Forms.ToolStripButton();
            this.tracksBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.tracksExportAsBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator23 = new System.Windows.Forms.ToolStripSeparator();
            this.tracksClearAllBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.secondaryToolStrip = new System.Windows.Forms.ToolStrip();
            this.markCurrentLocationBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.markedPointsVisibleBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.basePointsVisibleBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.historyLogVisibleBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.legendVisibleBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.notesVisibleBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.extraInfoVisibleBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.clearViewBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.statisticsBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.statStartStopBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.statResetBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.refPointCbx = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.followTargetBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.showMapTilesBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.setTargetDepthBtn = new System.Windows.Forms.ToolStripButton();
            this.setwTmpBtn = new System.Windows.Forms.ToolStripButton();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.connectionStatusLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.bottomLinkLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.moonPhaseLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.bottomToolStrip = new System.Windows.Forms.ToolStrip();
            this.noteTxb = new System.Windows.Forms.ToolStripTextBox();
            this.addnoteBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.screenShotBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.autoscreenShotBtn = new System.Windows.Forms.ToolStripButton();
            this.secondaryBottomToolStrip = new System.Windows.Forms.ToolStrip();
            this.zoomInBtn = new System.Windows.Forms.ToolStripButton();
            this.zoomOutBtn = new System.Windows.Forms.ToolStripButton();
            this.serialBypassBtn = new System.Windows.Forms.ToolStripButton();
            this.serialBypassPortCbx = new System.Windows.Forms.ToolStripComboBox();
            this.serialBypassPortRefreshBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.udpBypassBtn = new System.Windows.Forms.ToolStripButton();
            this.udpBypassAddrPortTxb = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
            this.primaryToolStrip.SuspendLayout();
            this.secondaryToolStrip.SuspendLayout();
            this.mainStatusStrip.SuspendLayout();
            this.bottomToolStrip.SuspendLayout();
            this.secondaryBottomToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // uPlot
            // 
            resources.ApplyResources(this.uPlot, "uPlot");
            this.uPlot.BackColor = System.Drawing.Color.PowderBlue;
            this.uPlot.GridSizeVisible = false;
            this.uPlot.HistoryFont = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.uPlot.HistoryLinesNumber = 4;
            this.uPlot.HistoryTextColor = System.Drawing.Color.Green;
            this.uPlot.HistoryVisible = false;
            this.uPlot.LeftUpperText = null;
            this.uPlot.LeftUpperTextBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.uPlot.LeftUpperTextColor = System.Drawing.Color.Blue;
            this.uPlot.LeftUpperTextFont = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.uPlot.LeftUpperTextVisible = false;
            this.uPlot.LegendFont = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.uPlot.LegendVisible = false;
            this.uPlot.MeasuringLineBackgroundColor = System.Drawing.Color.White;
            this.uPlot.MeasuringLineBackTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.uPlot.MeasuringLineColor = System.Drawing.Color.Black;
            this.uPlot.MeasuringLineCrossSize = 15;
            this.uPlot.MeasuringLineFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.uPlot.MeasuringLineTextColor = System.Drawing.Color.Black;
            this.uPlot.MeasuringLineWidth = 1F;
            this.uPlot.Name = "uPlot";
            this.uPlot.RightUpperTextBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.uPlot.RightUpperTextColor = System.Drawing.Color.Brown;
            this.uPlot.RightUpperTextFont = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.uPlot.RightUpperTextVisible = false;
            this.uPlot.ScaleLineBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.uPlot.ScaleLineColor = System.Drawing.Color.Black;
            this.uPlot.ScaleLineFont = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.uPlot.ScaleLineTextColor = System.Drawing.Color.Black;
            this.uPlot.ScaleLineWidth = 2F;
            this.uPlot.ScaleTickSize = 10F;
            this.uPlot.ShowZoomLevel = false;
            this.uPlot.TileBorderColor = System.Drawing.Color.Gray;
            this.uPlot.TileBorderStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.uPlot.TileBordersVisible = true;
            this.uPlot.TileBorderWidth = 1F;
            this.uPlot.TilesEnabled = false;
            // 
            // primaryToolStrip
            // 
            resources.ApplyResources(this.primaryToolStrip, "primaryToolStrip");
            this.primaryToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.primaryToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.linkBtn,
            this.toolStripSeparator1,
            this.settingsBtn,
            this.toolStripSeparator2,
            this.logBtn,
            this.toolStripSeparator3,
            this.utilsBtn,
            this.toolStripSeparator4,
            this.infoBtn,
            this.tracksBtn});
            this.primaryToolStrip.Name = "primaryToolStrip";
            // 
            // linkBtn
            // 
            this.linkBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.linkBtn, "linkBtn");
            this.linkBtn.Name = "linkBtn";
            this.linkBtn.Click += new System.EventHandler(this.linkBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // settingsBtn
            // 
            this.settingsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.settingsBtn, "settingsBtn");
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Click += new System.EventHandler(this.settingsBtn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // logBtn
            // 
            this.logBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.logBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logOpenCurrentBtn,
            this.logPlaybackBtn,
            this.toolStripSeparator21,
            this.logClearEmptyEntriesBtn,
            this.logArchiveAllItemsBtn,
            this.toolStripSeparator22,
            this.logDeleteAllEntriesBtn,
            this.logDoThemAllBtn});
            resources.ApplyResources(this.logBtn, "logBtn");
            this.logBtn.Name = "logBtn";
            // 
            // logOpenCurrentBtn
            // 
            resources.ApplyResources(this.logOpenCurrentBtn, "logOpenCurrentBtn");
            this.logOpenCurrentBtn.Name = "logOpenCurrentBtn";
            this.logOpenCurrentBtn.Click += new System.EventHandler(this.logOpenCurrentBtn_Click);
            // 
            // logPlaybackBtn
            // 
            resources.ApplyResources(this.logPlaybackBtn, "logPlaybackBtn");
            this.logPlaybackBtn.Name = "logPlaybackBtn";
            this.logPlaybackBtn.Click += new System.EventHandler(this.logPlaybackBtn_Click);
            // 
            // toolStripSeparator21
            // 
            this.toolStripSeparator21.Name = "toolStripSeparator21";
            resources.ApplyResources(this.toolStripSeparator21, "toolStripSeparator21");
            // 
            // logClearEmptyEntriesBtn
            // 
            resources.ApplyResources(this.logClearEmptyEntriesBtn, "logClearEmptyEntriesBtn");
            this.logClearEmptyEntriesBtn.Name = "logClearEmptyEntriesBtn";
            this.logClearEmptyEntriesBtn.Click += new System.EventHandler(this.logClearEmptyEntriesBtn_Click);
            // 
            // logArchiveAllItemsBtn
            // 
            resources.ApplyResources(this.logArchiveAllItemsBtn, "logArchiveAllItemsBtn");
            this.logArchiveAllItemsBtn.Name = "logArchiveAllItemsBtn";
            this.logArchiveAllItemsBtn.Click += new System.EventHandler(this.logArchiveAllItemsBtn_Click);
            // 
            // toolStripSeparator22
            // 
            this.toolStripSeparator22.Name = "toolStripSeparator22";
            resources.ApplyResources(this.toolStripSeparator22, "toolStripSeparator22");
            // 
            // logDeleteAllEntriesBtn
            // 
            resources.ApplyResources(this.logDeleteAllEntriesBtn, "logDeleteAllEntriesBtn");
            this.logDeleteAllEntriesBtn.Name = "logDeleteAllEntriesBtn";
            this.logDeleteAllEntriesBtn.Click += new System.EventHandler(this.logDeleteAllEntriesBtn_Click);
            // 
            // logDoThemAllBtn
            // 
            resources.ApplyResources(this.logDoThemAllBtn, "logDoThemAllBtn");
            this.logDoThemAllBtn.Name = "logDoThemAllBtn";
            this.logDoThemAllBtn.Click += new System.EventHandler(this.logDoThemAllBtn_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // utilsBtn
            // 
            this.utilsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.utilsBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator24,
            this.deviceInfoViewBtn});
            resources.ApplyResources(this.utilsBtn, "utilsBtn");
            this.utilsBtn.Name = "utilsBtn";
            // 
            // toolStripSeparator24
            // 
            this.toolStripSeparator24.Name = "toolStripSeparator24";
            resources.ApplyResources(this.toolStripSeparator24, "toolStripSeparator24");
            // 
            // deviceInfoViewBtn
            // 
            resources.ApplyResources(this.deviceInfoViewBtn, "deviceInfoViewBtn");
            this.deviceInfoViewBtn.Name = "deviceInfoViewBtn";
            this.deviceInfoViewBtn.Click += new System.EventHandler(this.deviceInfoViewBtn_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // infoBtn
            // 
            this.infoBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.infoBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.infoBtn, "infoBtn");
            this.infoBtn.Name = "infoBtn";
            this.infoBtn.Click += new System.EventHandler(this.infoBtn_Click);
            // 
            // tracksBtn
            // 
            this.tracksBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tracksBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tracksExportAsBtn,
            this.toolStripSeparator23,
            this.tracksClearAllBtn});
            resources.ApplyResources(this.tracksBtn, "tracksBtn");
            this.tracksBtn.Name = "tracksBtn";
            // 
            // tracksExportAsBtn
            // 
            resources.ApplyResources(this.tracksExportAsBtn, "tracksExportAsBtn");
            this.tracksExportAsBtn.Name = "tracksExportAsBtn";
            this.tracksExportAsBtn.Click += new System.EventHandler(this.tracksExportAsBtn_Click);
            // 
            // toolStripSeparator23
            // 
            this.toolStripSeparator23.Name = "toolStripSeparator23";
            resources.ApplyResources(this.toolStripSeparator23, "toolStripSeparator23");
            // 
            // tracksClearAllBtn
            // 
            resources.ApplyResources(this.tracksClearAllBtn, "tracksClearAllBtn");
            this.tracksClearAllBtn.Name = "tracksClearAllBtn";
            this.tracksClearAllBtn.Click += new System.EventHandler(this.tracksClearAllBtn_Click);
            // 
            // secondaryToolStrip
            // 
            resources.ApplyResources(this.secondaryToolStrip, "secondaryToolStrip");
            this.secondaryToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.secondaryToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.markCurrentLocationBtn,
            this.toolStripSeparator5,
            this.markedPointsVisibleBtn,
            this.toolStripSeparator6,
            this.basePointsVisibleBtn,
            this.toolStripSeparator7,
            this.historyLogVisibleBtn,
            this.toolStripSeparator8,
            this.legendVisibleBtn,
            this.toolStripSeparator9,
            this.notesVisibleBtn,
            this.toolStripSeparator10,
            this.extraInfoVisibleBtn,
            this.toolStripSeparator11,
            this.clearViewBtn,
            this.toolStripSeparator12,
            this.statisticsBtn,
            this.toolStripSeparator13,
            this.toolStripLabel1,
            this.refPointCbx,
            this.toolStripSeparator14,
            this.followTargetBtn,
            this.toolStripSeparator15,
            this.showMapTilesBtn,
            this.toolStripSeparator16,
            this.setTargetDepthBtn,
            this.setwTmpBtn});
            this.secondaryToolStrip.Name = "secondaryToolStrip";
            // 
            // markCurrentLocationBtn
            // 
            this.markCurrentLocationBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.markCurrentLocationBtn, "markCurrentLocationBtn");
            this.markCurrentLocationBtn.Name = "markCurrentLocationBtn";
            this.markCurrentLocationBtn.Click += new System.EventHandler(this.markCurrentLocationBtn_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // markedPointsVisibleBtn
            // 
            this.markedPointsVisibleBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.markedPointsVisibleBtn, "markedPointsVisibleBtn");
            this.markedPointsVisibleBtn.Name = "markedPointsVisibleBtn";
            this.markedPointsVisibleBtn.Click += new System.EventHandler(this.markedPointsVisibleBtn_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            // 
            // basePointsVisibleBtn
            // 
            this.basePointsVisibleBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.basePointsVisibleBtn, "basePointsVisibleBtn");
            this.basePointsVisibleBtn.Name = "basePointsVisibleBtn";
            this.basePointsVisibleBtn.Click += new System.EventHandler(this.basePointsVisibleBtn_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
            // 
            // historyLogVisibleBtn
            // 
            this.historyLogVisibleBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.historyLogVisibleBtn, "historyLogVisibleBtn");
            this.historyLogVisibleBtn.Name = "historyLogVisibleBtn";
            this.historyLogVisibleBtn.Click += new System.EventHandler(this.historyLogVisibleBtn_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            resources.ApplyResources(this.toolStripSeparator8, "toolStripSeparator8");
            // 
            // legendVisibleBtn
            // 
            this.legendVisibleBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.legendVisibleBtn, "legendVisibleBtn");
            this.legendVisibleBtn.Name = "legendVisibleBtn";
            this.legendVisibleBtn.Click += new System.EventHandler(this.legendVisibleBtn_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            resources.ApplyResources(this.toolStripSeparator9, "toolStripSeparator9");
            // 
            // notesVisibleBtn
            // 
            this.notesVisibleBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.notesVisibleBtn, "notesVisibleBtn");
            this.notesVisibleBtn.Name = "notesVisibleBtn";
            this.notesVisibleBtn.Click += new System.EventHandler(this.notesVisibleBtn_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            resources.ApplyResources(this.toolStripSeparator10, "toolStripSeparator10");
            // 
            // extraInfoVisibleBtn
            // 
            this.extraInfoVisibleBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.extraInfoVisibleBtn, "extraInfoVisibleBtn");
            this.extraInfoVisibleBtn.Name = "extraInfoVisibleBtn";
            this.extraInfoVisibleBtn.Click += new System.EventHandler(this.extraInfoVisibleBtn_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            resources.ApplyResources(this.toolStripSeparator11, "toolStripSeparator11");
            // 
            // clearViewBtn
            // 
            this.clearViewBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.clearViewBtn, "clearViewBtn");
            this.clearViewBtn.Name = "clearViewBtn";
            this.clearViewBtn.Click += new System.EventHandler(this.clearViewBtn_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            resources.ApplyResources(this.toolStripSeparator12, "toolStripSeparator12");
            // 
            // statisticsBtn
            // 
            this.statisticsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statisticsBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statStartStopBtn,
            this.statResetBtn});
            resources.ApplyResources(this.statisticsBtn, "statisticsBtn");
            this.statisticsBtn.Name = "statisticsBtn";
            // 
            // statStartStopBtn
            // 
            this.statStartStopBtn.Name = "statStartStopBtn";
            resources.ApplyResources(this.statStartStopBtn, "statStartStopBtn");
            this.statStartStopBtn.Click += new System.EventHandler(this.statStartStopBtn_Click);
            // 
            // statResetBtn
            // 
            this.statResetBtn.Name = "statResetBtn";
            resources.ApplyResources(this.statResetBtn, "statResetBtn");
            this.statResetBtn.Click += new System.EventHandler(this.statResetBtn_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            resources.ApplyResources(this.toolStripSeparator13, "toolStripSeparator13");
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            resources.ApplyResources(this.toolStripLabel1, "toolStripLabel1");
            // 
            // refPointCbx
            // 
            this.refPointCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.refPointCbx, "refPointCbx");
            this.refPointCbx.Name = "refPointCbx";
            this.refPointCbx.SelectedIndexChanged += new System.EventHandler(this.refPointCbx_SelectedIndexChanged);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            resources.ApplyResources(this.toolStripSeparator14, "toolStripSeparator14");
            // 
            // followTargetBtn
            // 
            this.followTargetBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.followTargetBtn, "followTargetBtn");
            this.followTargetBtn.Name = "followTargetBtn";
            this.followTargetBtn.Click += new System.EventHandler(this.followTargetBtn_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            resources.ApplyResources(this.toolStripSeparator15, "toolStripSeparator15");
            // 
            // showMapTilesBtn
            // 
            resources.ApplyResources(this.showMapTilesBtn, "showMapTilesBtn");
            this.showMapTilesBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.showMapTilesBtn.Name = "showMapTilesBtn";
            this.showMapTilesBtn.Click += new System.EventHandler(this.showMapTilesBtn_Click);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            resources.ApplyResources(this.toolStripSeparator16, "toolStripSeparator16");
            // 
            // setTargetDepthBtn
            // 
            this.setTargetDepthBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.setTargetDepthBtn, "setTargetDepthBtn");
            this.setTargetDepthBtn.Name = "setTargetDepthBtn";
            this.setTargetDepthBtn.Click += new System.EventHandler(this.setTargetDepthBtn_Click);
            // 
            // setwTmpBtn
            // 
            this.setwTmpBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.setwTmpBtn, "setwTmpBtn");
            this.setwTmpBtn.Name = "setwTmpBtn";
            this.setwTmpBtn.Click += new System.EventHandler(this.setwTmpBtn_Click);
            // 
            // mainStatusStrip
            // 
            resources.ApplyResources(this.mainStatusStrip, "mainStatusStrip");
            this.mainStatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionStatusLbl,
            this.bottomLinkLbl,
            this.moonPhaseLbl,
            this.toolStripStatusLabel2});
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.ShowItemToolTips = true;
            // 
            // connectionStatusLbl
            // 
            this.connectionStatusLbl.Name = "connectionStatusLbl";
            resources.ApplyResources(this.connectionStatusLbl, "connectionStatusLbl");
            // 
            // bottomLinkLbl
            // 
            this.bottomLinkLbl.IsLink = true;
            this.bottomLinkLbl.Name = "bottomLinkLbl";
            resources.ApplyResources(this.bottomLinkLbl, "bottomLinkLbl");
            this.bottomLinkLbl.Spring = true;
            this.bottomLinkLbl.Click += new System.EventHandler(this.bottomLinkLbl_Click);
            // 
            // moonPhaseLbl
            // 
            this.moonPhaseLbl.AutoToolTip = true;
            this.moonPhaseLbl.Name = "moonPhaseLbl";
            resources.ApplyResources(this.moonPhaseLbl, "moonPhaseLbl");
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            resources.ApplyResources(this.toolStripStatusLabel2, "toolStripStatusLabel2");
            // 
            // bottomToolStrip
            // 
            resources.ApplyResources(this.bottomToolStrip, "bottomToolStrip");
            this.bottomToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bottomToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noteTxb,
            this.addnoteBtn,
            this.toolStripSeparator17,
            this.screenShotBtn,
            this.toolStripSeparator18,
            this.autoscreenShotBtn});
            this.bottomToolStrip.Name = "bottomToolStrip";
            // 
            // noteTxb
            // 
            resources.ApplyResources(this.noteTxb, "noteTxb");
            this.noteTxb.Name = "noteTxb";
            this.noteTxb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.noteTxb_KeyDown);
            this.noteTxb.TextChanged += new System.EventHandler(this.noteTxb_TextChanged);
            // 
            // addnoteBtn
            // 
            this.addnoteBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.addnoteBtn, "addnoteBtn");
            this.addnoteBtn.Name = "addnoteBtn";
            this.addnoteBtn.Click += new System.EventHandler(this.addnoteBtn_Click);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            resources.ApplyResources(this.toolStripSeparator17, "toolStripSeparator17");
            // 
            // screenShotBtn
            // 
            this.screenShotBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.screenShotBtn, "screenShotBtn");
            this.screenShotBtn.Name = "screenShotBtn";
            this.screenShotBtn.Click += new System.EventHandler(this.screenShotBtn_Click);
            // 
            // toolStripSeparator18
            // 
            this.toolStripSeparator18.Name = "toolStripSeparator18";
            resources.ApplyResources(this.toolStripSeparator18, "toolStripSeparator18");
            // 
            // autoscreenShotBtn
            // 
            this.autoscreenShotBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.autoscreenShotBtn, "autoscreenShotBtn");
            this.autoscreenShotBtn.Name = "autoscreenShotBtn";
            this.autoscreenShotBtn.Click += new System.EventHandler(this.autoscreenShotBtn_Click);
            // 
            // secondaryBottomToolStrip
            // 
            resources.ApplyResources(this.secondaryBottomToolStrip, "secondaryBottomToolStrip");
            this.secondaryBottomToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.secondaryBottomToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomInBtn,
            this.zoomOutBtn,
            this.serialBypassBtn,
            this.serialBypassPortCbx,
            this.serialBypassPortRefreshBtn,
            this.toolStripSeparator19,
            this.udpBypassBtn,
            this.udpBypassAddrPortTxb,
            this.toolStripSeparator20});
            this.secondaryBottomToolStrip.Name = "secondaryBottomToolStrip";
            // 
            // zoomInBtn
            // 
            this.zoomInBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.zoomInBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.zoomInBtn, "zoomInBtn");
            this.zoomInBtn.Name = "zoomInBtn";
            this.zoomInBtn.Click += new System.EventHandler(this.zoomInBtn_Click);
            // 
            // zoomOutBtn
            // 
            this.zoomOutBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.zoomOutBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.zoomOutBtn, "zoomOutBtn");
            this.zoomOutBtn.Name = "zoomOutBtn";
            this.zoomOutBtn.Click += new System.EventHandler(this.zoomOutBtn_Click);
            // 
            // serialBypassBtn
            // 
            this.serialBypassBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.serialBypassBtn, "serialBypassBtn");
            this.serialBypassBtn.Name = "serialBypassBtn";
            this.serialBypassBtn.Click += new System.EventHandler(this.serialBypassBtn_Click);
            // 
            // serialBypassPortCbx
            // 
            this.serialBypassPortCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.serialBypassPortCbx.Name = "serialBypassPortCbx";
            resources.ApplyResources(this.serialBypassPortCbx, "serialBypassPortCbx");
            // 
            // serialBypassPortRefreshBtn
            // 
            this.serialBypassPortRefreshBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.serialBypassPortRefreshBtn, "serialBypassPortRefreshBtn");
            this.serialBypassPortRefreshBtn.Name = "serialBypassPortRefreshBtn";
            this.serialBypassPortRefreshBtn.Click += new System.EventHandler(this.serialBypassPortRefreshBtn_Click);
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            resources.ApplyResources(this.toolStripSeparator19, "toolStripSeparator19");
            // 
            // udpBypassBtn
            // 
            this.udpBypassBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.udpBypassBtn, "udpBypassBtn");
            this.udpBypassBtn.Name = "udpBypassBtn";
            this.udpBypassBtn.Click += new System.EventHandler(this.udpBypassBtn_Click);
            // 
            // udpBypassAddrPortTxb
            // 
            this.udpBypassAddrPortTxb.AutoToolTip = true;
            resources.ApplyResources(this.udpBypassAddrPortTxb, "udpBypassAddrPortTxb");
            this.udpBypassAddrPortTxb.Name = "udpBypassAddrPortTxb";
            this.udpBypassAddrPortTxb.ShortcutsEnabled = false;
            this.udpBypassAddrPortTxb.TextChanged += new System.EventHandler(this.udpBypassAddrPortTxb_TextChanged);
            // 
            // toolStripSeparator20
            // 
            this.toolStripSeparator20.Name = "toolStripSeparator20";
            resources.ApplyResources(this.toolStripSeparator20, "toolStripSeparator20");
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.secondaryBottomToolStrip);
            this.Controls.Add(this.bottomToolStrip);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.secondaryToolStrip);
            this.Controls.Add(this.primaryToolStrip);
            this.Controls.Add(this.uPlot);
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.primaryToolStrip.ResumeLayout(false);
            this.primaryToolStrip.PerformLayout();
            this.secondaryToolStrip.ResumeLayout(false);
            this.secondaryToolStrip.PerformLayout();
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.bottomToolStrip.ResumeLayout(false);
            this.bottomToolStrip.PerformLayout();
            this.secondaryBottomToolStrip.ResumeLayout(false);
            this.secondaryBottomToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UCNLUI.Controls.uPlot.uGeoPlot uPlot;
        private System.Windows.Forms.ToolStrip primaryToolStrip;
        private System.Windows.Forms.ToolStrip secondaryToolStrip;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStrip bottomToolStrip;
        private System.Windows.Forms.ToolStripButton linkBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton settingsBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton logBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripDropDownButton utilsBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton infoBtn;
        private System.Windows.Forms.ToolStripButton markCurrentLocationBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton markedPointsVisibleBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton basePointsVisibleBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton historyLogVisibleBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton legendVisibleBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton notesVisibleBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton extraInfoVisibleBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripButton clearViewBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripDropDownButton statisticsBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox refPointCbx;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripButton followTargetBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripButton showMapTilesBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ToolStripStatusLabel connectionStatusLbl;
        private System.Windows.Forms.ToolStrip secondaryBottomToolStrip;
        private System.Windows.Forms.ToolStripTextBox noteTxb;
        private System.Windows.Forms.ToolStripButton addnoteBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        private System.Windows.Forms.ToolStripButton screenShotBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator18;
        private System.Windows.Forms.ToolStripButton autoscreenShotBtn;
        private System.Windows.Forms.ToolStripStatusLabel bottomLinkLbl;
        private System.Windows.Forms.ToolStripButton zoomInBtn;
        private System.Windows.Forms.ToolStripButton zoomOutBtn;
        private System.Windows.Forms.ToolStripButton serialBypassBtn;
        private System.Windows.Forms.ToolStripComboBox serialBypassPortCbx;
        private System.Windows.Forms.ToolStripButton serialBypassPortRefreshBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator19;
        private System.Windows.Forms.ToolStripButton udpBypassBtn;
        private System.Windows.Forms.ToolStripTextBox udpBypassAddrPortTxb;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator20;
        private System.Windows.Forms.ToolStripStatusLabel moonPhaseLbl;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem logOpenCurrentBtn;
        private System.Windows.Forms.ToolStripMenuItem logPlaybackBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator21;
        private System.Windows.Forms.ToolStripMenuItem logClearEmptyEntriesBtn;
        private System.Windows.Forms.ToolStripMenuItem logArchiveAllItemsBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator22;
        private System.Windows.Forms.ToolStripMenuItem logDeleteAllEntriesBtn;
        private System.Windows.Forms.ToolStripMenuItem logDoThemAllBtn;
        private System.Windows.Forms.ToolStripMenuItem statStartStopBtn;
        private System.Windows.Forms.ToolStripMenuItem statResetBtn;
        private System.Windows.Forms.ToolStripButton setTargetDepthBtn;
        private System.Windows.Forms.ToolStripButton setwTmpBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator24;
        private System.Windows.Forms.ToolStripMenuItem deviceInfoViewBtn;
        private System.Windows.Forms.ToolStripDropDownButton tracksBtn;
        private System.Windows.Forms.ToolStripMenuItem tracksExportAsBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator23;
        private System.Windows.Forms.ToolStripMenuItem tracksClearAllBtn;
    }
}

