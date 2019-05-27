using System;
using System.Linq;
using System.IO;

namespace Lib
{
    public class LogException
    {
        private static string LOG_PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Primo\error.log";

        public int Id { get; }
        private string[] Data;
        private Exception Exception;

        public LogException(Exception exception, params string[] data)
        {
            Id = GenerateId();
            Exception = exception;
            Data = data;
        }

        private int GenerateId()
        {
            string s = "";
            var r = new Random();

            for (int i = 0; i < 5; i++)
            {
                s += r.Next(0, 9);
            }

            return int.Parse(s);
        }

        public override string ToString() {
            var exceptionString = string.Join(Environment.NewLine, (Exception.ToString()).Split('\n').Select(l => Id + "\t" + l).ToArray());
            var dataString = string.Join(Environment.NewLine, Data.Select(l => Id + "\t" + l).ToArray());

            return exceptionString + Environment.NewLine + dataString;
        }

        public void Log()
        {
            File.AppendAllText(LOG_PATH, ToString());
        }
    }
}
