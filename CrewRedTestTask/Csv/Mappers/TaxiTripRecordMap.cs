using CrewRedTestTask.Models;
using CsvHelper.Configuration;

namespace CrewredTestTask.Csv.Mappers
{
    public class TaxiTripRecordMap : ClassMap<TaxiTripRecordModel>
    {
        public TaxiTripRecordMap()
        {
            Map(record => record.VendorID).Name("VendorID");
            Map(record => record.TpepPickupDateTime).Name("tpep_pickup_datetime");
            Map(record => record.TpepDropoffDatetime).Name("tpep_dropoff_datetime");
            Map(record => record.PassengerCount).Name("passenger_count");
            Map(record => record.TripDistance).Name("trip_distance");
            Map(record => record.RatecodeID).Name("RatecodeID");
            Map(record => record.StoreAndFwdFlag).Name("store_and_fwd_flag");
            Map(record => record.PULocationID).Name("PULocationID");
            Map(record => record.DOLocationID).Name("DOLocationID");
            Map(record => record.PaymentType).Name("payment_type");
            Map(record => record.FareAmount).Name("fare_amount");
            Map(record => record.Extra).Name("extra");
            Map(record => record.MtaTax).Name("mta_tax");
            Map(record => record.TipAmount).Name("tip_amount");
            Map(record => record.TollsAmount).Name("tolls_amount");
            Map(record => record.ImprovementSurcharge).Name("improvement_surcharge");
            Map(record => record.TotalAmount).Name("total_amount");
            Map(record => record.CongestionSurcharge).Name("congestion_surcharge");
        }
    }
}
