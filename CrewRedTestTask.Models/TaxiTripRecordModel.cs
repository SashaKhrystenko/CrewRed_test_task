namespace CrewRedTestTask.Models
{
    public class TaxiTripRecordModel
    {
        public int? VendorID { get; set; }
        public DateTime TpepPickupDateTime { get; set; }
        public DateTime TpepDropoffDatetime { get; set; }
        public int? PassengerCount { get; set; }
        public decimal TripDistance { get; set; }
        public int? RatecodeID { get; set; }
        public string? StoreAndFwdFlag { get; set; }
        public int PULocationID { get; set; }
        public int DOLocationID { get; set; }
        public int? PaymentType { get; set; }
        public decimal FareAmount { get; set; }
        public decimal Extra { get; set; }
        public decimal MtaTax { get; set; }
        public decimal TipAmount { get; set; }
        public decimal TollsAmount { get; set; }
        public decimal ImprovementSurcharge { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal CongestionSurcharge { get; set; }
    }
}
