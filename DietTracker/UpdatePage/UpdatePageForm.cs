using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            MySqlCommand WhatIsCurrentCalorieCommand = new MySqlCommand();
            WhatIsCurrentCalorieCommand.CommandText = "SELECT Calories FROM day WHERE UserID = '" + Username + "' AND Date = '" + dateTimeToday + "';";
            WhatIsCurrentCalorieCommand.Connection = conCal;
            conCal.Open();
            MySqlDataReader ReadCalories = WhatIsCurrentCalorieCommand.ExecuteReader();
            ReadCalories.Read();
            int CaloriesRead = ReadCalories.GetInt32(0);
            conCal.Close();

            MainPageGraphs.MainPageForm mainPageForm = new MainPageGraphs.MainPageForm(Username, CaloriesRead);
            mainPageForm.Tag = this;
            Hide();
            mainPageForm.Show(this);
        }

        internal void UpdateButton_Click(object sender, EventArgs e)
        {
            DateTime doB;
            var a = 0;
            User Orguser = User.GetUser(Username);
            User Tempuser = Orguser.DoUserChange();
            Tempuser.password = Orguser.password;
            Tempuser.name = Orguser.name;
            doB = Convert.ToDateTime(Orguser.doB);
            Tempuser.doB = doB.ToString("yyyy-MM-dd");
            Tempuser.doB = Tempuser.doB.Substring(0, 10);
            Tempuser.height = Orguser.height;
            Tempuser.weight = Orguser.weight;
            Tempuser.activity = Orguser.activity;



            if (UpdatePagePassword.Text != "")
            {
                Tempuser.password = UpdatePagePassword.Text;
                a++;
            }
            if (UpdatePageName.Text != "")
            {
                Tempuser.name = UpdatePageName.Text;
                a++;
            }
            if (UpdatePageDoB.Value.ToShortDateString() != "10-05-2018")
            {
                Tempuser.doB = UpdatePageDoB.Value.ToString("yyyy-MM-dd");
                if (Tempuser.doB == "2018-05-10")
                {
                    Tempuser.doB = Orguser.doB;
                }
                a++;
            }
            if (UpdatePageHeight.Text != "")
            {
                Tempuser.height = Convert.ToInt32(UpdatePageHeight.Text);
                a++;
            }
            if (UpdatePageWeight.Text != "")
            {
                Tempuser.weight = Convert.ToDouble(UpdatePageWeight.Text, CultureInfo.InvariantCulture);
                a++;
            }
            if (UpdatePageActivity.Value != 0)
            {
                Tempuser.activity = Convert.ToInt32(UpdatePageActivity.Value);
                a++;
            }

            if (Tempuser != Orguser)
            {
                try
                {
                    if (!string.IsNullOrEmpty(Tempuser.password) && Tempuser.password != Orguser.password &&
                        Tempuser.IsUpdateInfoCorrect(Tempuser.user, Tempuser.name, Tempuser.doB,
                        Convert.ToInt32(Tempuser.height), Convert.ToDouble(Tempuser.weight), Tempuser.activity, Tempuser, Orguser) != false)
                    {
                        MySqlConnection conUU = DatabaseConnect.OpenDefaultDBConnection();
                        MySqlConnection conUP = DatabaseConnect.OpenDefaultDBConnection();

                        MySqlCommand UpdateUserCommand = new MySqlCommand();
                        MySqlCommand UpdatePwdCommand = new MySqlCommand();
                        UpdateUserCommand.CommandText = "UPDATE diettracker.users SET Name = '" + Tempuser.name +
                            "', DoB = '" + Tempuser.doB + "', Height = '" + Tempuser.height + "', Weight = '" + Tempuser.weight +
                            "', Activity = '" + Tempuser.activity + "' WHERE Username = '" + Orguser.user + "';";
                        UpdatePwdCommand.CommandText = "UPDATE diettracker.password SET Password = '" + Tempuser.password +
                            "' WHERE ForeignID = '" + Orguser.id + "';";

                        UpdateUserCommand.Connection = conUU;
                        UpdatePwdCommand.Connection = conUP;
                        conUU.Open();
                        UpdateUserCommand.ExecuteNonQuery();
                        conUU.Close();
                        conUP.Open();
                        UpdatePwdCommand.ExecuteNonQuery();
                        conUP.Close();

                        MySqlConnection conFW = DatabaseConnect.OpenDefaultDBConnection();
                        MySqlCommand SelectFirstWeightValueCommand = new MySqlCommand();
                        SelectFirstWeightValueCommand.CommandText = "SELECT Date, Weight from day WHERE UserID = '" + Username + "' AND Date <= COALESCE((SELECT Date FROM day ORDER BY Date ASC LIMIT 1),(SELECT MAX(Date) FROM day));";
                        SelectFirstWeightValueCommand.Connection = conFW;
                        conFW.Open();
                        MySqlDataReader FirstWeightRead = SelectFirstWeightValueCommand.ExecuteReader();
                        FirstWeightRead.Read();
                        string date = FirstWeightRead.GetDateTime(0).ToString("yyyy-MM-dd");
                        string weight = FirstWeightRead.GetDouble(1).ToString(CultureInfo.InvariantCulture);
                        conFW.Close();

                        MySqlConnection conUFW = DatabaseConnect.OpenDefaultDBConnection();
                        MySqlCommand UpdateFirstWeightValueCommand = new MySqlCommand();
                        UpdateFirstWeightValueCommand.CommandText = "UPDATE day SET Weight = '" + Tempuser.weight + "' WHERE UserID = '" + Username + "' AND Date = '" + date + "' AND Weight = '" + weight + "';";
                        UpdateFirstWeightValueCommand.Connection = conUFW;
                        conUFW.Open();
                        UpdateFirstWeightValueCommand.ExecuteNonQuery();
                        conUFW.Close();


                        MySqlConnection conCal = DietTracker.DatabaseConnect.OpenDefaultDBConnection();

                        var dateTimeToday = DateTime.Today.ToString("yyyy-MM-dd");
                        MySqlCommand WhatIsCurrentCalorieCommand = new MySqlCommand();
                        WhatIsCurrentCalorieCommand.CommandText = "SELECT Calories FROM day WHERE UserID = '" + Username + "' AND Date = '" + dateTimeToday + "';";
                        WhatIsCurrentCalorieCommand.Connection = conCal;
                        conCal.Open();
                        MySqlDataReader ReadCalories = WhatIsCurrentCalorieCommand.ExecuteReader();
                        ReadCalories.Read();
                        int CaloriesRead = ReadCalories.GetInt32(0);
                        conCal.Close();

                        MainPageGraphs.MainPageForm mainPage = new MainPageGraphs.MainPageForm(Username, CaloriesRead);
                        mainPage.Tag = this;
                        Hide();
                        mainPage.Show(this);

                    }
                    else if (Tempuser.IsUpdateInfoCorrect(Tempuser.user, Tempuser.name, Tempuser.doB,
                        Convert.ToInt32(Tempuser.height), Convert.ToDouble(Tempuser.weight), Tempuser.activity, Tempuser, Orguser) != false)
                    {
                        MySqlConnection ConU = DatabaseConnect.OpenDefaultDBConnection();
                        MySqlCommand UpdateCommand = new MySqlCommand();
                        UpdateCommand.CommandText = "UPDATE diettracker.users SET Name = '" + Tempuser.name +
                            "', DoB = '" + Tempuser.doB + "', Height = '" + Tempuser.height + "', Weight = '" + Tempuser.weight.ToString(CultureInfo.InvariantCulture) +
                            "', Activity = '" + Tempuser.activity + "' WHERE Username = '" + Orguser.user + "';";
                        UpdateCommand.Connection = ConU;
                        ConU.Open();
                        UpdateCommand.ExecuteNonQuery();
                        ConU.Close();

                        MySqlConnection conCal = DietTracker.DatabaseConnect.OpenDefaultDBConnection();

                        var dateTimeToday = DateTime.Today.ToString("yyyy-MM-dd");
                        MySqlCommand WhatIsCurrentCalorieCommand = new MySqlCommand();
                        WhatIsCurrentCalorieCommand.CommandText = "SELECT Calories FROM day WHERE UserID = '" + Username + "' AND Date = '" + dateTimeToday + "';";
                        WhatIsCurrentCalorieCommand.Connection = conCal;
                        conCal.Open();
                        MySqlDataReader ReadCalories = WhatIsCurrentCalorieCommand.ExecuteReader();
                        ReadCalories.Read();
                        int CaloriesRead = ReadCalories.GetInt32(0);
                        conCal.Close();

                        MySqlConnection conFW = DatabaseConnect.OpenDefaultDBConnection();
                        MySqlCommand SelectFirstWeightValueCommand = new MySqlCommand();
                        SelectFirstWeightValueCommand.CommandText = "SELECT Date, Weight from day WHERE UserID = '" + Username + "' AND Date >= COALESCE((SELECT Date FROM day ORDER BY Date ASC LIMIT 1),(SELECT MAX(Date) FROM day));";
                        SelectFirstWeightValueCommand.Connection = conFW;
                        conFW.Open();
                        MySqlDataReader FirstWeightRead = SelectFirstWeightValueCommand.ExecuteReader();
                        FirstWeightRead.Read();
                        string date = FirstWeightRead.GetDateTime(0).ToString("yyyy-MM-dd");
                        string weight = FirstWeightRead.GetDouble(1).ToString(CultureInfo.InvariantCulture);

                        conFW.Close();

                        MySqlConnection conUFW = DatabaseConnect.OpenDefaultDBConnection();
                        MySqlCommand UpdateFirstWeightValueCommand = new MySqlCommand();
                        UpdateFirstWeightValueCommand.CommandText = "UPDATE day SET Weight = '" + Tempuser.weight.ToString(CultureInfo.InvariantCulture) + "' WHERE UserID = '" + Username + "' AND Date = '" + date + "' AND Weight = '" + weight + "';";
                        UpdateFirstWeightValueCommand.Connection = conUFW;
                        conUFW.Open();
                        UpdateFirstWeightValueCommand.ExecuteNonQuery();
                        conUFW.Close();

                        MainPageGraphs.MainPageForm mainPage = new MainPageGraphs.MainPageForm(Username, CaloriesRead);
                        mainPage.Tag = this;
                        Hide();
                        mainPage.Show(this);
                    }
                }
                catch
                {
                    MessageBox.Show("Something went wrong");
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
