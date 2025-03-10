namespace UI.Forms
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
            LoginBtn = new Button();
            passwordTxtBox = new TextBox();
            label3 = new Label();
            emailTxtBox = new TextBox();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // LoginBtn
            // 
            LoginBtn.BackColor = Color.SeaGreen;
            LoginBtn.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LoginBtn.ForeColor = Color.White;
            LoginBtn.Location = new Point(61, 287);
            LoginBtn.Name = "LoginBtn";
            LoginBtn.Size = new Size(232, 37);
            LoginBtn.TabIndex = 23;
            LoginBtn.Text = "LogIn";
            LoginBtn.UseVisualStyleBackColor = false;
            LoginBtn.Click += LoginBtn_Click;
            // 
            // passwordTxtBox
            // 
            passwordTxtBox.Location = new Point(138, 211);
            passwordTxtBox.Name = "passwordTxtBox";
            passwordTxtBox.Size = new Size(176, 23);
            passwordTxtBox.TabIndex = 22;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe Print", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.SeaGreen;
            label3.Location = new Point(26, 211);
            label3.Name = "label3";
            label3.Size = new Size(93, 28);
            label3.TabIndex = 21;
            label3.Text = "Password:";
            // 
            // emailTxtBox
            // 
            emailTxtBox.Location = new Point(138, 155);
            emailTxtBox.Name = "emailTxtBox";
            emailTxtBox.Size = new Size(176, 23);
            emailTxtBox.TabIndex = 20;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe Print", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.SeaGreen;
            label2.Location = new Point(26, 150);
            label2.Name = "label2";
            label2.Size = new Size(63, 28);
            label2.TabIndex = 19;
            label2.Text = "Email:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe Print", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.SeaGreen;
            label1.Location = new Point(105, 66);
            label1.Name = "label1";
            label1.Size = new Size(111, 56);
            label1.TabIndex = 18;
            label1.Text = "LogIn";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(337, 450);
            Controls.Add(LoginBtn);
            Controls.Add(passwordTxtBox);
            Controls.Add(label3);
            Controls.Add(emailTxtBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button LoginBtn;
        private TextBox passwordTxtBox;
        private Label label3;
        private TextBox emailTxtBox;
        private Label label2;
        private Label label1;
    }
}
