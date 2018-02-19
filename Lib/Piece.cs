using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lib
{
    public class Piece
    {
        public int Ktn { get; }
        public int Length { get; }
        public int Position { get; }
        public string Cnc { get; }
        public string Prn { get; }
        public string Name { get; }

        public Piece(int ktn, int length, int position, string cnc, string prn, string name)
        {
            Ktn = ktn;
            Length = length;
            Position = position;
            Cnc = cnc;
            Prn = prn;
            Name = name;
        }

        public static Piece GetPiece(string line, List<Label> labels)
        {
            var name = line.Substring(0, line.IndexOf(' '));
            var ktn = int.Parse(new Regex("KTN(\\d+)").Match(line).Groups[1].Value);
            var length = int.Parse(new Regex("L(\\d+)G").Match(line).Groups[1].Value);
            var position = int.Parse(new Regex("T(\\d+)L").Match(line).Groups[1].Value);
            var cnc = new Regex(" (\\w+)\r").Match(line).Groups[1].Value;
            var label = labels.Find(l => l.Id == ktn);
            
            return new Piece(ktn, length, position, cnc, label.Prn, name);
        }

        public override string ToString() => "KTN" + Ktn;
    }
}
