using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Management;

namespace Lib
{
    public class Printer
    {
        private static string PRN_FILENAME = Path.GetTempPath() + @"\print.prn";
        private static string SPOOL_PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Primo\spool.exe";

        public static bool isOnline()
        {
            // Set management scope
            ManagementScope scope = new ManagementScope(@"\root\cimv2");
            scope.Connect();

            // Select Printers from WMI Object Collections
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Printer WHERE Name = 'EasyCoder PX4i (203 dpi) - DP'");
            var e = searcher.Get().GetEnumerator();
            if (!e.MoveNext())
            {
                throw new Exception("printeren er ikke installeret korrekt");
            }

            var printer = e.Current;

            if (!(bool)printer["Default"])
            {
                throw new Exception("printeren skal være valgt som standart");
            }

            return !(bool)printer["WorkOffline"];
        }

        public static void Print(List<Piece> pieces)
        {
            ////if (!isOnline())
            ////{
            ////    throw new Exception("printeren er ikke online");
            ////}

            var file = new StringBuilder();
            file.Append("LTS& ON" + Environment.NewLine);

            foreach (var piece in pieces)
            {
                file.Append(piece.Prn + Environment.NewLine);
            }

            File.WriteAllText(PRN_FILENAME, file.ToString());

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                CreateNoWindow = false,
                UseShellExecute = false,
                FileName = SPOOL_PATH,
                WindowStyle = ProcessWindowStyle.Hidden,
                Arguments = PRN_FILENAME
            };

            using (Process exeProcess = Process.Start(startInfo))
            {
                exeProcess.WaitForExit();
            }
        }
    }
}
