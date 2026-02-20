using CrewRedTestTask.Database.Interfaces;
using CrewRedTestTask.Entities;
using CrewRedTestTask.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CrewRedTestTask.Repositories
{
    public class TaxiTripRecordRepository : ITaxiTripRecordRepository
    {
        private readonly ITaxiDbContext _taxiDbContext;
        public TaxiTripRecordRepository(ITaxiDbContext taxiDbContext)
        {
            if (taxiDbContext == null)
            {
                throw new ArgumentNullException(nameof(taxiDbContext), $"{nameof(taxiDbContext)} is null.");
            }

            _taxiDbContext = taxiDbContext;
        }

        public void AddRange(IReadOnlyList<TaxiTripRecordEntity> newTaxiTripRecords)
        {
            if (newTaxiTripRecords == null)
            {
                throw new ArgumentNullException(nameof(newTaxiTripRecords), $"{nameof(newTaxiTripRecords)} is null.");
            }

            TaxiTripRecordEntity[] existingTaxiRecords = _taxiDbContext.TaxiTripRecords
                .AsNoTracking()
                .ToArray()
            ;

            TaxiTripRecordEntity[] newRecordsForAdding = newTaxiTripRecords.Where(newRecord =>
                !existingTaxiRecords.Any(oldRecord =>
                    oldRecord.TpepPickupDateTime == newRecord.TpepPickupDateTime
                    && oldRecord.TpepDropoffDateTime == newRecord.TpepDropoffDateTime
                    && oldRecord.PassangerCount == newRecord.PassangerCount
                )
            )
                .ToArray()
            ;

            using (var transaction = _taxiDbContext.Database.BeginTransaction())
            {
                try
                {
                    _taxiDbContext.TaxiTripRecords.AddRange(newRecordsForAdding);

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
