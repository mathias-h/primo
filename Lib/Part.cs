using System.Collections.Generic;

namespace Lib
{
    public class Part
    {
        public int Id { get; }
        public string Name { get; }
        public List<Piece> Pieces { get; }
        public int EndPiece { get; }
        public int Ksn { get; }

        public Part(int id, string name, List<Piece> pieces, int endPiece, int ksn)
        {
            Id = id;
            Name = name;
            Pieces = pieces;
            EndPiece = endPiece;
            Ksn = ksn;
        }

        public override string ToString() => Id + " " + Name;
    }
    public class Parts
    {
        Settings settings = Settings.Instance;
        public int Id { get; }
        public List<Part> Parts_ { get; }
        public int PieceCount { get { return GetPieceCount();  } }

        public Parts(int id, List<Part> parts)
        {
            Id = id;
            Parts_ = parts;
        }

        private int GetPieceCount()
        {
            int count = 0;
            foreach (var part in Parts_)
            {
                count += part.Pieces.Count;
                if (part.EndPiece/10 >= settings.EndPieceLength)
                {
                    count++;
                }
            }
            return count;
        }

        public override string ToString() => Id + " " + Parts_[0]?.Name;
    }
}
