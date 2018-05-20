using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainPageGraphs;
using MySql.Data.MySqlClient;


namespace Login
{
    /// <summary>
    /// This is the form a user uses to log in with
    /// </summary>
    public partial class LoginForm : Form
    {
        /// <summary>
        /// The LoginForm is exactly what it sounds like, you log in using the form. 
        /// The form does varius checks to make sure data is written inside the textboxes on it, and if they're correct
        /// If all is good and validated, and the user already exists, you'll be redirected to the approriate Form for your username
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        Login login = new Login("", "");

        private void LoginButton_Click(object sender, EventArgs e)
        {
            //define local variables from the user inputs 
            string user = nametxtbox.Text;
            string pass = pwdtxtbox.Text;

            //check if eligible to be logged in 
            if (login.IsLoggedIn(user, pass))
            {
                MessageBox.Show("You are logged in successfully!");
               /* var Landingpage = (LandingPage.LandingPageForm)Tag;
                Hide();
                Landingpage.Show();*/

                MainPageGraphs.MainPageForm mainPage = new MainPageGraphs.MainPageForm(user);
                mainPage.Tag = this;
                Hide();
                mainPage.Show(this);

            }
            else
            {
                //show default login error message 
                //MessageBox.Show("Login Error!"); //(ikke nødvendigt med alle de andre errors men godt at have med!)
            }
        }

        private void Forgot_password_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Redirect link to forgotten-password-page
            MessageBox.Show("Under development");
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            Register.RegisterForm RegisterForm  = new Register.RegisterForm();
            RegisterForm.Tag = this;
            Hide();
            RegisterForm.Show(this);
        }

        private void LoginForm_Closed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Home_Click(object sender, EventArgs e)
        {
            //Redirect button to LandingPage
            LandingPage.LandingPageForm landingPageForm = new LandingPage.LandingPageForm();
            landingPageForm.Tag = this;
            Hide();
            landingPageForm.Show(this);
        }
    }
}

