using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formler_BMI_BMR
{
    class Formler
    {
        int height, age, weight, activity;
        bool sex;

        
        //BMR Calc for both genders
        public double BMRCalc(int height, int age, int weight, int activity, bool sex)//Height, age, weight, activity niveau, gender
        {
            if (sex == true) //gender check for male
            {

                if (activity == 1) //Activity lvl
                {
                    return ((10 * weight) + (6.5 * height) - (5 * age) + 5) * 1.53;
                }
                else if (activity == 2)
                {
                    return ((10 * weight) + (6.5 * height) - (5 * age) + 5) * 1.76;
                }
                else
                {
                    return ((10 * weight) + (6.5 * height) - (5 * age) + 5) * 2.25;
                };
            }
            else // else Female
            {
                if (activity == 1)
                {
                    return ((10 * weight) + (6.5 * height) - (5 * age) - 161) * 1.53;
                }
                else if (activity == 2)
                {
                    return ((10 * weight) + (6.5 * height) - (5 * age) - 161) * 1.76;
                }
                else
                {
                    return ((10 * weight) + (6.5 * height) - (5 * age) - 161) * 2.25;
                };
            };
        }

        public int BMICalc (int weight, int height)
        {
            return weight / (height * height);
        }
    }




    class Program
    {
        static void Main(string[] args)
        {
            var 
            Console.WriteLine("BMR is" + bmr);

            Console.WriteLine(BMI);
        }
    }
}
