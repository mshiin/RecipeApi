using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FoodRecipesApi.Core.Common.Mappers.Implementations;
using FoodRecipesApi.Core.Common.Mappers.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FoodRecipesApi.Core.Common.Interfaces
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            
            services.AddScoped<IRecipeMapper, RecipeMapper>();

            return services;
        }
    }
}
