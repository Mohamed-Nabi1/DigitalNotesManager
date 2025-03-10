namespace UIPresentation
{
    partial class Form2
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
            RegiserBtn = new Button();
            passwordTxtBox = new TextBox();
            label3 = new Label();
            UserNameTxtBox = new TextBox();
            label2 = new Label();
            label1 = new Label();
            emailTxtBox = new TextBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // RegiserBtn
            // 
            RegiserBtn.BackColor = Color.SeaGreen;
            RegiserBtn.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RegiserBtn.ForeColor = Color.White;
            RegiserBtn.Location = new Point(42, 393);
            RegiserBtn.Margin = new Padding(3, 4, 3, 4);
            RegiserBtn.Name = "RegiserBtn";
            RegiserBtn.Size = new Size(265, 49);
            RegiserBtn.TabIndex = 29;
            RegiserBtn.Text = "Register";
            RegiserBtn.UseVisualStyleBackColor = false;
            RegiserBtn.Click += RegiserBtn_Click;
            // 
            // passwordTxtBox
            // 
            passwordTxtBox.Location = new Point(136, 317);
            passwordTxtBox.Margin = new Padding(3, 4, 3, 4);
            passwordTxtBox.Name = "passwordTxtBox";
            passwordTxtBox.Size = new Size(201, 27);
            passwordTxtBox.TabIndex = 28;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe Print", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.SeaGreen;
            label3.Location = new Point(8, 317);
            label3.Name = "label3";
            label3.Size = new Size(115, 35);
            label3.TabIndex = 27;
            label3.Text = "Password:";
            // 
            // UserNameTxtBox
            // 
            UserNameTxtBox.Location = new Point(136, 196);
            UserNameTxtBox.Margin = new Padding(3, 4, 3, 4);
            UserNameTxtBox.Name = "UserNameTxtBox";
            UserNameTxtBox.Size = new Size(201, 27);
            UserNameTxtBox.TabIndex = 26;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe Print", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.SeaGreen;
            label2.Location = new Point(8, 189);
            label2.Name = "label2";
            label2.Size = new Size(139, 35);
            label2.TabIndex = 25;
            label2.Text = "UserBName:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe Print", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.SeaGreen;
            label1.Location = new Point(97, 41);
            label1.Name = "label1";
            label1.Size = new Size(192, 70);
            label1.TabIndex = 24;
            label1.Text = "Register";
            // 
            // emailTxtBox
            // 
            emailTxtBox.Location = new Point(136, 261);
            emailTxtBox.Margin = new Padding(3, 4, 3, 4);
            emailTxtBox.Name = "emailTxtBox";
            emailTxtBox.Size = new Size(201, 27);
            emailTxtBox.TabIndex = 31;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe Print", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.SeaGreen;
            label4.Location = new Point(8, 255);
            label4.Name = "label4";
            label4.Size = new Size(80, 35);
            label4.TabIndex = 30;
            label4.Text = "Email:";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(345, 600);
            Controls.Add(emailTxtBox);
            Controls.Add(label4);
            Controls.Add(RegiserBtn);
            Controls.Add(passwordTxtBox);
            Controls.Add(label3);
            Controls.Add(UserNameTxtBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button RegiserBtn;
        private TextBox passwordTxtBox;
        private Label label3;
        private TextBox UserNameTxtBox;
        private Label label2;
        private Label label1;
        private TextBox emailTxtBox;
        private Label label4;
    }
}