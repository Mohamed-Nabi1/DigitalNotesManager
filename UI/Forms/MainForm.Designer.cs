namespace UI.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            pastToolStripMenuItem = new ToolStripMenuItem();
            cutToolStripMenuItem = new ToolStripMenuItem();
            copyToolStripMenuItem = new ToolStripMenuItem();
            pasteToolStripMenuItem = new ToolStripMenuItem();
            formatToolStripMenuItem = new ToolStripMenuItem();
            boldToolStripMenuItem = new ToolStripMenuItem();
            italicToolStripMenuItem = new ToolStripMenuItem();
            underLineToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            noteListToolStripMenuItem = new ToolStripMenuItem();
            arrangeListToolStripMenuItem = new ToolStripMenuItem();
            titleToolStripMenuItem1 = new ToolStripMenuItem();
            cascadeToolStripMenuItem1 = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem1 = new ToolStripMenuItem();
            ParentPanel = new FlowLayoutPanel();
            button1 = new Button();
            alarmBtn = new Button();
            gridView = new DataGridView();
            comboBox1 = new ComboBox();
            searchBox = new TextBox();
            SearchButton = new Button();
            SortButton = new Button();
            sortComboBox = new ComboBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridView).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.LightBlue;
            menuStrip1.Font = new Font("Segoe UI Symbol", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuStrip1.GripStyle = ToolStripGripStyle.Visible;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, pastToolStripMenuItem, viewToolStripMenuItem, aboutToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1579, 31);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, saveToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(53, 27);
            fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(140, 28);
            newToolStripMenuItem.Text = "New";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(140, 28);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(140, 28);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(140, 28);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // pastToolStripMenuItem
            // 
            pastToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cutToolStripMenuItem, copyToolStripMenuItem, pasteToolStripMenuItem, formatToolStripMenuItem });
            pastToolStripMenuItem.Name = "pastToolStripMenuItem";
            pastToolStripMenuItem.Size = new Size(57, 27);
            pastToolStripMenuItem.Text = "Edit";
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.Size = new Size(154, 28);
            cutToolStripMenuItem.Text = "Cut";
            cutToolStripMenuItem.Click += cutToolStripMenuItem_Click;
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.Size = new Size(154, 28);
            copyToolStripMenuItem.Text = "Copy";
            copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.Size = new Size(154, 28);
            pasteToolStripMenuItem.Text = "Paste";
            pasteToolStripMenuItem.Click += pasteToolStripMenuItem_Click;
            // 
            // formatToolStripMenuItem
            // 
            formatToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { boldToolStripMenuItem, italicToolStripMenuItem, underLineToolStripMenuItem });
            formatToolStripMenuItem.Name = "formatToolStripMenuItem";
            formatToolStripMenuItem.Size = new Size(154, 28);
            formatToolStripMenuItem.Text = "Format";
            // 
            // boldToolStripMenuItem
            // 
            boldToolStripMenuItem.Name = "boldToolStripMenuItem";
            boldToolStripMenuItem.Size = new Size(181, 28);
            boldToolStripMenuItem.Text = "Bold";
            boldToolStripMenuItem.Click += boldToolStripMenuItem_Click;
            // 
            // italicToolStripMenuItem
            // 
            italicToolStripMenuItem.Name = "italicToolStripMenuItem";
            italicToolStripMenuItem.Size = new Size(181, 28);
            italicToolStripMenuItem.Text = "Italic";
            italicToolStripMenuItem.Click += italicToolStripMenuItem_Click;
            // 
            // underLineToolStripMenuItem
            // 
            underLineToolStripMenuItem.Name = "underLineToolStripMenuItem";
            underLineToolStripMenuItem.Size = new Size(181, 28);
            underLineToolStripMenuItem.Text = "UnderLine";
            underLineToolStripMenuItem.Click += underLineToolStripMenuItem_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { noteListToolStripMenuItem, arrangeListToolStripMenuItem });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(64, 27);
            viewToolStripMenuItem.Text = "View";
            // 
            // noteListToolStripMenuItem
            // 
            noteListToolStripMenuItem.Name = "noteListToolStripMenuItem";
            noteListToolStripMenuItem.Size = new Size(236, 28);
            noteListToolStripMenuItem.Text = "Note List";
            noteListToolStripMenuItem.Click += noteListToolStripMenuItem_Click;
            // 
            // arrangeListToolStripMenuItem
            // 
            arrangeListToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { titleToolStripMenuItem1, cascadeToolStripMenuItem1 });
            arrangeListToolStripMenuItem.Name = "arrangeListToolStripMenuItem";
            arrangeListToolStripMenuItem.Size = new Size(236, 28);
            arrangeListToolStripMenuItem.Text = "Arrange Window";
            // 
            // titleToolStripMenuItem1
            // 
            titleToolStripMenuItem1.Name = "titleToolStripMenuItem1";
            titleToolStripMenuItem1.Size = new Size(164, 28);
            titleToolStripMenuItem1.Text = "Title";
            titleToolStripMenuItem1.Click += titleToolStripMenuItem1_Click;
            // 
            // cascadeToolStripMenuItem1
            // 
            cascadeToolStripMenuItem1.Name = "cascadeToolStripMenuItem1";
            cascadeToolStripMenuItem1.Size = new Size(164, 28);
            cascadeToolStripMenuItem1.Text = "Cascade";
            cascadeToolStripMenuItem1.Click += cascadeToolStripMenuItem1_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem1 });
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(63, 27);
            aboutToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem1
            // 
            aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            aboutToolStripMenuItem1.Size = new Size(146, 28);
            aboutToolStripMenuItem1.Text = "About";
            aboutToolStripMenuItem1.Click += aboutToolStripMenuItem1_Click;
            // 
            // ParentPanel
            // 
            ParentPanel.AutoScroll = true;
            ParentPanel.BackColor = Color.LightBlue;
            ParentPanel.FlowDirection = FlowDirection.TopDown;
            ParentPanel.Location = new Point(526, 105);
            ParentPanel.Name = "ParentPanel";
            ParentPanel.Size = new Size(334, 581);
            ParentPanel.TabIndex = 1;
            ParentPanel.WrapContents = false;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ControlLight;
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Zoom;
            button1.Location = new Point(1479, 215);
            button1.Name = "button1";
            button1.Size = new Size(68, 59);
            button1.TabIndex = 2;
            button1.UseVisualStyleBackColor = false;
            button1.Click += newToolStripMenuItem_Click;
            // 
            // alarmBtn
            // 
            alarmBtn.BackColor = SystemColors.ControlLight;
            alarmBtn.BackgroundImage = (Image)resources.GetObject("alarmBtn.BackgroundImage");
            alarmBtn.BackgroundImageLayout = ImageLayout.Zoom;
            alarmBtn.Location = new Point(1479, 120);
            alarmBtn.Name = "alarmBtn";
            alarmBtn.Size = new Size(68, 58);
            alarmBtn.TabIndex = 3;
            alarmBtn.UseVisualStyleBackColor = false;
            alarmBtn.Click += alarmBtn_Click;
            // 
            // gridView
            // 
            gridView.BackgroundColor = Color.LightBlue;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = Color.DarkCyan;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            gridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            gridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridView.GridColor = Color.DarkCyan;
            gridView.Location = new Point(908, 346);
            gridView.MinimumSize = new Size(620, 340);
            gridView.Name = "gridView";
            gridView.RowHeadersWidth = 51;
            gridView.Size = new Size(639, 340);
            gridView.TabIndex = 4;
            gridView.CellContentClick += gridView_CellContentClick;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = SystemColors.ButtonFace;
            comboBox1.Font = new Font("Segoe UI Symbol", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(908, 186);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(505, 36);
            comboBox1.TabIndex = 5;
            // 
            // searchBox
            // 
            searchBox.BackColor = SystemColors.ButtonFace;
            searchBox.Font = new Font("Segoe UI Symbol", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            searchBox.Location = new Point(908, 269);
            searchBox.Name = "searchBox";
            searchBox.Size = new Size(387, 34);
            searchBox.TabIndex = 6;
            // 
            // SearchButton
            // 
            SearchButton.BackColor = SystemColors.ControlLight;
            SearchButton.BackgroundImage = (Image)resources.GetObject("SearchButton.BackgroundImage");
            SearchButton.BackgroundImageLayout = ImageLayout.Zoom;
            SearchButton.Location = new Point(1317, 269);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(96, 34);
            SearchButton.TabIndex = 7;
            SearchButton.UseVisualStyleBackColor = false;
            SearchButton.Click += SearchButton_Click;
            // 
            // SortButton
            // 
            SortButton.BackColor = SystemColors.ControlLight;
            SortButton.BackgroundImage = (Image)resources.GetObject("SortButton.BackgroundImage");
            SortButton.BackgroundImageLayout = ImageLayout.Zoom;
            SortButton.Location = new Point(1317, 105);
            SortButton.Name = "SortButton";
            SortButton.Size = new Size(96, 36);
            SortButton.TabIndex = 8;
            SortButton.UseVisualStyleBackColor = false;
            SortButton.Click += SortButton_Click;
            // 
            // sortComboBox
            // 
            sortComboBox.Font = new Font("Segoe UI Symbol", 12F, FontStyle.Bold);
            sortComboBox.FormattingEnabled = true;
            sortComboBox.Location = new Point(908, 105);
            sortComboBox.Name = "sortComboBox";
            sortComboBox.Size = new Size(387, 36);
            sortComboBox.TabIndex = 9;
            // 
            // MainForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.ButtonHighlight;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(1579, 724);
            Controls.Add(sortComboBox);
            Controls.Add(SortButton);
            Controls.Add(SearchButton);
            Controls.Add(searchBox);
            Controls.Add(comboBox1);
            Controls.Add(gridView);
            Controls.Add(alarmBtn);
            Controls.Add(button1);
            Controls.Add(ParentPanel);
            Controls.Add(menuStrip1);
            ForeColor = Color.Maroon;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MaximumSize = new Size(1597, 771);
            MinimumSize = new Size(1597, 771);
            Name = "MainForm";
            Text = "Digital Note Manger";
            TransparencyKey = Color.White;
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem pastToolStripMenuItem;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripMenuItem formatToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem noteListToolStripMenuItem;
        private ToolStripMenuItem arrangeListToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem boldToolStripMenuItem;
        private ToolStripMenuItem italicToolStripMenuItem;
        private ToolStripMenuItem underLineToolStripMenuItem;
        private FlowLayoutPanel ParentPanel;
        private Button button1;
        private Button alarmBtn;
        private DataGridView gridView;
        private ComboBox comboBox1;
        private TextBox searchBox;
        private Button SearchButton;
        private Button SortButton;
        private ToolStripMenuItem aboutToolStripMenuItem1;
        private ToolStripMenuItem titleToolStripMenuItem1;
        private ToolStripMenuItem cascadeToolStripMenuItem1;
        private ComboBox sortComboBox;
    }
}