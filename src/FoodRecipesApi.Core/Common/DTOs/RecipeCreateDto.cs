using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodRecipesApi.Domain.Entities;

namespace FoodRecipesApi.Core.Common.DTOs
{
    public class RecipeCreateDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public AuthorCreateDto Author { get; set; }
        public string? ImageUrl { get; set; }

        public int PreparationTimeInMinutes { get; set; }
        public int TotalTimeInMinutes { get; set; }
        public IEnumerable<RecipeStepDto> RecipeSteps { get; set; } = Array.Empty<RecipeStepDto>();
        public IEnumerable<IngredientCreateDto> RecipeIngredient { get; set; } = Array.Empty<RecipeStepDto>();

    }
}