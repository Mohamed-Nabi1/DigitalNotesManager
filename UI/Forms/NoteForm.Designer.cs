namespace UI.Forms
{
    partial class NoteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoteForm));
            richTextBox1 = new RichTextBox();
            ReminderPicker = new DateTimePicker();
            TitleTxt = new TextBox();
            btnAdd = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            lblCategory = new Label();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(10, 108);
            richTextBox1.Margin = new Padding(5, 4, 5, 4);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(408, 232);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // ReminderPicker
            // 
            ReminderPicker.CalendarForeColor = Color.Maroon;
            ReminderPicker.CalendarTitleForeColor = Color.Maroon;
            ReminderPicker.Location = new Point(12, 395);
            ReminderPicker.Margin = new Padding(5, 4, 5, 4);
            ReminderPicker.Name = "ReminderPicker";
            ReminderPicker.Size = new Size(408, 31);
            ReminderPicker.TabIndex = 2;
            // 
            // TitleTxt
            // 
            TitleTxt.Location = new Point(91, 24);
            TitleTxt.Margin = new Padding(5, 4, 5, 4);
            TitleTxt.Name = "TitleTxt";
            TitleTxt.Size = new Size(327, 31);
            TitleTxt.TabIndex = 3;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.DarkCyan;
            btnAdd.Font = new Font("Segoe UI Symbol", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(30, 541);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(351, 42);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "ADD NOTE";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Symbol", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(10, 17);
            label1.Name = "label1";
            label1.Size = new Size(75, 38);
            label1.TabIndex = 6;
            label1.Text = "Title";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Symbol", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DarkCyan;
            label2.Location = new Point(10, 73);
            label2.Name = "label2";
            label2.Size = new Size(102, 31);
            label2.TabIndex = 7;
            label2.Text = "Content";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Symbol", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.DarkCyan;
            label3.Location = new Point(12, 360);
            label3.Name = "label3";
            label3.Size = new Size(180, 31);
            label3.TabIndex = 8;
            label3.Text = "Reminder Date";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Symbol", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.DarkCyan;
            label4.Location = new Point(12, 446);
            label4.Name = "label4";
            label4.Size = new Size(134, 31);
            label4.TabIndex = 9;
            label4.Text = "Category : ";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.BackColor = Color.Transparent;
            lblCategory.Font = new Font("Segoe UI Symbol", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCategory.Location = new Point(152, 446);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(0, 31);
            lblCategory.TabIndex = 10;
            // 
            // NoteForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(432, 586);
            Controls.Add(lblCategory);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnAdd);
            Controls.Add(TitleTxt);
            Controls.Add(ReminderPicker);
            Controls.Add(richTextBox1);
            Font = new Font("Segoe UI Symbol", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.DarkSlateGray;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 4, 5, 4);
            Name = "NoteForm";
            Text = "Note Form";
            FormClosing += NoteForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox richTextBox1;
        private DateTimePicker ReminderPicker;
        private TextBox TitleTxt;
        private Button btnAdd;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label lblCategory;
    }
}