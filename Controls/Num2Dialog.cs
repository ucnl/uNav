using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UCNLUI;

namespace uNav.Controls
{
    public partial class Num2Dialog: Form
    {
        #region Properties

        public double Value1
        {
            get => Convert.ToDouble(num1Edit.Value);
            set => UIHelpers.SetNumericEditValue(num1Edit, value);
        }

        public string Value1Caption
        {
            get => num1Caption.Text;
            set => num1Caption.Text = value;
        }

        public int Value1DecimalPlaces
        {
            get => num1Edit.DecimalPlaces;
            set => num1Edit.DecimalPlaces = value;
        }

        public double Value1MaxValue
        {
            get => Convert.ToDouble(num1Edit.Maximum);
            set => num1Edit.Maximum = Convert.ToDecimal(value);
        }

        public double Value1MinValue
        {
            get => Convert.ToDouble(num1Edit.Minimum);
            set => num1Edit.Minimum = Convert.ToDecimal(value);
        }

        public double Value2
        {
            get => Convert.ToDouble(num2Edit.Value);
            set => UIHelpers.SetNumericEditValue(num2Edit, value);
        }

        public string Value2Caption
        {
            get => num2Caption.Text;
            set => num2Caption.Text = value;
        }

        public int Value2DecimalPlaces
        {
            get => num2Edit.DecimalPlaces;
            set => num2Edit.DecimalPlaces = value;
        }

        public double Value2MaxValue
        {
            get => Convert.ToDouble(num2Edit.Maximum);
            set => num2Edit.Maximum = Convert.ToDecimal(value);
        }

        public double Value2MinValue
        {
            get => Convert.ToDouble(num2Edit.Minimum);
            set => num2Edit.Minimum = Convert.ToDecimal(value);
        }

        #endregion

        #region Constructor

        public Num2Dialog()
        {
            InitializeComponent();
        }

        #endregion
    }
}
