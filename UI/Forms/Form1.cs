using Application.Interfaces;
using DigitalNotesManager.Application.Interfaces;
using UIPresentation;
namespace UI.Forms
{
    public partial class Form1 : Form
    {
        private readonly IUserService _userService;
        INoteService _noteService;
        ICategoryService _categoryService;
        public Form1(IUserService userService, INoteService noteService, ICategoryService categoryService)
        {
            _userService = userService;
            _noteService = noteService;
            _categoryService = categoryService;
            InitializeComponent();
        }
        public Form1(IUserService userService)
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
                MainForm mainform = new MainForm(user.Id,_noteService, _categoryService);
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
            Form2 registerForm = new Form2(_userService);
            this.Hide();
            registerForm.ShowDialog();
        }
    }
}
