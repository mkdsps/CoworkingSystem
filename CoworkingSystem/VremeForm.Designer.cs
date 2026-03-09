namespace CoworkingSystem
{
    partial class VremeForm
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
            od_TimePicker = new DateTimePicker();
            do_TimePicker = new DateTimePicker();
            textBox1 = new TextBox();
            dodajDugme = new Button();
            od = new Label();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // od_TimePicker
            // 
            od_TimePicker.CustomFormat = "HH:mm";
            od_TimePicker.Format = DateTimePickerFormat.Custom;
            od_TimePicker.Location = new Point(29, 51);
            od_TimePicker.Name = "od_TimePicker";
            od_TimePicker.ShowUpDown = true;
            od_TimePicker.Size = new Size(51, 23);
            od_TimePicker.TabIndex = 0;
            od_TimePicker.ValueChanged += od_TimePicker_ValueChanged;
            // 
            // do_TimePicker
            // 
            do_TimePicker.CustomFormat = "HH:mm";
            do_TimePicker.Format = DateTimePickerFormat.Custom;
            do_TimePicker.Location = new Point(114, 51);
            do_TimePicker.Name = "do_TimePicker";
            do_TimePicker.ShowUpDown = true;
            do_TimePicker.Size = new Size(54, 23);
            do_TimePicker.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(29, 113);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(231, 95);
            textBox1.TabIndex = 2;
            // 
            // dodajDugme
            // 
            dodajDugme.Location = new Point(323, 185);
            dodajDugme.Name = "dodajDugme";
            dodajDugme.Size = new Size(75, 23);
            dodajDugme.TabIndex = 3;
            dodajDugme.Text = "dodaj";
            dodajDugme.UseVisualStyleBackColor = true;
            dodajDugme.Click += button1_Click;
            // 
            // od
            // 
            od.AutoSize = true;
            od.Location = new Point(29, 33);
            od.Name = "od";
            od.Size = new Size(21, 15);
            od.TabIndex = 4;
            od.Text = "od";
            od.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(114, 33);
            label2.Name = "label2";
            label2.Size = new Size(21, 15);
            label2.TabIndex = 5;
            label2.Text = "do";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 95);
            label1.Name = "label1";
            label1.Size = new Size(29, 15);
            label1.TabIndex = 6;
            label1.Text = "opis";
            // 
            // VremeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(429, 239);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(od);
            Controls.Add(dodajDugme);
            Controls.Add(textBox1);
            Controls.Add(do_TimePicker);
            Controls.Add(od_TimePicker);
            Name = "VremeForm";
            Text = "VremeForm";
            Load += VremeForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker od_TimePicker;
        private DateTimePicker do_TimePicker;
        private TextBox textBox1;
        private Button dodajDugme;
        private Label od;
        private Label label2;
        private Label label1;
    }
}