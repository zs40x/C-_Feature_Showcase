using System;
using System.Windows.Forms;

namespace _01_asynchronous_programming_with_async_and_await
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWnd());
        }
    }
}
