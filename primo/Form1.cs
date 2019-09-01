using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Lib;

namespace primo
{
    public partial class Form1 : Form
    {
        private static Settings settings = Settings.Instance;
        Batch SelectedBatch => (Batch)listBox1.SelectedItem;
        Parts SelectedPart => (Parts)comboBox1.SelectedItem;
        List<Piece> SelectedPieces
        {
            get
            {
                var pieces = new List<Piece>();

                foreach (var item in checkedListBox1.CheckedItems)
                {
                    pieces.Add((Piece)item);
                }

                return pieces;
            }
        }

        public Form1()
        {
            InitializeComponent();

            Load += (s, e) => {
                //if (!Printer.isOnline())
                //    throw new Exception("printeren er ikke online");

                ShowBatches();
            };
        }

        private void ShowBatches()
        {
            SetBatches(Batch.GetBatches());
        }

        private void SetBatches(List<Batch> batches)
        {
            if (batches.Count == 0)
            {
                MessageBox.Show("Der blev ikke fundet nogle batches");
            }

            listBox1.Items.Clear();
            foreach (var b in batches)
            {
                listBox1.Items.Add(b);
            }

            if (batches.Count > 0)
                listBox1.SelectedIndex = 0;
        }

        private void ShowBatch()
        {
            comboBox1.Items.Clear();
            foreach (var parts in SelectedBatch.Parts)
            {
                comboBox1.Items.Add(parts);
            }

            if (SelectedBatch.Parts.Count > 0)
                comboBox1.SelectedIndex = 0;
        }

        private void ShowPart()
        {
            checkedListBox1.Items.Clear();

            foreach (var part in SelectedPart.Parts_)
            {
                foreach (var piece in part.Pieces)
                {
                    checkedListBox1.Items.Add(piece);
                }
            }

            if (SelectedPart.PieceCount > 0)
                checkedListBox1.SelectedIndex = 0;
        }

        private void runSelected(bool isBig, bool isComplete)
        {
            var pieces = new List<Piece>();
            Parts part = SelectedPart;

            if (part == null)
            {
                throw new Exception("der er ikke valgt en del");
            }

            if (SelectedPieces.Count > 0)
            {
                pieces = SelectedPieces;
                var p = part.Parts_[0];
                part = new Parts(part.Id, new List<Part> { new Part(p.Id, p.Name, pieces, -1, p.Ksn) });
            }
            else
            {
                foreach (var p in part.Parts_)
                {
                    pieces.AddRange(p.Pieces);
                }
            }

            bool printerSelected = printerCheckBox.Checked;
            bool cncSelected = cncCheckBox.Checked;
            bool savSelected = savCheckBox.Checked;

            if (!printerSelected && !savSelected && !cncSelected)
            {
                printerSelected = true;
                savSelected = true;
                cncSelected = true;
            }

            if (printerSelected) Printer.Print(pieces);
            if (cncSelected) new Cnc(part.Id, pieces).Start(isBig, isComplete);
            if (savSelected) new Saw(SelectedBatch.Name, part).Start();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowBatch();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowPart();
        }

        private void button1_Click(object sender, EventArgs args)
        {
            runSelected(true, false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowBatches();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            runSelected(false, false);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            runSelected(false, true);
        }
    }
}
