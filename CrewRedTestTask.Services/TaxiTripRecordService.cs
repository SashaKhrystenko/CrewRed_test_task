using CrewRedTestTask.Models;
using CrewRedTestTask.Services.Interfaces;

namespace CrewRedTestTask.Services
{
    public class TaxiTripRecordService : ITaxiTripRecordService
    {
        public void AddRange(IEnumerable<TaxiTripRecordModel> taxiTripRecords)
        {
            if (taxiTripRecords == null)
            {
                throw new ArgumentNullException(nameof(taxiTripRecords), $"{nameof(taxiTripRecords)} is null.");
            }


        }
    }
}
