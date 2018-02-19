using System;

namespace Lib
{
    class Util
    {
        public static string NumberToString(int n, int max)
        {
            var pad = "";
            if (n >= max) throw new ArgumentOutOfRangeException("number too big");
            for (int i = 0; i < (max-1).ToString().Length-n.ToString().Length; i++)
            {
                pad += "0";
            }

            return pad + n;
        }
    }
}
