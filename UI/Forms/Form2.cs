using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DigitalNotesManager.Application.Interfaces;

namespace UIPresentation
{
    public partial class Form2 : Form
    {
        private readonly IUserService   _userService;
        public Form2(IUserService userService)
        {
            _userService = userService;
            InitializeComponent();
        }

        private async void RegiserBtn_Click(object sender, EventArgs e)
        {
            var email = emailTxtBox.Text;
            var password = passwordTxtBox.Text;
            var userList = await _userService.GetAllUsersAsync();
            var user = userList.ToList().Find(xx => xx.Email == email && xx.Password == password);
            if (user != null)
            {
                //TaskManagment taskManagment = new TaskManagment(user.Id);
                //this.Hide();
                //taskManagment.ShowDialog();
            }
        }
    }
}
