using System;
using System.Text;
using System.IO;

namespace Lib
{
    public class Saw
    {
        private static Settings Settings = Settings.Instance;
        private static readonly string ASC_PATH = Path.Combine(Settings.ASCFolder, "sav.ASC");
        private readonly Parts Parts;
        private readonly string BatchName;

        public Saw(string batchName, Parts parts)
        {
            Parts = parts;
            BatchName = batchName;
        }

        public void Start()
        {
            var i = 1;
            var file = new StringBuilder();
            file.Append("[General]" + Environment.NewLine +
                $"ProgName={BatchName}" + Environment.NewLine +
                $"ProgDes={Parts.Id}" + Environment.NewLine +
                $"[LenghtsW01q01]" + Environment.NewLine);
            
            foreach (var part in Parts.Parts_)
            {
                bool isFirst = true;

                foreach (var piece in part.Pieces)
                {
                    file.Append($"Len{Util.NumberToString(i, 3)}=0," +
                        $"{Parts.PieceCount - i + 1}," + 
                        $"{piece.Length/10}.0,1,0,0,0,0," + 
                        $"KTN{Util.NumberToString(piece.Ktn, 4)}{(isFirst ? " KSN" + Util.NumberToString(part.Ksn, 3) : "")}" +
                        Environment.NewLine);
                    i++;
                    isFirst = false;
                }
                
                if (part.EndPiece/10 >= Settings.EndPieceLength)
                {
                    file.Append($"Len{Util.NumberToString(i, 3)}=0," + 
                        $"{Parts.PieceCount - i + 1}," + 
                        $"{part.EndPiece/10}.0," + 
                        $"1,0,1,0,0,RESTSTYKKE" + 
                        Environment.NewLine);
                    i++;
                }
            }

            File.WriteAllText(ASC_PATH, file.ToString());
        }

        
    }
}
