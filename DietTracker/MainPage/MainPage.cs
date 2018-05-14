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
    /// <summary>
    /// 
    /// </summary>
    public partial class MainPageForm : Form
    {
        private Chart WeightChart;
        private Chart CalorieChart;
        private Button button1;
        /// <summary>
        /// 
        /// </summary>
        public MainPageForm()
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

            CalorieChart.Series["CalorieIntake"].Points.AddXY("Calories Eaten", info.maxCalories);
            CalorieChart.Series["CalorieIntake"].Points.AddXY("Calorie left", caloriesLeft);
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

                        WeightChart.Series["Weight"].Points.AddXY(newDayInput, newWeight);
                        WeightChart.ChartAreas[0].RecalculateAxesScale();
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

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.WeightChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.CalorieChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.WeightChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CalorieChart)).BeginInit();
            this.SuspendLayout();
            // 
            // WeightChart
            // 
            chartArea1.Name = "ChartArea1";
            this.WeightChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.WeightChart.Legends.Add(legend1);
            this.WeightChart.Location = new System.Drawing.Point(12, 204);
            this.WeightChart.Name = "WeightChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.WeightChart.Series.Add(series1);
            this.WeightChart.Size = new System.Drawing.Size(361, 181);
            this.WeightChart.TabIndex = 0;
            this.WeightChart.Text = "WeightChart";
            this.WeightChart.Validating += new System.ComponentModel.CancelEventHandler(this.weightOverTimeChart_Validating);
            // 
            // CalorieChart
            // 
            chartArea2.Name = "ChartArea1";
            this.CalorieChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.CalorieChart.Legends.Add(legend2);
            this.CalorieChart.Location = new System.Drawing.Point(12, 12);
            this.CalorieChart.Name = "CalorieChart";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.CalorieChart.Series.Add(series2);
            this.CalorieChart.Size = new System.Drawing.Size(138, 157);
            this.CalorieChart.TabIndex = 1;
            this.CalorieChart.Text = "CalorieChart";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(183, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "LoadGraph";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ClickToLoadGraph);
            // 
            // MainPageForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 397);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CalorieChart);
            this.Controls.Add(this.WeightChart);
            this.Name = "MainPageForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.WeightChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CalorieChart)).EndInit();
            this.ResumeLayout(false);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
