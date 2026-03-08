namespace CoworkingSystem
{
    partial class IzmenaRezervacije
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
            dateTimePicker1 = new DateTimePicker();
            textBox1 = new TextBox();
            button1 = new Button();
            comboBox1 = new ComboBox();
            dateTimePicker3 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            datum = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 36);
            label1.Name = "label1";
            label1.Size = new Size(21, 15);
            label1.TabIndex = 0;
            label1.Text = "od";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(126, 36);
            label2.Name = "label2";
            label2.Size = new Size(21, 15);
            label2.TabIndex = 1;
            label2.Text = "do";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "HH:mm";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(45, 54);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker1.Size = new Size(53, 23);
            dateTimePicker1.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(45, 224);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(207, 74);
            textBox1.TabIndex = 4;
            // 
            // button1
            // 
            button1.Location = new Point(365, 275);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 5;
            button1.Text = "azuriraj";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "aktivan", "otkazan" });
            comboBox1.Location = new Point(45, 160);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 6;
            // 
            // dateTimePicker3
            // 
            dateTimePicker3.Format = DateTimePickerFormat.Short;
            dateTimePicker3.Location = new Point(45, 108);
            dateTimePicker3.Name = "dateTimePicker3";
            dateTimePicker3.Size = new Size(90, 23);
            dateTimePicker3.TabIndex = 7;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.CustomFormat = "HH:mm";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Location = new Point(126, 54);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.ShowUpDown = true;
            dateTimePicker2.Size = new Size(53, 23);
            dateTimePicker2.TabIndex = 8;
            // 
            // datum
            // 
            datum.AutoSize = true;
            datum.Location = new Point(45, 90);
            datum.Name = "datum";
            datum.Size = new Size(42, 15);
            datum.TabIndex = 9;
            datum.Text = "datum";
            datum.Click += label3_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(45, 206);
            label3.Name = "label3";
            label3.Size = new Size(29, 15);
            label3.TabIndex = 10;
            label3.Text = "opis";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(45, 142);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 11;
            label4.Text = "stanje";
            // 
            // IzmenaRezervacije
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(483, 332);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(datum);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker3);
            Controls.Add(comboBox1);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(dateTimePicker1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "IzmenaRezervacije";
            Text = "IzmenaRezervacije";
            Load += IzmenaRezervacije_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private DateTimePicker dateTimePicker1;
        private TextBox textBox1;
        private Button button1;
        private ComboBox comboBox1;
        private DateTimePicker dateTimePicker3;
        private DateTimePicker dateTimePicker2;
        private Label datum;
        private Label label3;
        private Label label4;
    }
}