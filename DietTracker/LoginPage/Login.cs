﻿using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Login
{
    class Login
    {
        //We declare properties 
        internal string Username { get; set; }
        internal string Userpassword { get; set; }

        //intialise  
        internal Login(string user, string pass)
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

        //We clear user inputs before we do any login validation to make sure we dont glitch a random login
        private void ClearTexts(string user, string pass)
        {
            user = String.Empty;
            pass = String.Empty;
        }

        //method to check if eligible to be logged in 
        internal bool IsLoggedIn(string user, string pass)
        {
            // MYSQL CODE to receive Usernames from the database
            try
            {
                MySqlConnection conU = DietTracker.DatabaseConnect.OpenDefaultDBConnection();

                MySqlCommand userCommand = new MySqlCommand();
                userCommand.CommandText = "SELECT Username FROM users WHERE Username = '" + user + "';";
                userCommand.Connection = conU;
                conU.Open();
                MySqlDataReader usernameRead = userCommand.ExecuteReader();

                /* C# CODE to assign the username equal to the data in the database
                We use a try here instead of an if, since if the MySqlDataReader can't find the written name in the database it crashes.
                Further down an exception handles that*/

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

                try
                {
                    usernameRead.Read();
                    string Username = usernameRead.GetString(0);
                    var UserDatabase = String.Format("{0}", Username);
                    Username = UserDatabase;

                    //Now that we know Username is correct, we begin checking the password and if its empty 
                    {
                        if (string.IsNullOrEmpty(pass))
                        {
                            MessageBox.Show("Please enter a password");
                            return false;
                        }

                        //check password is valid (This is related to being able to input tekst inside a password)
                        else if (StringValidator(pass) == true)
                        {
                            MessageBox.Show("You can't use special characters");
                            ClearTexts(user, pass);
                            return false;
                        }

                        // MYSQL CODE: SELECT password FROM password, username WHERE password.ID = username.ID AND username.Username = 'User';
                        // C# code til at sætte password; pass = password received from MySql 

                        conU.Close();
                        ClearTexts(user, pass);

                        MySqlConnection conP = DietTracker.DatabaseConnect.OpenDefaultDBConnection();

                        MySqlCommand PasswordCommand = new MySqlCommand();
                        PasswordCommand.CommandText = "SELECT Password FROM users, password WHERE password.ForeignID = users.ID AND username = '" + user + "';";
                        PasswordCommand.Connection = conP;
                        conP.Open();
                        MySqlDataReader PasswordRead = PasswordCommand.ExecuteReader();

                        //Even though, for some reason, the system doesn't crash if you input a non-existing password, i still use a try just to be sure nothing goes wrong
                        try
                        {
                            PasswordRead.Read();

                            string userPassword = PasswordRead.GetString(0);
                            var passwordDatabase = String.Format("{0}", userPassword);
                            userPassword = passwordDatabase;

                            //Since a password was entered, we check if the password is correct 
                            if (userPassword != pass)
                            {
                                MessageBox.Show("Incorrect Username and/or Password");
                                ClearTexts(user, pass);
                                conP.Close();
                                return false;
                            }
                            else
                            {
                                //Once we managed to get to this part of the code, we know both the Username and the Password was correct
                                conP.Close();
                                return true;
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Unusual error occured, please try again or restart the application");
                            conP.Close();
                            return false;
                        }
                    }
                }

                //As written above, in case the user doesn't exist in the database, the reader can't handle it, so instead this exception catches it and resets it all
                catch
                {
                    MessageBox.Show("Incorrect Username and/or Password");
                    ClearTexts(user, pass);
                    conU.Close();
                    return false;

                }
                finally
                {
                    conU.Close();
                }
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cant connect to server.");
                        break;
                }
                return false;
            }
            catch
            {
                MessageBox.Show("Please write your Username and/or Password");
                return false;
            }
        }
    }
}

