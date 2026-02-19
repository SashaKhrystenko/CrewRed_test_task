using CrewRedTestTask.Entities;
using CrewRedTestTask.Models;

namespace CrewRedTestTask.Services.Mappers
{
    public class TaxiTripRecordMapper
    {
        public TaxiTripRecordEntity GetEntity(TaxiTripRecordModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), $"{nameof(model)} is null.");
            }

            return new TaxiTripRecordEntity
            {
                TpepPickupDateTime = model.TpepPickupDateTime,
                TpepDropoffDateTime = model.TpepDropoffDatetime,
                PassangerCount = model.PassengerCount,
                TripDistance = model.TripDistance,
                StoreAndFwdFlag = model.StoreAndFwdFlag,
                PULocationID = model.PULocationID,
                DOLocationID = model.DOLocationID,
                FareAmount = model.FareAmount,
                TipAmount = model.TipAmount
            };
        }
    }
}
