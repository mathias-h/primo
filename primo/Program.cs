using System;
using System.Windows.Forms;
using Lib;

namespace primo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += (s, t) =>
            {
                var le = new LogException(t.Exception);
                le.Log();
                MessageBox.Show($"E{le.Id} {t.Exception.Message}", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            
        }
    }
}
