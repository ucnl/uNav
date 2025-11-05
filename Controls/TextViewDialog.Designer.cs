namespace uNav.Controls
{
    partial class TextViewDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextViewDialog));
            this.okBtn = new System.Windows.Forms.Button();
            this.txb = new System.Windows.Forms.RichTextBox();
            this.copyBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // okBtn
            // 
            resources.ApplyResources(this.okBtn, "okBtn");
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Name = "okBtn";
            this.okBtn.UseVisualStyleBackColor = true;
            // 
            // txb
            // 
            resources.ApplyResources(this.txb, "txb");
            this.txb.Name = "txb";
            this.txb.ReadOnly = true;
            // 
            // copyBtn
            // 
            resources.ApplyResources(this.copyBtn, "copyBtn");
            this.copyBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.copyBtn.Name = "copyBtn";
            this.copyBtn.UseVisualStyleBackColor = true;
            this.copyBtn.Click += new System.EventHandler(this.copyBtn_Click);
            // 
            // TextViewDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.copyBtn);
            this.Controls.Add(this.txb);
            this.Controls.Add(this.okBtn);
            this.Name = "TextViewDialog";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.RichTextBox txb;
        private System.Windows.Forms.Button copyBtn;
    }
}