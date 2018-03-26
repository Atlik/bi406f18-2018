using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formler_BMI_BMR
{
    class Formler
    {
        int height = 19;
        int age = 1;
        int weight = 1;
        int activity = 1;
        bool sex = true;



        //BMR Calc for both genders
        public static double BMRCalc(int height, int age, int weight, int activity, bool sex)//Height, age, weight, activity niveau, gender
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

        public int BMICalc(int weight, int height)
        {
            return weight / (height * height);
        }
    }




    class Program
    {
        public static void Main(string[] args)
        {



            double bmr = bmrcalc();
            Console.WriteLine("BMR is " + bmr);
            int BMI = bmicalc;
            Console.WriteLine(bmi);
        }
    }
}
