using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application.Interfaces;
using Application.Services;
using DigitalNotesManager.Application.DTOs;
using DigitalNotesManager.Application.Interfaces;
using UI.Forms;

namespace UI
{
    public partial class NoteCard : UserControl
    {
        private readonly int noteId;
        private readonly DataGridView gridView;
        private readonly INoteService _noteService;

        private readonly ICategoryService _categoryService;

        public NoteCard(NoteDTO note, DataGridView gridView, INoteService noteService, ICategoryService categoryService)
        {
            this.noteId = note.Id;
            this.gridView = gridView;
            this._noteService = noteService;

            InitializeComponent();

            this.BackColor = Color.Bisque;
            this.Padding = new Padding(10);
            this.Margin = new Padding(10);
            this.BorderStyle = BorderStyle.FixedSingle;
            _categoryService = categoryService;
            RefreshDisplayCard(note);
        }

        #region Display CardNote 

        public async Task RefreshDisplayCard(NoteDTO note)
        {
            this.TitleLabel.Text = note.Title;
            this.ReminderDateLabel.Text = note.ReminderDate.HasValue ? note.ReminderDate.Value.ToString() : DateTime.Now.ToString();
            var category = await _categoryService.GetCategoryByIdAsync(note.CategoryId.Value);
            this.CategoryLabel.Text = category != null ? category.Name : "No Category";

        }

        #endregion


        #region Delete | Edit Button
        private async void DeleteNoteBtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("You Want To Delete This Note?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                await _noteService.DeleteNoteAsync(this.noteId);

                if (this.Parent is FlowLayoutPanel parentPanel)
                {
                    parentPanel.Controls.Remove(this);
                    parentPanel.Refresh();
                }

                await RefreshGridView();
            }
        }

        private async void EditNoteBtn_Click(object sender, EventArgs e)
        {
            var note = await _noteService.GetNoteByIdAsync(this.noteId);
            string content = note.Content ?? "";

            NoteForm noteForm = new NoteForm(note, this.Parent as FlowLayoutPanel, gridView, _noteService, _categoryService);
            noteForm.MdiParent = this.ParentForm;

            noteForm.DisplayFileContent(content);

            noteForm.FormClosed += async (s, args) =>
            {
                var updatedNote = await _noteService.GetNoteByIdAsync(this.noteId);
                RefreshDisplayCard(updatedNote);
                await RefreshGridView();
                
            };

            noteForm.Show();
        }

        private async Task RefreshGridView()
        {
            var notes = await _noteService.GetAllNotesAsync();
            gridView.DataSource = notes.Select(n => new { n.Id, n.Title, n.ReminderDate, n.CategoryId,n.CreatedDate,n.UserId }).ToList();
        }

        #endregion

        
    }
}
