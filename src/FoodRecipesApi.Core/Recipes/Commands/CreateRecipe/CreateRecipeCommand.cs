using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodRecipesApi.Core.Common.DTOs;
using MediatR;

namespace FoodRecipesApi.Core.Recipes.Commands.CreateRecipe
{
    public class CreateRecipeCommand : RecipeCreateDto, IRequest<int>
    {
        
    }
}