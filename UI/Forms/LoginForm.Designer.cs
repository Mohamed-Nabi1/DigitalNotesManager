namespace UI.Forms
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            LoginBtn = new Button();
            passwordTxtBox = new TextBox();
            label3 = new Label();
            emailTxtBox = new TextBox();
            label2 = new Label();
            label1 = new Label();
            registerBtn = new Button();
            validationMsgLabel = new Label();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // LoginBtn
            // 
            LoginBtn.BackColor = Color.DarkCyan;
            LoginBtn.Font = new Font("Segoe Print", 18F);
            LoginBtn.ForeColor = Color.White;
            LoginBtn.Location = new Point(1015, 532);
            LoginBtn.Margin = new Padding(3, 4, 3, 4);
            LoginBtn.Name = "LoginBtn";
            LoginBtn.Size = new Size(368, 62);
            LoginBtn.TabIndex = 23;
            LoginBtn.Text = "LogIn";
            LoginBtn.UseVisualStyleBackColor = false;
            LoginBtn.Click += LoginBtn_Click;
            // 
            // passwordTxtBox
            // 
            passwordTxtBox.Font = new Font("Segoe UI Symbol", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            passwordTxtBox.Location = new Point(1104, 381);
            passwordTxtBox.Margin = new Padding(3, 4, 3, 4);
            passwordTxtBox.Name = "passwordTxtBox";
            passwordTxtBox.Size = new Size(319, 34);
            passwordTxtBox.TabIndex = 22;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe Print", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.DarkCyan;
            label3.Location = new Point(891, 368);
            label3.Name = "label3";
            label3.Size = new Size(174, 52);
            label3.TabIndex = 21;
            label3.Text = "Password:";
            // 
            // emailTxtBox
            // 
            emailTxtBox.Font = new Font("Segoe UI Symbol", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            emailTxtBox.Location = new Point(1104, 281);
            emailTxtBox.Margin = new Padding(3, 4, 3, 4);
            emailTxtBox.Name = "emailTxtBox";
            emailTxtBox.Size = new Size(319, 34);
            emailTxtBox.TabIndex = 20;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe Print", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DarkCyan;
            label2.Location = new Point(891, 272);
            label2.Name = "label2";
            label2.Size = new Size(119, 52);
            label2.TabIndex = 19;
            label2.Text = "Email:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe Print", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(1044, 63);
            label1.Name = "label1";
            label1.Size = new Size(279, 141);
            label1.TabIndex = 18;
            label1.Text = "LogIn";
            // 
            // registerBtn
            // 
            registerBtn.BackColor = Color.LightBlue;
            registerBtn.Font = new Font("Segoe Print", 18F);
            registerBtn.ForeColor = Color.Black;
            registerBtn.Location = new Point(1015, 627);
            registerBtn.Name = "registerBtn";
            registerBtn.Size = new Size(368, 62);
            registerBtn.TabIndex = 24;
            registerBtn.Text = "Register";
            registerBtn.UseVisualStyleBackColor = false;
            registerBtn.Click += registerBtn_Click;
            // 
            // validationMsgLabel
            // 
            validationMsgLabel.AutoSize = true;
            validationMsgLabel.BackColor = Color.Transparent;
            validationMsgLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            validationMsgLabel.ForeColor = Color.White;
            validationMsgLabel.Location = new Point(1002, 444);
            validationMsgLabel.Name = "validationMsgLabel";
            validationMsgLabel.Size = new Size(92, 28);
            validationMsgLabel.TabIndex = 25;
            validationMsgLabel.Text = "                ";
            validationMsgLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Location = new Point(2, -3);
            panel1.Name = "panel1";
            panel1.Size = new Size(684, 804);
            panel1.TabIndex = 26;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1579, 724);
            Controls.Add(panel1);
            Controls.Add(validationMsgLabel);
            Controls.Add(registerBtn);
            Controls.Add(LoginBtn);
            Controls.Add(passwordTxtBox);
            Controls.Add(label3);
            Controls.Add(emailTxtBox);
            Controls.Add(label2);
            Controls.Add(label1);
            ForeColor = Color.White;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MaximumSize = new Size(1597, 771);
            MinimumSize = new Size(1597, 771);
            Name = "LoginForm";
            Text = "Login";
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
        private Button registerBtn;
        private Label validationMsgLabel;
        private Panel panel1;
    }
}
