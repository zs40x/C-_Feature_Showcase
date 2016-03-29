using System;
using System.Collections.Generic;
using System.Windows.Forms;
using _02_autoprops.Logic.Data;
using _02_autoprops.Logic.MoneyCalculator;
using _02_autoprops.Properties;

namespace _02_autoprops
{
    public partial class MainWnd : Form
    {
        private readonly List<string> _allowedOperator = new List<string>() {"+","-","*","/"};
        private readonly MoneyCalculator _moneyCalc = new MoneyCalculator(Currency.EUR);

        public MainWnd()
        {
            InitializeComponent();

            _moneyCalc.TotalChanged += _moneyCalc_TotalChanged;
        }

        private void MainWnd_Shown(object sender, EventArgs e)
        {
            tbMoneyTotal.Text = _moneyCalc.Total.ToString();
        }

        private void tbMoneyIn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Calculate();
        }


        private void Calculate()
        {
            if (!_allowedOperator.Contains(tbOperator.Text))
            {
                MessageBox.Show(Resources.MainWnd_Calculate_Invalid_Operator, Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            
            _moneyCalc.Calculate(tbMoneyIn.Text, tbOperator.Text);
        }

        private void _moneyCalc_TotalChanged(object sender, TotalChangedEventArgs e)
            => tbMoneyTotal.Text = _moneyCalc.Total.ToString();
    }
}
