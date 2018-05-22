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

/// <summary>
/// This is the UpdatePage
/// </summary>

namespace DietTracker.UpdatePage
{
    /// <summary>
    /// General Update of user
    /// </summary>
    public partial class UpdatePageForm : Form
    {
        internal string userName;
        /// <summary>
        /// The Update Page takes the information started for the specific user who's logged in, and changes it depending on if any changes was done on the page
        /// The update page will only update the userinformation that the user changes, and anything else will remain unchanged.
        /// </summary>

        public UpdatePageForm(string userName)
        {
            this.userName = userName;
            InitializeComponent();
        }

        private void MainPageBack_Click(object sender, EventArgs e)
        {
            MySqlConnection conCal = DietTracker.DatabaseConnect.OpenDefaultDBConnection();

            var dateTimeToday = DateTime.Today.ToString("yyyy-MM-dd");
            MySqlCommand WhatIsCurrentCalorieCommand = new MySqlCommand();
            WhatIsCurrentCalorieCommand.CommandText = "SELECT Calories FROM day WHERE UserID = '" + userName + "' AND Date = '" + dateTimeToday + "';";
            WhatIsCurrentCalorieCommand.Connection = conCal;
            conCal.Open();
            MySqlDataReader ReadCalories = WhatIsCurrentCalorieCommand.ExecuteReader();
            ReadCalories.Read();
            int CaloriesRead = ReadCalories.GetInt32(0);
            conCal.Close();

            MainPageGraphs.MainPageForm mainPageForm = new MainPageGraphs.MainPageForm(userName, CaloriesRead);
            mainPageForm.Tag = this;
            Hide();
            mainPageForm.Show(this);
        }
        
        internal void UpdateButton_Click(object sender, EventArgs e)
        {
            DateTime doB;
            var a = 0;
            User orgUser = User.GetUser(userName);
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
                        tempUser.IsUpdateInfoCorrect(tempUser.userName, tempUser.name, tempUser.doB,
                        Convert.ToInt32(tempUser.height), Convert.ToInt32(tempUser.weight), tempUser.activity, tempUser, orgUser) != false)
                    {
                        MySqlConnection conUU = DatabaseConnect.OpenDefaultDBConnection();
                        MySqlConnection conUP = DatabaseConnect.OpenDefaultDBConnection();
                        MySqlCommand UpdateUserCommand = new MySqlCommand();
                        MySqlCommand UpdatePwdCommand = new MySqlCommand();
                        UpdateUserCommand.CommandText = "UPDATE diettracker.users SET Name = '" + tempUser.name +
                            "', DoB = '" + tempUser.doB + "', Height = '" + tempUser.height + "', Weight = '" + tempUser.weight +
                            "', Activity = '" + tempUser.activity + "' WHERE Username = '" + orgUser.userName + "';";
                        UpdatePwdCommand.CommandText = "UPDATE diettracker.password SET Password = '" + tempUser.password + 
                            "' WHERE ForeignID = '" + orgUser.id + "';";
                        UpdateUserCommand.Connection = conUU;
                        UpdatePwdCommand.Connection = conUP;
                        conUU.Open();
                        UpdateUserCommand.ExecuteNonQuery();
                        conUU.Close();
                        conUP.Open();
                        UpdatePwdCommand.ExecuteNonQuery();
                        conUP.Close();

                        MySqlConnection conCal = DietTracker.DatabaseConnect.OpenDefaultDBConnection();

                        var dateTimeToday = DateTime.Today.ToString("yyyy-MM-dd");
                        MySqlCommand WhatIsCurrentCalorieCommand = new MySqlCommand();
                        WhatIsCurrentCalorieCommand.CommandText = "SELECT Calories FROM day WHERE UserID = '" + userName + "' AND Date = '" + dateTimeToday + "';";
                        WhatIsCurrentCalorieCommand.Connection = conCal;
                        conCal.Open();
                        MySqlDataReader ReadCalories = WhatIsCurrentCalorieCommand.ExecuteReader();
                        ReadCalories.Read();
                        int CaloriesRead = ReadCalories.GetInt32(0);
                        conCal.Close();

                        MainPageGraphs.MainPageForm mainPage = new MainPageGraphs.MainPageForm(userName, CaloriesRead);
                        mainPage.Tag = this;
                        Hide();
                        mainPage.Show(this);

                    }
                    else if (tempUser.IsUpdateInfoCorrect(tempUser.userName, tempUser.name, tempUser.doB,
                        Convert.ToInt32(tempUser.height), Convert.ToInt32(tempUser.weight), tempUser.activity, tempUser, orgUser) != false)
                    {
                        MySqlConnection ConU = DatabaseConnect.OpenDefaultDBConnection();
                        MySqlCommand UpdateCommand = new MySqlCommand();
                        UpdateCommand.CommandText = "UPDATE diettracker.users SET Name = '" + tempUser.name + 
                            "', DoB = '" + tempUser.doB + "', Height = '" + tempUser.height + "', Weight = '" + tempUser.weight + 
                            "', Activity = '" + tempUser.activity + "' WHERE Username = '" + orgUser.userName + "';";
                        UpdateCommand.Connection = ConU;
                        ConU.Open();
                        UpdateCommand.ExecuteNonQuery();
                        ConU.Close();

                        MySqlConnection conCal = DietTracker.DatabaseConnect.OpenDefaultDBConnection();

                        var dateTimeToday = DateTime.Today.ToString("yyyy-MM-dd");
                        MySqlCommand WhatIsCurrentCalorieCommand = new MySqlCommand();
                        WhatIsCurrentCalorieCommand.CommandText = "SELECT Calories FROM day WHERE UserID = '" + userName + "' AND Date = '" + dateTimeToday + "';";
                        WhatIsCurrentCalorieCommand.Connection = conCal;
                        conCal.Open();
                        MySqlDataReader ReadCalories = WhatIsCurrentCalorieCommand.ExecuteReader();
                        ReadCalories.Read();
                        int CaloriesRead = ReadCalories.GetInt32(0);
                        conCal.Close();

                        MainPageGraphs.MainPageForm mainPage = new MainPageGraphs.MainPageForm(userName, CaloriesRead);
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
