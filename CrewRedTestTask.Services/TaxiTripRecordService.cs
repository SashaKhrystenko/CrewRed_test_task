using CrewRedTestTask.Entities;
using CrewRedTestTask.Models;
using CrewRedTestTask.Repositories.Interfaces;
using CrewRedTestTask.Services.Interfaces;
using CrewRedTestTask.Services.Mappers;

namespace CrewRedTestTask.Services
{
    public class TaxiTripRecordService : ITaxiTripRecordService
    {
        private readonly ITaxiTripRecordRepository _taxiTripRecordRepository;
        public TaxiTripRecordService(ITaxiTripRecordRepository taxiTripRecordRepository)
        {
            if (taxiTripRecordRepository == null)
            {
                throw new ArgumentNullException(nameof(taxiTripRecordRepository), $"{nameof(taxiTripRecordRepository)} is null.");
            }

            _taxiTripRecordRepository = taxiTripRecordRepository;
        }

        public void AddRange(IReadOnlyList<TaxiTripRecordModel> taxiTripRecords)
        {
            if (taxiTripRecords == null)
            {
                throw new ArgumentNullException(nameof(taxiTripRecords), $"{nameof(taxiTripRecords)} is null.");
            }

            IReadOnlyList<TaxiTripRecordEntity> entities = TaxiTripRecordMapper.GetEntities(taxiTripRecords);

            _taxiTripRecordRepository.AddRange(entities);
        }
    }
}
