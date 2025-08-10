using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodRecipesApi.Domain.Entities
{
    public class IngredientQuantity
    {
        public int IngredientQuantityId { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}