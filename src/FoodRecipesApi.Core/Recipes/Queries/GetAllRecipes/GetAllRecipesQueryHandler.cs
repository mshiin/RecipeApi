using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FoodRecipesApi.Core.Common.DTOs;
using FoodRecipesApi.Core.Common.Interfaces;
using FoodRecipesApi.Core.Common.Mappers.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FoodRecipesApi.Core.Common.Queries.GetAllRecipes
{
    public class GetAllRecipesQueryHandler : IRequestHandler<GetAllRecipesQuery, List<RecipeDto>>
    {
        private readonly IFoodRecipesDbContext _context;
        private readonly IRecipeMapper _mapper;
        private readonly ILogger<GetAllRecipesQueryHandler> _logger;
        public GetAllRecipesQueryHandler(
            IFoodRecipesDbContext context,
            ILogger<GetAllRecipesQueryHandler> logger,
            IRecipeMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<List<RecipeDto>> Handle(GetAllRecipesQuery request, CancellationToken ct)
        {
            try
            {
                var recipes = await _context.Recipes
                   .AsNoTracking()
                   .Select(_mapper.ToDtoSelector())   // projected in SQL
                   .ToListAsync(ct);
                return recipes;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
        

    }
}