using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FoodRecipesApi.Domain.Entities;

namespace FoodRecipesApi.Core.Common.Interfaces
{
    public interface IFoodRecipesDbContext
    {
        DbSet<Recipe> Recipes { get; set; }
        DbSet<Author> Authors { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    } 
}