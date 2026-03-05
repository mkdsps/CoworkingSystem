namespace CoworkingSystem
{
    partial class LoginForma
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
            lgnBtn = new Button();
            pswLbl = new Label();
            usrLbl = new Label();
            usrTxt = new TextBox();
            pswTxt = new TextBox();
            greskaLbl = new Label();
            SuspendLayout();
            // 
            // lgnBtn
            // 
            lgnBtn.Location = new Point(188, 117);
            lgnBtn.Name = "lgnBtn";
            lgnBtn.Size = new Size(75, 23);
            lgnBtn.TabIndex = 0;
            lgnBtn.Text = "login";
            lgnBtn.UseVisualStyleBackColor = true;
            lgnBtn.Click += lgnBtn_Click;
            // 
            // pswLbl
            // 
            pswLbl.AutoSize = true;
            pswLbl.Location = new Point(25, 88);
            pswLbl.Name = "pswLbl";
            pswLbl.Size = new Size(60, 15);
            pswLbl.TabIndex = 1;
            pswLbl.Text = "password:";
            // 
            // usrLbl
            // 
            usrLbl.AutoSize = true;
            usrLbl.Location = new Point(23, 62);
            usrLbl.Name = "usrLbl";
            usrLbl.Size = new Size(62, 15);
            usrLbl.TabIndex = 2;
            usrLbl.Text = "username:";
            // 
            // usrTxt
            // 
            usrTxt.Location = new Point(91, 59);
            usrTxt.Name = "usrTxt";
            usrTxt.Size = new Size(172, 23);
            usrTxt.TabIndex = 3;
            // 
            // pswTxt
            // 
            pswTxt.Location = new Point(91, 88);
            pswTxt.Name = "pswTxt";
            pswTxt.Size = new Size(172, 23);
            pswTxt.TabIndex = 4;
            pswTxt.UseSystemPasswordChar = true;
            // 
            // greskaLbl
            // 
            greskaLbl.AutoSize = true;
            greskaLbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            greskaLbl.ForeColor = Color.Red;
            greskaLbl.Location = new Point(283, 79);
            greskaLbl.Name = "greskaLbl";
            greskaLbl.Size = new Size(0, 15);
            greskaLbl.TabIndex = 5;
            // 
            // LoginForma
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 184);
            Controls.Add(greskaLbl);
            Controls.Add(pswTxt);
            Controls.Add(usrTxt);
            Controls.Add(usrLbl);
            Controls.Add(pswLbl);
            Controls.Add(lgnBtn);
            Name = "LoginForma";
            Text = "LoginForma";
            Load += LoginForma_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button lgnBtn;
        private Label pswLbl;
        private Label usrLbl;
        private TextBox usrTxt;
        private TextBox pswTxt;
        private Label greskaLbl;
    }
}