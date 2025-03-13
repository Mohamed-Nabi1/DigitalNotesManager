using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application.Interfaces;
using Application.Services;
using DigitalNotesManager.Application.DTOs;
using DigitalNotesManager.Application.Interfaces;
using Domain.Entities;
using Infrastructure.Context;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UI.Forms
{
    public partial class MainForm : Form
    {
        private readonly INoteService _noteService;
        private readonly ICategoryService _categoryService;
        int idUser;

        #region Constructor
        public MainForm(int id,INoteService noteService, ICategoryService categoryService)
        {
            InitializeComponent(); 
            this.idUser = id;
            _noteService = noteService;
            this.IsMdiContainer = true;
            _categoryService = categoryService;
           
            LoadContent();

        }
        #endregion

        #region  Load Data into GridView And CardNote
        public async Task LoadContent()
        {
            
            await LoadNotesInPanel();
            await LoadNotesInGrid(gridView);


        }
        public async Task LoadNotesInGrid(DataGridView gridView)
        {
            

            if (gridView == null)
            {
                MessageBox.Show("GridView is Not Found");
                return;
            }

            var notes = await _noteService.GetAllNotesAsync(idUser);

            if (notes == null || !notes.Any()) 
            {
                gridView.DataSource = null;  
                return;
            }

            gridView.DataSource = notes.Select(n => new
            {
                n.Id,
                n.Title,
                n.ReminderDate,
                n.CreatedDate,
                n.CategoryId,
                n.UserId
            }).ToList();
        }


        public async Task LoadNotesInPanel()
        {
            ParentPanel.Controls.Clear();

            var notes = await _noteService.GetAllNotesAsync(idUser);

            if (notes == null || !notes.Any())
            {
                MessageBox.Show("No Notes Found ");
                return;
            }

            foreach (var note in notes)
            {
                NoteCard noteCard = new NoteCard(idUser,note, gridView, _noteService, _categoryService);
                ParentPanel.Controls.Add(noteCard);
            }

            ParentPanel.Refresh();
        }
        #endregion


        #region File(New|Open|Save|Exit) Tools IN Menue
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoteForm noteForm = new NoteForm(idUser,this, ParentPanel, gridView, _noteService, _categoryService);
            noteForm.MdiParent = this;
            noteForm.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog
            {
                Title = "Open Text File",
                Filter = "Text Files|*.txt"
            };

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string contentInFile = File.ReadAllText(openFile.FileName);
                NoteForm notepadForm = new NoteForm(idUser, this, ParentPanel, gridView, _noteService, _categoryService);
                notepadForm.MdiParent = this;
                notepadForm.DisplayFileContent(contentInFile);
                notepadForm.Show();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is NoteForm activeNote)
            {
                SaveFileDialog savedFile = new SaveFileDialog();
                if (savedFile.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(savedFile.FileName, activeNote.GetFileContent());
                }
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Close();
            }
        }
        #endregion

        #region  Cut|Copy|Paste Tools In Menue
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is NoteForm activeNote)
            {
                activeNote.GetRichTextBox()?.Cut();
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is NoteForm activeNote)
            {
                activeNote.GetRichTextBox()?.Copy();
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is NoteForm activeNote)
            {
                activeNote.GetRichTextBox()?.Paste();
            }
        }


        #endregion

        #region Format Tool In Menue
        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is NoteForm activeNote)
            {
                activeNote.StyleBold();
            }
        }
        private void italicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is NoteForm activeNote)
            {
                activeNote.StyleItalic();
            }
        }

        private void underLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is NoteForm activeNote)
            {
                activeNote.StyleUnderline();
            }
        }
        #endregion


        #region Note List Tool 
        private async void noteListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView == null)
            {
                gridView = new DataGridView();
                this.Controls.Add(gridView);
            }

            await LoadNotesInGrid(gridView);
        }
        #endregion

        #region Title | Cascade Tools
        private void titleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                foreach (Control control in this.Controls)
                {
                    if (!(control is MenuStrip) && !(control is MdiClient))
                    {
                        control.Visible = false;
                    }
                }
                this.LayoutMdi(MdiLayout.TileVertical);
            }
        }

        private void cascadeToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            foreach (Control control in this.Controls)
            {
                control.Visible = true;
            }

            this.Size = new Size(329, 547);
            this.LayoutMdi(MdiLayout.Cascade);
        }


        #endregion

        #region About Tool
        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();

            aboutForm.ShowDialog();
        }

        #endregion


        #region  Select Item In GridView

        private async void gridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = gridView.Rows[e.RowIndex];

                int selectId = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                var selectNote = await _noteService.GetNoteByIdAsync(selectId);

                if (selectNote != null)
                {
                    NoteForm noteForm = new NoteForm(selectNote, ParentPanel, gridView, _noteService, _categoryService);
                    noteForm.MdiParent = this;
                    noteForm.FormClosed += async (s, args) =>
                    {
                        await LoadContent();
                    };

                    noteForm.Show();
                }
            }

        }

        #endregion


        #region To Show Alarm Form

        private HashSet<int> shownNoteIds = new HashSet<int>();
        private async void alarmBtn_Click(object sender, EventArgs e)
        {
            var notes = await _noteService.GetAllNotesAsync(idUser);
            var reminderNotes = notes.Where(n => n.ReminderDate <= DateTime.Now && !shownNoteIds.Contains(n.Id)).ToList();

            if (reminderNotes.Any())
            {
                foreach (var note in reminderNotes)
                {
                    
                    AlarmForm alarm = new AlarmForm(note.Title, note.Content);
                    alarm.Show();
                    shownNoteIds.Add(note.Id);
                }
            }
            else
            {
                MessageBox.Show("No Reminder Notes");
            }
        }



        #endregion

        #region Search Form Content And Title
        private async void SearchButton_Click(object sender, EventArgs e)
        {

            await SearchAndFilterNotes();
        }

        private async Task SearchAndFilterNotes()
        {
            var notes = await _noteService.GetAllNotesAsync(idUser);

            string searchText = searchBox.Text.Trim().ToLower();

            int selectedCategoryId = comboBox1.SelectedItem != null ? (int)comboBox1.SelectedValue : 0;

            var filteredNotes = notes.Where(n =>
                (string.IsNullOrEmpty(searchText) ||
                 n.Title.ToLower().Contains(searchText) ||
                 n.Content.ToLower().Contains(searchText)) &&
                (selectedCategoryId == 0 || n.CategoryId == selectedCategoryId)
            ).ToList();

            gridView.DataSource = filteredNotes.Select(n => new
            {
                n.Id,
                n.Title,
                n.ReminderDate,
                n.CreatedDate,
                n.CategoryId,
                n.UserId
            }).ToList();
        }

        #endregion

        #region  Sort Notes In Grid View
                private void SortButton_Click(object sender, EventArgs e)
                {
                    if (sortComboBox.SelectedItem == null) return;

                    string selectedSortOption = sortComboBox.SelectedItem.ToString();
                    SortNotes(selectedSortOption);
                }
                private async void SortNotes(string sortBy)
                {

                    var allNotes = await _noteService.GetAllNotesAsync(idUser);
                    if (allNotes == null || !allNotes.Any())
                    {
                        MessageBox.Show("No Notes to Sort");
                        return;
                    }
                    switch (sortBy)
                    {
                        case "Title":
                            allNotes = allNotes.OrderBy(n => n.Title).ToList();
                            break;
                        case "Reminder Date":
                            allNotes = allNotes.OrderBy(n => n.ReminderDate).ToList();
                            break;
                        case "Created Date":
                            allNotes = allNotes.OrderBy(n => n.CreatedDate).ToList();
                            break;
                    }
                    gridView.DataSource = allNotes.Select(n => new
                    {
                        n.Id,
                        n.Title,
                        n.ReminderDate,
                        n.CreatedDate,
                        n.CategoryId,
                        n.UserId
                    }).ToList();
                }

                private async void MainForm_Load(object sender, EventArgs e)
                {
                    sortComboBox.Items.AddRange(new[] { "Title", "Reminder Date", "Created Date" });

                    sortComboBox.SelectedIndex = 0;
                    sortComboBox.SelectedIndexChanged += SortButton_Click;

                     await LoadCategories();
                 }

        #endregion



        #region Load Categories
        private async Task LoadCategories()
        {
            try
            {
                var categories = await _categoryService.GetAllCategoriesAsync();

                if (categories != null && categories.Any())
                {
                    comboBox1.DataSource = categories;
                    comboBox1.DisplayMember = "Name";
                    comboBox1.ValueMember = "Id";
                }
                else
                {
                    MessageBox.Show("There are no categories available!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error event while downloading categories:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion


 
       

    }

}


    

