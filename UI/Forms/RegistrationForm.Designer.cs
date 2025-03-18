namespace UIPresentation
{
    partial class RegistrationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrationForm));
            RegiserBtn = new Button();
            passwordTxtBox = new TextBox();
            label3 = new Label();
            UserNameTxtBox = new TextBox();
            label2 = new Label();
            label1 = new Label();
            emailTxtBox = new TextBox();
            label4 = new Label();
            validationMsgLabel = new Label();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // RegiserBtn
            // 
            RegiserBtn.BackColor = Color.DarkCyan;
            RegiserBtn.Font = new Font("Segoe Print", 18F);
            RegiserBtn.ForeColor = Color.White;
            RegiserBtn.Location = new Point(717, 419);
            RegiserBtn.Name = "RegiserBtn";
            RegiserBtn.Size = new Size(322, 46);
            RegiserBtn.TabIndex = 4;
            RegiserBtn.Text = "Register";
            RegiserBtn.UseVisualStyleBackColor = false;
            RegiserBtn.Click += RegiserBtn_Click;
            // 
            // passwordTxtBox
            // 
            passwordTxtBox.Font = new Font("Segoe UI Symbol", 12F, FontStyle.Bold);
            passwordTxtBox.Location = new Point(789, 307);
            passwordTxtBox.Name = "passwordTxtBox";
            passwordTxtBox.Size = new Size(280, 29);
            passwordTxtBox.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe Print", 18F);
            label3.ForeColor = Color.DarkCyan;
            label3.Location = new Point(571, 299);
            label3.Name = "label3";
            label3.Size = new Size(139, 42);
            label3.TabIndex = 27;
            label3.Text = "Password:";
            // 
            // UserNameTxtBox
            // 
            UserNameTxtBox.Font = new Font("Segoe UI Symbol", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UserNameTxtBox.Location = new Point(789, 191);
            UserNameTxtBox.Name = "UserNameTxtBox";
            UserNameTxtBox.Size = new Size(280, 29);
            UserNameTxtBox.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe Print", 18F);
            label2.ForeColor = Color.DarkCyan;
            label2.Location = new Point(565, 178);
            label2.Name = "label2";
            label2.Size = new Size(148, 42);
            label2.TabIndex = 25;
            label2.Text = "UserName:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe Print", 48F, FontStyle.Bold);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(671, 9);
            label1.Name = "label1";
            label1.Size = new Size(304, 112);
            label1.TabIndex = 24;
            label1.Text = "Register";
            // 
            // emailTxtBox
            // 
            emailTxtBox.Font = new Font("Segoe UI Symbol", 12F, FontStyle.Bold);
            emailTxtBox.Location = new Point(789, 251);
            emailTxtBox.Name = "emailTxtBox";
            emailTxtBox.Size = new Size(280, 29);
            emailTxtBox.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe Print", 18F);
            label4.ForeColor = Color.DarkCyan;
            label4.Location = new Point(565, 243);
            label4.Name = "label4";
            label4.Size = new Size(94, 42);
            label4.TabIndex = 30;
            label4.Text = "Email:";
            // 
            // validationMsgLabel
            // 
            validationMsgLabel.AutoSize = true;
            validationMsgLabel.BackColor = Color.Transparent;
            validationMsgLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            validationMsgLabel.ForeColor = Color.White;
            validationMsgLabel.Location = new Point(671, 362);
            validationMsgLabel.Name = "validationMsgLabel";
            validationMsgLabel.Size = new Size(74, 21);
            validationMsgLabel.TabIndex = 32;
            validationMsgLabel.Text = "                ";
            validationMsgLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Location = new Point(1, 1);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(510, 603);
            panel1.TabIndex = 33;
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1199, 515);
            Controls.Add(panel1);
            Controls.Add(validationMsgLabel);
            Controls.Add(emailTxtBox);
            Controls.Add(label4);
            Controls.Add(RegiserBtn);
            Controls.Add(passwordTxtBox);
            Controls.Add(label3);
            Controls.Add(UserNameTxtBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(1399, 588);
            MinimumSize = new Size(1196, 554);
            Name = "RegistrationForm";
            Text = "Registration";
            TopMost = true;
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
        private Label validationMsgLabel;
        private Panel panel1;
    }
}