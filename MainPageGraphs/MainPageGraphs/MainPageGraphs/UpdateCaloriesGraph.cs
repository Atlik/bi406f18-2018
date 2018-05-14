using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainPageGraphs
{
    class UpdateCaloriesGraph
    {
        internal int maxCalories { get; set; }
        internal int CaloriesEaten { get; set; }

        public UpdateCaloriesGraph(int maxCal, int calEaten)
        {
            this.maxCalories = maxCal;
            this.CaloriesEaten = calEaten;
        }
    }
}
