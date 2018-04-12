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
                // MYSQL CODE to receive Usernames from the database
                MySqlConnection myUserConnection = new MySqlConnection();
                myUserConnection.ConnectionString = "database=diettracker;server=localhost;user id=ApplicationAccess;";

                MySqlCommand UserCommand = new MySqlCommand();
                UserCommand.CommandText = "SELECT Username FROM username WHERE Username = '" + user + "';";
                UserCommand.Connection = myUserConnection;
                myUserConnection.Open();
                MySqlDataReader UsernameRead = UserCommand.ExecuteReader();

                /* C# CODE to assign the username equal to the data in the database
                I use a try here instead of an if, since if the MySqlDataReader can't find the written name in the database it crashes.
                Further down an exception handles that*/
                try
                {
                    UsernameRead.Read();
                    string Username = UsernameRead.GetString(0);
                    var UserDatabase = String.Format("{0}", Username);
                    Username = UserDatabase;

                    //Now that we know Username is correct, we begin checking the password and if its empty 

                    {
                        if (string.IsNullOrEmpty(pass))
                        {
                            MessageBox.Show("Please enter your password!");
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

                        myUserConnection.Close();
                        ClearTexts(user, pass);
                        MySqlConnection myPasswordConnection = new MySqlConnection();
                        myPasswordConnection.ConnectionString = "database=diettracker;server=localhost;user id=ApplicationAccess;";

                        MySqlCommand PasswordCommand = new MySqlCommand();
                        PasswordCommand.CommandText = "SELECT Password FROM username, password WHERE password.ID = username.ID AND username = '" + user + "';";
                        PasswordCommand.Connection = myPasswordConnection;
                        myPasswordConnection.Open();
                        MySqlDataReader PasswordRead = PasswordCommand.ExecuteReader();

                        //Even though, for some reason, the system doesn't crash if you input a non-existing password, i still use a try just to be sure nothing goes wrong
                        try
                        {
                            PasswordRead.Read();
                            //MessageBox.Show();
                            string Userpassword = PasswordRead.GetString(0);
                            var PasswordDatabase = String.Format("{0}", Userpassword);
                            Userpassword = PasswordDatabase;

                            //Since a password was entered, we check if the password is correct 
                            if (Userpassword != pass)
                            {
                                MessageBox.Show("Incorrect Password");
                                ClearTexts(user, pass);
                                myPasswordConnection.Close();
                                return false;
                            }
                            else
                            {
                                //Once we managed to get to this part of the code, we know both the Username and the Password was correct
                                myPasswordConnection.Close();
                                return true;
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Unusual error; Incorrect Password");
                            myPasswordConnection.Close();
                            return false;
                        }
                    }
                }
            
                //As written above, in case the user doesn't exist in the database, the reader can't handle it, so instead this exception catches it and resets it all
                catch
                {
                    MessageBox.Show("That Username Doesn't exist");
                    ClearTexts(user, pass);
                    myUserConnection.Close();
                    return false;

                }
                finally
                {
                    myUserConnection.Close();
                }
            }
        }
    }
}
