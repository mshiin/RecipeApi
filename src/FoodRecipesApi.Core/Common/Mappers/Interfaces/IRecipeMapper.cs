using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FoodRecipesApi.Core.Common.DTOs;
using FoodRecipesApi.Domain.Entities;

namespace FoodRecipesApi.Core.Common.Mappers.Interfaces
{
    public interface IRecipeMapper
    
    {
        Expression<Func<Recipe, RecipeDto>> ToDtoSelector();
        public RecipeDto MapToRecipeDto(Recipe recipe);
        public Recipe MapFromCreateDtoToEntity(RecipeCreateDto recipeCreateDto);
    }
}