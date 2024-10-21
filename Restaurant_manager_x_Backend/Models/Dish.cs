namespace Restaurant_manager_x_backend.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string[] Ingredients { get; set; }
        public double PreparationTime { get; set; }

        public Dish()
        {
            Name = string.Empty;
            Ingredients = Array.Empty<string>();
        }

         public Dish(int id, string name, string[] ingredients, double preparationTime)
        {
            Id = id;
            Name = name;
            Ingredients = ingredients;
            PreparationTime = preparationTime;
        }
    }
}
