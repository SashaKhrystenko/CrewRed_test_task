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
        private readonly List<string> _errorRows;

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

        public List<string> ErrorRows
        {
            get
            {
                return _errorRows;
            }
        }

        public CsvReaderResult()
        {
            _uniqueRecordKeyes = new HashSet<(DateTime, DateTime, int?)>();

            _uniqueRecords = new List<TaxiTripRecordModel>();
            _duplicateRecords = new List<TaxiTripRecordModel>();
            _errorRows = new List<string>();
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

        public void AddErrorRow(string errorRow)
        {
            if (errorRow == null)
            {
                throw new ArgumentNullException(nameof(errorRow), $"{nameof(errorRow)} is null.");
            }

            _errorRows.Add(errorRow);
        }
    }
}
