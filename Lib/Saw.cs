using System;
using System.Text;
using System.IO;

namespace Lib
{
    public class Saw
    {
        private static Settings settings = Settings.Instance;
        private static string ASC_PATH = Path.Combine(settings.ASCFolder, "sav.ASC");
        Parts parts;
        string batchName;

        public Saw(string batchName, Parts parts)
        {
            this.parts = parts;
            this.batchName = batchName;
        }

        public void Start()
        {
            var i = 1;
            var file = new StringBuilder();
            file.Append("[General]" + Environment.NewLine +
                $"ProgName={batchName}" + Environment.NewLine +
                $"ProgDes={parts.Id}" + Environment.NewLine +
                $"[LenghtsW01q01]" + Environment.NewLine);
            
            foreach (var part in parts.Parts_)
            {
                bool isFirst = true;

                foreach (var piece in part.Pieces)
                {
                    file.Append($"Len{Util.NumberToString(i, 3)}=0," +
                        $"{parts.PieceCount - i + 1}," + 
                        $"{piece.Length/10}.0,1,0,0,0,0," + 
                        $"KTN{Util.NumberToString(piece.Ktn, 4)}{(isFirst ? " KSN" + Util.NumberToString(part.Ksn, 3) : "")}" +
                        Environment.NewLine);
                    i++;
                    isFirst = false;
                }
                
                if (part.EndPiece/10 >= settings.EndPieceLength)
                {
                    file.Append($"Len{Util.NumberToString(i, 3)}=0," + 
                        $"{parts.PieceCount - i + 1}," + 
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
