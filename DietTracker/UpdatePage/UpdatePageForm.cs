using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using System.Globalization;


namespace DietTracker.UpdatePage
{
    /// <summary>
    /// General Update of user
    /// </summary>
    public partial class UpdatePageForm : Form
    {
        internal string Username;
        /// <summary>
        /// The Update Page takes the information started for the specific user who's logged in, and changes it depending on if any changes was done on the page
        /// The update page will only update the userinformation that the user changes, and anything else will remain unchanged.
        /// </summary>
        public UpdatePageForm(string user)
        {
            this.Username = user;
            InitializeComponent();
        }

        private void MainPageBack_Click(object sender, EventArgs e)
        {
            MySqlConnection conCal = DietTracker.DatabaseConnect.OpenDefaultDBConnection();

            var dateTimeToday = DateTime.Today.ToString("yyyy-MM-dd");
            MySqlCommand whatIsCurrentCalorieCommand = new MySqlCommand();
            whatIsCurrentCalorieCommand.CommandText = "SELECT Calories FROM day WHERE UserID = '" + Username + "' AND Date = '" + dateTimeToday + "';";
            whatIsCurrentCalorieCommand.Connection = conCal;

            conCal.Open();
            MySqlDataReader readCalories = whatIsCurrentCalorieCommand.ExecuteReader();
            readCalories.Read();
            int caloriesRead = readCalories.GetInt32(0);
            conCal.Close();

            MainPageGraphs.MainPageForm mainPageForm = new MainPageGraphs.MainPageForm(Username, caloriesRead);
            mainPageForm.Tag = this;
            Hide();
            mainPageForm.Show(this);
        }
        
