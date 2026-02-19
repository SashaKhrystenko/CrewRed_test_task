using System;

namespace CrewRedTestTask.Entities
{
    public class TaxiTripRecordEntity
    {
        public DateTime TpepPickupDateTime { get; set; }
        public DateTime TpepDropoffDateTime { get; set; }
        public int? PassangerCount { get; set; }
        public decimal TripDistance { get; set; }
        public string StoreAndFwdFlag { get; set; }
        public int PULocationID { get; set; }
        public int DOLocationID { get; set; }
        public decimal FareAmount { get; set; }
        public decimal TipAmount { get; set; }
    }
}
