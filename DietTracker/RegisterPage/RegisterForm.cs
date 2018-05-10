using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Register
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {

        }


        private void Home_Click(object sender, EventArgs e)
        {
            //Redirect button to LandingPage
            LandingPage.LandingPageForm landingPageForm = new LandingPage.LandingPageForm();
            landingPageForm.Tag = this;
            Hide();
            landingPageForm.Show(this);
        }

        private void RegisterPage_Closed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        Register register = new Register("", "", "", "", "", "", "");

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            string user = RegisterPageUsername.Text;
            string pass = RegisterPagePassword.Text;
            string n = RegisterPageName.Text;
            string dob = RegisterPageDoB.Value.ToString("yyyy-MM-dd");
            string h = RegisterPageHeight.Text;
            string w = RegisterPageWeight.Text;
            decimal a = RegisterPageActivity.Value;

            if (register.IsRegisterInfoInput(user, pass, dob, n, h, w))

                try
                {
                    //DateTime dob = Convert.ToDateTime("yyyy-MM-dd");
                    MySqlConnection myRegisterConnection = new MySqlConnection();
                    myRegisterConnection.ConnectionString = "database=diettracker;server=localhost;user id=ApplicationAccess;";

                    MySqlCommand RegisterCommand = new MySqlCommand();
                    RegisterCommand.CommandText = "INSERT INTO username (Username)" +
                        "VALUES ('" + user + "');" +
                        "INSERT INTO password (Password)" +
                        "VALUES ('" + pass + "');" +
                        "INSERT INTO users (Name, DoB, Height, Weight, Activity)" +
                        "VALUES ('" + n + "', '" + dob + "', '" + h + "', '" + w + "', '" + a + "');";

                    RegisterCommand.Connection = myRegisterConnection;
                    myRegisterConnection.Open();
                    RegisterCommand.ExecuteNonQuery();

                    MessageBox.Show("User Successfully created!");
                }
                catch (Exception)
                {
                    MessageBox.Show("That Username is already in use");
                }
            else
            {

            }
        }
    }
}
