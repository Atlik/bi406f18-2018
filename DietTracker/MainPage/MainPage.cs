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
using Formler_BMI_BMR;
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
        private TextBox displayMaxCalorie;
        private Button Edit_User;
        private Button LogOff;
        private Button Log_off;
        private Button LoadGraphs;
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
            Initialize_weightOverTimeChart();
            InitializeText();
            Initialize_CalorieChart();
        }

        private void Initialize_weightOverTimeChart()
        {
            try
            {
                MySqlConnection getWeightSqlConnection = new MySqlConnection();
                getWeightSqlConnection.ConnectionString =
                    "server=localhost;user id=root;pwd=atlik91502.sql;database=diettracker;SslMode=none";

                MySqlCommand weightCommand = new MySqlCommand();
                weightCommand.CommandText = "SELECT Weight FROM day";
                weightCommand.Connection = getWeightSqlConnection;

                try
                {
                    MySqlConnection getDateSqlConnection = new MySqlConnection();
                    getDateSqlConnection.ConnectionString =
                        "server=localhost;user id=root;pwd=atlik91502.sql;database=diettracker;SslMode=none";

                    MySqlCommand dateCommand = new MySqlCommand();
                    dateCommand.CommandText = "SELECT Date FROM diettracker.day";
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.WeightChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.CalorieChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.LoadGraphs = new System.Windows.Forms.Button();
            this.displayMaxCalorie = new System.Windows.Forms.TextBox();
            this.Edit_User = new System.Windows.Forms.Button();
            this.Log_off = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.WeightChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CalorieChart)).BeginInit();
            this.SuspendLayout();
            // 
            // WeightChart
            // 
            this.WeightChart.Anchor = System.Windows.Forms.AnchorStyles.None;
            chartArea5.Name = "ChartArea1";
            this.WeightChart.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.WeightChart.Legends.Add(legend5);
            this.WeightChart.Location = new System.Drawing.Point(12, 268);
            this.WeightChart.Name = "WeightChart";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Legend = "Legend1";
            series5.Name = "Weight";
            this.WeightChart.Series.Add(series5);
            this.WeightChart.Size = new System.Drawing.Size(459, 181);
            this.WeightChart.TabIndex = 0;
            this.WeightChart.Text = "WeightChart";
            // 
            // CalorieChart
            // 
            chartArea6.Name = "ChartArea1";
            this.CalorieChart.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.CalorieChart.Legends.Add(legend6);
            this.CalorieChart.Location = new System.Drawing.Point(11, 38);
            this.CalorieChart.Name = "CalorieChart";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series6.Legend = "Legend1";
            series6.Name = "CalorieIntake";
            this.CalorieChart.Series.Add(series6);
            this.CalorieChart.Size = new System.Drawing.Size(238, 114);
            this.CalorieChart.TabIndex = 1;
            this.CalorieChart.Text = "CalorieChart";
            // 
            // LoadGraphs
            // 
            this.LoadGraphs.Location = new System.Drawing.Point(93, 9);
            this.LoadGraphs.Name = "LoadGraphs";
            this.LoadGraphs.Size = new System.Drawing.Size(75, 23);
            this.LoadGraphs.TabIndex = 2;
            this.LoadGraphs.Text = "LoadGraphs";
            this.LoadGraphs.UseVisualStyleBackColor = true;
            this.LoadGraphs.Click += new System.EventHandler(this.ClickToLoadGraph);
            // 
            // displayMaxCalorie
            // 
            this.displayMaxCalorie.Location = new System.Drawing.Point(12, 158);
            this.displayMaxCalorie.Multiline = true;
            this.displayMaxCalorie.Name = "displayMaxCalorie";
            this.displayMaxCalorie.ReadOnly = true;
            this.displayMaxCalorie.Size = new System.Drawing.Size(237, 104);
            this.displayMaxCalorie.TabIndex = 3;
            // 
            // Edit_User
            // 
            this.Edit_User.Location = new System.Drawing.Point(174, 9);
            this.Edit_User.Name = "Edit_User";
            this.Edit_User.Size = new System.Drawing.Size(75, 23);
            this.Edit_User.TabIndex = 4;
            this.Edit_User.Text = "EditUser";
            this.Edit_User.UseVisualStyleBackColor = true;
            this.Edit_User.Click += new System.EventHandler(this.EditUserData);
            // 
            // Log_off
            // 
            this.Log_off.BackColor = System.Drawing.Color.White;
            this.Log_off.Location = new System.Drawing.Point(12, 9);
            this.Log_off.Name = "Log_off";
            this.Log_off.Size = new System.Drawing.Size(75, 23);
            this.Log_off.TabIndex = 0;
            this.Log_off.Text = "LogOff";
            this.Log_off.UseVisualStyleBackColor = false;
            this.Log_off.Click += new System.EventHandler(this.LogOffToHome);
            // 
            // MainPageForm
            // 
            this.AllowDrop = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.Log_off);
            this.Controls.Add(this.Edit_User);
            this.Controls.Add(this.displayMaxCalorie);
            this.Controls.Add(this.LoadGraphs);
            this.Controls.Add(this.CalorieChart);
            this.Controls.Add(this.WeightChart);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainPageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.WeightChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CalorieChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        private void InitializeText()
        {
            Formler maxCalorie = new Formler();
            double show = maxCalorie.BMICalc(75, 175);
            string visible = "Max calories you can eat:" + Environment.NewLine + show;
            displayMaxCalorie.Text = visible;
        }

        private void Initialize_CalorieChart()
        {
            // Alt efter hvad og hvordan BMI udregning giver max antal calorier skal dette indsættes i points på denne måde
            var info = new UpdateCaloriesGraph(2600, 1500);

            int caloriesLeft = info.maxCalories - info.CaloriesEaten;

            CalorieChart.Series["CalorieIntake"].Points.AddXY("Calories Eaten", info.maxCalories);
            CalorieChart.Series["CalorieIntake"].Points.AddXY("Calorie left", caloriesLeft);
        }

        private void EditUserData(object sender, EventArgs e)
        {

        }

        private void LogOffToHome(object sender, EventArgs e)
        {
            LandingPage.LandingPageForm landingPageForm = new LandingPage.LandingPageForm();
            landingPageForm.Tag = this;
            Hide();
            landingPageForm.Show(this);
        }
    }
}
