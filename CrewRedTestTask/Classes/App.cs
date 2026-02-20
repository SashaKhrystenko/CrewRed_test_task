using CrewredTestTask.Csv;
using CrewredTestTask.Structures;
using CrewRedTestTask.Services.Interfaces;
using System;
using System.IO;

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
            string csvFilePath;
            string csvFilePathForDublicateData;

            Console.WriteLine("Enter the path of csv file.");

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

            Console.WriteLine($"Write csv file path to save dublicate data.");

            while (true)
            {
                csvFilePathForDublicateData = Console.ReadLine();

                if (!Path.Exists(Path.GetDirectoryName(csvFilePath)))
                {
                    Console.WriteLine($"The directory with this path '{Path.GetDirectoryName(csvFilePath)}' does not exist.");

                    continue;
                }

                if (Path.GetExtension(csvFilePathForDublicateData) != CsvWorker.CsvFileExtension)
                {
                    Console.WriteLine("File is not csv. Please enter the correct path of csv file.");

                    continue;
                }

                break;
            }

            CsvReaderResult taxiTripRecords = CsvWorker.ReadTaxiTripRecords(csvFilePath);

            _taxiTripRecordService.AddRange(taxiTripRecords.UniqueRecords);

            CsvWorker.WriteTaxiTripRecords(csvFilePathForDublicateData, taxiTripRecords.DuplicateRecords);

            Console.WriteLine("Data is transver to database");
        }
    }
}
