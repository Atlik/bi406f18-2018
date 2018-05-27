using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Register
{
    class Register
    {
        internal string Username { get; }
        internal string Userpassword { get; }

        internal string Name { get; }
        internal string DoB { get; }
        internal string Height { get; }
        internal string Weight { get; }
        internal string Activity { get; }

        internal Register(string user, string pass, string n, string dob, string h, string w, string a)
        {
            this.Username = user;
            this.Userpassword = pass;
            this.Name = n;
            this.DoB = dob;
            this.Height = h;
            this.Weight = w;
            this.Activity = a;
        }

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
        private bool StringValidatorName(string input)
        {
            string pattern = "[^a-zA-Z]";
            if (Regex.IsMatch(input, pattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IntValidator(string input)
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
        }

        private void ClearTexts(string user, string pass, string dob, string n, string h, string w)
        {
            user = String.Empty;
            pass = String.Empty;
            n = String.Empty;
            dob = String.Empty;
            h = String.Empty;
            w = String.Empty;
        }

        internal bool IsRegisterInfoInput(string user, string pass, string dob, string n, string h, string w)
        {
            try
            {
                if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(n) || string.IsNullOrEmpty(h) || string.IsNullOrEmpty(w))
                {
                    MessageBox.Show("You forgot to write something");
                    return false;

                }
                else if (StringValidator(user) || StringValidator(pass) == true)
                {
                    MessageBox.Show("You cant use special characters for your Username or Password");
                    return false;

                }
                else if (StringValidatorName(n) == true)
                {
                    MessageBox.Show("You cant have numbers or special characters in your name");
                    return false;
                }
                else if (IntValidator(h) || IntValidator(w) == true)
                {
                    MessageBox.Show("You cant have letters or special characters in your height or weight");
                    return false;
                }
                else
                {
                    MySqlConnection conR = DietTracker.DatabaseConnect.OpenDefaultDBConnection();

                    MySqlCommand userCommand = new MySqlCommand();
                    userCommand.CommandText = "SELECT Username FROM users WHERE Username = '" + user + "';";
                    userCommand.Connection = conR;
                    conR.Open();
                    MySqlDataReader usernameRead = userCommand.ExecuteReader();

                    try
                    {
                        usernameRead.Read();
                        string Username = usernameRead.GetString(0);
                        var userDatabase = String.Format("{0}", Username);
                        Username = userDatabase;
                        MessageBox.Show("That username already exists");
                        return false;
                    }
                    catch
                    {
                        conR.Close();
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Something happened: " + e);
                return false;
            }
        }
    }
}
