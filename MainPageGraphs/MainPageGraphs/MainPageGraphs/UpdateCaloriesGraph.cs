using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainPageGraphs
{
    class UpdateCaloriesGraph
    {
        internal int Calories { get; set; }
        internal int Goal { get; set; }

        internal UpdateCaloriesGraph(int goal, int calories)
        {
            this.Calories = calories;
            this.Goal = goal;
        }
    }
}
