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

namespace Register
{
    class Register
    {
        internal string Username { get; set; }
        internal string Userpassword { get; set; }

        internal string Name { get; set; }
        internal string DoB { get; set; }
        internal string Height { get; set; }
        internal string Weight { get; set; }
        internal string Activity { get; set; }

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
                    /*MySqlConnection conR = new MySqlConnection();
                    conR.ConnectionString = "server=localhost;user id=root;pwd=atlik91502.sql;database=diettracker;SslMode=none";
                    */

                    MySqlConnection conR = DietTracker.DatabaseConnect.OpenDefaultDBConnection();

                    MySqlCommand UserCommand = new MySqlCommand();
                    UserCommand.CommandText = "SELECT Username FROM users WHERE Username = '" + user + "';";
                    UserCommand.Connection = conR;
                    conR.Open();
                    MySqlDataReader UsernameRead = UserCommand.ExecuteReader();

                    try
                    {
                        UsernameRead.Read();
                        string Username = UsernameRead.GetString(0);
                        var UserDatabase = String.Format("{0}", Username);
                        Username = UserDatabase;
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
