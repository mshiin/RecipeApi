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
            builder.HasKey(iq => iq.IngredientQuantityId);
            builder.Property(iq => iq.Amount)
                .HasPrecision(10, 2)
                .IsRequired();
            builder.HasOne(iq => iq.MeasurementUnit)
                .WithMany(mu => mu.IngredientQuantities)
                .HasForeignKey(iq => iq.MeasurementUnitId)
                .OnDelete(DeleteBehavior.Restrict); // avoid nuking lookup rows
        }
        }
    }
