namespace uNav.Controls
{
    partial class Num2Dialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Num2Dialog));
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.num1Caption = new System.Windows.Forms.Label();
            this.num1Edit = new System.Windows.Forms.NumericUpDown();
            this.num2Edit = new System.Windows.Forms.NumericUpDown();
            this.num2Caption = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.num1Edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num2Edit)).BeginInit();
            this.SuspendLayout();
            // 
            // okBtn
            // 
            resources.ApplyResources(this.okBtn, "okBtn");
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Name = "okBtn";
            this.okBtn.UseVisualStyleBackColor = true;
            // 
            // cancelBtn
            // 
            resources.ApplyResources(this.cancelBtn, "cancelBtn");
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // num1Caption
            // 
            resources.ApplyResources(this.num1Caption, "num1Caption");
            this.num1Caption.Name = "num1Caption";
            // 
            // num1Edit
            // 
            resources.ApplyResources(this.num1Edit, "num1Edit");
            this.num1Edit.Name = "num1Edit";
            // 
            // num2Edit
            // 
            resources.ApplyResources(this.num2Edit, "num2Edit");
            this.num2Edit.Name = "num2Edit";
            // 
            // num2Caption
            // 
            resources.ApplyResources(this.num2Caption, "num2Caption");
            this.num2Caption.Name = "num2Caption";
            // 
            // Num2Dialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.num2Edit);
            this.Controls.Add(this.num2Caption);
            this.Controls.Add(this.num1Edit);
            this.Controls.Add(this.num1Caption);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Num2Dialog";
            ((System.ComponentModel.ISupportInitialize)(this.num1Edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num2Edit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label num1Caption;
        private System.Windows.Forms.NumericUpDown num1Edit;
        private System.Windows.Forms.NumericUpDown num2Edit;
        private System.Windows.Forms.Label num2Caption;
    }
}