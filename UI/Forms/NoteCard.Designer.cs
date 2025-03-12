namespace UI
{
    partial class NoteCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoteCard));
            TitleLabel = new Label();
            CategoryLabel = new Label();
            ReminderDateLabel = new Label();
            EditNoteBtn = new Button();
            DeleteNoteBtn = new Button();
            SuspendLayout();
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.Location = new Point(21, 12);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(38, 20);
            TitleLabel.TabIndex = 0;
            TitleLabel.Text = "Title";
            // 
            // CategoryLabel
            // 
            CategoryLabel.AutoSize = true;
            CategoryLabel.Location = new Point(97, 12);
            CategoryLabel.Name = "CategoryLabel";
            CategoryLabel.Size = new Size(69, 20);
            CategoryLabel.TabIndex = 1;
            CategoryLabel.Text = "Category";
            // 
            // ReminderDateLabel
            // 
            ReminderDateLabel.AutoSize = true;
            ReminderDateLabel.Location = new Point(21, 69);
            ReminderDateLabel.Name = "ReminderDateLabel";
            ReminderDateLabel.Size = new Size(109, 20);
            ReminderDateLabel.TabIndex = 2;
            ReminderDateLabel.Text = "Reminder Date";
            // 
            // EditNoteBtn
            // 
            EditNoteBtn.BackColor = SystemColors.Control;
            EditNoteBtn.BackgroundImage = (Image)resources.GetObject("EditNoteBtn.BackgroundImage");
            EditNoteBtn.BackgroundImageLayout = ImageLayout.Zoom;
            EditNoteBtn.Location = new Point(214, 12);
            EditNoteBtn.Name = "EditNoteBtn";
            EditNoteBtn.Size = new Size(59, 41);
            EditNoteBtn.TabIndex = 3;
            EditNoteBtn.UseVisualStyleBackColor = false;
            EditNoteBtn.Click += EditNoteBtn_Click;
            // 
            // DeleteNoteBtn
            // 
            DeleteNoteBtn.BackColor = SystemColors.Control;
            DeleteNoteBtn.BackgroundImage = (Image)resources.GetObject("DeleteNoteBtn.BackgroundImage");
            DeleteNoteBtn.BackgroundImageLayout = ImageLayout.Zoom;
            DeleteNoteBtn.Location = new Point(214, 59);
            DeleteNoteBtn.Name = "DeleteNoteBtn";
            DeleteNoteBtn.Size = new Size(59, 41);
            DeleteNoteBtn.TabIndex = 4;
            DeleteNoteBtn.UseVisualStyleBackColor = false;
            DeleteNoteBtn.Click += DeleteNoteBtn_Click;
            // 
            // NoteCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            Controls.Add(DeleteNoteBtn);
            Controls.Add(EditNoteBtn);
            Controls.Add(ReminderDateLabel);
            Controls.Add(CategoryLabel);
            Controls.Add(TitleLabel);
            Name = "NoteCard";
            Size = new Size(300, 121);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TitleLabel;
        private Label CategoryLabel;
        private Label ReminderDateLabel;
        private Button EditNoteBtn;
        private Button DeleteNoteBtn;
    }
}
