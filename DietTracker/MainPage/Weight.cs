using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MainPageGraphs
{
    class Weightupdater
    {
        internal string Weight { get; }

        internal Weightupdater(string w)
        {
            Weight = w;
        }
        private bool DoubleValidator(string input)
        {
            string pattern = "[^0-9-.]";
            if (Regex.IsMatch(input, pattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        internal bool IsWeightInputCorrect(string w)
        {
            try
            {
                if (string.IsNullOrEmpty(w))
                {
                    MessageBox.Show("You didn't input anything");
                    return false;
                }
                else if (DoubleValidator(w) == true)
                {
                    MessageBox.Show("The Weight input only accepts numbers and dots");
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