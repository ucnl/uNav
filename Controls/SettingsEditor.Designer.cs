namespace uNav.Controls
{
    partial class SettingsEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.setDefaultsBtn = new System.Windows.Forms.Button();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.physicsTabPage = new System.Windows.Forms.TabPage();
            this.physicsTable = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.salinityEdit = new System.Windows.Forms.NumericUpDown();
            this.waterTemperatureEdit = new System.Windows.Forms.NumericUpDown();
            this.speedOfSoundEdit = new System.Windows.Forms.NumericUpDown();
            this.isAutoSalinityChb = new System.Windows.Forms.CheckBox();
            this.isAutoSoundSpeedChb = new System.Windows.Forms.CheckBox();
            this.salinityFromDbBtn = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.targetMaxSpeedEdit = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.sThresholdEdit = new System.Windows.Forms.NumericUpDown();
            this.sFIFOSizeEdit = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.dhThresholdEdit = new System.Windows.Forms.NumericUpDown();
            this.dhFIFOSizeEdit = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.cFIFOSizeEdit = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.mainTabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.outportBaudrateCbx = new System.Windows.Forms.ComboBox();
            this.inportBaudrateCbx = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.extraTabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.numberOfPointsToShowEdit = new System.Windows.Forms.NumericUpDown();
            this.tileSizeEdit = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tileServersTxb = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.enableTileDonwloadChb = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.rwlt_modeCbx = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.rwlt_dratingCbx = new System.Windows.Forms.ComboBox();
            this.mainTabControl.SuspendLayout();
            this.physicsTabPage.SuspendLayout();
            this.physicsTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salinityEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.waterTemperatureEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedOfSoundEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.targetMaxSpeedEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sThresholdEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sFIFOSizeEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dhThresholdEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dhFIFOSizeEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cFIFOSizeEdit)).BeginInit();
            this.mainTabPage.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.extraTabPage.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfPointsToShowEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileSizeEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(645, 496);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(125, 45);
            this.cancelBtn.TabIndex = 0;
            this.cancelBtn.Text = "CANCEL";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Location = new System.Drawing.Point(476, 496);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(125, 45);
            this.okBtn.TabIndex = 1;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            // 
            // setDefaultsBtn
            // 
            this.setDefaultsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.setDefaultsBtn.Location = new System.Drawing.Point(12, 496);
            this.setDefaultsBtn.Name = "setDefaultsBtn";
            this.setDefaultsBtn.Size = new System.Drawing.Size(182, 45);
            this.setDefaultsBtn.TabIndex = 2;
            this.setDefaultsBtn.Text = "SET DEFAULTS";
            this.setDefaultsBtn.UseVisualStyleBackColor = true;
            this.setDefaultsBtn.Click += new System.EventHandler(this.setDefaultsBtn_Click);
            // 
            // mainTabControl
            // 
            this.mainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTabControl.Controls.Add(this.physicsTabPage);
            this.mainTabControl.Controls.Add(this.mainTabPage);
            this.mainTabControl.Controls.Add(this.extraTabPage);
            this.mainTabControl.Location = new System.Drawing.Point(12, 12);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(758, 461);
            this.mainTabControl.TabIndex = 3;
            // 
            // physicsTabPage
            // 
            this.physicsTabPage.Controls.Add(this.physicsTable);
            this.physicsTabPage.Location = new System.Drawing.Point(4, 37);
            this.physicsTabPage.Name = "physicsTabPage";
            this.physicsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.physicsTabPage.Size = new System.Drawing.Size(750, 420);
            this.physicsTabPage.TabIndex = 1;
            this.physicsTabPage.Text = "🧪 PHYSICS";
            this.physicsTabPage.UseVisualStyleBackColor = true;
            // 
            // physicsTable
            // 
            this.physicsTable.ColumnCount = 4;
            this.physicsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.physicsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.physicsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.physicsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.physicsTable.Controls.Add(this.label1, 0, 0);
            this.physicsTable.Controls.Add(this.label2, 0, 1);
            this.physicsTable.Controls.Add(this.label3, 0, 2);
            this.physicsTable.Controls.Add(this.salinityEdit, 1, 0);
            this.physicsTable.Controls.Add(this.waterTemperatureEdit, 1, 1);
            this.physicsTable.Controls.Add(this.speedOfSoundEdit, 1, 2);
            this.physicsTable.Controls.Add(this.isAutoSalinityChb, 2, 0);
            this.physicsTable.Controls.Add(this.isAutoSoundSpeedChb, 2, 2);
            this.physicsTable.Controls.Add(this.salinityFromDbBtn, 3, 0);
            this.physicsTable.Controls.Add(this.label4, 0, 4);
            this.physicsTable.Controls.Add(this.targetMaxSpeedEdit, 1, 4);
            this.physicsTable.Controls.Add(this.label5, 0, 5);
            this.physicsTable.Controls.Add(this.label6, 0, 6);
            this.physicsTable.Controls.Add(this.sThresholdEdit, 1, 5);
            this.physicsTable.Controls.Add(this.sFIFOSizeEdit, 1, 6);
            this.physicsTable.Controls.Add(this.label7, 0, 7);
            this.physicsTable.Controls.Add(this.dhThresholdEdit, 1, 7);
            this.physicsTable.Controls.Add(this.dhFIFOSizeEdit, 1, 8);
            this.physicsTable.Controls.Add(this.label8, 0, 9);
            this.physicsTable.Controls.Add(this.cFIFOSizeEdit, 1, 9);
            this.physicsTable.Controls.Add(this.label13, 0, 8);
            this.physicsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.physicsTable.Location = new System.Drawing.Point(3, 3);
            this.physicsTable.Name = "physicsTable";
            this.physicsTable.RowCount = 11;
            this.physicsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.physicsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.physicsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.physicsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.physicsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.physicsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.physicsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.physicsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.physicsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.physicsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.physicsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.physicsTable.Size = new System.Drawing.Size(744, 414);
            this.physicsTable.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Salinity, PSU";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(260, 40);
            this.label2.TabIndex = 1;
            this.label2.Text = "Water temperature, °C";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(260, 40);
            this.label3.TabIndex = 2;
            this.label3.Text = "Speed of sound, m/s";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // salinityEdit
            // 
            this.salinityEdit.DecimalPlaces = 1;
            this.salinityEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.salinityEdit.Location = new System.Drawing.Point(269, 3);
            this.salinityEdit.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.salinityEdit.Name = "salinityEdit";
            this.salinityEdit.Size = new System.Drawing.Size(146, 34);
            this.salinityEdit.TabIndex = 1;
            // 
            // waterTemperatureEdit
            // 
            this.waterTemperatureEdit.DecimalPlaces = 1;
            this.waterTemperatureEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.waterTemperatureEdit.Location = new System.Drawing.Point(269, 43);
            this.waterTemperatureEdit.Maximum = new decimal(new int[] {
            46,
            0,
            0,
            0});
            this.waterTemperatureEdit.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            -2147483648});
            this.waterTemperatureEdit.Name = "waterTemperatureEdit";
            this.waterTemperatureEdit.Size = new System.Drawing.Size(146, 34);
            this.waterTemperatureEdit.TabIndex = 4;
            this.waterTemperatureEdit.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // speedOfSoundEdit
            // 
            this.speedOfSoundEdit.DecimalPlaces = 1;
            this.speedOfSoundEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.speedOfSoundEdit.Location = new System.Drawing.Point(269, 83);
            this.speedOfSoundEdit.Maximum = new decimal(new int[] {
            1600,
            0,
            0,
            0});
            this.speedOfSoundEdit.Minimum = new decimal(new int[] {
            1300,
            0,
            0,
            0});
            this.speedOfSoundEdit.Name = "speedOfSoundEdit";
            this.speedOfSoundEdit.Size = new System.Drawing.Size(146, 34);
            this.speedOfSoundEdit.TabIndex = 5;
            this.speedOfSoundEdit.Value = new decimal(new int[] {
            1450,
            0,
            0,
            0});
            // 
            // isAutoSalinityChb
            // 
            this.isAutoSalinityChb.AutoSize = true;
            this.isAutoSalinityChb.Location = new System.Drawing.Point(421, 3);
            this.isAutoSalinityChb.Name = "isAutoSalinityChb";
            this.isAutoSalinityChb.Size = new System.Drawing.Size(77, 32);
            this.isAutoSalinityChb.TabIndex = 2;
            this.isAutoSalinityChb.Text = "Auto";
            this.isAutoSalinityChb.UseVisualStyleBackColor = true;
            this.isAutoSalinityChb.CheckedChanged += new System.EventHandler(this.isAutoSalinityChb_CheckedChanged);
            // 
            // isAutoSoundSpeedChb
            // 
            this.isAutoSoundSpeedChb.AutoSize = true;
            this.isAutoSoundSpeedChb.Location = new System.Drawing.Point(421, 83);
            this.isAutoSoundSpeedChb.Name = "isAutoSoundSpeedChb";
            this.isAutoSoundSpeedChb.Size = new System.Drawing.Size(77, 32);
            this.isAutoSoundSpeedChb.TabIndex = 6;
            this.isAutoSoundSpeedChb.Text = "Auto";
            this.isAutoSoundSpeedChb.UseVisualStyleBackColor = true;
            this.isAutoSoundSpeedChb.CheckedChanged += new System.EventHandler(this.isAutoSoundSpeedChb_CheckedChanged);
            // 
            // salinityFromDbBtn
            // 
            this.salinityFromDbBtn.AutoSize = true;
            this.salinityFromDbBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.salinityFromDbBtn.Location = new System.Drawing.Point(504, 0);
            this.salinityFromDbBtn.Name = "salinityFromDbBtn";
            this.salinityFromDbBtn.Size = new System.Drawing.Size(39, 40);
            this.salinityFromDbBtn.TabIndex = 3;
            this.salinityFromDbBtn.TabStop = true;
            this.salinityFromDbBtn.Text = "🔎";
            this.salinityFromDbBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.salinityFromDbBtn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.salinityFromDbBtn_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(260, 40);
            this.label4.TabIndex = 9;
            this.label4.Text = "Target max speed, m/s";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // targetMaxSpeedEdit
            // 
            this.targetMaxSpeedEdit.DecimalPlaces = 1;
            this.targetMaxSpeedEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.targetMaxSpeedEdit.Location = new System.Drawing.Point(269, 143);
            this.targetMaxSpeedEdit.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.targetMaxSpeedEdit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.targetMaxSpeedEdit.Name = "targetMaxSpeedEdit";
            this.targetMaxSpeedEdit.Size = new System.Drawing.Size(146, 34);
            this.targetMaxSpeedEdit.TabIndex = 7;
            this.targetMaxSpeedEdit.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(260, 40);
            this.label5.TabIndex = 11;
            this.label5.Text = "S-filter range threshold, m";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 220);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(260, 40);
            this.label6.TabIndex = 12;
            this.label6.Text = "S-filter FIFO size";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sThresholdEdit
            // 
            this.sThresholdEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sThresholdEdit.Location = new System.Drawing.Point(269, 183);
            this.sThresholdEdit.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.sThresholdEdit.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sThresholdEdit.Name = "sThresholdEdit";
            this.sThresholdEdit.Size = new System.Drawing.Size(146, 34);
            this.sThresholdEdit.TabIndex = 8;
            this.sThresholdEdit.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // sFIFOSizeEdit
            // 
            this.sFIFOSizeEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sFIFOSizeEdit.Location = new System.Drawing.Point(269, 223);
            this.sFIFOSizeEdit.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.sFIFOSizeEdit.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.sFIFOSizeEdit.Name = "sFIFOSizeEdit";
            this.sFIFOSizeEdit.Size = new System.Drawing.Size(146, 34);
            this.sFIFOSizeEdit.TabIndex = 9;
            this.sFIFOSizeEdit.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 260);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(260, 40);
            this.label7.TabIndex = 15;
            this.label7.Text = "DH-filter range threshold, m";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dhThresholdEdit
            // 
            this.dhThresholdEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dhThresholdEdit.Location = new System.Drawing.Point(269, 263);
            this.dhThresholdEdit.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.dhThresholdEdit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dhThresholdEdit.Name = "dhThresholdEdit";
            this.dhThresholdEdit.Size = new System.Drawing.Size(146, 34);
            this.dhThresholdEdit.TabIndex = 10;
            this.dhThresholdEdit.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // dhFIFOSizeEdit
            // 
            this.dhFIFOSizeEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dhFIFOSizeEdit.Location = new System.Drawing.Point(269, 303);
            this.dhFIFOSizeEdit.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.dhFIFOSizeEdit.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.dhFIFOSizeEdit.Name = "dhFIFOSizeEdit";
            this.dhFIFOSizeEdit.Size = new System.Drawing.Size(146, 34);
            this.dhFIFOSizeEdit.TabIndex = 11;
            this.dhFIFOSizeEdit.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 340);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(260, 40);
            this.label8.TabIndex = 17;
            this.label8.Text = "Course estimation by, points";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cFIFOSizeEdit
            // 
            this.cFIFOSizeEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cFIFOSizeEdit.Location = new System.Drawing.Point(269, 343);
            this.cFIFOSizeEdit.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.cFIFOSizeEdit.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.cFIFOSizeEdit.Name = "cFIFOSizeEdit";
            this.cFIFOSizeEdit.Size = new System.Drawing.Size(146, 34);
            this.cFIFOSizeEdit.TabIndex = 12;
            this.cFIFOSizeEdit.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Location = new System.Drawing.Point(3, 300);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(260, 40);
            this.label13.TabIndex = 20;
            this.label13.Text = "DH-filter FIFO size";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mainTabPage
            // 
            this.mainTabPage.Controls.Add(this.tableLayoutPanel2);
            this.mainTabPage.Location = new System.Drawing.Point(4, 37);
            this.mainTabPage.Name = "mainTabPage";
            this.mainTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.mainTabPage.Size = new System.Drawing.Size(750, 420);
            this.mainTabPage.TabIndex = 0;
            this.mainTabPage.Text = "❗ CONNECTION";
            this.mainTabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.outportBaudrateCbx, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.inportBaudrateCbx, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label14, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label15, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(744, 414);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // outportBaudrateCbx
            // 
            this.outportBaudrateCbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outportBaudrateCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.outportBaudrateCbx.FormattingEnabled = true;
            this.outportBaudrateCbx.Location = new System.Drawing.Point(261, 45);
            this.outportBaudrateCbx.Name = "outportBaudrateCbx";
            this.outportBaudrateCbx.Size = new System.Drawing.Size(242, 36);
            this.outportBaudrateCbx.TabIndex = 1;
            // 
            // inportBaudrateCbx
            // 
            this.inportBaudrateCbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inportBaudrateCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inportBaudrateCbx.FormattingEnabled = true;
            this.inportBaudrateCbx.Location = new System.Drawing.Point(261, 3);
            this.inportBaudrateCbx.Name = "inportBaudrateCbx";
            this.inportBaudrateCbx.Size = new System.Drawing.Size(242, 36);
            this.inportBaudrateCbx.TabIndex = 0;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Location = new System.Drawing.Point(3, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(252, 42);
            this.label14.TabIndex = 2;
            this.label14.Text = "Input port baudrate";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Location = new System.Drawing.Point(3, 42);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(252, 42);
            this.label15.TabIndex = 3;
            this.label15.Text = "Serial bypass port baudrate";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // extraTabPage
            // 
            this.extraTabPage.Controls.Add(this.tableLayoutPanel1);
            this.extraTabPage.Location = new System.Drawing.Point(4, 37);
            this.extraTabPage.Name = "extraTabPage";
            this.extraTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.extraTabPage.Size = new System.Drawing.Size(750, 420);
            this.extraTabPage.TabIndex = 2;
            this.extraTabPage.Text = "🛸 EXTRA";
            this.extraTabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.numberOfPointsToShowEdit, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tileSizeEdit, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tileServersTxb, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.enableTileDonwloadChb, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label16, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.rwlt_modeCbx, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label17, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.rwlt_dratingCbx, 1, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(744, 414);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label9.Location = new System.Drawing.Point(3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(289, 40);
            this.label9.TabIndex = 0;
            this.label9.Text = "Number of track points to show";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numberOfPointsToShowEdit
            // 
            this.numberOfPointsToShowEdit.Dock = System.Windows.Forms.DockStyle.Left;
            this.numberOfPointsToShowEdit.Location = new System.Drawing.Point(298, 3);
            this.numberOfPointsToShowEdit.Maximum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.numberOfPointsToShowEdit.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numberOfPointsToShowEdit.Name = "numberOfPointsToShowEdit";
            this.numberOfPointsToShowEdit.Size = new System.Drawing.Size(120, 34);
            this.numberOfPointsToShowEdit.TabIndex = 1;
            this.numberOfPointsToShowEdit.Value = new decimal(new int[] {
            512,
            0,
            0,
            0});
            // 
            // tileSizeEdit
            // 
            this.tileSizeEdit.Dock = System.Windows.Forms.DockStyle.Left;
            this.tileSizeEdit.Enabled = false;
            this.tileSizeEdit.Location = new System.Drawing.Point(298, 56);
            this.tileSizeEdit.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.tileSizeEdit.Minimum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.tileSizeEdit.Name = "tileSizeEdit";
            this.tileSizeEdit.Size = new System.Drawing.Size(120, 34);
            this.tileSizeEdit.TabIndex = 2;
            this.tileSizeEdit.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label10.Location = new System.Drawing.Point(3, 53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(289, 40);
            this.label10.TabIndex = 2;
            this.label10.Text = "Tile size, px";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(3, 93);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(289, 178);
            this.label11.TabIndex = 4;
            this.label11.Text = "Tile servers";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tileServersTxb
            // 
            this.tileServersTxb.Dock = System.Windows.Forms.DockStyle.Top;
            this.tileServersTxb.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tileServersTxb.Location = new System.Drawing.Point(298, 96);
            this.tileServersTxb.Multiline = true;
            this.tileServersTxb.Name = "tileServersTxb";
            this.tileServersTxb.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tileServersTxb.Size = new System.Drawing.Size(443, 172);
            this.tileServersTxb.TabIndex = 3;
            this.tileServersTxb.Text = "https://a.tile.openstreetmap.org\r\nhttps://b.tile.openstreetmap.org\r\nhttps://c.til" +
    "e.openstreetmap.org";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(3, 271);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(289, 28);
            this.label12.TabIndex = 6;
            this.label12.Text = "Enable tile download";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // enableTileDonwloadChb
            // 
            this.enableTileDonwloadChb.AutoSize = true;
            this.enableTileDonwloadChb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.enableTileDonwloadChb.Location = new System.Drawing.Point(298, 274);
            this.enableTileDonwloadChb.Name = "enableTileDonwloadChb";
            this.enableTileDonwloadChb.Size = new System.Drawing.Size(443, 22);
            this.enableTileDonwloadChb.TabIndex = 4;
            this.enableTileDonwloadChb.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Location = new System.Drawing.Point(3, 299);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(289, 42);
            this.label16.TabIndex = 7;
            this.label16.Text = "RWLT Mode⚠";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rwlt_modeCbx
            // 
            this.rwlt_modeCbx.Dock = System.Windows.Forms.DockStyle.Left;
            this.rwlt_modeCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rwlt_modeCbx.FormattingEnabled = true;
            this.rwlt_modeCbx.Items.AddRange(new object[] {
            "0",
            "1"});
            this.rwlt_modeCbx.Location = new System.Drawing.Point(298, 302);
            this.rwlt_modeCbx.Name = "rwlt_modeCbx";
            this.rwlt_modeCbx.Size = new System.Drawing.Size(121, 36);
            this.rwlt_modeCbx.TabIndex = 8;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Location = new System.Drawing.Point(3, 341);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(289, 42);
            this.label17.TabIndex = 9;
            this.label17.Text = "RWLT Pinger depth rating⚠";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rwlt_dratingCbx
            // 
            this.rwlt_dratingCbx.Dock = System.Windows.Forms.DockStyle.Left;
            this.rwlt_dratingCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rwlt_dratingCbx.FormattingEnabled = true;
            this.rwlt_dratingCbx.Items.AddRange(new object[] {
            "0",
            "1",
            "2"});
            this.rwlt_dratingCbx.Location = new System.Drawing.Point(298, 344);
            this.rwlt_dratingCbx.Name = "rwlt_dratingCbx";
            this.rwlt_dratingCbx.Size = new System.Drawing.Size(121, 36);
            this.rwlt_dratingCbx.TabIndex = 10;
            // 
            // SettingsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.setDefaultsBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.cancelBtn);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "SettingsEditor";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SettingsEditor";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SettingsEditor_KeyDown);
            this.mainTabControl.ResumeLayout(false);
            this.physicsTabPage.ResumeLayout(false);
            this.physicsTable.ResumeLayout(false);
            this.physicsTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salinityEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.waterTemperatureEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedOfSoundEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.targetMaxSpeedEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sThresholdEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sFIFOSizeEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dhThresholdEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dhFIFOSizeEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cFIFOSizeEdit)).EndInit();
            this.mainTabPage.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.extraTabPage.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfPointsToShowEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileSizeEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button setDefaultsBtn;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage mainTabPage;
        private System.Windows.Forms.TabPage physicsTabPage;
        private System.Windows.Forms.ComboBox outportBaudrateCbx;
        private System.Windows.Forms.ComboBox inportBaudrateCbx;
        private System.Windows.Forms.TabPage extraTabPage;
        private System.Windows.Forms.TableLayoutPanel physicsTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown salinityEdit;
        private System.Windows.Forms.NumericUpDown waterTemperatureEdit;
        private System.Windows.Forms.NumericUpDown speedOfSoundEdit;
        private System.Windows.Forms.CheckBox isAutoSalinityChb;
        private System.Windows.Forms.CheckBox isAutoSoundSpeedChb;
        private System.Windows.Forms.LinkLabel salinityFromDbBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown targetMaxSpeedEdit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown sThresholdEdit;
        private System.Windows.Forms.NumericUpDown sFIFOSizeEdit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown dhThresholdEdit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown dhFIFOSizeEdit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numberOfPointsToShowEdit;
        private System.Windows.Forms.NumericUpDown tileSizeEdit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tileServersTxb;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox enableTileDonwloadChb;
        private System.Windows.Forms.NumericUpDown cFIFOSizeEdit;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox rwlt_modeCbx;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox rwlt_dratingCbx;
    }
}