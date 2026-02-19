using CrewredTestTask.Csv;
using CrewRedTestTask.Models;
using CrewRedTestTask.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CrewredTestTask.Classes
{
    public class App
    {
        private readonly ITaxiTripRecordService _taxiTripRecordService;

        public App(ITaxiTripRecordService taxiTripRecordService)
        {
            if (taxiTripRecordService == null)
            {
                throw new ArgumentNullException(nameof(taxiTripRecordService), $"{nameof(taxiTripRecordService)} is null.");
            }

            _taxiTripRecordService = taxiTripRecordService;
        }

        public void Run()
        {
            Console.WriteLine("Enter the path of csv file.");

            string csvFilePath;

            while (true)
            {
                csvFilePath = Console.ReadLine();

                if (!Path.Exists(csvFilePath))
                {
                    Console.WriteLine("File does not exist. Please enter the correct path of csv file.");

                    continue;
                }

                if (Path.GetExtension(csvFilePath) != CsvWorker.CsvFileExtension)
                {
                    Console.WriteLine("File is not csv. Please enter the correct path of csv file.");

                    continue;
                }

                break;
            }

            IEnumerable<TaxiTripRecordModel> taxiTripRecords = CsvWorker.ReadTaxiTripRecords(csvFilePath);

            int i = taxiTripRecords.Where(r => string.IsNullOrEmpty(r.StoreAndFwdFlag)).Count();

            _taxiTripRecordService.AddRange(taxiTripRecords);

            Console.WriteLine(i);
            Console.WriteLine("Data is transver to database");
        }
    }
}
