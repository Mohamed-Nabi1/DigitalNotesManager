using Application.Interfaces;
using DigitalNotesManager.Application.Interfaces;
using UIPresentation;
namespace UI.Forms
{
    public partial class LoginForm : Form
    {
        private readonly IUserService _userService;
        private readonly INoteService _noteService;
        private readonly ICategoryService _categoryService;
        public LoginForm(IUserService userService, INoteService noteService, ICategoryService categoryService)
        {
            _userService = userService;
            _noteService = noteService;
            _categoryService = categoryService;
            InitializeComponent();
        }
        public LoginForm(IUserService userService)
        {
            _userService = userService;

            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void LoginBtn_Click(object sender, EventArgs e)
        {

            var email = emailTxtBox.Text;
            var password = passwordTxtBox.Text;
            var userList = await _userService.GetAllUsersAsync();
            var user = userList.ToList().Find(xx => xx.Email == email && xx.Password == password);
            if (user != null)
            {
                MainForm mainform = new MainForm(user.Id, _noteService, _categoryService);
                this.Hide();
                mainform.ShowDialog();
            }
            else
            {
                validationMsgLabel.Text = "Emaill Address Or Password Is Not Valid";
            }
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            RegistrationForm registerForm = new RegistrationForm(_userService, _noteService, _categoryService);
            this.Hide();
            registerForm.ShowDialog();
        }
    }
}
