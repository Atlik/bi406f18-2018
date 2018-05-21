﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DietTracker
{
    class User : ICloneable
    {
        public string userName { get; set; }
        internal string userPassword { get; set; }

        internal string name { get; set; }
        internal string gender { get; set; }
        internal string doB { get; set; }
        internal int height { get; set; }
        internal double weight { get; set; }
        internal int activity { get; set; }
        internal User orgUser { get; set; }


        public User(string user, string n, string gender, string dob, int h, double w, int a)
        {
            this.userName = user;
            this.name = n;
            this.gender = gender;
            this.doB = dob;
            this.height = h;
            this.weight = w;
            this.activity = a;
        }

        public User(string userName)
        {
            this.userName = userName;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public object Clone()
        {
            Console.WriteLine("Cloning object");
            return this.MemberwiseClone();
        }

        public User DoUserChange()
        {
            var ChangedObject = (User)this.Clone();
            Console.WriteLine("It worked");
            Console.WriteLine(ChangedObject.height);
            //INDSÆT ALLE BOKSENE MED this.PROPERTY som default text. If new text != this.property then Changedobject.proterty = new value
            ChangedObject.name = "Nørge";
            Console.WriteLine(ChangedObject.name);
            return ChangedObject;
        }

        internal bool StringValidator(string input)
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

        internal bool StringValidatorName(string input)
        {
            string pattern = "[^a-zA-Z0-9]";
            if (Regex.IsMatch(input, pattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal bool IntValidator(string input)
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

        internal bool IsUpdateInfoCorrect(string userName, string name, string doB, int height, double weight, int activity)
        {
            try
            {
                if (!string.IsNullOrEmpty(userName) && StringValidator(userName) == true)
                {
                    MessageBox.Show("You cannot use special characters in your username.");
                    return false;
                }
                else if (!string.IsNullOrEmpty(userPassword) && StringValidator(userPassword) == true)
                {
                    MessageBox.Show("You forgot to type your password");
                    return false;
                }
                if (!string.IsNullOrEmpty(name) && StringValidatorName(name) == true)
                {
                    MessageBox.Show("You cannot have special characters in your name.");
                    return false;
                }
                else if (!string.IsNullOrEmpty(Convert.ToString(height)) && IntValidator(Convert.ToString(height)) == true)
                {
                    MessageBox.Show("You cannot use letters or special characters in your height.");
                    return false;
                }
                else if (!string.IsNullOrEmpty(Convert.ToString(weight)) && IntValidator(Convert.ToString(weight)) == true)
                {
                    MessageBox.Show("You cannot use letters or special characters in your weight.");
                    return false;
                }
                else
                {
                    MySqlConnection conU = DietTracker.DatabaseConnect.OpenDefaultDBConnection();

                    MySqlCommand UserCommand = new MySqlCommand();
                    UserCommand.CommandText = "SELECT Username FROM users WHERE Username = '" + userName + "';";
                    UserCommand.Connection = conU;
                    conU.Open();
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
                        conU.Close();
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
                

        public static User GetUser(string userName)
        {
            MySqlConnection conU = DatabaseConnect.OpenDefaultDBConnection();

            MySqlCommand UserCommand = new MySqlCommand();
            UserCommand.CommandText = "SELECT Name, Gender, DoB, Height, Weight, Activity, ID FROM users WHERE Username = '" + userName + "';";
            UserCommand.Connection = conU;

            conU.Open();
            MySqlDataReader userReader = UserCommand.ExecuteReader();
            userReader.Read();
            string name = userReader.GetString(0);
            string gender = userReader.GetString(1);
            string dob = userReader.GetString(2);
            int height = userReader.GetInt32(3);
            double weight = userReader.GetDouble(4);
            int activity = userReader.GetInt32(5);
            int id = userReader.GetInt32(6);

            User orgUser = new User(userName, name, gender, dob, height, weight, activity);

            return orgUser;
        }

        static void Main1(string[] args)
        {
            var a = new User("Test", "test", "Jesper", "2011-20-11", 190, 100, 18);
            //var b = (User)a.Clone();

            Console.WriteLine(a.name);
            //Console.WriteLine(b.Username);
            var b = a.DoUserChange();
            Console.WriteLine(b.name);
            a = b;
            Console.WriteLine(b.name + " new");

        }
    }
}