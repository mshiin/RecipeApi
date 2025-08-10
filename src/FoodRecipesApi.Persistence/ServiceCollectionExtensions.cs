using FoodRecipesApi.Core.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRecipesApi.Persistence
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("FoodRecipesDB")
                ?? throw new InvalidOperationException("Missing connection string 'FoodRecipesDB'.");


            services.AddDbContext<FoodRecipesDbContext>(options =>
                options.UseSqlServer(connection));

            services.AddScoped<IFoodRecipesDbContext>(sp => sp.GetRequiredService<FoodRecipesDbContext>());

            return services;
        }

    }
}