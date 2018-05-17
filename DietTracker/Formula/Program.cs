using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formler_BMI_BMR
{
    class Formler
    {
        public void Formula()
        {
        }

        //BMR Calc for both genders
        public double BMRCalc(double height, double age, double weight, double activity, bool sex)//Height, age, weight, activity niveau, gender
        {
            if (sex == true) //gender check for male
            {

                if (activity == 1) //Activity lvl
                {
                    return ((10 * weight) + (6.25 * height) - (5 * age) + 5) * 1.53;
                }
                else if (activity == 2)
                {
                    return ((10 * weight) + (6.25 * height) - (5 * age) + 5) * 1.76;
                }
                else
                {
                    return ((10 * weight) + (6.25 * height) - (5 * age) + 5) * 2.25;
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

        public double BMICalc(double weight, double height)
        {
            return (weight / (height * height));
        }
    }
}
