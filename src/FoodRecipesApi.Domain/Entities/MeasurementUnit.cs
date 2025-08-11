using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodRecipesApi.Domain.Entities
{
    public class MeasurementUnit
    {
    public int MeasurementUnitId { get; set; }
    public string Unit { get; set; } = string.Empty;

    public ICollection<IngredientQuantity> IngredientQuantities { get; } = new List<IngredientQuantity>();
    }
}