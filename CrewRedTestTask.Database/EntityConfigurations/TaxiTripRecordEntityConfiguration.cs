using CrewRedTestTask.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrewRedTestTask.Database.EntityConfigurations
{
    public class TaxiTripRecordEntityConfiguration : IEntityTypeConfiguration<TaxiTripRecordEntity>
    {
        public void Configure(EntityTypeBuilder<TaxiTripRecordEntity> builder)
        {
            builder
                .HasKey(record => new
                {
                    record.TpepPickupDateTime,
                    record.TpepDropoffDateTime,
                    record.PassangerCount
                })
            ;

            builder
                .Property(record => record.TpepPickupDateTime)
                .HasColumnName("tpep_pickup_datetime")
                .IsRequired()
            ;

            builder
                .Property(record => record.TpepDropoffDateTime)
                .HasColumnName("tpep_dropoff_datetime")
                .IsRequired()
            ;

            builder
                .Property(record => record.PassangerCount)
                .HasColumnName("passenger_count")
            ;

            builder
                .Property(record => record.TripDistance)
                .HasColumnName("trip_distance")
                .IsRequired()
            ;

            builder
                .Property(record => record.StoreAndFwdFlag)
                .HasColumnName("store_and_fwd_flag")
            ;

            builder
                .Property(record => record.PULocationID)
                .HasColumnName("PULocationID")
                .IsRequired()
            ;

            builder
                .Property(record => record.DOLocationID)
                .HasColumnName("DOLocationID")
                .IsRequired()
            ;

            builder
                .Property(record => record.FareAmount)
                .HasColumnName("fare_amount")
                .IsRequired()
            ;

            builder
                .Property(record => record.TipAmount)
                .HasColumnName("tip_amount")
                .IsRequired()
            ;
        }
    }
}
