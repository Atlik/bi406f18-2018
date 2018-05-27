using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Formler_BMI_BMR;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace MainPageGraphs
{
    /// <summary>
    /// This is the "MAIN" page users will be using to keep in check their dietary goals.
    /// It shows various information through graphs and makes sure a user will know, visually if they're improving or not.
    /// </summary>
    public partial class MainPageForm : Form
    {
        private Chart _weightChart;
        private Chart _calorieChart;
        private TextBox _displayMaxCalorie;
        private Button _editUser;
        private Button _logOff;
        private TextBox _userData;
        private TextBox _weightInfo;
        private TextBox _mainPageCalorieText;
        private Button _updateWeight;
        private TextBox _mainPageWeightText;
        private Button _updateCalories;

        private string Username { get; }
        private int CaloriesEaten { get; }

        /// <summary>
        /// Grabs the necessary information for the form to know which user is logged in
        /// <param name="calEaten"> Calories eaten </param>
        /// <param name="user"> Name of user </param>
        /// </summary>
        public MainPageForm(string user, int calEaten)
        {
            this.Username = user;
            this.CaloriesEaten = calEaten;
            InitializeComponent();
        }

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
                weightCommand.CommandText = "SELECT Weight, Date FROM day WHERE UserID = '" + Username + "';";
                weightCommand.Connection = conW;

                try
                {
                    conW.Open();
                    MySqlDataReader readWeight = weightCommand.ExecuteReader();

                    while (readWeight.Read())
                    {
                        int newWeight = readWeight.GetInt32(0);
                        string newDayInput = readWeight.GetDateTime(1).ToShortDateString();

                        _weightChart.Series["Weight"].Points.AddXY(newDayInput, newWeight);
                        _weightChart.ChartAreas[0].RecalculateAxesScale();
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
                string gender;
                bool sex = true;

                var dateTimeToday1 = DateTime.Today.ToString("yyyy-MM-dd");

                MySqlConnection conCal = DietTracker.DatabaseConnect.OpenDefaultDBConnection();

                MySqlCommand heightCommand = new MySqlCommand();
                heightCommand.CommandText = "SELECT Height FROM users WHERE Username = '" + Username + "';";
                heightCommand.Connection = conCal;

                MySqlCommand weightCommand = new MySqlCommand();
                weightCommand.CommandText = "SELECT Weight FROM day WHERE UserID = '" + Username + "' AND Date = '" + dateTimeToday1 + "';";
                weightCommand.Connection = conCal;

                MySqlCommand activityCommand = new MySqlCommand();
                activityCommand.CommandText = "SELECT Activity FROM users WHERE Username = '" + Username + "';";
                activityCommand.Connection = conCal;

                MySqlCommand ageCommand = new MySqlCommand();
                ageCommand.CommandText = "SELECT DoB FROM users WHERE Username = '" + Username + "';";
                ageCommand.Connection = conCal;

                MySqlCommand genderCommand = new MySqlCommand();
                genderCommand.CommandText = "SELECT Gender FROM users WHERE Username = '" + Username + "';";
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

                MySqlConnection conWUser = DietTracker.DatabaseConnect.OpenDefaultDBConnection();
                
                MySqlCommand dayWeightCommand = new MySqlCommand();
                dayWeightCommand.CommandText = "SELECT Weight FROM day WHERE UserID = '" + Username + "' AND Date = '" + dateTimeToday1 + "';";
                dayWeightCommand.Connection = conWUser;
                conWUser.Open();
                MySqlDataReader dayWeightReader = dayWeightCommand.ExecuteReader();
                dayWeightReader.Read();
                double currentWeight = dayWeightReader.GetDouble(0);
                conWUser.Close();

                //Inserts BMR value in text field
                Formler bmrValue = new Formler();
                double show = bmrValue.BMRCalc(height, age, weight, activity, sex);

                //Constucts graph
                var info = new UpdateCaloriesGraph(show, CaloriesEaten);
                double caloriesLeft = info.maxCalories - info.CaloriesEaten;
                _calorieChart.Series["CalorieIntake"].Points.AddXY("Calories Eaten", info.maxCalories);
                _calorieChart.Series["CalorieIntake"].Points.AddXY("Calories left", caloriesLeft);

                //Inserts text for the BMI value
                double showBMI = bmrValue.BMICalc(currentWeight, height);
                double newShow = showBMI * 10000;
                string visible = "Calories eaten: " + info.CaloriesEaten + Environment.NewLine +
                                 "Calories left for today: " + caloriesLeft + Environment.NewLine + Environment.NewLine +
                                 "BMR value (Basal Metabolic Rate)" + Environment.NewLine +
                                 "Calories: " + show + Environment.NewLine + Environment.NewLine +
                                 "BMI Value (Body Mass Index): " + Environment.NewLine + Math.Round(newShow, 1);

                _displayMaxCalorie.Text = visible;

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
                userCommand.CommandText = "SELECT Username, Name, Gender, DoB, Height, Weight, Activity FROM users WHERE Username = '" + Username + "';";
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
                    double weightOfUser = userReader.GetDouble(5);
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
                                  "Your starting weight: " + weightOfUser + Environment.NewLine +
                                  "Your current height: " + heightOfUser + Environment.NewLine +
                                  "Your current Activity Level: " + activityLevelOfUser;

                    _userData.Text = text;
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
                MySqlConnection conWUser = DietTracker.DatabaseConnect.OpenDefaultDBConnection();
                MySqlConnection conDateWeightUser = DietTracker.DatabaseConnect.OpenDefaultDBConnection();

                MySqlCommand userWeightCommand = new MySqlCommand();
                userWeightCommand.CommandText = "SELECT Weight FROM users WHERE Username = '" + Username + "';";
                userWeightCommand.Connection = conWUser;

                var dateTimeToday = DateTime.Today.ToString("yyyy-MM-dd");
                MySqlCommand dayWeightCommand = new MySqlCommand();
                dayWeightCommand.CommandText = "SELECT Weight FROM day WHERE UserID = '" + Username + "' AND Date = '" + dateTimeToday + "';";
                dayWeightCommand.Connection = conDateWeightUser;

                conWUser.Open();
                conDateWeightUser.Open();
                MySqlDataReader userWeightReader = userWeightCommand.ExecuteReader();
                MySqlDataReader dayWeightReader = dayWeightCommand.ExecuteReader();
                while (userWeightReader.Read() && dayWeightReader.Read())
                {
                    double startingWeight = userWeightReader.GetDouble(0);
                    double currentWeight = dayWeightReader.GetDouble(0);
                    //int currentWeight = 70;
                    double GainOrLoss = startingWeight - currentWeight;

                    string text = "Your Weight data" + Environment.NewLine + Environment.NewLine +
                                  "Your starting weight is: " + startingWeight + Environment.NewLine +
                                  "Your current weight is: " + currentWeight + Environment.NewLine +
                                  "Your gain/loss of weight is: " + GainOrLoss;

                    _weightInfo.Text = text;
                }
                userWeightReader.Close();
                dayWeightReader.Close();
                conWUser.Close();
                conDateWeightUser.Close();
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

                MySqlConnection conCDayData = DietTracker.DatabaseConnect.OpenDefaultDBConnection();
                MySqlCommand doesDataExistCommand = new MySqlCommand();
                doesDataExistCommand.CommandText = "SELECT Date FROM day WHERE UserID = '" + Username + "' AND Date = '" + dateTimeToday + "';";
                doesDataExistCommand.Connection = conCDayData;
                conCDayData.Open();

                MySqlDataReader doesDataExistRead = doesDataExistCommand.ExecuteReader();
                if (doesDataExistRead.Read() == true)
                {
                    conCDayData.Close();
                }
                else
                {
                    try
                    {
                        MySqlConnection conI = DietTracker.DatabaseConnect.OpenDefaultDBConnection();
                        MySqlConnection conR = DietTracker.DatabaseConnect.OpenDefaultDBConnection();


                        MySqlCommand ReadWeightFromDataDayCommand = new MySqlCommand();
                        ReadWeightFromDataDayCommand.CommandText =
                            "SELECT Weight FROM day WHERE UserID = '" + Username + "' AND Date >= COALESCE((SELECT Date FROM day ORDER BY Date DESC LIMIT 1),(SELECT MAX(Date) FROM day));";
                        ReadWeightFromDataDayCommand.Connection = conR;
                        conR.Open();

                        MySqlDataReader readWeight = ReadWeightFromDataDayCommand.ExecuteReader();
                        readWeight.Read();
                        string weight = readWeight.GetDouble(0).ToString(CultureInfo.InvariantCulture);
                        conR.Close();

                        MySqlCommand insertDataCommand = new MySqlCommand();
                        insertDataCommand.CommandText =
                            "INSERT INTO day (Date, Weight, Calories, UserID)" +
                            "VALUES ('" + dateTimeToday + "', '" + weight + "', 0, '" + Username + "');";
                        insertDataCommand.Connection = conI;
                        conI.Open();
                        insertDataCommand.ExecuteNonQuery();
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
            DietTracker.UpdatePage.UpdatePageForm UpdateForm = new DietTracker.UpdatePage.UpdatePageForm(Username);
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
            string calories = _mainPageCalorieText.Text;

            if(Calories.IsCaloriesInputCorrect(calories))
            {
                try
                {
                    var dateTimeToday = DateTime.Today.ToString("yyyy-MM-dd");
                    MySqlConnection conCal = DietTracker.DatabaseConnect.OpenDefaultDBConnection();
                    MySqlConnection conCCal = DietTracker.DatabaseConnect.OpenDefaultDBConnection();

                    MySqlCommand whatIsCurrentCalorieCommand = new MySqlCommand();
                    whatIsCurrentCalorieCommand.CommandText = "SELECT Calories FROM day WHERE UserID = '" + Username + "' AND Date = '" + dateTimeToday + "';";
                    whatIsCurrentCalorieCommand.Connection = conCCal;

                    conCCal.Open();
                    MySqlDataReader readCalories = whatIsCurrentCalorieCommand.ExecuteReader();
                    readCalories.Read();
                    int caloriesRead = readCalories.GetInt32(0);
                    conCCal.Close();

                    int caloriesVal = Int32.Parse(calories);
                    caloriesRead += caloriesVal;

                    MySqlCommand updateCaloriesCommand = new MySqlCommand();
                    updateCaloriesCommand.CommandText = "UPDATE day SET Calories = '" + caloriesRead + "' WHERE UserID = '" + Username + "' AND Date = '" + dateTimeToday + "';";
                    updateCaloriesCommand.Connection = conCal;
                    conCal.Open();
                    updateCaloriesCommand.ExecuteNonQuery();
                    conCal.Close();

                    MessageBox.Show("Updated calories succesfully to: " + caloriesRead);
                    MainPageGraphs.MainPageForm mainPage = new MainPageGraphs.MainPageForm(Username, caloriesRead);
                    mainPage.Tag = this;
                    Hide();
                    mainPage.Show(this);

                }
                catch
                {
                    MessageBox.Show("Something with your input in calories was wrong, please try again");
                }
            }
        }

        Weightupdater Weights = new Weightupdater("");

        private void ClickToLoadWeight(object sender, EventArgs e)
        {
            string weight = _mainPageWeightText.Text;

            if (Weights.IsWeightInputCorrect(weight))
            {
                try
                {
                    var dateTimeToday = DateTime.Today.ToString("yyyy-MM-dd");
                    MySqlConnection conW = DietTracker.DatabaseConnect.OpenDefaultDBConnection();

                    MySqlCommand updateCaloriesCommand = new MySqlCommand();
                    updateCaloriesCommand.CommandText = "UPDATE day SET Weight = '" + weight + "' WHERE UserID = '" + Username + "' AND Date = '" + dateTimeToday + "';";
                    updateCaloriesCommand.Connection = conW;

                    conW.Open();
                    updateCaloriesCommand.ExecuteNonQuery();
                    conW.Close();

                    MessageBox.Show("Updated weight succesfully");

                    MainPageGraphs.MainPageForm mainPage = new MainPageGraphs.MainPageForm(Username, CaloriesEaten);
                    mainPage.Tag = this;
                    Hide();
                    mainPage.Show(this);
                }
                catch
                {
                    MessageBox.Show("Something went wrong in your weight input, please try again");
                }
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
            this._weightChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this._calorieChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this._updateCalories = new System.Windows.Forms.Button();
            this._displayMaxCalorie = new System.Windows.Forms.TextBox();
            this._editUser = new System.Windows.Forms.Button();
            this._logOff = new System.Windows.Forms.Button();
            this._userData = new System.Windows.Forms.TextBox();
            this._weightInfo = new System.Windows.Forms.TextBox();
            this._mainPageCalorieText = new System.Windows.Forms.TextBox();
            this._updateWeight = new System.Windows.Forms.Button();
            this._mainPageWeightText = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this._weightChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._calorieChart)).BeginInit();
            this.SuspendLayout();
            // 
            // _weightChart
            // 
            this._weightChart.Anchor = System.Windows.Forms.AnchorStyles.Left;
            chartArea1.Name = "ChartArea1";
            this._weightChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this._weightChart.Legends.Add(legend1);
            this._weightChart.Location = new System.Drawing.Point(12, 268);
            this._weightChart.Name = "_weightChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Weight";
            this._weightChart.Series.Add(series1);
            this._weightChart.Size = new System.Drawing.Size(459, 181);
            this._weightChart.TabIndex = 0;
            this._weightChart.TabStop = false;
            this._weightChart.Text = "_weightChart";
            // 
            // _calorieChart
            // 
            this._calorieChart.Anchor = System.Windows.Forms.AnchorStyles.Left;
            chartArea2.AxisX.IsLabelAutoFit = false;
            chartArea2.AxisX2.IsLabelAutoFit = false;
            chartArea2.AxisY.IsLabelAutoFit = false;
            chartArea2.AxisY2.IsLabelAutoFit = false;
            chartArea2.Name = "ChartArea1";
            this._calorieChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this._calorieChart.Legends.Add(legend2);
            this._calorieChart.Location = new System.Drawing.Point(11, 38);
            this._calorieChart.Name = "_calorieChart";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.LabelForeColor = System.Drawing.Color.Transparent;
            series2.Legend = "Legend1";
            series2.Name = "CalorieIntake";
            this._calorieChart.Series.Add(series2);
            this._calorieChart.Size = new System.Drawing.Size(238, 82);
            this._calorieChart.TabIndex = 0;
            this._calorieChart.TabStop = false;
            this._calorieChart.Text = "_calorieChart";
            // 
            // _updateCalories
            // 
            this._updateCalories.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._updateCalories.Cursor = System.Windows.Forms.Cursors.Hand;
            this._updateCalories.Location = new System.Drawing.Point(113, 239);
            this._updateCalories.Name = "_updateCalories";
            this._updateCalories.Size = new System.Drawing.Size(106, 23);
            this._updateCalories.TabIndex = 1;
            this._updateCalories.Text = "Update Calories";
            this._updateCalories.UseVisualStyleBackColor = true;
            this._updateCalories.Click += new System.EventHandler(this.ClickToLoadCalories);
            // 
            // displayMaxCalorie
            // 
            this._displayMaxCalorie.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._displayMaxCalorie.BackColor = System.Drawing.SystemColors.Window;
            this._displayMaxCalorie.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._displayMaxCalorie.Location = new System.Drawing.Point(12, 126);
            this._displayMaxCalorie.Multiline = true;
            this._displayMaxCalorie.Name = "_displayMaxCalorie";
            this._displayMaxCalorie.ReadOnly = true;
            this._displayMaxCalorie.Size = new System.Drawing.Size(237, 107);
            this._displayMaxCalorie.TabIndex = 0;
            this._displayMaxCalorie.TabStop = false;
            // 
            // Edit_User
            // 
            this._editUser.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this._editUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this._editUser.Location = new System.Drawing.Point(174, 7);
            this._editUser.Name = "_editUser";
            this._editUser.Size = new System.Drawing.Size(75, 23);
            this._editUser.TabIndex = 4;
            this._editUser.Text = "EditUser";
            this._editUser.UseVisualStyleBackColor = true;
            this._editUser.Click += new System.EventHandler(this.EditUserData);
            // 
            // Log_off
            // 
            this._logOff.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this._logOff.BackColor = System.Drawing.Color.White;
            this._logOff.Cursor = System.Windows.Forms.Cursors.Hand;
            this._logOff.Location = new System.Drawing.Point(12, 7);
            this._logOff.Name = "_logOff";
            this._logOff.Size = new System.Drawing.Size(75, 23);
            this._logOff.TabIndex = 0;
            this._logOff.Text = "LogOff";
            this._logOff.UseVisualStyleBackColor = false;
            this._logOff.Click += new System.EventHandler(this.LogOffToHome);
            // 
            // UserData
            // 
            this._userData.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this._userData.BackColor = System.Drawing.SystemColors.Window;
            this._userData.Location = new System.Drawing.Point(256, 9);
            this._userData.Multiline = true;
            this._userData.Name = "_userData";
            this._userData.ReadOnly = true;
            this._userData.Size = new System.Drawing.Size(215, 143);
            this._userData.TabIndex = 0;
            this._userData.TabStop = false;
            // 
            // _weightInfo
            // 
            this._weightInfo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this._weightInfo.Location = new System.Drawing.Point(256, 159);
            this._weightInfo.Multiline = true;
            this._weightInfo.Name = "_weightInfo";
            this._weightInfo.ReadOnly = true;
            this._weightInfo.Size = new System.Drawing.Size(215, 74);
            this._weightInfo.TabIndex = 0;
            this._weightInfo.TabStop = false;
            // 
            // _mainPageCalorieText
            // 
            this._mainPageCalorieText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._mainPageCalorieText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._mainPageCalorieText.Location = new System.Drawing.Point(31, 239);
            this._mainPageCalorieText.MaxLength = 9999;
            this._mainPageCalorieText.Name = "_mainPageCalorieText";
            this._mainPageCalorieText.Size = new System.Drawing.Size(76, 23);
            this._mainPageCalorieText.TabIndex = 7;
            // 
            // _updateWeight
            // 
            this._updateWeight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._updateWeight.Cursor = System.Windows.Forms.Cursors.Hand;
            this._updateWeight.Location = new System.Drawing.Point(352, 239);
            this._updateWeight.Name = "_updateWeight";
            this._updateWeight.Size = new System.Drawing.Size(106, 23);
            this._updateWeight.TabIndex = 2;
            this._updateWeight.Text = "Update Weight";
            this._updateWeight.UseVisualStyleBackColor = true;
            this._updateWeight.Click += new System.EventHandler(this.ClickToLoadWeight);
            // 
            // _mainPageWeightText
            // 
            this._mainPageWeightText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._mainPageWeightText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._mainPageWeightText.Location = new System.Drawing.Point(270, 239);
            this._mainPageWeightText.MaxLength = 9999;
            this._mainPageWeightText.Name = "_mainPageWeightText";
            this._mainPageWeightText.Size = new System.Drawing.Size(76, 23);
            this._mainPageWeightText.TabIndex = 9;
            // 
            // MainPageForm
            // 
            this.AllowDrop = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this._mainPageWeightText);
            this.Controls.Add(this._updateWeight);
            this.Controls.Add(this._updateCalories);
            this.Controls.Add(this._mainPageCalorieText);
            this.Controls.Add(this._weightInfo);
            this.Controls.Add(this._userData);
            this.Controls.Add(this._logOff);
            this.Controls.Add(this._editUser);
            this.Controls.Add(this._displayMaxCalorie);
            this.Controls.Add(this._calorieChart);
            this.Controls.Add(this._weightChart);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainPageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Diet Tracker v.0.1";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainPage_Closed);
            this.Load += new System.EventHandler(this.MainPageForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this._weightChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._calorieChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
