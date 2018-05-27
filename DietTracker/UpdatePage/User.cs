using MySql.Data.MySqlClient;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DietTracker
{
    class User : ICloneable
    {
        public string user { get; set; }
        internal string password { get; set; }

        internal string name { get; set; }
        internal string gender { get; set; }
        internal string doB { get; set; }
        internal int height { get; set; }
        internal double weight { get; set; }
        internal int activity { get; set; }
        internal int id { get; set; }
        internal User orgUser { get; set; }
        internal User tempUser { get; set; }
  

        public User(string userName, string name, string gender, string dob, int height, double weight, int activity)
        {
            this.user = userName;
            this.name = name;
            this.gender = gender;
            this.doB = dob;
            this.height = height;
            this.weight = weight;
            this.activity = activity;
        }

        public User(string userName, string password, string name, string gender, string dob, int height, double weight, int activity)
        {
            this.user = userName;
            this.password = password;
            this.name = name;
            this.gender = gender;
            this.doB = dob;
            this.height = height;
            this.weight = weight;
            this.activity = activity;
        }

        public User(string userName, string name, string gender, string dob, int height, double weight, int activity, int id)
        {
            this.user = userName;
            this.name = name;
            this.gender = gender;
            this.doB = dob;
            this.height = height;
            this.weight = weight;
            this.activity = activity;
            this.id = id;
        }

        public User(string userName)
        {
            this.user = userName;
        }

        public object Clone()
        {
            Console.WriteLine("Cloning object");
            return this.MemberwiseClone();
        }

        public User DoUserChange()
        {
            var ChangedObject = (User)this.Clone();
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

        internal bool DoubleValidator(string input)
        {
            string pattern = "[^0-9.]";
            if (Regex.IsMatch(input, pattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal bool IsUpdateInfoCorrect(string userName, string name, string doB, int height, double weight, int activity, User tempUser, User orgUser)
        {
            if (!string.IsNullOrEmpty(password) && StringValidator(password) == true)
            {
                MessageBox.Show("You forgot to type your password");
                return false;
            }
            if (!string.IsNullOrEmpty(name) && StringValidatorName(name) == true)
            {
                MessageBox.Show("You cannot have special characters in your name.");
                return false;
            }
            if (!string.IsNullOrEmpty(Convert.ToString(height)) && IntValidator(Convert.ToString(height)) == true)
            {
                MessageBox.Show("You cannot use letters or special characters in your height.");
                return false;
            }
            if (!string.IsNullOrEmpty(Convert.ToString(weight)) && DoubleValidator(Convert.ToString(weight)) == true)
            {
                MessageBox.Show("You cannot use letters or special characters in your weight.");
                return false;
            }

            return true;
        }


        public static User GetUser(string userName)
        {
            try
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

                User orgUser = new User(userName, name, gender, dob, height, weight, activity, id);
                conU.Close();

                return orgUser;
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
                User orgUser = new User(userName);
                return orgUser;

            }
            catch
            {
                MessageBox.Show("Something went wrong while creating User");
                User orgUser = new User(userName);
                return orgUser;
            }
        }

        internal int GetUserID(string userName)
        {
            try
            {
                MySqlConnection conU = DatabaseConnect.OpenDefaultDBConnection();

                MySqlCommand UserCommand = new MySqlCommand();
                UserCommand.CommandText = "'SELECT ID FROM users WHERE Username = '" + userName + "';";
                UserCommand.Connection = conU;

                conU.Open();
                MySqlDataReader userReader = UserCommand.ExecuteReader();
                userReader.Read();
                int id = userReader.GetInt32(0);
                return id;
            }
            catch
            {
                MessageBox.Show("Dunno man.. You done goofed. while getting ID");
                int id = 0;
                return id;
            }
        }

        internal string GetUserPwd(int userID)
        {
            try
            {
                MySqlConnection conU = DatabaseConnect.OpenDefaultDBConnection();

                MySqlCommand UserCommand = new MySqlCommand();
                UserCommand.CommandText = "'SELECT Password FROM password WHERE ForeignID = '" + userID + "';";
                UserCommand.Connection = conU;

                conU.Open();
                MySqlDataReader userReader = UserCommand.ExecuteReader();
                userReader.Read();
                string pwd = userReader.GetString(0);

                return pwd;
            }
            catch
            {
                MessageBox.Show("Dunno man.. You done goofed while getting PWD");
                return "";
            }
        }
    }
}
