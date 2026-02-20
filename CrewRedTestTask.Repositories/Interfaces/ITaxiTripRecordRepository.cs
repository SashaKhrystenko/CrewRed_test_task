using CrewRedTestTask.Entities;

namespace CrewRedTestTask.Repositories.Interfaces
{
    public interface ITaxiTripRecordRepository
    {
        public void AddRange(IReadOnlyList<TaxiTripRecordEntity> taxiTripRecords);
    }
}
