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

/// <summary>
/// This is the Main Page Form
/// </summary>

namespace MainPageGraphs
{
    /// <summary>
    /// This is the "MAIN" page users will be using to keep in check their dietary goals.
    /// It shows various information through graphs and makes sure a user will know, visually if they're improving or not.
    /// </summary>
    public partial class MainPageForm : Form
    {
        private Chart WeightChart;
        private Chart CalorieChart;
        private TextBox displayMaxCalorie;
        private Button Edit_User;
        private Button Log_off;
        private TextBox UserData;
        private TextBox weightInfo;
        private TextBox MainPageCalorieText;
        private Button UpdateCalories;

        internal string userName { get; }

        /// <summary>
        /// Grabs the necessary information for the form to know which user is logged in
        /// </summary>
        public MainPageForm(string user)
        {
            this.userName = user;
            InitializeComponent();
        }

        //Initializes methods used to load forms
        /*private void ClickToLoadGraph(object sender, EventArgs e)
        {
            Initialize_weightOverTimeChart();
            Initialize_CalorieChart();
            GetUserData();
            GetWeightData();

        }*/
        private void MainPageForm_Load(object sender, EventArgs e)
        {
            CurrentDayData();
            Initialize_weightOverTimeChart();
            Initialize_CalorieChart();
            GetUserData();
            GetWeightData();
        }

