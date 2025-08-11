using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FoodRecipesApi.Core.Common.DTOs;
using FoodRecipesApi.Core.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FoodRecipesApi.Core.Common.Queries.GetAllRecipes
{
    public class GetAllRecipesQueryHandler : IRequestHandler<GetAllRecipesQuery, List<RecipeDto>>
    {
        private readonly IFoodRecipesDbContext _context;
        private readonly ILogger<GetAllRecipesQueryHandler> _logger;
        public GetAllRecipesQueryHandler(IFoodRecipesDbContext context, ILogger<GetAllRecipesQueryHandler> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<List<RecipeDto>> Handle(GetAllRecipesQuery request, CancellationToken cancellationToken)
            {
            try
            {
                return await _context.Recipes
                    .AsNoTracking()
                    .Select(r => new RecipeDto
                    {
                        RecipeId = r.RecipeId,
                        Title = r.Title,
                        Description = r.Description,
                        Author = r.Author.Name + " " + r.Author.Surname,
                        ImageUrl = r.ImageUrl,
                        PreparationTimeInMinutes = r.PreparationTimeInMinutes,
                        TotalTimeInMinutes = r.TotalTimeInMinutes,
                        RecipeSteps = r.RecipeSteps
                            .OrderBy(s => s.StepNumber)
                            .Select(s => new RecipeStepDto
                            {
                                RecipeStepId = s.RecipeStepId,
                                StepNumber = s.StepNumber,
                                Instruction = s.Instruction,
                                ImageUrl = s.ImageUrl
                            }),
                        RecipeIngredients = r.RecipeIngredients.Select(ri => new IngredientDto
                        {
                            IngredientId = ri.Ingredient.IngredientId,
                            Name = ri.Ingredient.Name,
                            Quantity = new IngredientQuantityDto
                            {
                                Amount = ri.Ingredient.Quantity.Amount,
                                MeasurementUnit = ri.Ingredient.Quantity.MeasurementUnit.Unit
                            }
                        })
                    })
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get recipes");
                throw; 
            }
            }

    }
}