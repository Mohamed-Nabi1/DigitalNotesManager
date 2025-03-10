using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class AlarmForm : Form  
    {
        private string noteTitle;
        private string noteContent;

        public AlarmForm(string _title,string _content)
        {
            InitializeComponent();
            this.noteTitle = _title;
            this.noteContent = _content;
            DisplayReminder();
        }

        private void DisplayReminder()
        {
            ReminderTitle.Text= noteTitle;
            ReminderContent.Text = noteContent;
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }

}
