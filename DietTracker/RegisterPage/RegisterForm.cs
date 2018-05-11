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


                    //First it writes to the user table
                    MySqlCommand RegisterCommand = new MySqlCommand();
                    RegisterCommand.CommandText =
                    "INSERT INTO diettracker.users (Username, Name, DoB, Height, Weight, Activity)" +
                    "VALUES ('" + user + "', '" + n + "', '" + dob + "', '" + h + "', '" + w + "', '" + a + "');";
                    RegisterCommand.Connection = myRegisterConnection;
                    myRegisterConnection.Open();
                    RegisterCommand.ExecuteNonQuery();
                    myRegisterConnection.Close();

                    //It then takes the ID from the user table to use it
                    MySqlCommand IDCommand = new MySqlCommand();
                    IDCommand.CommandText = "SELECT ID FROM users WHERE Username = '" + user + "';";
                    IDCommand.Connection = myRegisterConnection;
                    myRegisterConnection.Open();
                    MySqlDataReader IDRead = IDCommand.ExecuteReader();
                    IDRead.Read();
                    string UserID = IDRead.GetString(0);
                    var ID = String.Format("{0}", UserID);
                    UserID = ID;
                    myRegisterConnection.Close();

                    //It inserts into the password table the password and the ID that corresponded to the user table
                    MySqlCommand PasswordCommand = new MySqlCommand();
                    PasswordCommand.CommandText = "INSERT INTO diettracker.password (Password, ForeignID) " +
                        "VALUES ('" + pass + "', '" + UserID + "');";
                    PasswordCommand.Connection = myRegisterConnection;
                    myRegisterConnection.Open();
                    PasswordCommand.ExecuteNonQuery();
                    myRegisterConnection.Close();

                    MessageBox.Show("User Successfully created!");

                }
                catch (MySqlException ex)
                {
                    switch (ex.Number)
                    {
                        case 0:
                            MessageBox.Show("Cannot connect to server.");
                            break;
                        case 1062:
                            MessageBox.Show("That Username is already in use");
                            break;
                    }
                }

                catch (Exception)
                {
                    MessageBox.Show("That Username is already in use");
                }
            else
            {
                
            }
        }

        private void RegisterTextHeight_Remove(object sender, EventArgs e)
        {
            RegisterPageHeight.Text = "";
        }

        private void RegisterTextWeight_Remove(object sender, EventArgs e)
        {
            RegisterPageWeight.Text = "";
        }

        private void RegisterPageActivityButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 = Very little to no exercise at all\n" +
                "2 = Moderate exercise\n" +
                "3 = Exercise every day");
        }
    }
}
