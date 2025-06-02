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
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Location = new System.Drawing.Point(537, 374);
            this.okBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(181, 55);
            this.okBtn.TabIndex = 3;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(320, 374);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(181, 55);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.Text = "CANCEL";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // num1Caption
            // 
            this.num1Caption.AutoSize = true;
            this.num1Caption.Location = new System.Drawing.Point(12, 9);
            this.num1Caption.Name = "num1Caption";
            this.num1Caption.Size = new System.Drawing.Size(78, 32);
            this.num1Caption.TabIndex = 5;
            this.num1Caption.Text = "label1";
            // 
            // num1Edit
            // 
            this.num1Edit.Location = new System.Drawing.Point(18, 44);
            this.num1Edit.Name = "num1Edit";
            this.num1Edit.Size = new System.Drawing.Size(272, 39);
            this.num1Edit.TabIndex = 6;
            // 
            // num2Edit
            // 
            this.num2Edit.Location = new System.Drawing.Point(18, 155);
            this.num2Edit.Name = "num2Edit";
            this.num2Edit.Size = new System.Drawing.Size(272, 39);
            this.num2Edit.TabIndex = 8;
            // 
            // num2Caption
            // 
            this.num2Caption.AutoSize = true;
            this.num2Caption.Location = new System.Drawing.Point(12, 120);
            this.num2Caption.Name = "num2Caption";
            this.num2Caption.Size = new System.Drawing.Size(78, 32);
            this.num2Caption.TabIndex = 7;
            this.num2Caption.Text = "label1";
            // 
            // Num2Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 448);
            this.Controls.Add(this.num2Edit);
            this.Controls.Add(this.num2Caption);
            this.Controls.Add(this.num1Edit);
            this.Controls.Add(this.num1Caption);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Num2Dialog";
            this.Text = "Num2Dialog";
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