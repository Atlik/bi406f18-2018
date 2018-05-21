using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Users
{
    class User
    {
        //Properties
        public int id { get; set; }
        public bool gender { get; set; }
        public double height { get; set; }
        public double currentWeight { get; set; }
        public DateTime dateOfBirth { get; set; }
        public int lifeStyle { get; set; }
        public double targetWeight { get; set; }
        

        //Constructer
        public User(int id, bool gender, double height, double currentWeight, string dateOfBirth, int lifeStyle, double targetWeight)
        {

            this.id = id;
            this.gender = gender;
            this.height = height;
            this.currentWeight = currentWeight;
            this.dateOfBirth = DateTime.ParseExact(dateOfBirth, "dd-MM-yyyy", null);
            this.lifeStyle = lifeStyle;
            this.targetWeight = targetWeight;

        }

        /// <summary>
        /// Updates the users current weight
        /// skal tage input fra tekstbox for at updatere (skal fikses)
        /// </summary>
        public static void UpdateCurrentWeight(int id)
        {
            double newCurrentWeight;
            if (!double.TryParse(Console.ReadLine(), out newCurrentWeight));


            var con = OpenDefaultDBConnection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update users set weight = @weight where id = @id";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@weight", newCurrentWeight);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            if (con != null) { con.Close(); }
        }

        /// <summary>
        /// Updates the users target weight
        /// skal tage input fra tekstbox for at updatere (skal fikses)
        /// </summary>
        /// <returns></returns>
        public static void UpdateTargetWeight(int id)
        {
            double newTargetWeight;
            if (!double.TryParse(Console.ReadLine(), out newTargetWeight));

            var con = OpenDefaultDBConnection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update Users set targetweight = @targetweight where id = @id";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@targetweight", newTargetWeight);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            if (con != null) { con.Close(); }
        }

        /// <summary>
        /// Skal fjernes, udelukkende for at se om den opretter obejkterne korrekt
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "ID: " + id + ", gender: " + gender + ", height: " + height + ", current weight:" + currentWeight + 
                ", date of birth: " + dateOfBirth + ", life style: " + lifeStyle + " and target weight: " + targetWeight;
        }

        public static MySqlConnection OpenDBConnection(string host, string user, string pwd, string db)
        {
            string connStr = String.Format("server={0};uid={1};pwd={2};database={3}", host, user, pwd, db);
            var conn = new MySqlConnection();

            conn.ConnectionString = connStr;

            conn.Open();
            return conn;
        }

        public static MySqlConnection OpenDefaultDBConnection()
        {
            return OpenDBConnection("127.0.0.1", "root", "root", "diettracker");
        }

    }
}
