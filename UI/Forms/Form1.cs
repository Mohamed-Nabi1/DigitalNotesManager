using DigitalNotesManager.Application.Interfaces;
namespace UI.Forms
{
    public partial class Form1 : Form
    {
        private readonly IUserService _userService;
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
            var user = userList.ToList().Find(xx => xx.Email== email && xx.Password == password);
            if (user != null)
            {
                //TaskManagment taskManagment = new TaskManagment(user.Id);
                //this.Hide();
                //taskManagment.ShowDialog();
            }
        }
    }
}
