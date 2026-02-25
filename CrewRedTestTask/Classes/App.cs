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

        public void Run(string[] args)
        {
            if (!TryGetPathFromArgs(args, out string csvFilePath))
            {
                Console.WriteLine("Enter the path to csv file.");

                csvFilePath = GetFromConsole();
            }

            string basePath = Path.GetDirectoryName(csvFilePath);
            string dublicateFilePath = Path.Combine(basePath, "Dublicates.csv");
            string errorDataFilePath = Path.Combine(basePath, "ErrorData.csv");

            CsvReaderResult taxiTripRecords = CsvWorker.ReadTaxiTripRecords(csvFilePath);

            _taxiTripRecordService.AddRange(taxiTripRecords.UniqueRecords);

            CsvWorker.WriteTaxiTripRecords(dublicateFilePath, taxiTripRecords.DuplicateRecords);
            CsvWorker.WriteErrorRows(errorDataFilePath, taxiTripRecords.ErrorRows);

            Console.WriteLine("Data is transver to database");
            Console.WriteLine("Files with duplicate and error records is located in source data file directory.");
        }

        private static string GetFromConsole()
        {
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

                return csvFilePath;
            }
        }

        private static bool TryGetPathFromArgs(string[] args, out string csvFilePath)
        {
            csvFilePath = string.Empty;

            if (args == null || args.Length == 0)
            {
                return false;
            }

            foreach (string arg in args)
            {
                if (File.Exists(arg))
                {
                    csvFilePath = arg;

                    return true;
                }
            }

            Console.WriteLine("Invalid file path.");

            return false;
        }
    }
}
