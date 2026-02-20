using CrewRedTestTask.Entities;
using CrewRedTestTask.Models;

namespace CrewRedTestTask.Services.Mappers
{
    public class TaxiTripRecordMapper
    {
        public static TaxiTripRecordEntity GetEntity(TaxiTripRecordModel model)
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
                StoreAndFwdFlag = ConvertFlag(model.StoreAndFwdFlag),
                PULocationID = model.PULocationID,
                DOLocationID = model.DOLocationID,
                FareAmount = model.FareAmount,
                TipAmount = model.TipAmount
            };
        }

        public static IReadOnlyList<TaxiTripRecordEntity> GetEntities(IReadOnlyList<TaxiTripRecordModel> models)
        {
            if (models == null)
            {
                throw new ArgumentNullException(nameof(models), $"{nameof(models)} is null.");
            }

            TaxiTripRecordEntity[] entities = new TaxiTripRecordEntity[models.Count];

            for (int i = 0; i < entities.Length; i++)
            {
                entities[i] = GetEntity(models[i]);
            }

            return entities;
        }

        private static string ConvertFlag(string flag)
        {
            if (flag == null)
            {
                throw new ArgumentNullException(nameof(flag), $"{nameof(flag)} is null.");
            }

            switch (flag)
            {
                case "Y":
                    return "Yes";

                case "N":
                    return "No";

                default:
                    return flag;  //Here we can also throw an exception if the flag has an unexpected value, but I decided to return the original value cuz I don't know the business logic.
            }
        }
    }
}
