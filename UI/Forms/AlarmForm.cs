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
        public string noteTitle;
        private string noteContent;

        #region Constructor
        public AlarmForm(string _title, string _content)
        {
            InitializeComponent();
            this.noteTitle = _title;
            this.noteContent = _content;
            DisplayReminder();
        }
        #endregion

        #region Display Content Of Note Reminder
            private void DisplayReminder()
            {
                ReminderTitle.Text = noteTitle;
                ReminderRichBox.Rtf = noteContent;
            }
        #endregion

        #region Close Alarm Form
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        #endregion 
    }

}
