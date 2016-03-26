using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_asynchronous_programming_with_async_and_await
{
    public partial class MainWnd : Form
    {
        public MainWnd()
        {
            InitializeComponent();
        }
        
        private void btnDoWhoisLookup_Click(object sender, EventArgs e)
        {
            DoWhoisLookup();
        }


        private async void DoWhoisLookup()
        {
            EnableInput(false);

            try
            {
                var googleWhoisLookup = new WhoisLookup(tbHostToLookup.Text);

                // initiate HTTP request asynchronously
                Task<string> getWhoisInfoTask = googleWhoisLookup.GetWhoisInformationsAsync();

                // during the HTTP download we display this state in the GUI
                DisplayMessageWithBgColor("Loading....", Color.Orange);

                // now we wait untit the download is completed
                var result = await getWhoisInfoTask;

                // and display the content
                DisplayMessageWithBgColor(result.Replace("\n", Environment.NewLine), Color.LightGreen);
            }
            catch (Exception exception)
            {
                DisplayMessageWithBgColor(exception.Message, Color.LightCoral);
            }
            finally
            {
                EnableInput(true);
            }
        }

        private void EnableInput(bool enabled)
        {
            tbHostToLookup.Enabled = enabled;
            btnDoWhoisLookup.Enabled = enabled;
        }

        private void DisplayMessageWithBgColor(string message, Color bgColor)
        {
            tbMessage.Text = message;
            tbMessage.BackColor = bgColor;
        } 
    }
}
