using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodRecipesApi.Domain.Entities;

namespace FoodRecipesApi.Core.Common.DTOs
{
    public class IngredientDto
    {
        public int IngredientId { get; set; }
        public string? Name { get; set; }
        public IngredientQuantityDto Quantity{ get; set; }
    }
}