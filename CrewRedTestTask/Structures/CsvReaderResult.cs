using CrewRedTestTask.Models;
using System;
using System.Collections.Generic;

namespace CrewredTestTask.Structures
{
    public struct CsvReaderResult
    {
        private readonly HashSet<(DateTime, DateTime, int?)> _uniqueRecordKeyes;

        private readonly List<TaxiTripRecordModel> _uniqueRecords;
        private readonly List<TaxiTripRecordModel> _duplicateRecords;

        public List<TaxiTripRecordModel> UniqueRecords
        {
            get
            {
                return _uniqueRecords;
            }
        }

        public List<TaxiTripRecordModel> DuplicateRecords
        {
            get
            {
                return _duplicateRecords;
            }
        }

        public CsvReaderResult()
        {
            _uniqueRecordKeyes = new HashSet<(DateTime, DateTime, int?)>();

            _uniqueRecords = new List<TaxiTripRecordModel>();
            _duplicateRecords = new List<TaxiTripRecordModel>();
        }

        public void Update(TaxiTripRecordModel record)
        {
            if (record == null)
            {
                throw new ArgumentNullException(nameof(record), $"{nameof(record)} is null.");
            }

            var key = (record.TpepPickupDateTime, record.TpepDropoffDatetime, record.PassengerCount);

            if (_uniqueRecordKeyes.Add(key))
            {
                _uniqueRecords.Add(record);
            }
            else
            {
                _duplicateRecords.Add(record);
            }
        }
    }
}
