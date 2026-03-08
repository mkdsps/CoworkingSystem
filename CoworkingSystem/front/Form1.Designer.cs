namespace CoworkingSystem
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvKorisnici = new DataGridView();
            dgvLokacije = new DataGridView();
            dgvResursi = new DataGridView();
            dgvRezervacije = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label1 = new Label();
            comboBox1 = new ComboBox();
            cmbStatusNaloga = new ComboBox();
            cmbTipClanstva = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            Korisnici = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            button5 = new Button();
            button6 = new Button();
            txtPretragaKorisnika = new TextBox();
            label10 = new Label();
            label11 = new Label();
            dateTimePicker1 = new DateTimePicker();
            chkDatum = new CheckBox();
            button7 = new Button();
            button8 = new Button();
            label2 = new Label();
            comboBox4 = new ComboBox();
            cmbTipResursa = new ComboBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvKorisnici).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvLokacije).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvResursi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvRezervacije).BeginInit();
            SuspendLayout();
            // 
            // dgvKorisnici
            // 
            dgvKorisnici.AllowUserToAddRows = false;
            dgvKorisnici.AllowUserToDeleteRows = false;
            dgvKorisnici.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKorisnici.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKorisnici.Location = new Point(12, 141);
            dgvKorisnici.MultiSelect = false;
            dgvKorisnici.Name = "dgvKorisnici";
            dgvKorisnici.ReadOnly = true;
            dgvKorisnici.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKorisnici.Size = new Size(1231, 199);
            dgvKorisnici.TabIndex = 0;
            dgvKorisnici.SelectionChanged += dgvKorisnici_SelectionChanged;
            // 
            // dgvLokacije
            // 
            dgvLokacije.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLokacije.Location = new Point(1318, 141);
            dgvLokacije.Name = "dgvLokacije";
            dgvLokacije.Size = new Size(563, 199);
            dgvLokacije.TabIndex = 3;
            dgvLokacije.SelectionChanged += dgvLokacije_SelectionChanged;
            // 
            // dgvResursi
            // 
            dgvResursi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResursi.Location = new Point(12, 539);
            dgvResursi.Name = "dgvResursi";
            dgvResursi.Size = new Size(563, 199);
            dgvResursi.TabIndex = 4;
            dgvResursi.SelectionChanged += dgvResursi_SelectionChanged;
            // 
            // dgvRezervacije
            // 
            dgvRezervacije.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRezervacije.Location = new Point(642, 539);
            dgvRezervacije.Name = "dgvRezervacije";
            dgvRezervacije.Size = new Size(1079, 288);
            dgvRezervacije.TabIndex = 5;
            dgvRezervacije.CellContentClick += dgvRezervacije_CellContentClick;
            // 
            // button1
            // 
            button1.Location = new Point(642, 850);
            button1.Name = "button1";
            button1.Size = new Size(283, 67);
            button1.TabIndex = 6;
            button1.Text = "Kreiraj Rezervaciju";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(1084, 346);
            button2.Name = "button2";
            button2.Size = new Size(159, 73);
            button2.TabIndex = 7;
            button2.Text = "Dodaj Korisnika";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(1318, 346);
            button3.Name = "button3";
            button3.Size = new Size(132, 73);
            button3.TabIndex = 8;
            button3.Text = "Dodaj Lokaciju";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(642, 934);
            button4.Name = "button4";
            button4.Size = new Size(132, 73);
            button4.TabIndex = 9;
            button4.Text = "Dodaj Tip Clanstva";
            button4.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(1014, 9);
            label1.Name = "label1";
            label1.Size = new Size(94, 37);
            label1.TabIndex = 10;
            label1.Text = "NAZIV";
            label1.Click += label1_Click_1;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(1991, 159);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(170, 23);
            comboBox1.TabIndex = 11;
            // 
            // cmbStatusNaloga
            // 
            cmbStatusNaloga.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatusNaloga.FormattingEnabled = true;
            cmbStatusNaloga.Location = new Point(719, 98);
            cmbStatusNaloga.Name = "cmbStatusNaloga";
            cmbStatusNaloga.Size = new Size(170, 23);
            cmbStatusNaloga.TabIndex = 12;
            cmbStatusNaloga.SelectedIndexChanged += cmbStatusNaloga_SelectedIndexChanged;
            // 
            // cmbTipClanstva
            // 
            cmbTipClanstva.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipClanstva.FormattingEnabled = true;
            cmbTipClanstva.Location = new Point(543, 98);
            cmbTipClanstva.Name = "cmbTipClanstva";
            cmbTipClanstva.Size = new Size(170, 23);
            cmbTipClanstva.TabIndex = 13;
            cmbTipClanstva.SelectedIndexChanged += cmbTipClanstva_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(642, 68);
            label3.Name = "label3";
            label3.Size = new Size(71, 15);
            label3.TabIndex = 17;
            label3.Text = "Tip Clanstva";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(809, 68);
            label4.Name = "label4";
            label4.Size = new Size(80, 15);
            label4.TabIndex = 18;
            label4.Text = "Status Naloga";
            // 
            // Korisnici
            // 
            Korisnici.AutoSize = true;
            Korisnici.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Korisnici.Location = new Point(12, 98);
            Korisnici.Name = "Korisnici";
            Korisnici.Size = new Size(81, 24);
            Korisnici.TabIndex = 19;
            Korisnici.Text = "Korisnici";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(1318, 94);
            label6.Name = "label6";
            label6.Size = new Size(79, 24);
            label6.TabIndex = 21;
            label6.Text = "Lokacije";
            label6.Click += label6_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(2098, 129);
            label7.Name = "label7";
            label7.Size = new Size(63, 15);
            label7.TabIndex = 22;
            label7.Text = "Tip resursa";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(12, 492);
            label8.Name = "label8";
            label8.Size = new Size(73, 24);
            label8.TabIndex = 23;
            label8.Text = "Resursi";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(642, 499);
            label9.Name = "label9";
            label9.Size = new Size(139, 29);
            label9.TabIndex = 24;
            label9.Text = "Rezervacije";
            // 
            // button5
            // 
            button5.Location = new Point(1749, 663);
            button5.Name = "button5";
            button5.Size = new Size(132, 73);
            button5.TabIndex = 28;
            button5.Text = "Izmeni Rezervaciju";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(1749, 754);
            button6.Name = "button6";
            button6.Size = new Size(132, 73);
            button6.TabIndex = 29;
            button6.Text = "Otkazi rezervaciju";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // txtPretragaKorisnika
            // 
            txtPretragaKorisnika.Location = new Point(121, 98);
            txtPretragaKorisnika.Name = "txtPretragaKorisnika";
            txtPretragaKorisnika.Size = new Size(210, 23);
            txtPretragaKorisnika.TabIndex = 30;
            txtPretragaKorisnika.TextChanged += txtPretragaKorisnika_TextChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(231, 68);
            label10.Name = "label10";
            label10.Size = new Size(100, 15);
            label10.TabIndex = 31;
            label10.Text = "Pretrazi po imenu";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(1657, 476);
            label11.Name = "label11";
            label11.Size = new Size(43, 15);
            label11.TabIndex = 32;
            label11.Text = "Datum";
            label11.Click += label11_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(1523, 504);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(177, 23);
            dateTimePicker1.TabIndex = 34;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // chkDatum
            // 
            chkDatum.AutoSize = true;
            chkDatum.Location = new Point(1706, 511);
            chkDatum.Name = "chkDatum";
            chkDatum.Size = new Size(15, 14);
            chkDatum.TabIndex = 35;
            chkDatum.UseVisualStyleBackColor = true;
            chkDatum.CheckedChanged += chkDatum_CheckedChanged;
            // 
            // button7
            // 
            button7.Location = new Point(12, 744);
            button7.Name = "button7";
            button7.Size = new Size(132, 73);
            button7.TabIndex = 36;
            button7.Text = "Dodaj Salu";
            button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.Location = new Point(150, 744);
            button8.Name = "button8";
            button8.Size = new Size(132, 73);
            button8.TabIndex = 37;
            button8.Text = "Dodaj Radno Mesto";
            button8.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(487, 68);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 15;
            label2.Text = "Lokacija";
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(367, 98);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(170, 23);
            comboBox4.TabIndex = 14;
            // 
            // cmbTipResursa
            // 
            cmbTipResursa.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipResursa.FormattingEnabled = true;
            cmbTipResursa.Location = new Point(454, 504);
            cmbTipResursa.Name = "cmbTipResursa";
            cmbTipResursa.Size = new Size(121, 23);
            cmbTipResursa.TabIndex = 38;
            cmbTipResursa.SelectedIndexChanged += cmbTipResursa_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(502, 476);
            label5.Name = "label5";
            label5.Size = new Size(73, 15);
            label5.TabIndex = 39;
            label5.Text = "Vrsta resursa";
            label5.Click += label5_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(label5);
            Controls.Add(cmbTipResursa);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(chkDatum);
            Controls.Add(dateTimePicker1);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(txtPretragaKorisnika);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(Korisnici);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(comboBox4);
            Controls.Add(cmbTipClanstva);
            Controls.Add(cmbStatusNaloga);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dgvRezervacije);
            Controls.Add(dgvResursi);
            Controls.Add(dgvLokacije);
            Controls.Add(dgvKorisnici);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvKorisnici).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvLokacije).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvResursi).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvRezervacije).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvKorisnici;
        private DataGridView dgvLokacije;
        private DataGridView dgvResursi;
        private DataGridView dgvRezervacije;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label label1;
        private ComboBox comboBox1;
        private ComboBox cmbStatusNaloga;
        private ComboBox cmbTipClanstva;
        private Label label3;
        private Label label4;
        private Label Korisnici;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;        
        private Button button5;
        private Button button6;
        private TextBox txtPretragaKorisnika;
        private Label label10;
        private Label label11;
        private DateTimePicker dateTimePicker1;
        private CheckBox chkDatum;
        private Button button7;
        private Button button8;
        private Label label2;
        private ComboBox comboBox4;
        private ComboBox cmbTipResursa;
        private Label label5;
    }
}
