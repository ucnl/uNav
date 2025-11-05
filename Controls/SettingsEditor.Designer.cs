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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsEditor));
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
            this.rwlt_ModeLbl = new System.Windows.Forms.Label();
            this.rwlt_modeCbx = new System.Windows.Forms.ComboBox();
            this.rwltPingerDRatingLbl = new System.Windows.Forms.Label();
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
            resources.ApplyResources(this.cancelBtn, "cancelBtn");
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // okBtn
            // 
            resources.ApplyResources(this.okBtn, "okBtn");
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Name = "okBtn";
            this.okBtn.UseVisualStyleBackColor = true;
            // 
            // setDefaultsBtn
            // 
            resources.ApplyResources(this.setDefaultsBtn, "setDefaultsBtn");
            this.setDefaultsBtn.Name = "setDefaultsBtn";
            this.setDefaultsBtn.UseVisualStyleBackColor = true;
            this.setDefaultsBtn.Click += new System.EventHandler(this.setDefaultsBtn_Click);
            // 
            // mainTabControl
            // 
            resources.ApplyResources(this.mainTabControl, "mainTabControl");
            this.mainTabControl.Controls.Add(this.physicsTabPage);
            this.mainTabControl.Controls.Add(this.mainTabPage);
            this.mainTabControl.Controls.Add(this.extraTabPage);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            // 
            // physicsTabPage
            // 
            this.physicsTabPage.Controls.Add(this.physicsTable);
            resources.ApplyResources(this.physicsTabPage, "physicsTabPage");
            this.physicsTabPage.Name = "physicsTabPage";
            this.physicsTabPage.UseVisualStyleBackColor = true;
            // 
            // physicsTable
            // 
            resources.ApplyResources(this.physicsTable, "physicsTable");
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
            this.physicsTable.Name = "physicsTable";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // salinityEdit
            // 
            this.salinityEdit.DecimalPlaces = 1;
            resources.ApplyResources(this.salinityEdit, "salinityEdit");
            this.salinityEdit.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.salinityEdit.Name = "salinityEdit";
            // 
            // waterTemperatureEdit
            // 
            this.waterTemperatureEdit.DecimalPlaces = 1;
            resources.ApplyResources(this.waterTemperatureEdit, "waterTemperatureEdit");
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
            this.waterTemperatureEdit.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // speedOfSoundEdit
            // 
            this.speedOfSoundEdit.DecimalPlaces = 1;
            resources.ApplyResources(this.speedOfSoundEdit, "speedOfSoundEdit");
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
            this.speedOfSoundEdit.Value = new decimal(new int[] {
            1450,
            0,
            0,
            0});
            // 
            // isAutoSalinityChb
            // 
            resources.ApplyResources(this.isAutoSalinityChb, "isAutoSalinityChb");
            this.isAutoSalinityChb.Name = "isAutoSalinityChb";
            this.isAutoSalinityChb.UseVisualStyleBackColor = true;
            this.isAutoSalinityChb.CheckedChanged += new System.EventHandler(this.isAutoSalinityChb_CheckedChanged);
            // 
            // isAutoSoundSpeedChb
            // 
            resources.ApplyResources(this.isAutoSoundSpeedChb, "isAutoSoundSpeedChb");
            this.isAutoSoundSpeedChb.Name = "isAutoSoundSpeedChb";
            this.isAutoSoundSpeedChb.UseVisualStyleBackColor = true;
            this.isAutoSoundSpeedChb.CheckedChanged += new System.EventHandler(this.isAutoSoundSpeedChb_CheckedChanged);
            // 
            // salinityFromDbBtn
            // 
            resources.ApplyResources(this.salinityFromDbBtn, "salinityFromDbBtn");
            this.salinityFromDbBtn.Name = "salinityFromDbBtn";
            this.salinityFromDbBtn.TabStop = true;
            this.salinityFromDbBtn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.salinityFromDbBtn_LinkClicked);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // targetMaxSpeedEdit
            // 
            this.targetMaxSpeedEdit.DecimalPlaces = 1;
            resources.ApplyResources(this.targetMaxSpeedEdit, "targetMaxSpeedEdit");
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
            this.targetMaxSpeedEdit.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // sThresholdEdit
            // 
            resources.ApplyResources(this.sThresholdEdit, "sThresholdEdit");
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
            this.sThresholdEdit.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // sFIFOSizeEdit
            // 
            resources.ApplyResources(this.sFIFOSizeEdit, "sFIFOSizeEdit");
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
            this.sFIFOSizeEdit.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // dhThresholdEdit
            // 
            resources.ApplyResources(this.dhThresholdEdit, "dhThresholdEdit");
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
            this.dhThresholdEdit.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // dhFIFOSizeEdit
            // 
            resources.ApplyResources(this.dhFIFOSizeEdit, "dhFIFOSizeEdit");
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
            this.dhFIFOSizeEdit.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // cFIFOSizeEdit
            // 
            resources.ApplyResources(this.cFIFOSizeEdit, "cFIFOSizeEdit");
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
            this.cFIFOSizeEdit.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // mainTabPage
            // 
            this.mainTabPage.Controls.Add(this.tableLayoutPanel2);
            resources.ApplyResources(this.mainTabPage, "mainTabPage");
            this.mainTabPage.Name = "mainTabPage";
            this.mainTabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.outportBaudrateCbx, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.inportBaudrateCbx, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label14, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label15, 0, 1);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // outportBaudrateCbx
            // 
            resources.ApplyResources(this.outportBaudrateCbx, "outportBaudrateCbx");
            this.outportBaudrateCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.outportBaudrateCbx.FormattingEnabled = true;
            this.outportBaudrateCbx.Name = "outportBaudrateCbx";
            // 
            // inportBaudrateCbx
            // 
            resources.ApplyResources(this.inportBaudrateCbx, "inportBaudrateCbx");
            this.inportBaudrateCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inportBaudrateCbx.FormattingEnabled = true;
            this.inportBaudrateCbx.Name = "inportBaudrateCbx";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // extraTabPage
            // 
            this.extraTabPage.Controls.Add(this.tableLayoutPanel1);
            resources.ApplyResources(this.extraTabPage, "extraTabPage");
            this.extraTabPage.Name = "extraTabPage";
            this.extraTabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.numberOfPointsToShowEdit, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tileSizeEdit, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tileServersTxb, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.enableTileDonwloadChb, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.rwlt_ModeLbl, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.rwlt_modeCbx, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.rwltPingerDRatingLbl, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.rwlt_dratingCbx, 1, 7);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // numberOfPointsToShowEdit
            // 
            resources.ApplyResources(this.numberOfPointsToShowEdit, "numberOfPointsToShowEdit");
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
            this.numberOfPointsToShowEdit.Value = new decimal(new int[] {
            512,
            0,
            0,
            0});
            // 
            // tileSizeEdit
            // 
            resources.ApplyResources(this.tileSizeEdit, "tileSizeEdit");
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
            this.tileSizeEdit.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // tileServersTxb
            // 
            resources.ApplyResources(this.tileServersTxb, "tileServersTxb");
            this.tileServersTxb.Name = "tileServersTxb";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // enableTileDonwloadChb
            // 
            resources.ApplyResources(this.enableTileDonwloadChb, "enableTileDonwloadChb");
            this.enableTileDonwloadChb.Name = "enableTileDonwloadChb";
            this.enableTileDonwloadChb.UseVisualStyleBackColor = true;
            // 
            // rwlt_ModeLbl
            // 
            resources.ApplyResources(this.rwlt_ModeLbl, "rwlt_ModeLbl");
            this.rwlt_ModeLbl.Name = "rwlt_ModeLbl";
            // 
            // rwlt_modeCbx
            // 
            resources.ApplyResources(this.rwlt_modeCbx, "rwlt_modeCbx");
            this.rwlt_modeCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rwlt_modeCbx.FormattingEnabled = true;
            this.rwlt_modeCbx.Items.AddRange(new object[] {
            resources.GetString("rwlt_modeCbx.Items"),
            resources.GetString("rwlt_modeCbx.Items1")});
            this.rwlt_modeCbx.Name = "rwlt_modeCbx";
            // 
            // rwltPingerDRatingLbl
            // 
            resources.ApplyResources(this.rwltPingerDRatingLbl, "rwltPingerDRatingLbl");
            this.rwltPingerDRatingLbl.Name = "rwltPingerDRatingLbl";
            // 
            // rwlt_dratingCbx
            // 
            resources.ApplyResources(this.rwlt_dratingCbx, "rwlt_dratingCbx");
            this.rwlt_dratingCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rwlt_dratingCbx.FormattingEnabled = true;
            this.rwlt_dratingCbx.Items.AddRange(new object[] {
            resources.GetString("rwlt_dratingCbx.Items"),
            resources.GetString("rwlt_dratingCbx.Items1"),
            resources.GetString("rwlt_dratingCbx.Items2")});
            this.rwlt_dratingCbx.Name = "rwlt_dratingCbx";
            // 
            // SettingsEditor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.setDefaultsBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.cancelBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsEditor";
            this.ShowIcon = false;
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
        private System.Windows.Forms.Label rwlt_ModeLbl;
        private System.Windows.Forms.ComboBox rwlt_modeCbx;
        private System.Windows.Forms.Label rwltPingerDRatingLbl;
        private System.Windows.Forms.ComboBox rwlt_dratingCbx;
    }
}