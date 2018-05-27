using System;
using System.Windows.Forms;


namespace LandingPage
{
    public partial class LandingPageForm : Form
    {
        /// <summary>
        /// This is the Form any user will first interact with, when launching the application
        /// </summary>
        public LandingPageForm()
        {
            InitializeComponent();
        }

        private void LandingPageForm_Load(object sender, EventArgs e)
        {

        }

        private void LandingPageRegister_Click(object sender, EventArgs e)
        {
            Register.RegisterForm RegisterForm = new Register.RegisterForm();
            RegisterForm.Tag = this;
            Hide();
            RegisterForm.Show(this);

        }

        private void LandingPageLogin_Click(object sender, EventArgs e)
        {
            //Redirect button to registrationpage 

            Login.LoginForm LoginForm = new Login.LoginForm();
            LoginForm.Tag = this;
            Hide();
            LoginForm.Show(this);
        }

        private void LandingPage_Closed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
