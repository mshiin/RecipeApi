using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodRecipesApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodRecipesApi.Persistence.Configuration
{
    public class RecipeIngredientConfiguration : IEntityTypeConfiguration<RecipeIngredient>
    {
        public void Configure(EntityTypeBuilder<RecipeIngredient> builder)
        {
            builder.HasKey(ri => new { ri.RecipeId, ri.IngredientId }); // Composite PK
            builder.HasOne<Recipe>(ri => ri.Recipe) // each RecipeIngredient has ONE Recipe
                .WithMany(r => r.RecipeIngredients) // each Recipe has MANY RecipeIngredients
                .HasForeignKey(ri => ri.RecipeId);
            builder.HasOne<Ingredient>(ri => ri.Ingredient) // each RecipeIngredient has ONE Ingredient
                .WithMany(i => i.RecipeIngredients) // each Ingredient has MANY RecipeIngredient
                .HasForeignKey(ri => ri.IngredientId);
        }
    }
}