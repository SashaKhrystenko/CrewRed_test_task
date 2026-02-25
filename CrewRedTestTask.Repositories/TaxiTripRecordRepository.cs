using CrewRedTestTask.Database.Interfaces;
using CrewRedTestTask.Entities;
using CrewRedTestTask.Repositories.Interfaces;
using EFCore.BulkExtensions;

namespace CrewRedTestTask.Repositories
{
    public class TaxiTripRecordRepository : ITaxiTripRecordRepository
    {
        private readonly BulkConfig _bulkConfig;

        private readonly ITaxiDbContext _taxiDbContext;

        public TaxiTripRecordRepository(ITaxiDbContext taxiDbContext, BulkConfig bulkConfig)
        {
            if (taxiDbContext == null)
            {
                throw new ArgumentNullException(nameof(taxiDbContext), $"{nameof(taxiDbContext)} is null.");
            }

            if (bulkConfig == null)
            {
                throw new ArgumentNullException(nameof(bulkConfig), $"{nameof(bulkConfig)} is null.");

            }

            _taxiDbContext = taxiDbContext;
            _bulkConfig = bulkConfig;
        }

        public void AddRange(IReadOnlyList<TaxiTripRecordEntity> newTaxiTripRecords)
        {
            if (newTaxiTripRecords == null)
            {
                throw new ArgumentNullException(nameof(newTaxiTripRecords), $"{nameof(newTaxiTripRecords)} is null.");
            }

            using (var transaction = _taxiDbContext.Database.BeginTransaction())
            {
                try
                {
                    _taxiDbContext.BulkRecordsInsertSkippingDublicates(newTaxiTripRecords, _bulkConfig);

                    _taxiDbContext.SaveChanges();

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();

                    throw;
                }
            }
        }
    }
}
