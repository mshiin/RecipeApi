using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodRecipesApi.Domain.Entities
{
    public class MeasurementUnit
    {
        public int MeasurementUnitId { get; set; }
        public string? Unit { get; set; }
        public IngredientQuantity IngredientQuantity { get; set; }
        public int IngredientQuantityId { get; set; }

    }
}