using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodRecipesApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodRecipesApi.Persistence.Configuration
{
    public class RecipeStepConfiguration : IEntityTypeConfiguration<RecipeStep>
    {
        public void Configure(EntityTypeBuilder<RecipeStep> builder)
        {
            builder.HasOne(rs => rs.Recipe) // each RecipeStep has ONE Recipe
                .WithMany(r => r.RecipeSteps); // each Recipe has MANY RecipeStep
            builder.Property(rs => rs.Instruction)
                .HasMaxLength(500)
                .IsRequired();
            builder.Property(rs => rs.ImageUrl)
                .HasMaxLength(100);
        }
    }
}