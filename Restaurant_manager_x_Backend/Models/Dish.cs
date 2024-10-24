using System.ComponentModel.DataAnnotations;
namespace Restaurant_manager_x_backend.Models
{
    public class Dish
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string[] ingredients { get; set; }
        public double preparationTime { get; set; }

        public Dish()
        {
            name = string.Empty;
            ingredients = Array.Empty<string>();
        }

         public Dish(string name, string[] ingredients, double preparationTime)
        {
            this.name = name;
            this.ingredients = ingredients;
            this.preparationTime = preparationTime;
        }

        // Public getter methods
        public int GetId() {
            return id;
        }

        public string GetName() {
            return name;
        }

        public string[] GetIngredients() {
            return ingredients;
        }

        public double GetPreparationTime() {
            return preparationTime;
        }

        // Public setter methods
        public void SetId(int id) {
            this.id = id;
        }

        public void SetName(string name) {
            this.name = name;
        }

        public void SetIngredients(string[] ingredients) {
            this.ingredients = ingredients;
        }

        public void SetPreparationTime(double preparationTime) {
            this.preparationTime = preparationTime;
        }

        // Add an ingredient to the dish
        public void AddIngredient(string ingredient) {
            if (!ingredients.Contains(ingredient)) {
                var ingredientsList = ingredients.ToList();
                ingredientsList.Add(ingredient);
                ingredients = ingredientsList.ToArray();
            }
        }

        // Remove an ingredient from the dish
        public void RemoveIngredient(string ingredient) {
            if (ingredients.Contains(ingredient)) {
                var ingredientsList = ingredients.ToList();
                ingredientsList.Remove(ingredient);
                ingredients = ingredientsList.ToArray();
            }
        }

        // Check if the dish contains a specific ingredient
        public bool ContainsIngredient(string ingredient) {
            return ingredients.Contains(ingredient);
        }
    }
}
