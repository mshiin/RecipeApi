using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodRecipesApi.Core.Common.DTOs
{
    public class IngredientCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public IngredientQuantityDto Quantity {get; set;}
    }
}