using CrewredTestTask.Csv;
using CrewredTestTask.Structures;
using CrewRedTestTask.Services.Interfaces;
using System;
using System.IO;

namespace CrewredTestTask.Classes
{
    public class App
    {
        private static readonly string _dataFolderPath = Directory.GetParent(Directory.GetCurrentDirectory())!.Parent!.Parent!.FullName;

        private readonly string _dublicateFilePath = $"{_dataFolderPath}\\DataFolder\\Dublicates.csv";
        private readonly string _errorDataFilePath = $"{_dataFolderPath}\\DataFolder\\ErrorData.csv";

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

            CsvReaderResult taxiTripRecords = CsvWorker.ReadTaxiTripRecords(csvFilePath);

            _taxiTripRecordService.AddRange(taxiTripRecords.UniqueRecords);

            CsvWorker.WriteTaxiTripRecords(_dublicateFilePath, taxiTripRecords.DuplicateRecords);
            CsvWorker.WriteErrorRows(_errorDataFilePath, taxiTripRecords.ErrorRows);

            Console.WriteLine("Data is transver to database");
            Console.WriteLine("Files with dublicate and error records is located in DataFolder inside project.");
        }
    }
}
