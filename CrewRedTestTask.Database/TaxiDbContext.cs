using CrewRedTestTask.Database.EntityConfigurations;
using CrewRedTestTask.Database.Interfaces;
using CrewRedTestTask.Entities;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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

        public void BulkRecordsInsertSkippingDublicates(
            IEnumerable<TaxiTripRecordEntity> records,
            BulkConfig bulkConfig = null,
            Action<decimal> progress = null
        )
        {
            if (records == null)
            {
                throw new ArgumentNullException(nameof(records), $"{nameof(records)} is null.");
            }

            this.BulkInsertOrUpdate(records, bulkConfig, progress);
        }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TaxiTripRecordEntityConfiguration());
        }
    }
}
