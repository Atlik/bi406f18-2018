using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MySql.Data.MySqlClient;

namespace MainPageGraphs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //tænker på at tilføje denne således at MySQL bliver indlæst herfra istedet for fra en separat metode
        private void ClickToLoadGraph(object sender, EventArgs e)
        {
            string connectionsString = null;

            MySqlConnection cnn;
            connectionsString = "server=localhost;user id=root;pwd=atlik91502.sql;database=db_diettracker;SslMode=none";
            cnn = new MySqlConnection(connectionsString);

            try
            {
                cnn.Open();
                MessageBox.Show("Connection can be opened!");
            }
            catch (Exception exc)
            {
                MessageBox.Show("can not open connection");
                MessageBox.Show(exc.Message);
            }
            finally
            {
                if (cnn != null)
                {
                    cnn.Close();
                }
            }

            // Alt efter hvad og hvordan BMI udregning giver max antal calorier skal dette indsættes i points på denne måde
            var info = new UpdateCaloriesGraph(2600, 1500);

            int caloriesLeft = info.maxCalories - info.CaloriesEaten;

            caloriesChart.Series["CalorieIntake"].Points.AddXY("Calories Eaten", info.maxCalories);
            caloriesChart.Series["CalorieIntake"].Points.AddXY("Calorie left", caloriesLeft);
        }

        private void weightOverTimeChart_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                MySqlConnection getWeightSqlConnection = new MySqlConnection();
                getWeightSqlConnection.ConnectionString =
                    "server=localhost;user id=root;pwd=atlik91502.sql;database=db_diettracker;SslMode=none";

                MySqlCommand weightCommand = new MySqlCommand();
                weightCommand.CommandText = "SELECT Weight FROM day";
                weightCommand.Connection = getWeightSqlConnection;

                try
                {
                    MySqlConnection getDateSqlConnection = new MySqlConnection();
                    getDateSqlConnection.ConnectionString =
                        "server=localhost;user id=root;pwd=atlik91502.sql;database=db_diettracker;SslMode=none";

                    MySqlCommand dateCommand = new MySqlCommand();
                    dateCommand.CommandText = "SELECT Date FROM db_diettracker.day";
                    dateCommand.Connection = getDateSqlConnection;

                    MessageBox.Show("Opens connection");
                    getDateSqlConnection.Open();
                    MessageBox.Show("Connected to table (date)");
                    MessageBox.Show("Opens connection");
                    getWeightSqlConnection.Open();
                    MessageBox.Show("Connected to table (weight)");

                    MySqlDataReader readWeight = weightCommand.ExecuteReader();
                    MySqlDataReader read = dateCommand.ExecuteReader();

                    #region Skrald

                    /*  while (read.Read())
                      {

                          dayInput = read.GetDateTime(0).ToShortDateString();
                          MessageBox.Show("dette er repræsenteret: " + dayInput);

                      }
                      //MessageBox.Show(dayInput);

                      while (readWeight.Read())
                      {
                          Weight = readWeight.GetInt32(0);
                          MessageBox.Show("dette vises i weight: " + Weight);
                      }*/

                    #endregion

                    MessageBox.Show("Will now insert data into graph");

                    while (read.Read() && readWeight.Read())
                    {
                        int newWeight = readWeight.GetInt32(0);
                        string newDayInput = read.GetDateTime(0).ToShortDateString();

                        weightOverTimeChart.Series["Weight"].Points.AddXY(newDayInput, newWeight);
                        weightOverTimeChart.ChartAreas[0].RecalculateAxesScale();
                    }

                    readWeight.Close();
                    read.Close();

                    getDateSqlConnection.Close();
                    getWeightSqlConnection.Close();
                }
                catch
                {
                    MessageBox.Show("Something went wrong");
                    getWeightSqlConnection.Close();

                }
                finally
                {
                    getWeightSqlConnection.Close();
                }
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Can't connect to the server");
                        break;
                }

            }
            catch
            {
                MessageBox.Show("Something went wrong while updating the graph");
            }
            finally
            {
                MessageBox.Show("Press again to load next graph");
            }
        }

    }
}
