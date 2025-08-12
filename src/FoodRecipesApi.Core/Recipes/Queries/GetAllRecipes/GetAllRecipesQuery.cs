using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodRecipesApi.Core.Common.DTOs;
using MediatR;

namespace FoodRecipesApi.Core.Common.Queries.GetAllRecipes
{
    public class GetAllRecipesQuery : IRequest<List<RecipeDto>>
    {
    }
}