using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MainPageGraphs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            DateTime date = new DateTime(2018-04-06);
            var info = new  UpdateWeightGraph(new DateTime(2018-04-05), 72);
            var info1 = new UpdateWeightGraph(new DateTime(2018-04-05), 72);
            var info2 = new UpdateWeightGraph(date, 71);

            //får forkert string ud???
            var dateStr = Convert.ToString(date);
           // var dateStr2 = DateTime.ToString(date);

            weightOverTimeChart.Series["Weight"].Points.AddXY("2018-04-05", 72);
            weightOverTimeChart.Series["Weight"].Points.AddXY(dateStr, 72);
            weightOverTimeChart.Series["Weight"].Points.AddXY(Convert.ToString(info2.DayOfInput), info2.Weight);
        }

        //tænker på at tilføje denne således at MySQL bliver indlæst herfra istedet for fra en separat metode
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void caloriesChart_Click(object sender, EventArgs e)
        {
            var info = new UpdateCaloriesGraph(2600, 2220);

            caloriesChart.Series["CalorieIntake"].Points.AddXY("Goal", info.Goal);
            caloriesChart.Series["CalorieIntake"].Points.AddXY("Calorie intake", info.Calories);

        }
    }
}
