using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Lib
{
    public class Cnc
    {
        private static Settings settings = Settings.Instance;
        private static string GRP_PATH = Path.Combine(settings.GRPFolder, "IMA.GRP");
        List<Piece> pieces;
        int id;

        public Cnc(int id, List<Piece> pieces)
        {
            this.id = id;
            this.pieces = pieces;
        }
        public void Start(bool isBig)
        {
            foreach (var piece in pieces)
            {
                GenerateFMC(isBig, piece);
            }

            GenerateGRP(isBig);
        }
    
        public void GenerateGRP(bool isBig)
        {
            var data = "";
            
            foreach (var piece in pieces)
            {
                var srcPath = "C:\\IMAWOP\\" + (isBig ? "SRC1\\" : "M1\\");
                var fmcName = GetFMCName(isBig, piece);

                data += $"1,{fmcName}.FMC,{srcPath}{fmcName}.SRC,/P=1" + Environment.NewLine;
            }

            File.WriteAllText(GRP_PATH, data);
        }

        public void GenerateFMC(bool isBig, Piece p)
        {
            var data = $"[PGKOPF61]" + Environment.NewLine +
                $"PRNR={id}" + Environment.NewLine +
                $"LANG={p.Length}" + Environment.NewLine +
                $"PRPOS={Util.NumberToString(p.Position,2)}" + Environment.NewLine + Environment.NewLine;
            var instructions = p.Cnc.Substring(0, p.Cnc.Length - 11).Split('W').Skip(1);

            foreach (var instruction in instructions)
            {
                var name = Util.NumberToString(Int32.Parse(instruction.Substring(0, 8)), isBig ? 8 : 4);
                var klae = instruction.Substring(8);

                data += "[SWINCL61]" + Environment.NewLine +
                    $"NAME=W{name}" + Environment.NewLine +
                    $"KLAE={klae}" + Environment.NewLine;
            }

            string filename = Path.Combine(settings.FMCFolder,
                    GetFMCName(isBig, p)
                    + ".FMC");
            
            File.WriteAllText(filename, data);
        }

        private string GetFMCName(bool isBig, Piece p)
        {
            return isBig
                ? p.Name
                : p.Name.Substring(3, 4) + p.Name.Substring(p.Name.IndexOf('-') + 1);
        }
    }
}
