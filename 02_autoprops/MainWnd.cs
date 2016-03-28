using System;
using System.Windows.Forms;
using _02_autoprops.Logic.Data;
using _02_autoprops.Logic.MoneyCounter;

namespace _02_autoprops
{
    public partial class MainWnd : Form
    {
        private readonly MoneyCounter _moneyCounter = new MoneyCounter(Currency.EUR);

        public MainWnd()
        {
            InitializeComponent();
        }

        private void MainWnd_Shown(object sender, EventArgs e)
        {
            tbMoneyTotal.Text = _moneyCounter.Total.ToString();

            guiUpdateTimer.Start();
        }

        private void btnAdd_Click(object sender, EventArgs e) 
            => Count();

        private void tbMoneyIn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Count();
        }


        private void Count()
            => _moneyCounter.Count(tbMoneyIn.Text);

        private void guiUpdateTimer_Tick(object sender, EventArgs e)
            => tbMoneyTotal.Text = _moneyCounter.Total.ToString();
    }
}
