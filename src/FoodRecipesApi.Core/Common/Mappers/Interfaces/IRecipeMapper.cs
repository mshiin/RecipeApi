using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodRecipesApi.Core.Common.DTOs;
using FoodRecipesApi.Domain.Entities;

namespace FoodRecipesApi.Core.Common.Mappers.Interfaces
{
    public interface IRecipeMapper
    {
        public RecipeDto MapToRecipeDto(Recipe recipe);
        public Recipe MapFromCreateDtoToEntity(RecipeCreateDto recipeCreateDto);
    }
}