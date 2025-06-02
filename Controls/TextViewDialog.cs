using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uNav.Controls
{
    public partial class TextViewDialog : Form
    {
        #region Properties

        public bool EditorEnabled
        {
            get => !txb.ReadOnly; 
            set => txb.ReadOnly = !value;
        }

        public string TextContent
        {
            get => txb.Text;
            set => txb.Text = value;
        }

        #endregion

        #region Constructor

        public TextViewDialog()
        {
            InitializeComponent();
        }

        #endregion

        #region Handlers

        private void copyBtn_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txb.Text);
        }

        #endregion
    }
}
