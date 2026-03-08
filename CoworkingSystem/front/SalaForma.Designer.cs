namespace CoworkingSystem.front
{
    partial class SalaForma
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblLokacija = new Label();
            cmbLokacija = new ComboBox();
            lblOznaka = new Label();
            txtOznaka = new TextBox();
            lblKapacitet = new Label();
            numKapacitet = new NumericUpDown();
            lblPovrsina = new Label();
            numPovrsina = new NumericUpDown();
            lblOprema = new Label();
            panelOprema = new FlowLayoutPanel();
            chkProjektor = new CheckBox();
            chkTV = new CheckBox();
            chkTabla = new CheckBox();
            chkOnline = new CheckBox();
            lblAktivan = new Label();
            chkAktivan = new CheckBox();
            lblOpis = new Label();
            txtOpis = new TextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnDodaj = new Button();
            groupBox1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numKapacitet).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPovrsina).BeginInit();
            panelOprema.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tableLayoutPanel1);
            groupBox1.Font = new Font("Segoe UI", 14F);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1257, 520);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Nova sala";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(lblLokacija, 0, 0);
            tableLayoutPanel1.Controls.Add(cmbLokacija, 1, 0);
            tableLayoutPanel1.Controls.Add(lblOznaka, 0, 1);
            tableLayoutPanel1.Controls.Add(txtOznaka, 1, 1);
            tableLayoutPanel1.Controls.Add(lblKapacitet, 0, 2);
            tableLayoutPanel1.Controls.Add(numKapacitet, 1, 2);
            tableLayoutPanel1.Controls.Add(lblPovrsina, 0, 3);
            tableLayoutPanel1.Controls.Add(numPovrsina, 1, 3);
            tableLayoutPanel1.Controls.Add(lblOprema, 0, 4);
            tableLayoutPanel1.Controls.Add(panelOprema, 1, 4);
            tableLayoutPanel1.Controls.Add(lblAktivan, 0, 5);
            tableLayoutPanel1.Controls.Add(chkAktivan, 1, 5);
            tableLayoutPanel1.Controls.Add(lblOpis, 0, 6);
            tableLayoutPanel1.Controls.Add(txtOpis, 1, 6);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 1, 7);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 28);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(10);
            tableLayoutPanel1.RowCount = 8;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 110F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.Size = new Size(1251, 489);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblLokacija
            // 
            lblLokacija.AutoSize = true;
            lblLokacija.Dock = DockStyle.Fill;
            lblLokacija.Font = new Font("Segoe UI", 10F);
            lblLokacija.Location = new Point(13, 10);
            lblLokacija.Name = "lblLokacija";
            lblLokacija.Size = new Size(214, 29);
            lblLokacija.TabIndex = 0;
            lblLokacija.Text = "Lokacija";
            lblLokacija.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbLokacija
            // 
            cmbLokacija.Dock = DockStyle.Fill;
            cmbLokacija.Font = new Font("Segoe UI", 10F);
            cmbLokacija.Location = new Point(233, 13);
            cmbLokacija.Name = "cmbLokacija";
            cmbLokacija.Size = new Size(1005, 25);
            cmbLokacija.TabIndex = 1;
            // 
            // lblOznaka
            // 
            lblOznaka.AutoSize = true;
            lblOznaka.Dock = DockStyle.Fill;
            lblOznaka.Font = new Font("Segoe UI", 10F);
            lblOznaka.Location = new Point(13, 39);
            lblOznaka.Name = "lblOznaka";
            lblOznaka.Size = new Size(214, 31);
            lblOznaka.TabIndex = 2;
            lblOznaka.Text = "Oznaka";
            lblOznaka.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtOznaka
            // 
            txtOznaka.Dock = DockStyle.Fill;
            txtOznaka.Font = new Font("Segoe UI", 10F);
            txtOznaka.Location = new Point(233, 42);
            txtOznaka.Name = "txtOznaka";
            txtOznaka.Size = new Size(1005, 25);
            txtOznaka.TabIndex = 3;
            // 
            // lblKapacitet
            // 
            lblKapacitet.AutoSize = true;
            lblKapacitet.Dock = DockStyle.Fill;
            lblKapacitet.Font = new Font("Segoe UI", 10F);
            lblKapacitet.Location = new Point(13, 70);
            lblKapacitet.Name = "lblKapacitet";
            lblKapacitet.Size = new Size(214, 31);
            lblKapacitet.TabIndex = 4;
            lblKapacitet.Text = "Kapacitet (obavezno)";
            lblKapacitet.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numKapacitet
            // 
            numKapacitet.Dock = DockStyle.Fill;
            numKapacitet.Font = new Font("Segoe UI", 10F);
            numKapacitet.Location = new Point(233, 73);
            numKapacitet.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numKapacitet.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numKapacitet.Name = "numKapacitet";
            numKapacitet.Size = new Size(1005, 25);
            numKapacitet.TabIndex = 5;
            numKapacitet.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblPovrsina
            // 
            lblPovrsina.AutoSize = true;
            lblPovrsina.Dock = DockStyle.Fill;
            lblPovrsina.Font = new Font("Segoe UI", 10F);
            lblPovrsina.Location = new Point(13, 101);
            lblPovrsina.Name = "lblPovrsina";
            lblPovrsina.Size = new Size(214, 31);
            lblPovrsina.TabIndex = 6;
            lblPovrsina.Text = "Površina (m², opciono)";
            lblPovrsina.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numPovrsina
            // 
            numPovrsina.DecimalPlaces = 2;
            numPovrsina.Dock = DockStyle.Fill;
            numPovrsina.Font = new Font("Segoe UI", 10F);
            numPovrsina.Location = new Point(233, 104);
            numPovrsina.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numPovrsina.Name = "numPovrsina";
            numPovrsina.Size = new Size(1005, 25);
            numPovrsina.TabIndex = 7;
            // 
            // lblOprema
            // 
            lblOprema.AutoSize = true;
            lblOprema.Dock = DockStyle.Fill;
            lblOprema.Font = new Font("Segoe UI", 10F);
            lblOprema.Location = new Point(13, 132);
            lblOprema.Name = "lblOprema";
            lblOprema.Size = new Size(214, 106);
            lblOprema.TabIndex = 8;
            lblOprema.Text = "Oprema";
            lblOprema.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panelOprema
            // 
            panelOprema.Controls.Add(chkProjektor);
            panelOprema.Controls.Add(chkTV);
            panelOprema.Controls.Add(chkTabla);
            panelOprema.Controls.Add(chkOnline);
            panelOprema.Dock = DockStyle.Fill;
            panelOprema.Location = new Point(233, 135);
            panelOprema.Name = "panelOprema";
            panelOprema.Size = new Size(1005, 100);
            panelOprema.TabIndex = 9;
            // 
            // chkProjektor
            // 
            chkProjektor.AutoSize = true;
            chkProjektor.Font = new Font("Segoe UI", 10F);
            chkProjektor.Location = new Point(3, 3);
            chkProjektor.Name = "chkProjektor";
            chkProjektor.Size = new Size(84, 23);
            chkProjektor.TabIndex = 0;
            chkProjektor.Text = "Projektor";
            // 
            // chkTV
            // 
            chkTV.AutoSize = true;
            chkTV.Font = new Font("Segoe UI", 10F);
            chkTV.Location = new Point(93, 3);
            chkTV.Name = "chkTV";
            chkTV.Size = new Size(44, 23);
            chkTV.TabIndex = 1;
            chkTV.Text = "TV";
            // 
            // chkTabla
            // 
            chkTabla.AutoSize = true;
            chkTabla.Font = new Font("Segoe UI", 10F);
            chkTabla.Location = new Point(143, 3);
            chkTabla.Name = "chkTabla";
            chkTabla.Size = new Size(58, 23);
            chkTabla.TabIndex = 2;
            chkTabla.Text = "Tabla";
            // 
            // chkOnline
            // 
            chkOnline.AutoSize = true;
            chkOnline.Font = new Font("Segoe UI", 10F);
            chkOnline.Location = new Point(207, 3);
            chkOnline.Name = "chkOnline";
            chkOnline.Size = new Size(119, 23);
            chkOnline.TabIndex = 3;
            chkOnline.Text = "Online oprema";
            // 
            // lblAktivan
            // 
            lblAktivan.AutoSize = true;
            lblAktivan.Dock = DockStyle.Fill;
            lblAktivan.Font = new Font("Segoe UI", 10F);
            lblAktivan.Location = new Point(13, 238);
            lblAktivan.Name = "lblAktivan";
            lblAktivan.Size = new Size(214, 29);
            lblAktivan.TabIndex = 10;
            lblAktivan.Text = "Status";
            lblAktivan.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // chkAktivan
            // 
            chkAktivan.AutoSize = true;
            chkAktivan.Font = new Font("Segoe UI", 10F);
            chkAktivan.Location = new Point(233, 241);
            chkAktivan.Name = "chkAktivan";
            chkAktivan.Size = new Size(75, 23);
            chkAktivan.TabIndex = 11;
            chkAktivan.Text = "Aktivno";
            // 
            // lblOpis
            // 
            lblOpis.AutoSize = true;
            lblOpis.Dock = DockStyle.Fill;
            lblOpis.Font = new Font("Segoe UI", 10F);
            lblOpis.Location = new Point(13, 267);
            lblOpis.Name = "lblOpis";
            lblOpis.Size = new Size(214, 110);
            lblOpis.TabIndex = 12;
            lblOpis.Text = "Opis";
            lblOpis.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtOpis
            // 
            txtOpis.Dock = DockStyle.Fill;
            txtOpis.Font = new Font("Segoe UI", 10F);
            txtOpis.Location = new Point(233, 270);
            txtOpis.Multiline = true;
            txtOpis.Name = "txtOpis";
            txtOpis.ScrollBars = ScrollBars.Vertical;
            txtOpis.Size = new Size(1005, 104);
            txtOpis.TabIndex = 13;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnDodaj);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(233, 380);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(5);
            flowLayoutPanel1.Size = new Size(1005, 96);
            flowLayoutPanel1.TabIndex = 14;
            flowLayoutPanel1.WrapContents = false;
            // 
            // btnDodaj
            // 
            btnDodaj.AutoSize = true;
            btnDodaj.Font = new Font("Segoe UI", 10F);
            btnDodaj.Location = new Point(917, 8);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(75, 29);
            btnDodaj.TabIndex = 0;
            btnDodaj.Text = "Dodaj";
            btnDodaj.Click += btnDodaj_Click;
            // 
            // SalaForma
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1285, 545);
            Controls.Add(groupBox1);
            Name = "SalaForma";
            Text = "SalaForma";
            Load += SalaForma_Load;
            groupBox1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numKapacitet).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPovrsina).EndInit();
            panelOprema.ResumeLayout(false);
            panelOprema.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnDodaj;

        private Label lblLokacija;
        private Label lblOznaka;
        private Label lblKapacitet;
        private Label lblPovrsina;
        private Label lblOprema;
        private Label lblAktivan;
        private Label lblOpis;

        private ComboBox cmbLokacija;
        private TextBox txtOznaka;
        private NumericUpDown numKapacitet;
        private NumericUpDown numPovrsina;

        private FlowLayoutPanel panelOprema;
        private CheckBox chkProjektor;
        private CheckBox chkTV;
        private CheckBox chkTabla;
        private CheckBox chkOnline;

        private CheckBox chkAktivan;
        private TextBox txtOpis;
    }
}