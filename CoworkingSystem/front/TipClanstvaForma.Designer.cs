namespace CoworkingSystem.front
{
    partial class TipClanstvaForma
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            button2 = new Button();
            label4 = new Label();
            numericUpDown4 = new NumericUpDown();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            numericUpDown3 = new NumericUpDown();
            checkBox1 = new CheckBox();
            txtNaziv = new TextBox();
            txtOpis = new TextBox();
            groupBox1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Bottom;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(11, 64);
            label1.Name = "label1";
            label1.Size = new Size(194, 19);
            label1.TabIndex = 0;
            label1.Text = "Cena";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Bottom;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(11, 101);
            label2.Name = "label2";
            label2.Size = new Size(194, 19);
            label2.TabIndex = 2;
            label2.Text = "Trajanje Dana";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Bottom;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(11, 138);
            label3.Name = "label3";
            label3.Size = new Size(194, 19);
            label3.TabIndex = 4;
            label3.Text = "Maks.SatiMesecno";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            label3.Click += label3_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Bottom;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(11, 173);
            label5.Name = "label5";
            label5.Size = new Size(194, 19);
            label5.TabIndex = 8;
            label5.Text = "Dozvola Sale";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Bottom;
            label7.Font = new Font("Segoe UI", 10F);
            label7.Location = new Point(11, 310);
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
            label8.Location = new Point(11, 210);
            label8.Name = "label8";
            label8.Size = new Size(194, 19);
            label8.TabIndex = 14;
            label8.Text = "Sati Sale Mesecno";
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
            groupBox1.Text = "Novi tip clanstva";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 1, 8);
            tableLayoutPanel1.Controls.Add(label4, 0, 0);
            tableLayoutPanel1.Controls.Add(numericUpDown4, 1, 1);
            tableLayoutPanel1.Controls.Add(label2, 0, 2);
            tableLayoutPanel1.Controls.Add(label3, 0, 3);
            tableLayoutPanel1.Controls.Add(numericUpDown1, 1, 5);
            tableLayoutPanel1.Controls.Add(numericUpDown2, 1, 3);
            tableLayoutPanel1.Controls.Add(numericUpDown3, 1, 2);
            tableLayoutPanel1.Controls.Add(label5, 0, 4);
            tableLayoutPanel1.Controls.Add(label8, 0, 5);
            tableLayoutPanel1.Controls.Add(label7, 0, 6);
            tableLayoutPanel1.Controls.Add(checkBox1, 1, 4);
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
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(button2);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(211, 643);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(8);
            flowLayoutPanel1.Size = new Size(1632, 170);
            flowLayoutPanel1.TabIndex = 1;
            flowLayoutPanel1.WrapContents = false;
            // 
            // button2
            // 
            button2.AutoSize = true;
            button2.Location = new Point(1503, 11);
            button2.Name = "button2";
            button2.Size = new Size(110, 40);
            button2.TabIndex = 0;
            button2.Text = "Dodaj";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
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
            // numericUpDown4
            // 
            numericUpDown4.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            numericUpDown4.DecimalPlaces = 2;
            numericUpDown4.Font = new Font("Segoe UI", 10F);
            numericUpDown4.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            numericUpDown4.Location = new Point(211, 52);
            numericUpDown4.Margin = new Padding(3, 6, 3, 6);
            numericUpDown4.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numericUpDown4.Name = "numericUpDown4";
            numericUpDown4.Size = new Size(1632, 25);
            numericUpDown4.TabIndex = 21;
            numericUpDown4.ValueChanged += numericUpDown4_ValueChanged;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            numericUpDown1.Font = new Font("Segoe UI", 10F);
            numericUpDown1.Location = new Point(211, 198);
            numericUpDown1.Margin = new Padding(3, 6, 3, 6);
            numericUpDown1.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(1632, 25);
            numericUpDown1.TabIndex = 18;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            numericUpDown2.Font = new Font("Segoe UI", 10F);
            numericUpDown2.Location = new Point(211, 126);
            numericUpDown2.Margin = new Padding(3, 6, 3, 6);
            numericUpDown2.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(1632, 25);
            numericUpDown2.TabIndex = 19;
            // 
            // numericUpDown3
            // 
            numericUpDown3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            numericUpDown3.Font = new Font("Segoe UI", 10F);
            numericUpDown3.Location = new Point(211, 89);
            numericUpDown3.Margin = new Padding(3, 6, 3, 6);
            numericUpDown3.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numericUpDown3.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(1632, 25);
            numericUpDown3.TabIndex = 20;
            numericUpDown3.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // checkBox1
            // 
            checkBox1.Anchor = AnchorStyles.Left;
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI", 10F);
            checkBox1.Location = new Point(211, 163);
            checkBox1.Margin = new Padding(3, 6, 3, 6);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(92, 23);
            checkBox1.TabIndex = 22;
            checkBox1.Text = "checkBox1";
            checkBox1.UseVisualStyleBackColor = true;
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
            txtOpis.Location = new Point(211, 232);
            txtOpis.Multiline = true;
            txtOpis.Name = "txtOpis";
            txtOpis.ScrollBars = ScrollBars.Vertical;
            txtOpis.Size = new Size(1632, 94);
            txtOpis.TabIndex = 25;
            // 
            // TipClanstvaForma
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1901, 941);
            Controls.Add(groupBox1);
            Name = "TipClanstvaForma";
            Text = "TipClanstvaForma";
            Load += TipClanstvaForma_Load;
            groupBox1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
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
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown3;
        private NumericUpDown numericUpDown4;
        private CheckBox checkBox1;
        private Label label4;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button button2;
        private TextBox txtNaziv;
        private TextBox txtOpis;
    }
}