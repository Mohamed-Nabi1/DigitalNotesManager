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
using System.Net.Mail;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
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
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            string usernamePattern = @"^[a-zA-Z0-9](?:[a-zA-Z0-9_]{1,18}[a-zA-Z0-9])?$";
            if (string.IsNullOrEmpty(emailTxtBox.Text)|| string.IsNullOrEmpty(passwordTxtBox.Text) ||string.IsNullOrEmpty( UserNameTxtBox.Text) )
            {
                validationMsgLabel.Text = "Please Complete All Required Data";
            }
            else if (!Regex.IsMatch(UserNameTxtBox.Text, usernamePattern))
            {
                validationMsgLabel.Text = "userName is invalid please sure it 3-20 characters," +"\n"+
                    " only has letters, numbers, and underscores and no whitespace";
            }
            else if (!Regex.IsMatch(emailTxtBox.Text, emailPattern))
            {
                validationMsgLabel.Text = "email is invalid";
            }
            else
            {
                var email = emailTxtBox.Text;
                var password = passwordTxtBox.Text;
                var username = UserNameTxtBox.Text;
                
                UserDTO userDTO = new UserDTO() { Email=email,Password=password,Username=username};

                bool isRegistered = await _userService.RegisterUserAsync(userDTO);

                if (isRegistered)
                {
                    LoginForm login = new LoginForm(_userService, _noteService, _categoryService);
                    this.Hide();
                    login.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Username already exists.");
                }
            }
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
