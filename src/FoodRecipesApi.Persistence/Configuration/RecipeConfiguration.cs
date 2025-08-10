using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodRecipesApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodRecipesApi.Persistence.Configuration
{
    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.HasOne(r => r.Author) // each Recipe has ONE author
                .WithMany(a => a.Recipes) // each author has MANY recipes
                .HasForeignKey(r => r.AuthorId)
                .IsRequired();

            builder.HasMany(r => r.RecipeSteps) // each Recipe has MANY RecipeStep
                .WithOne(rs => rs.Recipe) // each RecipeStep has ONE Recipe
                .HasForeignKey(rs => rs.RecipeId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
            builder.Property(r => r.Title)
                .HasMaxLength(30)
                .IsRequired();
            builder.Property(r => r.Description)
                .HasMaxLength(500)
                .IsRequired();
            builder.Property(r => r.PreparationTimeInMinutes)
                .IsRequired();
            builder.Property(r => r.TotalTimeInMinutes)
                .IsRequired();
            builder.Property(r => r.ImageUrl)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}