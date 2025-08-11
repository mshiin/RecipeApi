using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodRecipesApi.Core.Common.DTOs;
using FoodRecipesApi.Core.Common.Interfaces;
using FoodRecipesApi.Core.Common.Queries.GetAllRecipes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace FoodRecipesApi.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodRecipesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FoodRecipesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeDto>>> Get()
        {
            var recipes = await _mediator.Send(new GetAllRecipesQuery());
            return Ok(recipes);
        }
    }
}