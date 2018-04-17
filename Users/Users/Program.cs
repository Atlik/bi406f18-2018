using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Users
{
    class Program
    {
        static void Main(string[] args)
        {
            User mark = new User(1, true, 1.80, 83, "15-03-1994", 1, 75);

            Console.WriteLine("Update your weight: ");
            User.UpdateCurrentWeight(1);
            Console.WriteLine("Update your target weight: ");
            User.UpdateTargetWeight(1);
            Console.ReadKey();
        }
    }
}
