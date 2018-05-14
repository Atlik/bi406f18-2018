namespace MainPageGraphs
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.weightOverTimeChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.caloriesChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnLoadGraph = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.weightOverTimeChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.caloriesChart)).BeginInit();
            this.SuspendLayout();
            // 
            // weightOverTimeChart
            // 
            chartArea1.Name = "ChartArea1";
            this.weightOverTimeChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.weightOverTimeChart.Legends.Add(legend1);
            this.weightOverTimeChart.Location = new System.Drawing.Point(2, 250);
            this.weightOverTimeChart.Name = "weightOverTimeChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Weight";
            this.weightOverTimeChart.Series.Add(series1);
            this.weightOverTimeChart.Size = new System.Drawing.Size(599, 270);
            this.weightOverTimeChart.TabIndex = 0;
            this.weightOverTimeChart.Text = "Weight over time";
            this.weightOverTimeChart.Validating += new System.ComponentModel.CancelEventHandler(this.weightOverTimeChart_Validating);
            // 
            // caloriesChart
            // 
            chartArea2.Name = "ChartArea1";
            this.caloriesChart.ChartAreas.Add(chartArea2);
            this.caloriesChart.DataSource = this.weightOverTimeChart.Legends;
            legend2.Name = "Legend1";
            this.caloriesChart.Legends.Add(legend2);
            this.caloriesChart.Location = new System.Drawing.Point(13, 13);
            this.caloriesChart.Name = "caloriesChart";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "CalorieIntake";
            this.caloriesChart.Series.Add(series2);
            this.caloriesChart.Size = new System.Drawing.Size(301, 231);
            this.caloriesChart.TabIndex = 1;
            this.caloriesChart.Text = "chart2";
            // 
            // btnLoadGraph
            // 
            this.btnLoadGraph.Location = new System.Drawing.Point(366, 35);
            this.btnLoadGraph.Name = "btnLoadGraph";
            this.btnLoadGraph.Size = new System.Drawing.Size(75, 23);
            this.btnLoadGraph.TabIndex = 2;
            this.btnLoadGraph.Text = "LoadGraphs";
            this.btnLoadGraph.UseVisualStyleBackColor = true;
            this.btnLoadGraph.Click += new System.EventHandler(this.ClickToLoadGraph);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 532);
            this.Controls.Add(this.btnLoadGraph);
            this.Controls.Add(this.caloriesChart);
            this.Controls.Add(this.weightOverTimeChart);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.weightOverTimeChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.caloriesChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart weightOverTimeChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart caloriesChart;
        private System.Windows.Forms.Button btnLoadGraph;
    }
}

