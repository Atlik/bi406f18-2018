using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainPageGraphs
{
    class UpdateCaloriesGraph
    {
        internal double maxCalories { get; set; }
        internal double CaloriesEaten { get; set; }

        public UpdateCaloriesGraph(double maxCal, double calEaten)
        {
            this.maxCalories = maxCal;
            this.CaloriesEaten = calEaten;
        }
    }
}
