using CrewRedTestTask.Entities;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;

namespace CrewRedTestTask.Database.Interfaces
{
    public interface ITaxiDbContext
    {
        DbSet<TaxiTripRecordEntity> TaxiTripRecords { get; set; }
        public DatabaseFacade Database { get; }
        public void BulkRecordsInsertSkippingDublicates(
            IEnumerable<TaxiTripRecordEntity> records,
            BulkConfig bulkConfig = null,
            Action<decimal> progress = null
        );
        public int SaveChanges();
    }
}
