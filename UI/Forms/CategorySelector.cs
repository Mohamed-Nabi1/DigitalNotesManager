using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Forms
{
    public class CategorySelector : UserControl
    {

        public event EventHandler<string> CategoryChanged;

        public CategorySelector()
        {
            cmbCategories = new ComboBox { Dock = DockStyle.Fill };
            cmbCategories.Items.AddRange(new string[] { "Work", "Personal", "Ideas", "Other" });
            cmbCategories.SelectedIndexChanged += CmbCategories_SelectedIndexChanged;
            Controls.Add(cmbCategories);
        }

        private void CmbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Raise the custom event when selection changes
            CategoryChanged?.Invoke(this, cmbCategories.SelectedItem.ToString());
        }
        private ComboBox cmbCategories;

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // CategorySelector
            // 
            Name = "CategorySelector";
            Size = new Size(223, 166);
            ResumeLayout(false);
        }
    }
}
