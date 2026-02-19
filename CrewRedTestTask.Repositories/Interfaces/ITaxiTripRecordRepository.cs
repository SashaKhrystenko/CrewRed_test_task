using CrewRedTestTask.Entities;

namespace CrewRedTestTask.Repositories.Interfaces
{
    public interface ITaxiTripRecordRepository
    {
        public void AddRange(IEnumerable<TaxiTripRecordEntity> taxiTripRecords);
    }
}
