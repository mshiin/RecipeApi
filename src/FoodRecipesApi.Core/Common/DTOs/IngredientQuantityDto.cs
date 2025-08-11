using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodRecipesApi.Domain.Entities;

namespace FoodRecipesApi.Core.Common.DTOs
{
    public class IngredientQuantityDto
    {
        public decimal Amount { get; set; }
        public string MeasurementUnit { get; set; } = string.Empty;
    }
}