using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodRecipesApi.Domain.Entities
{
    public class IngredientQuantity
    {
        public int IngredientQuantityId { get; set; }
        public Ingredient Ingredient { get; set; } = null!;      
        public decimal Amount { get; set; }
        public int MeasurementUnitId { get; set; }                 // FK
        public MeasurementUnit MeasurementUnit { get; set; } = null!;


    }
}