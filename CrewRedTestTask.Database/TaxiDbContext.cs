using CrewRedTestTask.Database.EntityConfigurations;
using CrewRedTestTask.Database.Interfaces;
using CrewRedTestTask.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace CrewRedTestTask.Database
{
    public class TaxiDbContext : DbContext, ITaxiDbContext
    {
        public TaxiDbContext(DbContextOptions<TaxiDbContext> options) : base(options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options), $"{nameof(options)} is null.");
            }
        }

        public DbSet<TaxiTripRecordEntity> TaxiTripRecords { get; set; }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TaxiTripRecordEntityConfiguration());
        }
    }
}
