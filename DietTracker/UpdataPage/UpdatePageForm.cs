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

namespace DietTracker.UpdataPage
{
    /// <summary>
    /// General Update of user
    /// </summary>
    public partial class UpdatePageForm : Form
    {

        internal string userName { get; }
        internal string user { get; set; }
        internal string pass { get; set; }
        internal string name { get; set; }
        internal string dob { get; set; }
        internal string height { get; set; }
        internal string weight { get; set; }
        internal int activity { get; set; }

        /// <summary>
        /// The Update Page takes the information started for the specific user who's logged in, and changes it depending on if any changes was done on the page
        /// The update page will only update the userinformation that the user changes, and anything else will remain unchanged.
        /// </summary>

        public UpdatePageForm(string user)
        {
            this.userName = user;
            InitializeComponent();
        }

        private void UpdateUserForm_Load(object sender, EventArgs e)
        {

        }

        private void MainPageBack_Click(object sender, EventArgs e)
        {
            MainPageGraphs.MainPageForm mainPageForm = new MainPageGraphs.MainPageForm(userName);
            mainPageForm.Tag = this;
            Hide();
            mainPageForm.Show(this);
        }
        
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            var a = 0;
            User orgpUser = User.GetUser(userName);
            User tempUser = orgpUser.DoUserChange();
            if (UpdatePageUsername.Text != "")
            {
                user = UpdatePageUsername.Text;
                a++;
            }
            if (UpdatePagePassword.Text != "")
            {
                pass = UpdatePagePassword.Text;
                a++;
            }
            if (UpdatePageName.Text != "")
            {
                name = UpdatePageName.Text;
                a++;
            }
            if (UpdatePageDoB.Value.ToString("yyyy-MM-dd") != "2018-05-18")
            {
                dob = UpdatePageDoB.Value.ToString("yyyy-MM-dd");
                a++;
            }
            if (UpdatePageHeight.Text != "")
            {
                height = UpdatePageHeight.Text;
                a++;
            }
            if (UpdatePageWeight.Text != "")
            {
                weight = UpdatePageWeight.Text;
                a++;
            }
            if (UpdatePageActivity.Value != 0)
            {
                activity = Convert.ToInt32(UpdatePageActivity.Value);
                a++;
            }

            if(a != 0)
            {
                tempUser.IsUpdateInfoCorrect(user, name, dob, Convert.ToInt32(height), Convert.ToInt32(weight), activity);
                MySqlConnection ConU = DatabaseConnect.OpenDefaultDBConnection();
                MySqlCommand UpdateCommand = new MySqlCommand();
                UpdateCommand.CommandText = "UPDATE Diettracker.User (Username, Name, Gender, DoB, height, weight, activity)" +
                    "VALUES ('" + user + "','" + name + "','" + dob + "','" + height + "','" + weight + "','" + activity + 
                    "') WHERE Username = '" + orgpUser.userName + "';";
                UpdateCommand.Connection = ConU;
                ConU.Open();
                UpdateCommand.ExecuteNonQuery();
                ConU.Close();
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
