﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Login
{
    public partial class LoginForm : Form
    {
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
                MessageBox.Show("You are logged in successfully");
            }
            else
            {
                //show default login error message 
                // MessageBox.Show("Login Error!"); (ikke nødvendigt med alle de andre errors men godt at have med!)
            }
        }

        private void Forgot_password_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Redirect link to forgotten-password-page
            MessageBox.Show("Under development");
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            //Redirect button to registrationpage 
            MessageBox.Show("Under development");
        }

        private void LoginPageBack_Click(object sender, EventArgs e)
        {
            //Redirect button to LandingPage
            var Landingpage = (LandingPage.LandingPageForm)Tag;
            Hide();
            Landingpage.Show();
        }

        private void LoginForm_Closed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
