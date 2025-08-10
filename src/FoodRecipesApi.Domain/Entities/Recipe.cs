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
        public string Author { get; set; }

    }
}