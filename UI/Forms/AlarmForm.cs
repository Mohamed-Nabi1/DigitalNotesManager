using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

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
            if (noteContent.StartsWith(@"{\rtf"))
            {
                ReminderRichBox.Rtf = noteContent;
            }
            else
            {
                ReminderRichBox.Text = noteContent;
            }

            ReminderRichBox.Visible = true;


        }
        #endregion

        #region Close Alarm Form
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        #endregion
        private void ReminderRichBox_TextChanged(object sender, EventArgs e)
        {

        }

    }
}


