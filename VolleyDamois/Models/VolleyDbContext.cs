using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VolleyDamois.DataConfiguration;
using VolleyDamois.Models;
using VolleyDamois.Models.Enum;

namespace VolleyDamois.Models
{
    public class VolleyDbContext : IdentityDbContext
    {
        public VolleyDbContext(DbContextOptions<VolleyDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Confrontation>().Property(c => c.BeginTime).HasDefaultValueSql("Getdate()");
            modelBuilder.Entity<Confrontation>().HasOne(c => c.TeamA).WithMany(t => t.ConfrontationsA);
            modelBuilder.Entity<Confrontation>().HasOne(c => c.TeamB).WithMany(t => t.ConfrontationsB);

            modelBuilder.Entity<Player>().Property(p => p.Gender).HasConversion(new EnumToStringConverter<Genders>());

            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerConfigurtation());
            modelBuilder.ApplyConfiguration(new TerrainConfiguration());
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Confrontation> Confrontations { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<Pool> Pools { get; set; }
    }
}
