using CrewRedTestTask.Entities;
using CrewRedTestTask.Models;

namespace CrewRedTestTask.Services.Mappers
{
    public class TaxiTripRecordMapper
    {
        private const string _windowsUstTimeZoneInfoId = "Eastern Standard Time";
        private const string _otherOSUstTimeZoneInfoId = "America/New_York";

        private static readonly TimeZoneInfo _ustTimeZoneInfo;

        static TaxiTripRecordMapper()
        {
            if (OperatingSystem.IsWindows())
            {
                _ustTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(_windowsUstTimeZoneInfoId);
            }
            else
            {
                _ustTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(_otherOSUstTimeZoneInfoId);
            }
        }

        public static TaxiTripRecordEntity GetEntity(TaxiTripRecordModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), $"{nameof(model)} is null.");
            }

            return new TaxiTripRecordEntity
            {
                TpepPickupDateTime = TimeZoneInfo.ConvertTimeToUtc(model.TpepPickupDateTime, _ustTimeZoneInfo),
                TpepDropoffDateTime = TimeZoneInfo.ConvertTimeToUtc(model.TpepDropoffDatetime, _ustTimeZoneInfo),
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
                    throw new ArgumentOutOfRangeException(nameof(flag), "Invalid flag format.");
            }
        }
    }
}
