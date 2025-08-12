using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodRecipesApi.Core.Common.DTOs
{
    public class RecipeStepCreateDto
    {
        public int StepNumber { get; set; }          
        public string? Instruction { get; set; }
        public string? ImageUrl { get; set; }
    }
}