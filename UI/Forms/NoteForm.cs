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
        private bool isSaving = false;
        private CheckedListBox checkedListBox1;
        private CategorySelector categorySelector;
        private TextBox itemInput;
        private Button addItemButton;
        int idUser;


        #region Constructor for adding a new note
        public NoteForm(int id, MainForm mainForm, FlowLayoutPanel parent, DataGridView gridView, INoteService noteService, ICategoryService categoryService)
            {
                InitializeComponent();
                this.idUser = id;
                _mainForm = mainForm;
                parentPanel = parent;
                this.gridView = gridView;
                _noteService = noteService;
                _categoryService = categoryService;
                var categorySelector = new CategorySelector(categoryService) { Dock = DockStyle.None };
                categorySelector.CategoryChanged += CategorySelector_CategoryChanged;
                
                Controls.Add(categorySelector);
                checkedListBox1 = new CheckedListBox
                {
                    Size = new System.Drawing.Size(408, 204),
                    Location = new System.Drawing.Point(10, 108),
                    BackColor = Color.Beige,
                    Visible = true
                };

                Controls.Add(checkedListBox1);
                
        }
        #endregion


        #region Constructor for editing an existing note
            public NoteForm(NoteDTO note, FlowLayoutPanel parent, DataGridView gridView, INoteService noteService, ICategoryService categoryService)
            {
                InitializeComponent();
                parentPanel = parent;
                noteIdToEdit = note.Id;
                currentNote = note;
                this.gridView = gridView;
                _noteService = noteService;
                _categoryService = categoryService;
                LoadEditNote();
                var categorySelector = new CategorySelector(categoryService) { Dock = DockStyle.None };
                categorySelector.CategoryChanged += CategorySelector_CategoryChanged;
                Controls.Add(categorySelector);

                checkedListBox1 = new CheckedListBox
                {
                    Size = new System.Drawing.Size(408, 204),
                    Location = new System.Drawing.Point(10, 108),
                    BackColor = Color.Beige,
                    Visible = true 
                };

                Controls.Add(checkedListBox1);
            }

        #endregion


        #region Event When Change Category
        private void CategorySelector_CategoryChanged(object sender, string newCategory)
        {
            lblCategory.Text = newCategory;

            if (newCategory == "Important")
            {
                richTextBox1.Visible= false;
                checkedListBox1 .Visible = true;
                
                if (checkedListBox1 == null)
                {
                    checkedListBox1 = new CheckedListBox
                    {
                        Size = new System.Drawing.Size(408, 204),
                        Location = new System.Drawing.Point(10, 108),
                        Visible = true
                    };
                }
                checkedListBox1.Items.Clear();
                if (!string.IsNullOrEmpty(currentNote?.Content))
                {
                    string normalText = ConvertRtfTText(currentNote.Content); 
                    var items = normalText.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var item in items)
                    {
                        bool isChecked = item.StartsWith("[x] "); 
                        string itemText = isChecked ? item.Substring(4) : item;
                        checkedListBox1.Items.Add(itemText, isChecked);
                    }
                }

                Controls.Add(checkedListBox1);
                SetupChecklistControls();
                GetChecklistContent();
            }
            else
            {
                if (richTextBox1 == null)
                {
                    richTextBox1 = new RichTextBox
                    {
                        Size = new System.Drawing.Size(408, 232),
                        Location = new System.Drawing.Point(10, 50),
                        BackColor= Color.Beige,
                        Visible = true
                    };
                }

                richTextBox1.Visible = true;
                checkedListBox1.Visible = false;
                Controls.Remove(itemInput);
                Controls.Remove(addItemButton);
                switch (newCategory)
                {
                    case "Work":
                        richTextBox1.BackColor = Color.LightYellow;
                        break;
                    case "Personal":
                        richTextBox1.BackColor = Color.LightGreen;
                        break;
                    case "Not Important":
                        richTextBox1.BackColor = Color.Tan;
                        break;
                    default:
                        richTextBox1.BackColor = Color.White;
                        break;
                }
               
                if (!string.IsNullOrEmpty(currentNote?.Content))
                {
                    try
                    {
                        richTextBox1.Rtf = currentNote.Content; 
                    }
                    catch
                    {
                        richTextBox1.Text = currentNote.Content; 
                    }
                }

                Controls.Add(richTextBox1);
            }
        }

        private string ConvertRtfTText(string rtfContent)
        {
            using (RichTextBox rtb = new RichTextBox())
            {
                try
                {
                    rtb.Rtf = rtfContent;
                    return rtb.Text;
                }
                catch
                {
                    return rtfContent; 
                }
            }
        }

        #endregion


        #region CheckBox Setting 
        private void SetupChecklistControls()
            {

                itemInput = new TextBox
                {
                    Size = new System.Drawing.Size(316, 29),
                    Location = new System.Drawing.Point(12, 314)
                };
            
                addItemButton = new Button
                {
                    Text = "Add",
                    Size = new System.Drawing.Size(77, 29),
                    Location = new System.Drawing.Point(334, 314)
                };
                addItemButton.Click += (s, e) =>
                {
                    if (!string.IsNullOrWhiteSpace(itemInput.Text))
                    {
                        checkedListBox1.Items.Add(itemInput.Text, false);
                        itemInput.Clear();
                    }
                };
                Controls.Add(itemInput);
                Controls.Add(addItemButton);
            }

        private string GetChecklistContent()
            {
                if (checkedListBox1 != null && checkedListBox1.Visible)
                {
                    List<string> items = new List<string>();
                    foreach (var item in checkedListBox1.Items)
                    {
                        items.Add(item.ToString());
                    }
                    return string.Join("\n", items);
                }
                return richTextBox1.Text;
            }


        #endregion


        #region Load Data 
        private async void LoadEditNote()
            {
                if (currentNote != null)
                {
                    TitleTxt.Text = currentNote.Title;
                    ReminderPicker.Value = currentNote.ReminderDate ?? DateTime.Now;
                    if (currentNote.CategoryId.HasValue)
                    {
                        var category = await _categoryService.GetCategoryByIdAsync(currentNote.CategoryId.Value);
                        lblCategory.Text = category != null ? category.Name : "No Category";

                        if (category.Name == "Important")  
                        {
                            ShowCheckList(currentNote.Content);
                            GetChecklistContent();
                        }
                        else
                        {
                            ShowRichText(currentNote.Content);
                        }
                    }
                    else
                    {
                        lblCategory.Text = "No Category";
                        ShowRichText(currentNote.Content);
                    }
                }
            }
        #endregion


        #region  Show CheckList Or RichTextBox Depend On Category
            private void ShowCheckList(string content)
            {
                richTextBox1.Visible = false;
                checkedListBox1.Visible = true;
                checkedListBox1.Items.Clear();

                if (!string.IsNullOrEmpty(content))
                {
                    var items = content.Split('\n');
                    foreach (var item in items)
                    {
                        checkedListBox1.Items.Add(item.Trim(), true);
                    }
                }
            }


            private void ShowRichText(string content)
            {
                richTextBox1.Visible = true;
                checkedListBox1.Visible = false;

                try
                {
                    richTextBox1.Rtf = content; 
                }
                catch
                {
                    richTextBox1.Text = content; 
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
            isSaving = true;

            int userId = idUser;
            string title = TitleTxt.Text.Trim();
            string contentToSave = "";

            if (checkedListBox1.Visible)
            {
                var items = new List<string>();
                foreach (var item in checkedListBox1.Items)
                {
                    items.Add(item.ToString());
                }
                contentToSave = string.Join("\n", items);
            }
            else
            {
                contentToSave = richTextBox1.Rtf; 
            }
            DateTime reminderDate = ReminderPicker.Value;
            string categoryText = lblCategory.Text.Trim();

            var selectedCategory = await _categoryService.GetCategoryByNameAsync(categoryText);

            if (selectedCategory == null)
            {
                MessageBox.Show("Selected Category Not Found");
                isSaving = false; 
                return;
            }

            int categoryId = selectedCategory.Id;

            if (!string.IsNullOrWhiteSpace(title) && !string.IsNullOrWhiteSpace(contentToSave))
            {
                if (noteIdToEdit != null)
                {
                    var updatedNote = new NoteDTO
                    {
                        Id = noteIdToEdit.Value,
                        Title = title,
                        Content = contentToSave,
                        ReminderDate = reminderDate,
                        CreatedDate = DateTime.Now,
                        UserId = userId,
                        CategoryId = categoryId
                    };

                    await _noteService.UpdateNoteAsync(updatedNote);
                }
                else
                {
                    var newNote = new NoteDTO
                    {
                        Title = title,
                        Content = contentToSave,
                        ReminderDate = reminderDate,
                        CreatedDate = DateTime.Now,
                        UserId = userId,
                        CategoryId = categoryId,
                        
                    };

                    await _noteService.AddNoteAsync(newNote);
                }

                await RefreshParentFormAsync();
                this.Close();
            }
            else
            {
                MessageBox.Show("You Should Enter Title And Content.");
                isSaving = false; 
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


        #region Msg For Closing Form
            private void NoteForm_FormClosing(object sender, FormClosingEventArgs e)
            {
                var result = MessageBox.Show("Do You Want to Close ?","Close Form",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        #endregion
    }
}
