using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodRecipesApi.Domain.Entities
{
    public class Recipe
    {
        public Recipe()
        {
            RecipeSteps = new List<RecipeStep>();
        }
        public int RecipeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public ICollection<RecipeStep> RecipeSteps { get; private set; }
        public string ImageUrl { get; set; }
        public int PreparationTimeInMinutes { get; set; }
        public int TotalTimeInMinutes { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
        

    }
}