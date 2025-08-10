using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodRecipesApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodRecipesApi.Persistence.Configuration
{
    public class MeasurementUnitConfiguration : IEntityTypeConfiguration<MeasurementUnit>
    {
        public void Configure(EntityTypeBuilder<MeasurementUnit> builder)
        {
            builder.HasOne(mu => mu.IngredientQuantity) // each MeasurementUnit has ONE Ingredient
                .WithOne(iq => iq.MeasurementUnit) // each IngredientQuantity has ONE MeasureUnit
                .HasForeignKey<MeasurementUnit>(mu => mu.IngredientQuantityId);

            builder.Property(mu => mu.Unit)
                .HasMaxLength(15)
                .IsRequired();
        }
    }
}