        private void Initialize_weightOverTimeChart()
        {
            try
            {
                MySqlConnection conW = DietTracker.DatabaseConnect.OpenDefaultDBConnection();

                MySqlCommand weightCommand = new MySqlCommand();
                weightCommand.CommandText = "SELECT Weight, Date FROM day WHERE UserID = '" + userName + "';";
                weightCommand.Connection = conW;

                try
                {
                    conW.Open();
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
                int height, age, activity;
                double weight;
                string gender, name;
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
                weight = userWeightRead.GetDouble(0);
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
                CalorieChart.Series["CalorieIntake"].Points.AddXY("Calories left", caloriesLeft);

                //Inserts text for the BMI value
                double showBMI = bmrValue.BMICalc(75, 175);
                double newShow = showBMI * 10000;
                string visible = "Calories eaten: " + info.CaloriesEaten + Environment.NewLine +
                                 "Calories left for today: " + caloriesLeft + Environment.NewLine + Environment.NewLine +
                                 "BMR value (Basal Metabolic Rate)" + Environment.NewLine +
                                 "Calories: " + show + Environment.NewLine + Environment.NewLine +
                                 "BMI Value (Body Mass Index): " + Environment.NewLine + newShow;

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

                    string text = "User Data" + Environment.NewLine + Environment.NewLine +
                                  "Username: " + usernameOfUser + Environment.NewLine +
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

        private void GetWeightData()
        {
            try
            {
                MySqlConnection conW_User = DietTracker.DatabaseConnect.OpenDefaultDBConnection();
                MySqlConnection conDW_User = DietTracker.DatabaseConnect.OpenDefaultDBConnection();

                MySqlCommand userWeightCommand = new MySqlCommand();
                userWeightCommand.CommandText = "SELECT Weight FROM users WHERE Username = '" + userName + "';";
                userWeightCommand.Connection = conW_User;

                var dateTimeToday = DateTime.Today.ToString("yyyy-MM-dd");
                MySqlCommand dayWeightCommand = new MySqlCommand();
                dayWeightCommand.CommandText = "SELECT Weight FROM day WHERE UserID = '" + userName + "' AND Date = '" + dateTimeToday + "';";
                dayWeightCommand.Connection = conDW_User;

                conW_User.Open();
                conDW_User.Open();
                MySqlDataReader userWeightReader = userWeightCommand.ExecuteReader();
                MySqlDataReader dayWeightReader = dayWeightCommand.ExecuteReader();
                while (userWeightReader.Read() && dayWeightReader.Read())
                {
                    int startingWeight = userWeightReader.GetInt32(0);
                    int currentWeight = dayWeightReader.GetInt32(0);
                    //int currentWeight = 70;
                    int GainOrLoss = startingWeight - currentWeight;

                    string text = "Your Weight data" + Environment.NewLine + Environment.NewLine +
                                  "Your starting weight is: " + startingWeight + Environment.NewLine +
                                  "Your current weight is: " + currentWeight + Environment.NewLine +
                                  "Your gain/loss of weight is: " + GainOrLoss;

                    weightInfo.Text = text;
                }
                userWeightReader.Close();
                dayWeightReader.Close();
                conW_User.Close();
                conDW_User.Close();
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

        private void CurrentDayData()
        {
            try
            {
                var dateTimeToday = DateTime.Today.ToString("yyyy-MM-dd");
                MySqlConnection conCDD = DietTracker.DatabaseConnect.OpenDefaultDBConnection();
                MySqlCommand DoesDataExistCommand = new MySqlCommand();
                DoesDataExistCommand.CommandText = "SELECT Date FROM day WHERE UserID = '" + userName + "' AND Date = '" + dateTimeToday + "';";
                DoesDataExistCommand.Connection = conCDD;
                conCDD.Open();

                MySqlDataReader DoesDataExistRead = DoesDataExistCommand.ExecuteReader();
                if (DoesDataExistRead.Read() == true)
                {
                    conCDD.Close();
                }
                else
                {
                    try
                    {
                        MySqlConnection conI = DietTracker.DatabaseConnect.OpenDefaultDBConnection();
                        MySqlConnection conR = DietTracker.DatabaseConnect.OpenDefaultDBConnection();


                        MySqlCommand ReadWeightFromDataDayCommand = new MySqlCommand();
                        ReadWeightFromDataDayCommand.CommandText =
                            "SELECT Weight FROM day WHERE UserID = '" + userName + "' AND Date >= COALESCE((SELECT Date FROM day ORDER BY Date DESC LIMIT 1),(SELECT MAX(Date) FROM day));";
                        ReadWeightFromDataDayCommand.Connection = conR;
                        conR.Open();
                        MySqlDataReader ReadWeight = ReadWeightFromDataDayCommand.ExecuteReader();
                        ReadWeight.Read();
                        double Weight = ReadWeight.GetDouble(0);
                        conR.Close();

                        MySqlCommand InsertDataCommand = new MySqlCommand();
                        InsertDataCommand.CommandText =
                            "INSERT INTO day (Date, Weight, Calories, UserID)" +
                            "VALUES ('" + dateTimeToday + "', '" + Weight + "', 0, '" + userName + "');";
                        InsertDataCommand.Connection = conI;
                        conI.Open();
                        InsertDataCommand.ExecuteNonQuery();
                        conI.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Couldn't insert data for new day on login");
                    }
                }

            }
            catch (MySqlException ex)
            {
                //MessageBox.Show("Something happened" + ex);
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.");
                        break;
                    case 1062:
                        MessageBox.Show("That Username is already in use");
                        break;
                    case 1264:
                        MessageBox.Show("You can't be higher than 255 cm (Come on, you're not that tall)");
                        break;
                }
            }
        }

        private void EditUserData(object sender, EventArgs e)
        {
            DietTracker.UpdataPage.UpdatePageForm UpdateForm = new DietTracker.UpdataPage.UpdatePageForm(userName);
            UpdateForm.Tag = this;
            Hide();
            UpdateForm.Show(this);
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



        Calorieupdater Calories = new Calorieupdater("");

        private void ClickToLoadCalories(object sender, EventArgs e)
        {
            string calories = MainPageCalorieText.Text;

            if(Calories.IsCaloriesInputCorrect(calories))
            {
                try
                {
                    var dateTimeToday = DateTime.Today.ToString("yyyy-MM-dd");
                    MySqlConnection conCal = DietTracker.DatabaseConnect.OpenDefaultDBConnection();
                    MySqlConnection conCCal = DietTracker.DatabaseConnect.OpenDefaultDBConnection();

                    MySqlCommand WhatIsCurrentCalorieCommand = new MySqlCommand();
                    WhatIsCurrentCalorieCommand.CommandText = "SELECT Calories FROM day WHERE UserID = '" + userName + "' AND Date = '" + dateTimeToday + "';";
                    WhatIsCurrentCalorieCommand.Connection = conCCal;
                    conCCal.Open();
                    MySqlDataReader ReadCalories = WhatIsCurrentCalorieCommand.ExecuteReader();
                    ReadCalories.Read();
                    int CaloriesRead = ReadCalories.GetInt32(0);
                    conCCal.Close();

                    int CaloriesVal = Int32.Parse(calories);

                    MessageBox.Show(CaloriesVal.ToString());
                    MessageBox.Show(CaloriesRead.ToString());

                    CaloriesRead += CaloriesVal;

                    MySqlCommand UpdateCaloriesCommand = new MySqlCommand();
                    UpdateCaloriesCommand.CommandText = "UPDATE day SET Calories = '" + CaloriesRead + "' WHERE UserID = '" + userName + "' AND Date = '" + dateTimeToday + "';";
                    UpdateCaloriesCommand.Connection = conCal;
                    conCal.Open();
                    UpdateCaloriesCommand.ExecuteNonQuery();
                    conCal.Close();

                    MessageBox.Show("Updated calories succesfully to: " + CaloriesRead);
                    
                }
                catch
                {
                    MessageBox.Show("Something went wrong, whops2");
                }
            }
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.WeightChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.CalorieChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.UpdateCalories = new System.Windows.Forms.Button();
            this.displayMaxCalorie = new System.Windows.Forms.TextBox();
            this.Edit_User = new System.Windows.Forms.Button();
            this.Log_off = new System.Windows.Forms.Button();
            this.UserData = new System.Windows.Forms.TextBox();
            this.weightInfo = new System.Windows.Forms.TextBox();
            this.MainPageCalorieText = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.WeightChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CalorieChart)).BeginInit();
            this.SuspendLayout();
            // 
            // WeightChart
            // 
            this.WeightChart.Anchor = System.Windows.Forms.AnchorStyles.Left;
            chartArea7.Name = "ChartArea1";
            this.WeightChart.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            this.WeightChart.Legends.Add(legend7);
            this.WeightChart.Location = new System.Drawing.Point(12, 268);
            this.WeightChart.Name = "WeightChart";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.Legend = "Legend1";
            series7.Name = "Weight";
            this.WeightChart.Series.Add(series7);
            this.WeightChart.Size = new System.Drawing.Size(459, 181);
            this.WeightChart.TabIndex = 0;
            this.WeightChart.TabStop = false;
            this.WeightChart.Text = "WeightChart";
            // 
            // CalorieChart
            // 
            this.CalorieChart.Anchor = System.Windows.Forms.AnchorStyles.Left;
            chartArea8.Name = "ChartArea1";
            this.CalorieChart.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            this.CalorieChart.Legends.Add(legend8);
            this.CalorieChart.Location = new System.Drawing.Point(11, 38);
            this.CalorieChart.Name = "CalorieChart";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series8.Legend = "Legend1";
            series8.Name = "CalorieIntake";
            this.CalorieChart.Series.Add(series8);
            this.CalorieChart.Size = new System.Drawing.Size(238, 114);
            this.CalorieChart.TabIndex = 1;
            this.CalorieChart.TabStop = false;
            this.CalorieChart.Text = "CalorieChart";
            // 
            // UpdateCalories
            // 
            this.UpdateCalories.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UpdateCalories.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UpdateCalories.Location = new System.Drawing.Point(350, 239);
            this.UpdateCalories.Name = "UpdateCalories";
            this.UpdateCalories.Size = new System.Drawing.Size(106, 23);
            this.UpdateCalories.TabIndex = 2;
            this.UpdateCalories.Text = "Update Calories";
            this.UpdateCalories.UseVisualStyleBackColor = true;
            this.UpdateCalories.Click += new System.EventHandler(this.ClickToLoadCalories);
            // 
            // displayMaxCalorie
            // 
            this.displayMaxCalorie.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.displayMaxCalorie.BackColor = System.Drawing.SystemColors.Window;
            this.displayMaxCalorie.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.displayMaxCalorie.Location = new System.Drawing.Point(12, 158);
            this.displayMaxCalorie.Multiline = true;
            this.displayMaxCalorie.Name = "displayMaxCalorie";
            this.displayMaxCalorie.ReadOnly = true;
            this.displayMaxCalorie.Size = new System.Drawing.Size(237, 104);
            this.displayMaxCalorie.TabIndex = 3;
            this.displayMaxCalorie.TabStop = false;
            // 
            // Edit_User
            // 
            this.Edit_User.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Edit_User.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Edit_User.Location = new System.Drawing.Point(174, 7);
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
            this.Log_off.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Log_off.Location = new System.Drawing.Point(12, 7);
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
            this.UserData.BackColor = System.Drawing.SystemColors.Window;
            this.UserData.Location = new System.Drawing.Point(256, 9);
            this.UserData.Multiline = true;
            this.UserData.Name = "UserData";
            this.UserData.ReadOnly = true;
            this.UserData.Size = new System.Drawing.Size(215, 143);
            this.UserData.TabIndex = 5;
            this.UserData.TabStop = false;
            // 
            // weightInfo
            // 
            this.weightInfo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.weightInfo.Location = new System.Drawing.Point(256, 159);
            this.weightInfo.Multiline = true;
            this.weightInfo.Name = "weightInfo";
            this.weightInfo.ReadOnly = true;
            this.weightInfo.Size = new System.Drawing.Size(215, 74);
            this.weightInfo.TabIndex = 6;
            this.weightInfo.TabStop = false;
            // 
            // MainPageCalorieText
            // 
            this.MainPageCalorieText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MainPageCalorieText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainPageCalorieText.Location = new System.Drawing.Point(268, 239);
            this.MainPageCalorieText.MaxLength = 9999;
            this.MainPageCalorieText.Name = "MainPageCalorieText";
            this.MainPageCalorieText.Size = new System.Drawing.Size(76, 23);
            this.MainPageCalorieText.TabIndex = 7;
            // 
            // MainPageForm
            // 
            this.AcceptButton = this.UpdateCalories;
            this.AllowDrop = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.UpdateCalories);
            this.Controls.Add(this.MainPageCalorieText);
            this.Controls.Add(this.weightInfo);
            this.Controls.Add(this.UserData);
            this.Controls.Add(this.Log_off);
            this.Controls.Add(this.Edit_User);
            this.Controls.Add(this.displayMaxCalorie);
            this.Controls.Add(this.CalorieChart);
            this.Controls.Add(this.WeightChart);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainPageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Diet Tracker v.0.1";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainPage_Closed);
            this.Load += new System.EventHandler(this.MainPageForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.WeightChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CalorieChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    }
}
