using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VolleyDamois.Models;

namespace VolleyDamois.DataConfiguration
{
    public class TerrainConfiguration : IEntityTypeConfiguration<Terrain>
    {
        public void Configure(EntityTypeBuilder<Terrain> builder)
        {
            for (int i = 1; i <= 12; i++)
                builder.HasData(new { Number = i, CategoryId = (i + 3) / 4 });
        }
    }
}
