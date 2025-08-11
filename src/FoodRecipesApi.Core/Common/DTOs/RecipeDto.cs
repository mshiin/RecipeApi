using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodRecipesApi.Domain.Entities;

namespace FoodRecipesApi.Core.Common.DTOs
{
    public class RecipeDto
    {
        public int RecipeId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public string? ImageUrl { get; set; }
        public int PreparationTimeInMinutes { get; set; }
        public int TotalTimeInMinutes { get; set; }

        public IEnumerable<RecipeStep> RecipeSteps { get; set; }
        public IEnumerable<IngredientDto> RecipeIngredients { get; set; }
        
    }
}