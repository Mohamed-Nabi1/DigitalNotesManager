using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application.Interfaces;
using Application.Services;
using DigitalNotesManager.Application.DTOs;
using DigitalNotesManager.Application.Interfaces;
using Infrastructure.Context;

namespace UI.Forms
{
    public partial class MainForm : Form
    {
        INoteService _noteService;
        ICategoryService _categoryService;

        public MainForm(INoteService noteService, ICategoryService categoryService)
        {
            InitializeComponent();
            _noteService = noteService;
            this.IsMdiContainer = true;
            _categoryService = categoryService;
            LoadContent();
        }


        #region  Load Data into GridView And CardNote
        private async Task LoadContent()
        {
            await LoadNotesInPanel();
            await LoadNotesInGrid(gridView);
            

        }

        public async Task LoadNotesInGrid(DataGridView gridView)
        {
            var notes = await _noteService.GetAllNotesAsync();
            gridView.DataSource = notes.Select(n => new { n.Id, n.Title, n.ReminderDate, n.CreatedDate, 
                n.CategoryId ,n.UserId }).ToList();

        }

        public async Task LoadNotesInPanel()
        {
            ParentPanel.Controls.Clear();
            var notes = await _noteService.GetAllNotesAsync();

            foreach (var note in notes)
            {
                NoteCard noteCard = new NoteCard(note, gridView, _noteService, _categoryService);
                ParentPanel.Controls.Add(noteCard);
            }

            ParentPanel.Refresh();
        }
        #endregion


        #region File(New|Open|Save|Exit) Tools IN Menue
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoteForm noteForm = new NoteForm(this, ParentPanel, gridView, _noteService, _categoryService);
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
                NoteForm notepadForm = new NoteForm(this, ParentPanel, gridView, _noteService, _categoryService);
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
            var notes = await _noteService.GetAllNotesAsync();
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
                MessageBox.Show("No Reminders Note");
            }
        }

        #endregion
    }

}


    

