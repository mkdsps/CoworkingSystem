namespace CoworkingSystem.front
{
    partial class KorisnikForma
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
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblIme = new Label();
            txtIme = new TextBox();
            lblPrezime = new Label();
            txtPrezime = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblTelefon = new Label();
            txtTelefon = new TextBox();
            lblTipClanstva = new Label();
            cmbTipClanstva = new ComboBox();
            lblLokacija = new Label();
            cmbLokacija = new ComboBox();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            lblDatumPocetka = new Label();
            dtpDatumPocetka = new DateTimePicker();
            lblDatumIsteka = new Label();
            dtpDatumIsteka = new DateTimePicker();
            lblNapomena = new Label();
            txtNapomena = new TextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnDodaj = new Button();
            groupBox1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tableLayoutPanel1);
            groupBox1.Font = new Font("Segoe UI", 14F);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1257, 560);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Novi korisnik";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(lblIme, 0, 0);
            tableLayoutPanel1.Controls.Add(txtIme, 1, 0);
            tableLayoutPanel1.Controls.Add(lblPrezime, 0, 1);
            tableLayoutPanel1.Controls.Add(txtPrezime, 1, 1);
            tableLayoutPanel1.Controls.Add(lblEmail, 0, 2);
            tableLayoutPanel1.Controls.Add(txtEmail, 1, 2);
            tableLayoutPanel1.Controls.Add(lblTelefon, 0, 3);
            tableLayoutPanel1.Controls.Add(txtTelefon, 1, 3);
            tableLayoutPanel1.Controls.Add(lblTipClanstva, 0, 4);
            tableLayoutPanel1.Controls.Add(cmbTipClanstva, 1, 4);
            tableLayoutPanel1.Controls.Add(lblLokacija, 0, 5);
            tableLayoutPanel1.Controls.Add(cmbLokacija, 1, 5);
            tableLayoutPanel1.Controls.Add(lblStatus, 0, 6);
            tableLayoutPanel1.Controls.Add(cmbStatus, 1, 6);
            tableLayoutPanel1.Controls.Add(lblDatumPocetka, 0, 7);
            tableLayoutPanel1.Controls.Add(dtpDatumPocetka, 1, 7);
            tableLayoutPanel1.Controls.Add(lblDatumIsteka, 0, 8);
            tableLayoutPanel1.Controls.Add(dtpDatumIsteka, 1, 8);
            tableLayoutPanel1.Controls.Add(lblNapomena, 0, 9);
            tableLayoutPanel1.Controls.Add(txtNapomena, 1, 9);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 1, 10);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 28);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(10);
            tableLayoutPanel1.RowCount = 11;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 140F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.Size = new Size(1251, 529);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblIme
            // 
            lblIme.AutoSize = true;
            lblIme.Dock = DockStyle.Fill;
            lblIme.Font = new Font("Segoe UI", 10F);
            lblIme.Location = new Point(13, 10);
            lblIme.Name = "lblIme";
            lblIme.Size = new Size(214, 31);
            lblIme.TabIndex = 0;
            lblIme.Text = "Ime";
            lblIme.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtIme
            // 
            txtIme.Dock = DockStyle.Fill;
            txtIme.Font = new Font("Segoe UI", 10F);
            txtIme.Location = new Point(233, 13);
            txtIme.Name = "txtIme";
            txtIme.Size = new Size(1005, 25);
            txtIme.TabIndex = 1;
            // 
            // lblPrezime
            // 
            lblPrezime.AutoSize = true;
            lblPrezime.Dock = DockStyle.Fill;
            lblPrezime.Font = new Font("Segoe UI", 10F);
            lblPrezime.Location = new Point(13, 41);
            lblPrezime.Name = "lblPrezime";
            lblPrezime.Size = new Size(214, 31);
            lblPrezime.TabIndex = 2;
            lblPrezime.Text = "Prezime";
            lblPrezime.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtPrezime
            // 
            txtPrezime.Dock = DockStyle.Fill;
            txtPrezime.Font = new Font("Segoe UI", 10F);
            txtPrezime.Location = new Point(233, 44);
            txtPrezime.Name = "txtPrezime";
            txtPrezime.Size = new Size(1005, 25);
            txtPrezime.TabIndex = 3;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Dock = DockStyle.Fill;
            lblEmail.Font = new Font("Segoe UI", 10F);
            lblEmail.Location = new Point(13, 72);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(214, 31);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email";
            lblEmail.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtEmail
            // 
            txtEmail.Dock = DockStyle.Fill;
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(233, 75);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(1005, 25);
            txtEmail.TabIndex = 5;
            // 
            // lblTelefon
            // 
            lblTelefon.AutoSize = true;
            lblTelefon.Dock = DockStyle.Fill;
            lblTelefon.Font = new Font("Segoe UI", 10F);
            lblTelefon.Location = new Point(13, 103);
            lblTelefon.Name = "lblTelefon";
            lblTelefon.Size = new Size(214, 31);
            lblTelefon.TabIndex = 6;
            lblTelefon.Text = "Telefon";
            lblTelefon.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtTelefon
            // 
            txtTelefon.Dock = DockStyle.Fill;
            txtTelefon.Font = new Font("Segoe UI", 10F);
            txtTelefon.Location = new Point(233, 106);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new Size(1005, 25);
            txtTelefon.TabIndex = 7;
            // 
            // lblTipClanstva
            // 
            lblTipClanstva.AutoSize = true;
            lblTipClanstva.Dock = DockStyle.Fill;
            lblTipClanstva.Font = new Font("Segoe UI", 10F);
            lblTipClanstva.Location = new Point(13, 134);
            lblTipClanstva.Name = "lblTipClanstva";
            lblTipClanstva.Size = new Size(214, 31);
            lblTipClanstva.TabIndex = 8;
            lblTipClanstva.Text = "Tip članstva";
            lblTipClanstva.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbTipClanstva
            // 
            cmbTipClanstva.Dock = DockStyle.Fill;
            cmbTipClanstva.Font = new Font("Segoe UI", 10F);
            cmbTipClanstva.Location = new Point(233, 137);
            cmbTipClanstva.Name = "cmbTipClanstva";
            cmbTipClanstva.Size = new Size(1005, 25);
            cmbTipClanstva.TabIndex = 9;
            // 
            // lblLokacija
            // 
            lblLokacija.AutoSize = true;
            lblLokacija.Dock = DockStyle.Fill;
            lblLokacija.Font = new Font("Segoe UI", 10F);
            lblLokacija.Location = new Point(13, 165);
            lblLokacija.Name = "lblLokacija";
            lblLokacija.Size = new Size(214, 33);
            lblLokacija.TabIndex = 10;
            lblLokacija.Text = "Lokacija";
            lblLokacija.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbLokacija
            // 
            cmbLokacija.Dock = DockStyle.Fill;
            cmbLokacija.Font = new Font("Segoe UI", 10F);
            cmbLokacija.Location = new Point(233, 168);
            cmbLokacija.Name = "cmbLokacija";
            cmbLokacija.Size = new Size(1005, 25);
            cmbLokacija.TabIndex = 11;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Dock = DockStyle.Fill;
            lblStatus.Font = new Font("Segoe UI", 10F);
            lblStatus.Location = new Point(13, 198);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(214, 33);
            lblStatus.TabIndex = 12;
            lblStatus.Text = "Status";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbStatus
            // 
            cmbStatus.Dock = DockStyle.Fill;
            cmbStatus.Font = new Font("Segoe UI", 10F);
            cmbStatus.Location = new Point(233, 201);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(1005, 25);
            cmbStatus.TabIndex = 13;
            // 
            // lblDatumPocetka
            // 
            lblDatumPocetka.AutoSize = true;
            lblDatumPocetka.Dock = DockStyle.Fill;
            lblDatumPocetka.Font = new Font("Segoe UI", 10F);
            lblDatumPocetka.Location = new Point(13, 231);
            lblDatumPocetka.Name = "lblDatumPocetka";
            lblDatumPocetka.Size = new Size(214, 31);
            lblDatumPocetka.TabIndex = 14;
            lblDatumPocetka.Text = "Datum početka";
            lblDatumPocetka.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dtpDatumPocetka
            // 
            dtpDatumPocetka.Dock = DockStyle.Left;
            dtpDatumPocetka.Font = new Font("Segoe UI", 10F);
            dtpDatumPocetka.Location = new Point(233, 234);
            dtpDatumPocetka.Name = "dtpDatumPocetka";
            dtpDatumPocetka.Size = new Size(250, 25);
            dtpDatumPocetka.TabIndex = 15;
            // 
            // lblDatumIsteka
            // 
            lblDatumIsteka.AutoSize = true;
            lblDatumIsteka.Dock = DockStyle.Fill;
            lblDatumIsteka.Font = new Font("Segoe UI", 10F);
            lblDatumIsteka.Location = new Point(13, 262);
            lblDatumIsteka.Name = "lblDatumIsteka";
            lblDatumIsteka.Size = new Size(214, 31);
            lblDatumIsteka.TabIndex = 16;
            lblDatumIsteka.Text = "Datum isteka";
            lblDatumIsteka.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dtpDatumIsteka
            // 
            dtpDatumIsteka.Dock = DockStyle.Left;
            dtpDatumIsteka.Font = new Font("Segoe UI", 10F);
            dtpDatumIsteka.Location = new Point(233, 265);
            dtpDatumIsteka.Name = "dtpDatumIsteka";
            dtpDatumIsteka.Size = new Size(250, 25);
            dtpDatumIsteka.TabIndex = 17;
            // 
            // lblNapomena
            // 
            lblNapomena.AutoSize = true;
            lblNapomena.Dock = DockStyle.Fill;
            lblNapomena.Font = new Font("Segoe UI", 10F);
            lblNapomena.Location = new Point(13, 293);
            lblNapomena.Name = "lblNapomena";
            lblNapomena.Size = new Size(214, 140);
            lblNapomena.TabIndex = 18;
            lblNapomena.Text = "Napomena";
            lblNapomena.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtNapomena
            // 
            txtNapomena.Dock = DockStyle.Fill;
            txtNapomena.Font = new Font("Segoe UI", 10F);
            txtNapomena.Location = new Point(233, 296);
            txtNapomena.Multiline = true;
            txtNapomena.Name = "txtNapomena";
            txtNapomena.ScrollBars = ScrollBars.Vertical;
            txtNapomena.Size = new Size(1005, 134);
            txtNapomena.TabIndex = 19;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnDodaj);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(233, 436);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(5);
            flowLayoutPanel1.Size = new Size(1005, 80);
            flowLayoutPanel1.TabIndex = 20;
            flowLayoutPanel1.WrapContents = false;
            // 
            // btnDodaj
            // 
            btnDodaj.AutoSize = true;
            btnDodaj.Font = new Font("Segoe UI", 10F);
            btnDodaj.Location = new Point(902, 8);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(90, 32);
            btnDodaj.TabIndex = 0;
            btnDodaj.Text = "Dodaj";
            btnDodaj.UseVisualStyleBackColor = true;
            btnDodaj.Click += btnDodaj_Click;
            // 
            // KorisnikForma
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1900, 1045);
            Controls.Add(groupBox1);
            Name = "KorisnikForma";
            Text = "KorisnikForma";
            Load += KorisnikForma_Load;
            groupBox1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnDodaj;

        private Label lblIme;
        private Label lblPrezime;
        private Label lblEmail;
        private Label lblTelefon;
        private Label lblTipClanstva;
        private Label lblLokacija;
        private Label lblStatus;
        private Label lblDatumPocetka;
        private Label lblDatumIsteka;
        private Label lblNapomena;

        private TextBox txtIme;
        private TextBox txtPrezime;
        private TextBox txtEmail;
        private TextBox txtTelefon;
        private ComboBox cmbTipClanstva;
        private ComboBox cmbLokacija;
        private ComboBox cmbStatus;
        private DateTimePicker dtpDatumPocetka;
        private DateTimePicker dtpDatumIsteka;
        private TextBox txtNapomena;
    }
}