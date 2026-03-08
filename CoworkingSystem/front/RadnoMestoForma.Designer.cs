namespace CoworkingSystem.front
{
    partial class RadnoMestoForma
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
            lblPodtip = new Label();
            cmbPodtipStola = new ComboBox();
            lblBrojRM = new Label();
            numBrojRadnihMesta = new NumericUpDown();
            lblAktivan = new Label();
            chkAktivan = new CheckBox();
            lblOpis = new Label();
            txtOpis = new TextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnDodaj = new Button();
            groupBox1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numBrojRadnihMesta).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tableLayoutPanel1);
            groupBox1.Font = new Font("Segoe UI", 14F);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1257, 430);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Novo radno mesto";
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
            tableLayoutPanel1.Controls.Add(lblPodtip, 0, 2);
            tableLayoutPanel1.Controls.Add(cmbPodtipStola, 1, 2);
            tableLayoutPanel1.Controls.Add(lblBrojRM, 0, 3);
            tableLayoutPanel1.Controls.Add(numBrojRadnihMesta, 1, 3);
            tableLayoutPanel1.Controls.Add(lblAktivan, 0, 4);
            tableLayoutPanel1.Controls.Add(chkAktivan, 1, 4);
            tableLayoutPanel1.Controls.Add(lblOpis, 0, 5);
            tableLayoutPanel1.Controls.Add(txtOpis, 1, 5);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 1, 6);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 28);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(10);
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 110F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.Size = new Size(1251, 399);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblLokacija
            // 
            lblLokacija.AutoSize = true;
            lblLokacija.Dock = DockStyle.Fill;
            lblLokacija.Font = new Font("Segoe UI", 10F);
            lblLokacija.Location = new Point(13, 10);
            lblLokacija.Name = "lblLokacija";
            lblLokacija.Size = new Size(214, 31);
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
            lblOznaka.Location = new Point(13, 41);
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
            txtOznaka.Location = new Point(233, 44);
            txtOznaka.Name = "txtOznaka";
            txtOznaka.Size = new Size(1005, 25);
            txtOznaka.TabIndex = 3;
            // 
            // lblPodtip
            // 
            lblPodtip.AutoSize = true;
            lblPodtip.Dock = DockStyle.Fill;
            lblPodtip.Font = new Font("Segoe UI", 10F);
            lblPodtip.Location = new Point(13, 72);
            lblPodtip.Name = "lblPodtip";
            lblPodtip.Size = new Size(214, 33);
            lblPodtip.TabIndex = 4;
            lblPodtip.Text = "Podtip stola";
            lblPodtip.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbPodtipStola
            // 
            cmbPodtipStola.Dock = DockStyle.Fill;
            cmbPodtipStola.Font = new Font("Segoe UI", 10F);
            cmbPodtipStola.Location = new Point(233, 75);
            cmbPodtipStola.Name = "cmbPodtipStola";
            cmbPodtipStola.Size = new Size(1005, 25);
            cmbPodtipStola.TabIndex = 5;
            cmbPodtipStola.SelectedIndexChanged += cmbPodtipStola_SelectedIndexChanged;
            // 
            // lblBrojRM
            // 
            lblBrojRM.AutoSize = true;
            lblBrojRM.Dock = DockStyle.Fill;
            lblBrojRM.Font = new Font("Segoe UI", 10F);
            lblBrojRM.Location = new Point(13, 105);
            lblBrojRM.Name = "lblBrojRM";
            lblBrojRM.Size = new Size(214, 31);
            lblBrojRM.TabIndex = 6;
            lblBrojRM.Text = "Broj radnih mesta (opciono)";
            lblBrojRM.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numBrojRadnihMesta
            // 
            numBrojRadnihMesta.Dock = DockStyle.Fill;
            numBrojRadnihMesta.Font = new Font("Segoe UI", 10F);
            numBrojRadnihMesta.Location = new Point(233, 108);
            numBrojRadnihMesta.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numBrojRadnihMesta.Name = "numBrojRadnihMesta";
            numBrojRadnihMesta.Size = new Size(1005, 25);
            numBrojRadnihMesta.TabIndex = 7;
            // 
            // lblAktivan
            // 
            lblAktivan.AutoSize = true;
            lblAktivan.Dock = DockStyle.Fill;
            lblAktivan.Font = new Font("Segoe UI", 10F);
            lblAktivan.Location = new Point(13, 136);
            lblAktivan.Name = "lblAktivan";
            lblAktivan.Size = new Size(214, 29);
            lblAktivan.TabIndex = 8;
            lblAktivan.Text = "Status";
            lblAktivan.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // chkAktivan
            // 
            chkAktivan.AutoSize = true;
            chkAktivan.Font = new Font("Segoe UI", 10F);
            chkAktivan.Location = new Point(233, 139);
            chkAktivan.Name = "chkAktivan";
            chkAktivan.Size = new Size(75, 23);
            chkAktivan.TabIndex = 9;
            chkAktivan.Text = "Aktivno";
            // 
            // lblOpis
            // 
            lblOpis.AutoSize = true;
            lblOpis.Dock = DockStyle.Fill;
            lblOpis.Font = new Font("Segoe UI", 10F);
            lblOpis.Location = new Point(13, 165);
            lblOpis.Name = "lblOpis";
            lblOpis.Size = new Size(214, 110);
            lblOpis.TabIndex = 10;
            lblOpis.Text = "Opis";
            lblOpis.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtOpis
            // 
            txtOpis.Dock = DockStyle.Fill;
            txtOpis.Font = new Font("Segoe UI", 10F);
            txtOpis.Location = new Point(233, 168);
            txtOpis.Multiline = true;
            txtOpis.Name = "txtOpis";
            txtOpis.ScrollBars = ScrollBars.Vertical;
            txtOpis.Size = new Size(1005, 104);
            txtOpis.TabIndex = 11;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnDodaj);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(233, 278);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(5);
            flowLayoutPanel1.Size = new Size(1005, 108);
            flowLayoutPanel1.TabIndex = 12;
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
            // RadnoMestoForma
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1892, 1047);
            Controls.Add(groupBox1);
            Name = "RadnoMestoForma";
            Text = "RadnoMestoForma";
            Load += RadnoMestoForma_Load;
            groupBox1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numBrojRadnihMesta).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnDodaj;

        private System.Windows.Forms.Label lblLokacija;
        private System.Windows.Forms.Label lblOznaka;
        private System.Windows.Forms.Label lblPodtip;
        private System.Windows.Forms.Label lblBrojRM;
        private System.Windows.Forms.Label lblAktivan;
        private System.Windows.Forms.Label lblOpis;

        private System.Windows.Forms.ComboBox cmbLokacija;
        private System.Windows.Forms.TextBox txtOznaka;
        private System.Windows.Forms.ComboBox cmbPodtipStola;
        private System.Windows.Forms.NumericUpDown numBrojRadnihMesta;
        private System.Windows.Forms.CheckBox chkAktivan;
        private System.Windows.Forms.TextBox txtOpis;
    }
}