using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodRecipesApi.Domain.Entities;

namespace FoodRecipesApi.Core.Common.DTOs
{
    public class IngredientQuantityDto
    {
        public float Amount { get; set; }
        public MeasurementUnit MeasurementUnit { get; set; }
    }
}