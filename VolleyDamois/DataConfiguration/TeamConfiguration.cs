using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VolleyDamois.Models;

namespace VolleyDamois.DataConfiguration
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            //Nationale
            for (int i = 1; i <= 16; i++)
                builder.HasData(new { Id = i, Name = $"Equipe Nationale {i}", Confirmation = false, Camping = i % 2 == 0, CategoryId = 1 });

            //Proviciale
            for (int i = 17; i <= 32; i++)
                builder.HasData(new { Id = i, Name = $"Equipe Provinciale {i}", Confirmation = false, Camping = i % 2 == 0, CategoryId = 2 });
            
            //Loisir
            for (int i = 33; i <= 48; i++)
                builder.HasData(new { Id = i, Name = $"Equipe Loisir {i}", Confirmation = false, Camping = i % 2 == 0, CategoryId = 3 });
        }
    }
}
