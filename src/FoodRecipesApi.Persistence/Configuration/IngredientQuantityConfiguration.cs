using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodRecipesApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodRecipesApi.Persistence.Configuration
{
        class IngredientQuantityConfiguration : IEntityTypeConfiguration<IngredientQuantity>
        {
        public void Configure(EntityTypeBuilder<IngredientQuantity> builder)
        {
            builder.HasOne(iq => iq.Ingredient) // each IngredientQuantity has ONE Ingredient
                .WithOne(i => i.Quantity) // each Ingredient has ONE IngredientQuantity
                .HasForeignKey<IngredientQuantity>(i => i.IngredientId)
                .IsRequired();

            builder.HasOne(iq => iq.MeasurementUnit) // each IngredientQuantity has ONE MeasurementUnit
                .WithOne(mu => mu.IngredientQuantity) // each MeasurementUnit has ONE IngredientQuantity
                .HasForeignKey<IngredientQuantity>(iq => iq.MeasurementUnitId);
            }
        }
    }
