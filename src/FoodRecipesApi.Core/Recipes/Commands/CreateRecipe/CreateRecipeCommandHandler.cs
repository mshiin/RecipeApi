using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodRecipesApi.Core.Common.Interfaces;
using FoodRecipesApi.Core.Common.Mappers.Interfaces;
using FoodRecipesApi.Core.Common.Queries.GetAllRecipes;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FoodRecipesApi.Core.Recipes.Commands.CreateRecipe
{
    public class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand, int>
    {
        private readonly IFoodRecipesDbContext _context;
        private readonly IRecipeMapper _recipeMapper;
        private readonly ILogger<GetAllRecipesQueryHandler> _logger;

        public async Task<int> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
        {
            var recipeEntity = _recipeMapper.MapFromCreateDtoToEntity(request);
            try
            {
                _context.Recipes.Add(recipeEntity);
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return recipeEntity.RecipeId;
        }

       
    }
}