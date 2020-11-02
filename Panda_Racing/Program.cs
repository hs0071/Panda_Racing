using System;
using System.Windows.Forms;

namespace Panda_Racing
{
    static class Program
    {
        // The main entry point for the application.
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RacingForm());
        }
    }
}
