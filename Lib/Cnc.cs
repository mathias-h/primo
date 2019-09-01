using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Lib
{
    public class Cnc
    {
        private static readonly Settings Settings = Settings.Instance;
        readonly List<Piece> Pieces;
        readonly int Id;

        public Cnc(int id, List<Piece> pieces)
        {
            Id = id;
            Pieces = pieces;
        }
        public void Start(bool isBig, bool isComplete)
        {
            foreach (var piece in Pieces)
            {
                GenerateFMC(isBig, isComplete, piece);
            }

            GenerateGRP(isBig);
        }
    
        public void GenerateGRP(bool isBig)
        {
            var data = "";
            
            foreach (var piece in Pieces)
            {
                var srcPath = "C:\\IMAWOP\\" + (isBig ? "SRC1\\" : "M1\\");
                var fmcName = GetFMCName(isBig, piece);

                data += $"1,{fmcName}.FMC,{srcPath}{fmcName}.SRC,/P=1" + Environment.NewLine;
            }

            var grpPath = Path.Combine(
                isBig ? Settings.GRPFolder : Settings.GRPSmallFolder,
                "IMA.GRP");

            File.WriteAllText(grpPath, data);
        }

        public void GenerateFMC(bool isBig, bool isComplete, Piece p)
        {
            var data = $"[PGKOPF61]" + Environment.NewLine +
                $"PRNR={Id}" + Environment.NewLine +
                $"LANG={p.Length}" + Environment.NewLine +
                $"PRPOS={Util.NumberToString(p.Position, 2)}" + Environment.NewLine +
                (isComplete ? $"Komplet=1" : "") +
                Environment.NewLine;
            var instructions = p.Cnc.Substring(0, p.Cnc.Length - 11).Split('W').Skip(1);

            foreach (var instruction in instructions)
            {
                var name = Util.NumberToString(int.Parse(instruction.Substring(0, 8)), isBig ? 8 : 4);
                var klae = instruction.Substring(8);

                data += "[SWINCL61]" + Environment.NewLine +
                    $"NAME=W{name}" + Environment.NewLine +
                    $"KLAE={klae}" + Environment.NewLine;
            }

            string filename = Path.Combine(Settings.FMCFolder,
                    GetFMCName(isBig, p)
                    + ".FMC");
            
            File.WriteAllText(filename, data);
        }

        private string GetFMCName(bool isBig, Piece p)
        {
            return isBig
                ? p.Name
                : p.Name.Substring(3, 4) + p.Name.Substring(p.Name.IndexOf('-') + 1, 4);
        }
    }
}
