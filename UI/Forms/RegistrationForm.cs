using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application.Interfaces;
using DigitalNotesManager.Application.DTOs;
using DigitalNotesManager.Application.Interfaces;
using DigitalNotesManager.Application.Services;
using Infrastructure.Repositories;
using UI.Forms;

namespace UIPresentation
{
    public partial class RegistrationForm : Form
    {
        private readonly IUserService _userService;
        INoteService _noteService;
        ICategoryService _categoryService;
        public RegistrationForm(IUserService userService,INoteService noteService,ICategoryService categoryService)
        {
            _noteService= noteService;
            _categoryService= categoryService;
            _userService = userService;
            InitializeComponent();
        }

        private async void RegiserBtn_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(emailTxtBox.Text)|| string.IsNullOrEmpty(passwordTxtBox.Text) ||string.IsNullOrEmpty( UserNameTxtBox.Text) )
            {
                validationMsgLabel.Text = "Please Complete All Required Data";
            }
            else
            {
                var email = emailTxtBox.Text;
                var password = passwordTxtBox.Text;
                var username = UserNameTxtBox.Text;
                UserDTO userDTO = new UserDTO() { Email=email,Password=password,Username=username};

                await _userService.AddUserAsync(userDTO);

                LoginForm login = new LoginForm(_userService, _noteService, _categoryService);
                this.Hide();
                login.ShowDialog();
            }
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
