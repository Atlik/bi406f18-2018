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
        public string userid { get; set; }
        public string password { get; set; }
        public bool gender { get; set; }
        public double height { get; set; }
        public double currentWeight { get; set; }
        public DateTime dateOfBirth { get; set; }
        public int lifeStyle { get; set; }
        public double targetWeight { get; set; }

        private string format = "yyyyMMdd";

        //Constructer
        public User(string userid, string password, bool gender, double height, double currentWeight, string dateOfBirth, int lifeStyle, double targetWeight)
        {

            this.userid = userid;
            this.password = password;
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
        public static void UpdateCurrentWeight(string userid)
        {
            double newCurrentWeight;
            if (!double.TryParse(Console.ReadLine(), out newCurrentWeight)) ;
            try
            {
                var con = OpenDefaultDBConnection();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "update Users set currentWeight = @newCurrentWeight where UserID = @userID";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@newCurrentWeight", newCurrentWeight);
                cmd.Parameters.AddWithValue("@userID", userid);
                cmd.ExecuteNonQuery();
                if (con != null) { con.Close(); }
            }
            catch
            {
                Console.WriteLine("Connection Error!\n");
            }
        }

        /// <summary>
        /// Updates the users target weight
        /// skal tage input fra tekstbox for at updatere (skal fikses)
        /// </summary>
        /// <returns></returns>
        public static void SetNewTarget(string userid)
        {
            double newTargetWeight;
            if (!double.TryParse(Console.ReadLine(), out newTargetWeight)) ;

            var con = OpenDefaultDBConnection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update Users set targetWeight = @newTargetWeight where UserID = @userID";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@newTargetWeight", newTargetWeight);
            cmd.Parameters.AddWithValue("@userID", userid);
            cmd.ExecuteNonQuery();
            if (con != null) { con.Close(); }
        }

        /// <summary>
        /// Skal fjernes, udelukkende for at se om den opretter obejkterne korrekt
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "UserID: " + userid + ", password: " + password + ", gender: " + gender + ", height: " + height +
                ", current weight:" + currentWeight + ", date of birth: " + dateOfBirth + ", life style: " + lifeStyle +
                " and target weight: " + targetWeight;
        }

        public static MySqlConnection OpenDBConnection(string host, string user, string pwd, string db)
        {
            string connStr = String.Format("server={0};uid={1};pwd={2};database={3}", host, user, pwd, db);
            var conn = new MySqlConnection();
            try
            {
                
                conn.ConnectionString = connStr;
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection Error!\n" + ex.Message);
                return conn;
            }

        }

        public static MySqlConnection OpenDefaultDBConnection()
        {
            return OpenDBConnection("127.0.0.1", "root", "root", "DTUsers");
        }

        public static void AddUsers(string userid, string pwd, bool gender, double height, double weight, string dateOfBirth, int lifeStyle, double targetWeight)
        {
            try
            {
                var con = User.OpenDefaultDBConnection();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert into Users values (@userID, @pwd, @gender, @height, @currentweight, @dateOfBirth, @lifeStyle, @targetWeight)";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@userID", userid);
                cmd.Parameters.AddWithValue("@pwd", pwd);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@currentWeight", weight);
                cmd.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
                cmd.Parameters.AddWithValue("@lifeStyle", lifeStyle);
                cmd.Parameters.AddWithValue("@targetWeight", targetWeight);
                cmd.ExecuteNonQuery();
                if (con != null) { con.Close(); }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection Error!\n" + ex.Message);

            }
        }

    }
}
