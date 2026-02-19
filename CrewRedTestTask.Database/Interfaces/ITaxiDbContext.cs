using CrewRedTestTask.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CrewRedTestTask.Database.Interfaces
{
    public interface ITaxiDbContext
    {
        DbSet<TaxiTripRecordEntity> TaxiTripRecords { get; set; }
        public DatabaseFacade Database { get; }
        int SaveChanges();
    }
}
