using System;
using System.Linq;
using System.IO;

namespace Lib
{
    public class LogException
    {
        private static string LOG_PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Primo\error.log";

        public int Id { get; }
        private string[] data;
        private Exception exception;

        public LogException(Exception exception, params string[] data)
        {
            Id = GenerateId();
            this.exception = exception;
            this.data = data;
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
            var exceptionString = String.Join(Environment.NewLine, (exception.ToString()).Split('\n').Select(l => Id + "\t" + l).ToArray());
            var dataString = String.Join(Environment.NewLine, data.Select(l => Id + "\t" + l).ToArray());

            return exceptionString + Environment.NewLine + dataString;
        }

        public void Log()
        {
            File.AppendAllText(LOG_PATH, ToString());
        }
    }
}
