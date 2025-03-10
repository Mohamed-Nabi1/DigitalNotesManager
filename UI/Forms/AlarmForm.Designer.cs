namespace UI.Forms
{
    partial class AlarmForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            CloseBtn = new Button();
            panel1 = new Panel();
            ReminderTitle = new Label();
            ReminderContent = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Symbol", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 12);
            label1.Name = "label1";
            label1.Size = new Size(314, 31);
            label1.TabIndex = 0;
            label1.Text = " Reminder Date Is Reached";
            // 
            // CloseBtn
            // 
            CloseBtn.BackColor = Color.DarkCyan;
            CloseBtn.Font = new Font("Segoe UI Symbol", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CloseBtn.ForeColor = Color.White;
            CloseBtn.Location = new Point(108, 220);
            CloseBtn.Name = "CloseBtn";
            CloseBtn.Size = new Size(94, 46);
            CloseBtn.TabIndex = 1;
            CloseBtn.Text = "Close";
            CloseBtn.UseVisualStyleBackColor = false;
            CloseBtn.Click += CloseBtn_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkCyan;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(1, -3);
            panel1.Margin = new Padding(5);
            panel1.Name = "panel1";
            panel1.Size = new Size(316, 63);
            panel1.TabIndex = 10;
            // 
            // ReminderTitle
            // 
            ReminderTitle.AutoSize = true;
            ReminderTitle.Font = new Font("Segoe UI Symbol", 13.8F, FontStyle.Bold);
            ReminderTitle.Location = new Point(142, 79);
            ReminderTitle.Name = "ReminderTitle";
            ReminderTitle.Size = new Size(0, 31);
            ReminderTitle.TabIndex = 11;
            // 
            // ReminderContent
            // 
            ReminderContent.AutoSize = true;
            ReminderContent.Font = new Font("Segoe UI Symbol", 13.8F, FontStyle.Bold);
            ReminderContent.Location = new Point(142, 140);
            ReminderContent.Name = "ReminderContent";
            ReminderContent.Size = new Size(0, 31);
            ReminderContent.TabIndex = 12;
            // 
            // AlarmForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(318, 278);
            Controls.Add(ReminderContent);
            Controls.Add(ReminderTitle);
            Controls.Add(panel1);
            Controls.Add(CloseBtn);
            MaximumSize = new Size(336, 325);
            MinimumSize = new Size(336, 325);
            Name = "AlarmForm";
            StartPosition = FormStartPosition.CenterParent;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button CloseBtn;
        private Panel panel1;
        private Label ReminderTitle;
        private Label ReminderContent;
    }
}
