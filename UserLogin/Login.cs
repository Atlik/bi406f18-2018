using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Login
{
    class Login
    {
        //We declare properties 
        public string Username { get; set; }
        public string Userpassword { get; set; }

        //intialise  
        public Login(string user, string pass)
        {
            this.Username = user;
            this.Userpassword = pass;
        }

        //validate string 
        private bool StringValidator(string input)
        {
            string pattern = "[^a-zA-Z-0-9]";
            if (Regex.IsMatch(input, pattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //validate integer (Didn't think this was necessary in the end)
        /*private bool IntegerValidator(string input)
        {
            string pattern = "[^0-9]";
            if (Regex.IsMatch(input, pattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }*/

        //We clear user inputs before we do any login validation to make sure we dont glitch a random login
        private void ClearTexts(string user, string pass)
        {
            user = String.Empty;
            pass = String.Empty;
        }

        //method to check if eligible to be logged in 
        internal bool IsLoggedIn(string user, string pass)
        {
            //Then we check if the user name is empty 
            if (string.IsNullOrEmpty(user))
            {
                MessageBox.Show("Please enter a Username");
                return false;

            }

            //Otherwise we check if the user name is valid 
            else if (StringValidator(user) == true)
            {
                MessageBox.Show("You can't use special characters");
                ClearTexts(user, pass);
                return false;
            }

            //If the if and else if pass, we check if the Username is even correct 
            else
            {
                if (Username != user)
                {
                    MessageBox.Show("The Username is incorrect");
                    ClearTexts(user, pass);
                    return false;
                }

                //Now that we know Username is correct, we begin checking the password and if its empty 
                else
                {
                    if (string.IsNullOrEmpty(pass))
                    {
                        MessageBox.Show("Please enter your password!");
                        return false;
                    }

                    //check password is valid (This is related to being able to input tekst inside a password)
                    /*else if (IntegerValidator(pass) == true)
                    {
                        MessageBox.Show("Enter only integer here");
                        return false;
                    }*/

                    //Since a password was entered, we check if the password is correct 
                    else if (Userpassword != pass)
                    {
                        MessageBox.Show("Incorrect Password");
                        return false;
                    }
                    else
                    {
                        //Once we managed to get to this part of the code, we know both the Username and the Password was correct
                        return true;
                    }
                }
            }
        }
    }
}
