﻿using System;
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
                
                /* var Landingpage = (LandingPage.LandingPageForm)Tag;
                 Hide();
                 Landingpage.Show();*/

                try
                {
                    var dateTimeToday = DateTime.Today.ToString("yyyy-MM-dd");
                    MySqlConnection conCal = DietTracker.DatabaseConnect.OpenDefaultDBConnection();
                    MySqlConnection conCCal = DietTracker.DatabaseConnect.OpenDefaultDBConnection();

                    MySqlCommand WhatIsCurrentCalorieCommand = new MySqlCommand();
                    WhatIsCurrentCalorieCommand.CommandText = "SELECT Calories FROM diettracker.day WHERE UserID = '" + user + "' AND Date = '" + dateTimeToday + "';";
                    WhatIsCurrentCalorieCommand.Connection = conCCal;
                    conCCal.Open();
                    MySqlDataReader ReadCalories = WhatIsCurrentCalorieCommand.ExecuteReader();
                    if (ReadCalories.Read() == false)
                    {
                        int CaloriesRead = 0;

                        MessageBox.Show("You are logged in successfully!");
                        MainPageForm mainPage = new MainPageForm(user, CaloriesRead);
                        mainPage.Tag = this;
                        Hide();
                        mainPage.Show(this);
                    }
                    else 
                    {
                        int CaloriesRead = ReadCalories.GetInt32(0);
                        conCCal.Close();

                        MessageBox.Show("You are logged in successfully!");
                        MainPageForm mainPage = new MainPageForm(user, CaloriesRead);
                        mainPage.Tag = this;
                        Hide();
                        mainPage.Show(this);
                    }
                }
                catch
                {
                    MessageBox.Show("Couldn't log in");
                }
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

