using CrewredTestTask.Csv.Mappers;
using CrewRedTestTask.Models;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace CrewredTestTask.Csv
{
    public class CsvWorker
    {
        public const string CsvFileExtension = ".csv";

        public static IEnumerable<TaxiTripRecordModel> ReadTaxiTripRecords(string csvFilePath)
        {
            if (csvFilePath == null)
            {
                throw new ArgumentNullException(nameof(csvFilePath), $"{nameof(csvFilePath)} is null.");
            }

            if (!Path.Exists(csvFilePath))
            {
                throw new FileNotFoundException($"The csv file with this path '{csvFilePath}' does not exist.", csvFilePath);
            }

            if (Path.GetExtension(csvFilePath) != CsvFileExtension)
            {
                throw new InvalidDataException($"The file must have {CsvFileExtension} extension.");
            }

            List<TaxiTripRecordModel> records = new();

            using (StreamReader streamReader = new(csvFilePath))
            {
                using (CsvReader csvReader = new(streamReader, CultureInfo.InvariantCulture))
                {
                    csvReader.Context.RegisterClassMap<TaxiTripRecordMap>();

                    while (csvReader.Read())
                    {
                        records.Add(csvReader.GetRecord<TaxiTripRecordModel>());
                    }
                }
            }

            return records;
        }
    }
}