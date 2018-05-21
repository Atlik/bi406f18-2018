using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MainPageGraphs
{
    class Calorieupdater
    {
        internal string Calories { get; set; }
        
        internal Calorieupdater(string c)
        {
            Calories = c;
        }
        private bool IntValidator(string input)
        {
            string pattern = "[^0-9-]";
            if (Regex.IsMatch(input, pattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        internal bool IsCaloriesInputCorrect(string c)
        {
            try
            {
                if (string.IsNullOrEmpty(c))
                {
                    MessageBox.Show("You didn't input anything");
                    return false;
                }
                else if (IntValidator(c) == true)
                {
                    MessageBox.Show("The Calorie input only accepts numbers");
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.");
                        return false;
                }
                return false;
            }
            catch
            {
                MessageBox.Show("Something unintended happened");
                return false;
            }
        }
    }
}
