using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Users
{
    class Program
    {
        static void Main4(string[] args)
        {

            User.AddUsers("test1ID", "Test1PW", true, 1.80, 83, "15-03-1994", 1, 75);
            User test1 = new User("test1ID", "Test1PW", true, 1.80, 83, "15-03-1994", 1, 75);

            Console.WriteLine(test1.ToString());
            Console.Read();

            Console.WriteLine("Update your weight: ");
            User.UpdateCurrentWeight("test1ID");

            Console.WriteLine(test1.ToString());
            Console.Read();
            Console.ReadLine();
        }
    }
}
