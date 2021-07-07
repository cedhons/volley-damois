using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VolleyDamois.Models;
using VolleyDamois.Models.Enum;

namespace VolleyDamois.DataConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Name).HasConversion(new EnumToStringConverter<Categories>());

            builder.HasData(new { Id = 1, Name = Categories.Nationale });
            builder.HasData(new { Id = 2, Name = Categories.Provinciale });
            builder.HasData(new { Id = 3, Name = Categories.Loisir });
        }
    }
}
