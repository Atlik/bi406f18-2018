using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MainPageGraphs
{
    class UpdateWeightGraph
    {
        //internal int Calories { get; set; }
        internal int Weight { get; set; }
        internal DateTime DayOfInput { get; set; }

        internal UpdateWeightGraph(DateTime dayOfInput, int weight)
        {
            this.Weight = weight;
            this.DayOfInput = dayOfInput;
        }

        /*
        internal bool IsAbleToUpdate(DateTime dayOfInput, int weight)
        {
            try
            {
                MySqlConnection getWeightSqlConnection = new MySqlConnection();
                getWeightSqlConnection.ConnectionString = "server=localhost;user id=root;password=atlik91502.sql;database=db_diettracker";

                MySqlCommand weightCommand = new MySqlCommand();
                weightCommand.CommandText = "SELECT Weight FROM day WHERE Weight = '" + weight + "';";
                weightCommand.Connection = getWeightSqlConnection;
                getWeightSqlConnection.Open();

                try
                {
                    MySqlConnection getDateSqlConnection = new MySqlConnection();
                    getDateSqlConnection.ConnectionString =
                        "server=localhost;user id=root;password=atlik91502.sql;database=db_diettracker";

                    MySqlCommand dateCommand = new MySqlCommand();
                    dateCommand.CommandText = "SELECT Date FROM day WHERE day = '" + dayOfInput + "';";
                    dateCommand.Connection = getDateSqlConnection;
                    getDateSqlConnection.Open();

                    if (dayOfInput != null)
                    {
                        UpdateWeightGraph newInfo = new UpdateWeightGraph(dayOfInput, weight);
                        getDateSqlConnection.Close();
                        getWeightSqlConnection.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Something went wrong");
                    getWeightSqlConnection.Close();
                    return false;
                }
                finally
                {
                    getWeightSqlConnection.Close();
                }
            }
            catch (MySqlException e)
            {
                switch (e.Number)
                {
                    case 0:
                        MessageBox.Show("Can't connect to the server");
                        break;
                }
                return false;
            }
            catch
            {
                MessageBox.Show("Something went wrong while updating the graph");
                return false;
            }
        }*/

    }
}
