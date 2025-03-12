using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using Application.Interfaces;

public class CategorySelector : UserControl
{
    private ComboBox cmbCategories;
    private readonly ICategoryService _categoryService;
    public event EventHandler<string> CategoryChanged;

    #region Constructor
        public CategorySelector(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            InitializeComponent();
            LoadCategoriesAsync();
        }
    #endregion

    #region To Initialize Component
        private void InitializeComponent()
        {
            cmbCategories = new ComboBox();
            SuspendLayout();

            cmbCategories.Location = new Point(0, 0);
            cmbCategories.Name = "cmbCategories";
            cmbCategories.Size = new Size(408, 31);
            cmbCategories.TabIndex = 0;
            cmbCategories.SelectedIndexChanged += CmbCategories_SelectedIndexChanged;

            Controls.Add(cmbCategories);
            Location = new Point(14, 490);
            Name = "CategorySelector";
            Padding = new Padding(20, 20, 0, 0);
            Size = new Size(408, 31);
            ResumeLayout(false);
        }
    #endregion

    #region Load Category From DataBase Into ComboBox
        private async void LoadCategoriesAsync()
        {
                var categories = await _categoryService.GetAllCategoriesAsync();
                if (categories == null || !categories.Any())
                {
                    MessageBox.Show("No Categories Found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                cmbCategories.Invoke((MethodInvoker)delegate
                {
                    cmbCategories.Items.Clear();
                    foreach (var category in categories)
                    {
                        cmbCategories.Items.Add(category.Name);
                    }
                });
        }
    #endregion

    #region To Fire Event
        private void CmbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
        
            CategoryChanged?.Invoke(this, cmbCategories.SelectedItem?.ToString());
        }

    #endregion

    #region Select Category
    public void SetSelectedCategory(string categoryName)
    {
        if (cmbCategories.Items.Contains(categoryName))
        {
            cmbCategories.SelectedItem = categoryName;
        }
    }

    #endregion
}