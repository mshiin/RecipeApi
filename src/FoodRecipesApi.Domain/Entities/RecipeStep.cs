using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodRecipesApi.Domain.Entities
{
    public class RecipeStep
    {
        public int RecipeStepId { get; set; }
        public Recipe? Recipe { get; set; }
        public int RecipeId { get; set; }
        public int StepNumber { get; set; }              
        public string Instruction { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    
    }
}