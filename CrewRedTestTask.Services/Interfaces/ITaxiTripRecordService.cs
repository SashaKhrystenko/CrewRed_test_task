using CrewRedTestTask.Models;

namespace CrewRedTestTask.Services.Interfaces
{
    public interface ITaxiTripRecordService
    {
        public void AddRange(IReadOnlyList<TaxiTripRecordModel> taxiTripRecords);
    }
}
