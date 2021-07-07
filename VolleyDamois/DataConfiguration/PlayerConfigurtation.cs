using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VolleyDamois.Models;
using VolleyDamois.Models.Enum;

namespace VolleyDamois.DataConfiguration
{
    public class PlayerConfigurtation : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            InitNationalPlayers(builder);
            InitProvincialPlayers(builder);
            InitLoisirPlayers(builder);
        }

        private void InitNationalPlayers(EntityTypeBuilder<Player> builder)
        {
            for (int i = 1; i <= 16; i++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    AddPlayerFor(builder, i, j, 4,'N');
                }
            }
        }

        private void InitProvincialPlayers(EntityTypeBuilder<Player> builder)
        {
            for (int i = 17; i <= 32; i++)
            {
                for (int j = 1; j <= 6; j++)
                {
                    AddPlayerFor(builder, i, j, 6, 'P');
                }
            }
        }
        private void InitLoisirPlayers(EntityTypeBuilder<Player> builder)
        {
            for (int i = 33; i <= 48; i++)
            {
                for (int j = 1; j <= 6; j++)
                {
                    AddPlayerFor(builder, i, j, 6,'L');
                }
            }
        }

        private static void AddPlayerFor(EntityTypeBuilder<Player> builder, int i, int j, int nbPlayers, char category)
        {
            int id = (i - 1) * nbPlayers + j;
            builder.HasData(
                new
                {
                    Id = id,
                    Lastname = $"Nom {category}:{id}",
                    Firstname = $"Prénom {category}:{id}",
                    Gender = id % 2 == 0 ? Genders.Female : Genders.Male,
                    AffiliationNumber = id.ToString(),
                    PhoneNumber = id.ToString(),
                    Email = $"mail{id}@mail.com",
                    TeamId = i,
                    Capitain = i == 1,
                    Reservist = i % 3 == 0,
                    Adress = $"Liège {id}"
                });
        }
    }
}
