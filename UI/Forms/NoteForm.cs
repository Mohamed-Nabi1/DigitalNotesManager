using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application.Interfaces;
using DigitalNotesManager.Application.DTOs;
using DigitalNotesManager.Application.Interfaces;
using Domain.Entities;

namespace UI.Forms
{
    public partial class NoteForm : Form
    {
        private readonly INoteService _noteService;
        private readonly ICategoryService _categoryService; 
        private FlowLayoutPanel parentPanel;
        private int? noteIdToEdit;
        private DataGridView gridView;
        private MainForm _mainForm;
        private NoteDTO currentNote;

        // Constructor for adding a new note
        public NoteForm(MainForm mainForm, FlowLayoutPanel parent, DataGridView gridView, INoteService noteService, ICategoryService categoryService)
        {
            InitializeComponent();
            _mainForm = mainForm;
            parentPanel = parent;
            this.gridView = gridView;
            _noteService = noteService;
            _categoryService = categoryService;
            LoadCategories();
           // LoadNoteData();
        }

        // Constructor for editing an existing note
        public NoteForm(NoteDTO note, FlowLayoutPanel parent, DataGridView gridView, INoteService noteService, ICategoryService categoryService)
        {
            InitializeComponent();
            parentPanel = parent;
            noteIdToEdit = note.Id;
            currentNote = note;
            this.gridView = gridView;
            _noteService = noteService;
            _categoryService = categoryService;
            LoadCategories(); 
        }

        #region Load Data 
        private async void LoadCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();

            if (categories == null || !categories.Any())
            {
                MessageBox.Show("No categories found!");
                return;
            }

            CategoryComboBox.DataSource = categories;
            CategoryComboBox.DisplayMember = "Name";
            CategoryComboBox.ValueMember = "Id";
            LoadEditNote();
        }

        private void LoadEditNote()
        {
            if (currentNote != null)
            {
                TitleTxt.Text = currentNote.Title;
                richTextBox1.Text = currentNote.Content;
                ReminderPicker.Value = currentNote.ReminderDate ?? DateTime.Now;

                if (CategoryComboBox.DataSource != null)
                {
                    CategoryComboBox.SelectedValue = currentNote.CategoryId;
                }
                else
                {
                    MessageBox.Show("Categories not loaded yet.");
                }
            }
        }

        #endregion

        #region Return Data From File
        public void DisplayFileContent(string contentInFile)
        {
            richTextBox1.Text = contentInFile;
        }

        public string GetFileContent()
        {
            return richTextBox1.Text;
        }

        public RichTextBox GetRichTextBox()
        {
            return richTextBox1;
        }
        #endregion

        #region Apply Text Formatting
        public void StyleBold()
        {
            if (richTextBox1.SelectionFont != null)
            {
                Font current = richTextBox1.SelectionFont;
                FontStyle newStyle = current.Bold ? current.Style & ~FontStyle.Bold : current.Style | FontStyle.Bold;
                richTextBox1.SelectionFont = new Font(current.FontFamily, current.Size, newStyle);
            }
        }

        public void StyleItalic()
        {
            if (richTextBox1.SelectionFont != null)
            {
                Font current = richTextBox1.SelectionFont;
                FontStyle newStyle = current.Italic ? current.Style & ~FontStyle.Italic : current.Style | FontStyle.Italic;
                richTextBox1.SelectionFont = new Font(current.FontFamily, current.Size, newStyle);
            }
        }

        public void StyleUnderline()
        {
            if (richTextBox1.SelectionFont != null)
            {
                Font current = richTextBox1.SelectionFont;
                FontStyle newStyle = current.Underline ? current.Style & ~FontStyle.Underline : current.Style | FontStyle.Underline;
                richTextBox1.SelectionFont = new Font(current.FontFamily, current.Size, newStyle);
            }
        }
        #endregion

        #region Add or Update Note
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            string title = TitleTxt.Text.Trim();
            string content = richTextBox1.Text.Trim();
            DateTime reminderDate = ReminderPicker.Value;
            string categoryText = CategoryComboBox.Text.Trim(); // ✅ Trim for safety

            var selectedCategory = await _categoryService.GetCategoryByNameAsync(categoryText);

            if (selectedCategory == null)
            {
                MessageBox.Show("Selected category not found.");
                return;
            }

            int categoryId = selectedCategory.Id;

            if (!string.IsNullOrWhiteSpace(title) && !string.IsNullOrWhiteSpace(content))
            {
                if (noteIdToEdit != null)
                {
                    var updatedNote = new NoteDTO
                    {
                        Id = noteIdToEdit.Value,
                        Title = title,
                        Content = content,
                        ReminderDate = reminderDate,
                        CreatedDate = DateTime.Now,
                        UserId = 2,
                        CategoryId = categoryId
                    };

                    await _noteService.UpdateNoteAsync(updatedNote);
                }
                else
                {
                    var newNote = new NoteDTO
                    {
                        Title = title,
                        Content = content,
                        ReminderDate = reminderDate,
                        CreatedDate = DateTime.Now,
                        UserId = 2,
                        CategoryId = categoryId
                    };

                    await _noteService.AddNoteAsync(newNote);
                }

                await RefreshParentFormAsync();
                this.Close();
            }
            else
            {
                MessageBox.Show("You should enter a title and content.");
            }
        }

        private async Task RefreshParentFormAsync()
        {
            if (_mainForm != null)
            {
                await _mainForm.LoadNotesInGrid(gridView);
                await _mainForm.LoadNotesInPanel();
            }
        }
        
        #endregion

    }
}
