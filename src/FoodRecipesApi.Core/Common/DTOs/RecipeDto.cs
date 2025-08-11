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
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Author { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public int PreparationTimeInMinutes { get; set; }
        public int TotalTimeInMinutes { get; set; }

        public IEnumerable<RecipeStepDto> RecipeSteps { get; set; } = Array.Empty<RecipeStepDto>();
        public IEnumerable<IngredientDto> RecipeIngredients { get; set; } = Array.Empty<IngredientDto>();

        
    }
}