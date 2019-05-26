namespace primo
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.printerCheckBox = new System.Windows.Forms.CheckBox();
            this.savCheckBox = new System.Windows.Forms.CheckBox();
            this.cncCheckBox = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 31;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(136, 283);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(158, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(379, 39);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(158, 58);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(254, 301);
            this.checkedListBox1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(421, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 90);
            this.button1.TabIndex = 3;
            this.button1.Text = "Start stor";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(12, 301);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 58);
            this.button2.TabIndex = 4;
            this.button2.Text = "Indlæs Batches";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // printerCheckBox
            // 
            this.printerCheckBox.AutoSize = true;
            this.printerCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.printerCheckBox.Location = new System.Drawing.Point(421, 254);
            this.printerCheckBox.Name = "printerCheckBox";
            this.printerCheckBox.Size = new System.Drawing.Size(95, 30);
            this.printerCheckBox.TabIndex = 5;
            this.printerCheckBox.Text = "Printer";
            this.printerCheckBox.UseVisualStyleBackColor = true;
            // 
            // savCheckBox
            // 
            this.savCheckBox.AutoSize = true;
            this.savCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.savCheckBox.Location = new System.Drawing.Point(421, 321);
            this.savCheckBox.Name = "savCheckBox";
            this.savCheckBox.Size = new System.Drawing.Size(69, 30);
            this.savCheckBox.TabIndex = 6;
            this.savCheckBox.Text = "Sav";
            this.savCheckBox.UseVisualStyleBackColor = true;
            // 
            // cncCheckBox
            // 
            this.cncCheckBox.AutoSize = true;
            this.cncCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.cncCheckBox.Location = new System.Drawing.Point(421, 288);
            this.cncCheckBox.Name = "cncCheckBox";
            this.cncCheckBox.Size = new System.Drawing.Size(79, 30);
            this.cncCheckBox.TabIndex = 7;
            this.cncCheckBox.Text = "CNC";
            this.cncCheckBox.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(421, 154);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(116, 90);
            this.button3.TabIndex = 8;
            this.button3.Text = "Start lille";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 379);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.cncCheckBox);
            this.Controls.Add(this.savCheckBox);
            this.Controls.Add(this.printerCheckBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "Primo Vinduer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox printerCheckBox;
        private System.Windows.Forms.CheckBox savCheckBox;
        private System.Windows.Forms.CheckBox cncCheckBox;
        private System.Windows.Forms.Button button3;
    }
}

