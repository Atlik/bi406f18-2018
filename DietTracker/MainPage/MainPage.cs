using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Formler_BMI_BMR;
using MySql.Data.MySqlClient;
using Login;

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
        private Button Log_off;
        private TextBox UserData;
        private Button LoadGraphs;

        internal string userName { get; }

        /// <summary>
        /// 
        /// </summary>
        public MainPageForm(string user)
        {
            this.userName = user;
            InitializeComponent();
        }

        //Initializes methods used to load forms
        private void ClickToLoadGraph(object sender, EventArgs e)
        {
            Initialize_weightOverTimeChart();
            Initialize_CalorieChart();
            GetUserData();

        }

        private void Initialize_weightOverTimeChart()
        {
            try
            {
                MySqlConnection conW = DietTracker.DatabaseConnect.OpenDefaultDBConnection();

                MySqlCommand weightCommand = new MySqlCommand();
                weightCommand.CommandText = "SELECT Weight, Date FROM day";
                weightCommand.Connection = conW;

                try
                {
                    MessageBox.Show("Opens connection");
                    conW.Open();
                    MessageBox.Show("Connected to table (day)");

                    MySqlDataReader readWeight = weightCommand.ExecuteReader();

                    #region Skrald

                    /* MySqlCommand dateCommand = new MySqlCommand();
                    dateCommand.CommandText = "SELECT Date FROM diettracker.day";
                    dateCommand.Connection = conW;*/
                    /*
                    MessageBox.Show("Opens connection");
                    conW.Open();
                    MessageBox.Show("Connected to table (date)");*/

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

                    MessageBox.Show("Will now insert data into fields");

                    while (readWeight.Read())
                    {
                        int newWeight = readWeight.GetInt32(0);
                        string newDayInput = readWeight.GetDateTime(1).ToShortDateString();

                        WeightChart.Series["Weight"].Points.AddXY(newDayInput, newWeight);
                        WeightChart.ChartAreas[0].RecalculateAxesScale();
                    }

                    readWeight.Close();
                    conW.Close();
                }
                catch
                {
                    MessageBox.Show("Something went wrong");
                    conW.Close();

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
        }

        private void Initialize_CalorieChart()
        {
            try
            {
                double height, age, weight, activity;
                string gender;
                bool sex = true;

                MySqlConnection conCal = DietTracker.DatabaseConnect.OpenDefaultDBConnection();

                MySqlCommand heightCommand = new MySqlCommand();
                heightCommand.CommandText = "SELECT Height FROM users WHERE Username = '" + userName + "';";
                heightCommand.Connection = conCal;

                MySqlCommand weightCommand = new MySqlCommand();
                weightCommand.CommandText = "SELECT Weight FROM users WHERE Username = '" + userName + "';";
                weightCommand.Connection = conCal;

                MySqlCommand activityCommand = new MySqlCommand();
                activityCommand.CommandText = "SELECT Activity FROM users WHERE Username = '" + userName + "';";
                activityCommand.Connection = conCal;

                MySqlCommand ageCommand = new MySqlCommand();
                ageCommand.CommandText = "SELECT DoB FROM users WHERE Username = '" + userName + "';";
                ageCommand.Connection = conCal;

                MySqlCommand genderCommand = new MySqlCommand();
                genderCommand.CommandText = "SELECT Gender FROM users WHERE Username = '" + userName + "';";
                genderCommand.Connection = conCal;

                conCal.Open();
                MySqlDataReader userHeightRead = heightCommand.ExecuteReader();
                userHeightRead.Read();
                height = userHeightRead.GetInt32(0);
                userHeightRead.Close();
                conCal.Close();

                conCal.Open();
                MySqlDataReader userWeightRead = weightCommand.ExecuteReader();
                userWeightRead.Read();
                weight = userWeightRead.GetInt32(0);
                userWeightRead.Close();
                conCal.Close();

                conCal.Open();
                MySqlDataReader userActivityRead = activityCommand.ExecuteReader();
                userActivityRead.Read();
                activity = userActivityRead.GetInt32(0);
                userActivityRead.Close();
                conCal.Close();

                conCal.Open();
                MySqlDataReader userDoBRead = ageCommand.ExecuteReader();
                userDoBRead.Read();
                string DoB = userDoBRead.GetDateTime(0).ToShortDateString();
                DateTime parsedDoB = DateTime.Parse(DoB);
                var dateTimeToday = DateTime.Today;
                age = dateTimeToday.Year - parsedDoB.Year;
                userDoBRead.Close();
                conCal.Close();


                conCal.Open();
                MySqlDataReader userGenderRead = genderCommand.ExecuteReader();
                userGenderRead.Read();
                gender = userGenderRead.GetString(0);
                if (gender == "Male")
                {
                    sex = true;
                }
                else if (gender == "Female")
                {
                    sex = false;
                }
                userGenderRead.Close();
                conCal.Close();

                //Inserts BMR value in text field
                Formler bmrValue = new Formler();
                double show = bmrValue.BMRCalc(height, age, weight, activity, sex);

                //Constucts graph
                var info = new UpdateCaloriesGraph(show, 1500);
                double caloriesLeft = info.maxCalories - info.CaloriesEaten;
                CalorieChart.Series["CalorieIntake"].Points.AddXY("Calories Eaten", info.maxCalories);
                CalorieChart.Series["CalorieIntake"].Points.AddXY("Calorie left", caloriesLeft);

                //Inserts text for the BMI value
                double showBMI = bmrValue.BMICalc(75, 175);
                double newShow = showBMI * 10000;
                string visible = "BMR value (Calories): " + Environment.NewLine + show + Environment.NewLine +
                                 "BMI Value" + Environment.NewLine + newShow;

                displayMaxCalorie.Text = visible;

            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error happened in Connection:" + Environment.NewLine + e);
            }
            catch (Exception)
            {
                MessageBox.Show("Something unexpected happened");
            }
        }

        private void GetUserData()
        {
            try
            {
                MySqlConnection conUser = DietTracker.DatabaseConnect.OpenDefaultDBConnection();

                MySqlCommand userCommand = new MySqlCommand();
                userCommand.CommandText = "SELECT Username, Name, Gender, DoB, Height, Weight, Activity FROM users WHERE Username = '" + userName + "';";
                userCommand.Connection = conUser;

                conUser.Open();
                MySqlDataReader userReader = userCommand.ExecuteReader();
                while (userReader.Read())
                {
                    string usernameOfUser = userReader.GetString(0);
                    string nameOfUser = userReader.GetString(1);
                    string genderOfUser = userReader.GetString(2);
                    string DoB_User = userReader.GetDateTime(3).ToShortDateString();
                    int heightOfUser = userReader.GetInt32(4);
                    int weightOfUser = userReader.GetInt32(5);
                    int activityLevelOfUser = userReader.GetInt32(6);

                    DateTime parsedDoB_User = DateTime.Parse(DoB_User);
                    var dateTimeToday = DateTime.Today;
                    int age = dateTimeToday.Year - parsedDoB_User.Year;

                    string text = "Username: " + usernameOfUser + Environment.NewLine +
                                  "Name: " + nameOfUser + Environment.NewLine +
                                  "Gender: " + genderOfUser + Environment.NewLine +
                                  "Your birthday: " + DoB_User + Environment.NewLine +
                                  "Your age: " + age + Environment.NewLine +
                                  "Your current weight: " + weightOfUser + Environment.NewLine +
                                  "Your current height: " + heightOfUser + Environment.NewLine +
                                  "Your current Activity Level: " + activityLevelOfUser;

                    UserData.Text = text;
                }
                userReader.Close();
                conUser.Close();
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
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading data: \r\n" + e);
            }
        }

        private void EditUserData(object sender, EventArgs e)
        {
            MessageBox.Show("Under development");
        }

        private void LogOffToHome(object sender, EventArgs e)
        {
            LandingPage.LandingPageForm landingPageForm = new LandingPage.LandingPageForm();
            landingPageForm.Tag = this;
            Hide();
            landingPageForm.Show(this);
        }

        private void MainPage_Closed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.WeightChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.CalorieChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.LoadGraphs = new System.Windows.Forms.Button();
            this.displayMaxCalorie = new System.Windows.Forms.TextBox();
            this.Edit_User = new System.Windows.Forms.Button();
            this.Log_off = new System.Windows.Forms.Button();
            this.UserData = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.WeightChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CalorieChart)).BeginInit();
            this.SuspendLayout();
            // 
            // WeightChart
            // 
            this.WeightChart.Anchor = System.Windows.Forms.AnchorStyles.Left;
            chartArea3.Name = "ChartArea1";
            this.WeightChart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.WeightChart.Legends.Add(legend3);
            this.WeightChart.Location = new System.Drawing.Point(12, 268);
            this.WeightChart.Name = "WeightChart";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "Weight";
            this.WeightChart.Series.Add(series3);
            this.WeightChart.Size = new System.Drawing.Size(459, 181);
            this.WeightChart.TabIndex = 0;
            this.WeightChart.Text = "WeightChart";
            // 
            // CalorieChart
            // 
            this.CalorieChart.Anchor = System.Windows.Forms.AnchorStyles.Left;
            chartArea4.Name = "ChartArea1";
            this.CalorieChart.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.CalorieChart.Legends.Add(legend4);
            this.CalorieChart.Location = new System.Drawing.Point(11, 38);
            this.CalorieChart.Name = "CalorieChart";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series4.Legend = "Legend1";
            series4.Name = "CalorieIntake";
            this.CalorieChart.Series.Add(series4);
            this.CalorieChart.Size = new System.Drawing.Size(238, 114);
            this.CalorieChart.TabIndex = 1;
            this.CalorieChart.Text = "CalorieChart";
            // 
            // LoadGraphs
            // 
            this.LoadGraphs.Anchor = System.Windows.Forms.AnchorStyles.Top;
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
            this.displayMaxCalorie.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.displayMaxCalorie.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.displayMaxCalorie.Location = new System.Drawing.Point(12, 158);
            this.displayMaxCalorie.Multiline = true;
            this.displayMaxCalorie.Name = "displayMaxCalorie";
            this.displayMaxCalorie.ReadOnly = true;
            this.displayMaxCalorie.Size = new System.Drawing.Size(237, 104);
            this.displayMaxCalorie.TabIndex = 3;
            // 
            // Edit_User
            // 
            this.Edit_User.Anchor = System.Windows.Forms.AnchorStyles.Top;
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
            this.Log_off.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Log_off.BackColor = System.Drawing.Color.White;
            this.Log_off.Location = new System.Drawing.Point(12, 9);
            this.Log_off.Name = "Log_off";
            this.Log_off.Size = new System.Drawing.Size(75, 23);
            this.Log_off.TabIndex = 0;
            this.Log_off.Text = "LogOff";
            this.Log_off.UseVisualStyleBackColor = false;
            this.Log_off.Click += new System.EventHandler(this.LogOffToHome);
            // 
            // UserData
            // 
            this.UserData.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.UserData.Location = new System.Drawing.Point(256, 9);
            this.UserData.Multiline = true;
            this.UserData.Name = "UserData";
            this.UserData.ReadOnly = true;
            this.UserData.Size = new System.Drawing.Size(215, 253);
            this.UserData.TabIndex = 5;
            // 
            // MainPageForm
            // 
            this.AllowDrop = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.UserData);
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
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainPage_Closed);
            ((System.ComponentModel.ISupportInitialize)(this.WeightChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CalorieChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
