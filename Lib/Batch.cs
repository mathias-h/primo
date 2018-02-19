using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lib
{
    public class Batch
    {
        private static Settings settings = Settings.Instance;
        public string Name { get; }
        public List<Parts> Parts { get; }

        public Batch(string filename)
        {
            Name = filename.Substring(filename.LastIndexOf(@"\") + 1);
            Parts = GetParts(filename);
        }
        private Batch() { }

        List<Parts> GetParts(string filename)
        {
            string etFile = File.ReadAllText(filename + ".$ET");
            string txFile = File.ReadAllText(filename + ".$TX");
            var labels = GetLabels(etFile);
            var parts = new List<Part>();
            var lines = txFile.Split('\n').Skip(1).ToList();
            var start = 0;
            
            while ((start = lines.FindIndex(start + 1, l => l.StartsWith("KSN"))) != -1)
            {
                var end = lines.FindIndex(start + 1, l => l.StartsWith("KRL"));
                var id = int.Parse(new Regex("\\d{6}$").Match(lines[start].Split(' ')[0]).Value);
                var name = new Regex("\\s(.+)L").Match(lines[start]).Groups[1].Value.Trim();
                var ksn = int.Parse(new Regex("KSN(\\d+)").Match(lines[start]).Groups[1].Value);
                var pieces = lines.Skip(start + 1).Take(end - start - 1).Select(line => Piece.GetPiece(line, labels)).ToList();
                var endPiece = int.Parse(new Regex("KRL(\\d+)").Match(lines[end]).Groups[1].Value);

                parts.Add(new Part(id, name, pieces, endPiece, ksn));
            }

            return parts.GroupBy(p => p.Id).Select(g => new Parts(g.Key, g.ToList())).ToList();
        }

        List<Label> GetLabels(string labelFile) =>
            labelFile.Split('\n').ToList()
                .FindAll(l => l != "")
                .GroupBy(l => l.Substring(0, 8))
                .Select(group =>
                {
                    var id = int.Parse(new Regex("EDN(\\d+)T").Match(group.Key).Groups[1].Value);
                    var command = String.Join(Environment.NewLine, group.Select(l =>
                    {
                        var s = l.Substring(8, l.Length - 9);
                        if (s.StartsWith("PF")) return "PF";
                        else return s.Substring(0, s.Length - 1);
                    }));

                    return new Label(id, command);
                })
                .ToList();

        public override string ToString() => Name;

        public static List<Batch> GetBatches() =>
            Directory.GetFiles(settings.BatchFolder)
                .ToList()
                .FindAll(f => f.EndsWith("$ET"))
                .Select(f => f.Replace(".$ET", ""))
                .Select(f => new Batch(f))
                .ToList();
    }
}
