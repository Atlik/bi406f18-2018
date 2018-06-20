
namespace MainPageGraphs
{
    class UpdateCaloriesGraph
    {
        internal double maxCalories { get; }
        internal double CaloriesRead { get; }

        public UpdateCaloriesGraph(double maxCal, double calEaten)
        {
            this.maxCalories = maxCal;
            this.CaloriesRead = calEaten;
        }
    }
}
