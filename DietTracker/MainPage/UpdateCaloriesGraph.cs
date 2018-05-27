
namespace MainPageGraphs
{
    class UpdateCaloriesGraph
    {
        internal double maxCalories { get; }
        internal double CaloriesEaten { get; }

        public UpdateCaloriesGraph(double maxCal, double calEaten)
        {
            this.maxCalories = maxCal;
            this.CaloriesEaten = calEaten;
        }
    }
}
