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
            builder.HasKey(mu => mu.MeasurementUnitId);

            builder.Property(mu => mu.Unit)
                .HasMaxLength(15)
                .IsRequired();

            builder.HasMany(mu => mu.IngredientQuantities)
                .WithOne(iq => iq.MeasurementUnit)
                .HasForeignKey(iq => iq.MeasurementUnitId)
                .OnDelete(DeleteBehavior.Restrict);

            // Optional: prevent duplicate unit names
            builder.HasIndex(mu => mu.Unit).IsUnique();
        }
    }

}