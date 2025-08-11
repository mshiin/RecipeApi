using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodRecipesApi.Domain.Entities
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string Name { get; set; } = string.Empty;
        public IngredientQuantity Quantity { get; set; } = null!;
        public int QuantityId { get; set; }
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
        

    }
}