        internal void UpdateButton_Click(object sender, EventArgs e)
        {
            DateTime doB;
            var a = 0;
            User orgUser = User.GetUser(Username);
            User tempUser = orgUser.DoUserChange();
            tempUser.password = orgUser.password;
            tempUser.name = orgUser.name;
            doB = Convert.ToDateTime(orgUser.doB);
            tempUser.doB = doB.ToString("yyyy-MM-dd");
            tempUser.doB = tempUser.doB.Substring(0, 10);
            tempUser.height = orgUser.height;
            tempUser.weight = orgUser.weight;
            tempUser.activity = orgUser.activity;
            
            if (UpdatePagePassword.Text != "")
            {
                tempUser.password = UpdatePagePassword.Text;
                a++;
            }
            if (UpdatePageName.Text != "")
            {
                tempUser.name = UpdatePageName.Text;
                a++;
            }
            if (UpdatePageDoB.Value.ToShortDateString() != "10-05-2018")
            {
                tempUser.doB = UpdatePageDoB.Value.ToString("yyyy-MM-dd");
                if(tempUser.doB == "2018-05-10")
                {
                    tempUser.doB = orgUser.doB;
                }
                a++;
            }
            if (UpdatePageHeight.Text != "")
            {
                tempUser.height = Convert.ToInt32(UpdatePageHeight.Text);
                a++;
            }
            if (UpdatePageWeight.Text != "")
            {
                tempUser.weight = Convert.ToDouble(UpdatePageWeight.Text);
                a++;
            }
            if (UpdatePageActivity.Value != 0)
            {
                tempUser.activity = Convert.ToInt32(UpdatePageActivity.Value);
                a++;
            }

            if (tempUser != orgUser)
            {
                try
                {
                    if(!string.IsNullOrEmpty(tempUser.password) && tempUser.password != orgUser.password && 
                        tempUser.IsUpdateInfoCorrect(tempUser.user, tempUser.name, tempUser.doB,
                        Convert.ToInt32(tempUser.height), Convert.ToDouble(tempUser.weight), tempUser.activity, tempUser, orgUser) != false)
                    {
                        MySqlConnection conUpdateU = DatabaseConnect.OpenDefaultDBConnection();
                        MySqlConnection conUpdateP = DatabaseConnect.OpenDefaultDBConnection();
                        
                        MySqlCommand updateUserCommand = new MySqlCommand();
                        MySqlCommand updatePwdCommand = new MySqlCommand();

                        updateUserCommand.CommandText = "UPDATE diettracker.users SET Name = '" + tempUser.name +
                            "', DoB = '" + tempUser.doB + "', Height = '" + tempUser.height + "', Weight = '" + tempUser.weight +
                            "', Activity = '" + tempUser.activity + "' WHERE Username = '" + orgUser.user + "';";

                        updatePwdCommand.CommandText = "UPDATE diettracker.password SET Password = '" + tempUser.password + 
                                                        "' WHERE ForeignID = '" + orgUser.id + "';";

                        updateUserCommand.Connection = conUpdateU;
                        updatePwdCommand.Connection = conUpdateP;

                        conUpdateU.Open();
                        updateUserCommand.ExecuteNonQuery();
                        conUpdateU.Close();

                        conUpdateP.Open();
                        updatePwdCommand.ExecuteNonQuery();
                        conUpdateP.Close();

                        MySqlConnection conFirstW = DatabaseConnect.OpenDefaultDBConnection();
                        MySqlCommand selectFirstWeightValueCommand = new MySqlCommand();
                        selectFirstWeightValueCommand.CommandText = "SELECT Date, Weight from day WHERE UserID = '" + Username + "' AND Date <= COALESCE((SELECT Date FROM day ORDER BY Date ASC LIMIT 1),(SELECT MAX(Date) FROM day));";
                        selectFirstWeightValueCommand.Connection = conFirstW;

                        conFirstW.Open();
                        MySqlDataReader firstWeightRead = selectFirstWeightValueCommand.ExecuteReader();
                        firstWeightRead.Read();
                        string date = firstWeightRead.GetDateTime(0).ToString("yyyy-MM-dd");
                        double weight = firstWeightRead.GetDouble(1);
                        string inputweight = UpdatePageWeight.Text;
                        conFirstW.Close();

                        MySqlConnection conUpdateFW = DatabaseConnect.OpenDefaultDBConnection();
                        MySqlCommand updateFirstWeightValueCommand = new MySqlCommand();
                        updateFirstWeightValueCommand.CommandText = "UPDATE day SET Weight = '" + inputweight + "' WHERE UserID = '" + Username + "' AND Date = '" + date + "' AND Weight = '" + weight + "';";
                        updateFirstWeightValueCommand.Connection = conUpdateFW;

                        conUpdateFW.Open();
                        updateFirstWeightValueCommand.ExecuteNonQuery();
                        conUpdateFW.Close();

                        MySqlConnection conCal = DietTracker.DatabaseConnect.OpenDefaultDBConnection();

                        var dateTimeToday = DateTime.Today.ToString("yyyy-MM-dd");
                        MySqlCommand whatIsCurrentCalorieCommand = new MySqlCommand();
                        whatIsCurrentCalorieCommand.CommandText = "SELECT Calories FROM day WHERE UserID = '" + Username + "' AND Date = '" + dateTimeToday + "';";
                        whatIsCurrentCalorieCommand.Connection = conCal;
                        conCal.Open();
                        MySqlDataReader readCalories = whatIsCurrentCalorieCommand.ExecuteReader();
                        readCalories.Read();
                        int caloriesRead = readCalories.GetInt32(0);
                        conCal.Close();

                        MainPageGraphs.MainPageForm mainPage = new MainPageGraphs.MainPageForm(Username, caloriesRead);
                        mainPage.Tag = this;
                        Hide();
                        mainPage.Show(this);
                    }
                    else if (tempUser.IsUpdateInfoCorrect(tempUser.user, tempUser.name, tempUser.doB,
                        Convert.ToInt32(tempUser.height), Convert.ToDouble(tempUser.weight), tempUser.activity, tempUser, orgUser) != false)
                    {
                        string inputweight = UpdatePageWeight.Text;

                        MySqlConnection conU = DatabaseConnect.OpenDefaultDBConnection();

                        MySqlCommand updateCommand = new MySqlCommand();
                        updateCommand.CommandText = "UPDATE diettracker.users SET Name = '" + tempUser.name + 
                                                     "', DoB = '" + tempUser.doB + "', Height = '" 
                                                    + tempUser.height + "', Weight = '" + inputweight + 
                                                     "', Activity = '" + tempUser.activity + 
                                                    "' WHERE Username = '" + orgUser.user + "';";
                        updateCommand.Connection = conU;

                        conU.Open();
                        updateCommand.ExecuteNonQuery();
                        conU.Close();

                        MySqlConnection conCal = DietTracker.DatabaseConnect.OpenDefaultDBConnection();

                        var dateTimeToday = DateTime.Today.ToString("yyyy-MM-dd");
                        MySqlCommand whatIsCurrentCalorieCommand = new MySqlCommand();
                        whatIsCurrentCalorieCommand.CommandText = "SELECT Calories FROM day WHERE UserID = '" + Username + "' AND Date = '" + dateTimeToday + "';";
                        whatIsCurrentCalorieCommand.Connection = conCal;

                        conCal.Open();
                        MySqlDataReader readCalories = whatIsCurrentCalorieCommand.ExecuteReader();
                        readCalories.Read();
                        int caloriesRead = readCalories.GetInt32(0);
                        conCal.Close();

                        MySqlConnection conFirstW = DatabaseConnect.OpenDefaultDBConnection();
                        MySqlCommand selectFirstWeightValueCommand = new MySqlCommand();
                        selectFirstWeightValueCommand.CommandText = "SELECT Date, Weight from day WHERE UserID = '" + Username + "' AND Date <= COALESCE((SELECT Date FROM day ORDER BY Date ASC LIMIT 1),(SELECT MAX(Date) FROM day));";
                        selectFirstWeightValueCommand.Connection = conFirstW;

                        conFirstW.Open();
                        MySqlDataReader firstWeightRead = selectFirstWeightValueCommand.ExecuteReader();
                        firstWeightRead.Read();
                        string date = firstWeightRead.GetDateTime(0).ToString("yyyy-MM-dd");
                        string weight = firstWeightRead.GetDouble(1).ToString(CultureInfo.InvariantCulture);
                        conFirstW.Close();

                        MySqlConnection conUpdateFW = DatabaseConnect.OpenDefaultDBConnection();
                        MySqlCommand updateFirstWeightValueCommand = new MySqlCommand();
                        updateFirstWeightValueCommand.CommandText = "UPDATE day SET Weight = '" + inputweight + "' WHERE UserID = '" + Username + "' AND Date = '" + date + "' AND Weight = '" + weight + "';";
                        updateFirstWeightValueCommand.Connection = conUpdateFW;
                        conUpdateFW.Open();
                        updateFirstWeightValueCommand.ExecuteNonQuery();
                        conUpdateFW.Close();

                        MainPageGraphs.MainPageForm mainPage = new MainPageGraphs.MainPageForm(Username, caloriesRead);
                        mainPage.Tag = this;
                        Hide();
                        mainPage.Show(this);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something went wrong" + ex);
                }
            }   
        }

        private void UpdatePageActivityButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 = Very little to no exercise at all\n" +
                            "2 = Moderate exercise\n" +
                            "3 = Exercise every day");
        }

        private void RegisterPage_Closed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void UpdatePageForm_Load(object sender, EventArgs e)
        {

        }
    }
}
