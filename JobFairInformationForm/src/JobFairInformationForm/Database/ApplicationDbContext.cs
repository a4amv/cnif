using JobFairInformationForm.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace JobFairInformationForm.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<InformationForm> InformationForm { get; set; }
        public DbSet<Location> Location { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InformationForm2Location>()
                        .HasKey(c => new { c.InformationFormId, c.LocationId });

            modelBuilder.Entity<InformationForm2Location>()
                        .HasOne<Location>(s => s.Location)
                        .WithMany(c => c.InformationForm2Locations)
                        .HasForeignKey(c => c.LocationId);

            modelBuilder.Entity<InformationForm2Location>()
                        .HasOne<InformationForm>(s => s.InformationForm)
                        .WithMany(c => c.InformationForm2Locations)
                        .HasForeignKey(c => c.InformationFormId);
        }
    }

}
