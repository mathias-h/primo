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
        public void Start()
        {
            foreach (var piece in pieces)
            {
                GenerateFMC(piece);
            }

            GenerateGRP();
        }
    
        public void GenerateGRP()
        {
            var data = "";
            
            foreach (var piece in pieces)
            {
                data += $"1,{piece.Name}.FMC,C:\\IMAWOP\\SRC1\\{piece.Name}.SRC,/P=1" + Environment.NewLine;
            }

            File.WriteAllText(GRP_PATH, data);
        }

        public void GenerateFMC(Piece p)
        {
            var data = $"[PGKOPF61]" + Environment.NewLine +
                $"PRNR={id}" + Environment.NewLine +
                $"LANG={p.Length}" + Environment.NewLine +
                $"PRPOS={Util.NumberToString(p.Position,100)}" + Environment.NewLine + Environment.NewLine;
            var filename = Path.Combine(settings.FMCFolder,p.Name + ".FMC");

            var instructions = p.Cnc.Substring(0, p.Cnc.Length - 11).Split('W').Skip(1);

            foreach (var instruction in instructions)
            {
                var name = instruction.Substring(0, 8);
                var klae = instruction.Substring(8);

                data += "[SWINCL61]" + Environment.NewLine +
                    $"NAME=W{name}" + Environment.NewLine +
                    $"KLAE={klae}" + Environment.NewLine;
            }

            File.WriteAllText(filename, data);
        }


    }
}
