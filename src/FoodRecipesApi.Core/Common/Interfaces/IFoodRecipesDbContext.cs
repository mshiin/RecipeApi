using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FoodRecipesApi.Domain.Entities;

namespace FoodRecipesApi.Core.Common.Interfaces
{
    interface IFoodRecipesDbContext
    {
        DbSet<Recipe> Recipes { get; set; }
    } 
}