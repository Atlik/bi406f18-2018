using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Register
{
    public partial class RegisterForm : Form
    {
        /// <summary>
        /// The registerform does a lot of database based saving. It saves to all 3 tables in the database using either default data or data input by a potential user.
        /// The default data is necessary to use the tables dynamicly at a later time.
        /// One example could be the day table, that creates a new row per new date. If a user consumes more valories during that same day, the data for that data will just be updated with a new, higher value.
        /// </summary>

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
            string g = "";

            while (true)
            {
                if (RegisterPageRadioButtonMale.Checked == true)
                {
                    g = RegisterPageRadioButtonMale.Text;
                    break;
                }
                else
                {
                    g = RegisterPageRadioButtonFemale.Text;
                    break;
                }
            }

            if (register.IsRegisterInfoInput(user, pass, dob, n, h, w))
            {
                try
                {
                    MySqlConnection conR = DietTracker.DatabaseConnect.OpenDefaultDBConnection();

                    //First it writes to the user table
                    MySqlCommand registerCommand = new MySqlCommand();
                    registerCommand.CommandText =
                    "INSERT INTO diettracker.users (Username, Name, Gender, DoB, Height, Weight, Activity)" +
                    "VALUES ('" + user + "', '" + n + "', '" + g + "', '" + dob + "', '" + h + "', '" + w + "', '" + a + "');";
                    registerCommand.Connection = conR;

                    conR.Open();
                    registerCommand.ExecuteNonQuery();
                    conR.Close();

                    //It then takes the ID from the user table to use it
                    MySqlCommand idCommand = new MySqlCommand();
                    idCommand.CommandText = "SELECT ID FROM users WHERE Username = '" + user + "';";
                    idCommand.Connection = conR;

                    conR.Open();
                    MySqlDataReader IDRead = idCommand.ExecuteReader();
                    IDRead.Read();
                    string UserID = IDRead.GetString(0);
                    var ID = String.Format("{0}", UserID);
                    UserID = ID;
                    conR.Close();

                    //It inserts into the password table the password and the ID that corresponded to the user table
                    MySqlCommand passwordCommand = new MySqlCommand();
                    passwordCommand.CommandText = "INSERT INTO diettracker.password (Password, ForeignID) " +
                        "VALUES ('" + pass + "', '" + UserID + "');";
                    passwordCommand.Connection = conR;
                    conR.Open();
                    passwordCommand.ExecuteNonQuery();
                    conR.Close();

                    var dateTimeToday = DateTime.Today.ToString("yyyy-MM-dd");
                    MySqlCommand dayCommand = new MySqlCommand();
                    dayCommand.CommandText = "INSERT INTO diettracker.day (Date, Weight, Calories, UserID)" +
                        "VALUES ('" + dateTimeToday + "', '" + w + "', '0', '" + user + "');";
                    dayCommand.Connection = conR;
                    conR.Open();
                    dayCommand.ExecuteNonQuery();
                    conR.Close();

                    MessageBox.Show("User Successfully created!");

                    Login.LoginForm loginForm = new Login.LoginForm();
                    loginForm.Tag = this;
                    Hide();
                    loginForm.Show(this);
                }
                catch (MySqlException ex)
                {
                    //MessageBox.Show("Something happened" + ex);
                    switch (ex.Number)
                    {
                        case 0:
                            MessageBox.Show("Cannot connect to server.");
                            break;
                        case 1062:
                            MessageBox.Show("That Username is already in use");
                            break;
                        case 1264:
                            MessageBox.Show("You can't be higher than 255 cm (Come on, you're not that tall)");
                            break;
                    }
                }

                catch (Exception)
                {
                    MessageBox.Show("Something unexpected happened");
                }
            }
        }

        private void RegisterTextHeight_Remove(object sender, EventArgs e)
        {
            if (RegisterPageHeight.Text == "in cm")
                RegisterPageHeight.Text = "";
        }

        private void RegisterTextHeight_Add(object sender, EventArgs e)
        {
            if (RegisterPageHeight.Text == "")
                RegisterPageHeight.Text = "in cm";

        }

        private void RegisterTextWeight_Remove(object sender, EventArgs e)
        {
            if (RegisterPageWeight.Text == "in kg")
                RegisterPageWeight.Text = "";
        }

        private void RegisterTextWeight_Add(object sender, EventArgs e)
        {
            if (RegisterPageWeight.Text == "")
                RegisterPageWeight.Text = "in kg";
        }

        private void RegisterPageActivityButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 = Very little to no exercise at all\n" +
                "2 = Moderate exercise\n" +
                "3 = Exercise every day");

        }
    }
}
