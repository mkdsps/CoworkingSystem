namespace CoworkingSystem.front
{
    partial class LokacijaForma
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label5 = new Label();
            label7 = new Label();
            label8 = new Label();
            groupBox1 = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            txtRadnoVreme = new TextBox();
            txtGrad = new TextBox();
            txtAdresa = new TextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnDodaj = new Button();
            label4 = new Label();
            numMaxKorisnika = new NumericUpDown();
            chkAktivna = new CheckBox();
            txtNaziv = new TextBox();
            txtOpis = new TextBox();
            groupBox1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numMaxKorisnika).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Bottom;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(11, 65);
            label1.Name = "label1";
            label1.Size = new Size(194, 19);
            label1.TabIndex = 0;
            label1.Text = "Adresa";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Bottom;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(11, 103);
            label2.Name = "label2";
            label2.Size = new Size(194, 19);
            label2.TabIndex = 2;
            label2.Text = "Grad";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Bottom;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(11, 141);
            label3.Name = "label3";
            label3.Size = new Size(194, 19);
            label3.TabIndex = 4;
            label3.Text = "RadnoVreme";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            label3.Click += label3_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Bottom;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(11, 176);
            label5.Name = "label5";
            label5.Size = new Size(194, 19);
            label5.TabIndex = 8;
            label5.Text = "AktivnaLokacija";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Bottom;
            label7.Font = new Font("Segoe UI", 10F);
            label7.Location = new Point(11, 313);
            label7.Name = "label7";
            label7.Size = new Size(194, 19);
            label7.TabIndex = 12;
            label7.Text = "Opis";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Dock = DockStyle.Bottom;
            label8.Font = new Font("Segoe UI", 10F);
            label8.Location = new Point(11, 213);
            label8.Name = "label8";
            label8.Size = new Size(194, 19);
            label8.TabIndex = 14;
            label8.Text = "MaksimalanBrojKorisnika";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            groupBox1.AutoSize = true;
            groupBox1.Controls.Add(tableLayoutPanel1);
            groupBox1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(2, 1);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1860, 928);
            groupBox1.TabIndex = 17;
            groupBox1.TabStop = false;
            groupBox1.Text = "Nova lokacija ";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(txtRadnoVreme, 1, 3);
            tableLayoutPanel1.Controls.Add(txtGrad, 1, 2);
            tableLayoutPanel1.Controls.Add(txtAdresa, 1, 1);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 1, 8);
            tableLayoutPanel1.Controls.Add(label4, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 2);
            tableLayoutPanel1.Controls.Add(label3, 0, 3);
            tableLayoutPanel1.Controls.Add(numMaxKorisnika, 1, 5);
            tableLayoutPanel1.Controls.Add(label5, 0, 4);
            tableLayoutPanel1.Controls.Add(label8, 0, 5);
            tableLayoutPanel1.Controls.Add(label7, 0, 6);
            tableLayoutPanel1.Controls.Add(chkAktivna, 1, 4);
            tableLayoutPanel1.Controls.Add(label1, 0, 1);
            tableLayoutPanel1.Controls.Add(txtNaziv, 1, 0);
            tableLayoutPanel1.Controls.Add(txtOpis, 1, 6);
            tableLayoutPanel1.Dock = DockStyle.Bottom;
            tableLayoutPanel1.Location = new Point(3, 101);
            tableLayoutPanel1.Margin = new Padding(3, 6, 3, 6);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(8);
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 311F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.Size = new Size(1854, 824);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // txtRadnoVreme
            // 
            txtRadnoVreme.Dock = DockStyle.Fill;
            txtRadnoVreme.Location = new Point(211, 125);
            txtRadnoVreme.Name = "txtRadnoVreme";
            txtRadnoVreme.Size = new Size(1632, 32);
            txtRadnoVreme.TabIndex = 28;
            // 
            // txtGrad
            // 
            txtGrad.Dock = DockStyle.Fill;
            txtGrad.Location = new Point(211, 87);
            txtGrad.Name = "txtGrad";
            txtGrad.Size = new Size(1632, 32);
            txtGrad.TabIndex = 27;
            // 
            // txtAdresa
            // 
            txtAdresa.Dock = DockStyle.Fill;
            txtAdresa.Location = new Point(211, 49);
            txtAdresa.Name = "txtAdresa";
            txtAdresa.Size = new Size(1632, 32);
            txtAdresa.TabIndex = 26;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnDodaj);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(211, 646);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(8);
            flowLayoutPanel1.Size = new Size(1632, 167);
            flowLayoutPanel1.TabIndex = 1;
            flowLayoutPanel1.WrapContents = false;
            // 
            // btnDodaj
            // 
            btnDodaj.AutoSize = true;
            btnDodaj.Location = new Point(1503, 11);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(110, 40);
            btnDodaj.TabIndex = 0;
            btnDodaj.Text = "Dodaj";
            btnDodaj.UseVisualStyleBackColor = true;
            btnDodaj.Click += button2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Bottom;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(11, 27);
            label4.Name = "label4";
            label4.Size = new Size(194, 19);
            label4.TabIndex = 23;
            label4.Text = "Naziv";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            label4.Click += label4_Click;
            // 
            // numMaxKorisnika
            // 
            numMaxKorisnika.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            numMaxKorisnika.Font = new Font("Segoe UI", 10F);
            numMaxKorisnika.Location = new Point(211, 201);
            numMaxKorisnika.Margin = new Padding(3, 6, 3, 6);
            numMaxKorisnika.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numMaxKorisnika.Name = "numMaxKorisnika";
            numMaxKorisnika.Size = new Size(1632, 25);
            numMaxKorisnika.TabIndex = 18;
            numMaxKorisnika.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // chkAktivna
            // 
            chkAktivna.Anchor = AnchorStyles.Left;
            chkAktivna.AutoSize = true;
            chkAktivna.Checked = true;
            chkAktivna.CheckState = CheckState.Checked;
            chkAktivna.Font = new Font("Segoe UI", 10F);
            chkAktivna.Location = new Point(211, 166);
            chkAktivna.Margin = new Padding(3, 6, 3, 6);
            chkAktivna.Name = "chkAktivna";
            chkAktivna.Size = new Size(122, 23);
            chkAktivna.TabIndex = 22;
            chkAktivna.Text = "Aktivna lokacija";
            chkAktivna.UseVisualStyleBackColor = true;
            // 
            // txtNaziv
            // 
            txtNaziv.Dock = DockStyle.Fill;
            txtNaziv.Location = new Point(211, 11);
            txtNaziv.Name = "txtNaziv";
            txtNaziv.Size = new Size(1632, 32);
            txtNaziv.TabIndex = 24;
            // 
            // txtOpis
            // 
            txtOpis.Dock = DockStyle.Fill;
            txtOpis.Location = new Point(211, 235);
            txtOpis.Multiline = true;
            txtOpis.Name = "txtOpis";
            txtOpis.ScrollBars = ScrollBars.Vertical;
            txtOpis.Size = new Size(1632, 94);
            txtOpis.TabIndex = 25;
            // 
            // LokacijaForma
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1901, 941);
            Controls.Add(groupBox1);
            Name = "LokacijaForma";
            Text = "LokacijaForma";
            Load += LokacijaForma_Load;
            groupBox1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numMaxKorisnika).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label5;
        private Button button7;
        private Label label7;
        private Label label8;
        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private NumericUpDown numMaxKorisnika;
        private CheckBox chkAktivna;
        private Label label4;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnDodaj;
        private TextBox txtNaziv;
        private TextBox txtOpis;
        private TextBox txtRadnoVreme;
        private TextBox txtGrad;
        private TextBox txtAdresa;
    }
}