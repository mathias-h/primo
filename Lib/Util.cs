namespace Lib
{
    class Util
    {
        public static string NumberToString(int n, int maxLength)
        {
            var pad = "";
            var length = n.ToString().Length;

            for (int i = 0; i < maxLength-length; i++)
            {
                pad += "0";
            }

            return pad + n;
        }
    }
}
