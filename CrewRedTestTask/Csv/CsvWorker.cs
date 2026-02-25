using CrewredTestTask.Csv.Mappers;
using CrewredTestTask.Structures;
using CrewRedTestTask.Models;
using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace CrewredTestTask.Csv
{
    public class CsvWorker
    {
        public const string CsvFileExtension = ".csv";

        public static CsvReaderResult ReadTaxiTripRecords(string csvFilePath)
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

            CsvReaderResult csvReaderResult = new();

            CsvConfiguration csvReaderConfiguration = new(CultureInfo.InvariantCulture)
            {
                TrimOptions = TrimOptions.Trim,
                ReadingExceptionOccurred = ex =>
                {
                    csvReaderResult.AddErrorRow(ex.Exception.Context.Parser.RawRecord);

                    return false;
                },
                BadDataFound = context =>
                {
                    csvReaderResult.AddErrorRow(context.Context.Parser.RawRecord);
                },
                MissingFieldFound = (args) =>
                {
                    csvReaderResult.AddErrorRow(args.Context.Parser.RawRecord);
                }
            };

            TaxiTripRecordModel record;

            using (StreamReader streamReader = new(csvFilePath))
            {
                using (CsvReader csvReader = new(streamReader, csvReaderConfiguration))
                {
                    csvReader.Context.RegisterClassMap<TaxiTripRecordMap>();

                    while (csvReader.Read())
                    {
                        record = csvReader.GetRecord<TaxiTripRecordModel>();

                        if (record != null)
                        {
                            csvReaderResult.Update(record);
                        }
                    }
                }
            }

            return csvReaderResult;
        }

        public static void WriteTaxiTripRecords(string csvFilePath, IEnumerable<TaxiTripRecordModel> taxiTripRecords)
        {
            if (csvFilePath == null)
            {
                throw new ArgumentNullException(nameof(csvFilePath), $"{nameof(csvFilePath)} is null.");
            }

            if (!Path.Exists(Path.GetDirectoryName(csvFilePath)))
            {
                throw new DirectoryNotFoundException($"The directory with this path '{Path.GetDirectoryName(csvFilePath)}' does not exist.");
            }

            if (Path.GetExtension(csvFilePath) != CsvFileExtension)
            {
                throw new InvalidDataException($"The file must have {CsvFileExtension} extension.");
            }

            if (taxiTripRecords == null)
            {
                throw new ArgumentNullException(nameof(taxiTripRecords), $"{nameof(taxiTripRecords)} is null.");
            }

            using (StreamWriter streamWriter = new(csvFilePath))
            {
                using (CsvWriter csvWriter = new(streamWriter, CultureInfo.InvariantCulture))
                {
                    csvWriter.Context.RegisterClassMap<TaxiTripRecordMap>();

                    csvWriter.WriteHeader<TaxiTripRecordModel>();
                    csvWriter.NextRecord();

                    foreach (TaxiTripRecordModel record in taxiTripRecords)
                    {
                        csvWriter.WriteRecord(record);
                        csvWriter.NextRecord();
                    }
                }
            }
        }

        public static void WriteErrorRows(string csvFilePath, IEnumerable<string> errorRows)
        {
            if (csvFilePath == null)
            {
                throw new ArgumentNullException(nameof(csvFilePath), $"{nameof(csvFilePath)} is null.");
            }

            if (!Path.Exists(Path.GetDirectoryName(csvFilePath)))
            {
                throw new DirectoryNotFoundException($"The directory with this path '{Path.GetDirectoryName(csvFilePath)}' does not exist.");
            }

            if (Path.GetExtension(csvFilePath) != CsvFileExtension)
            {
                throw new InvalidDataException($"The file must have {CsvFileExtension} extension.");
            }

            if (errorRows == null)
            {
                throw new ArgumentNullException(nameof(errorRows), $"{nameof(errorRows)} is null.");
            }

            using (StreamWriter streamWriter = new(csvFilePath))
            {
                using (CsvWriter csvWriter = new(streamWriter, CultureInfo.InvariantCulture))
                {
                    csvWriter.WriteHeader<TaxiTripRecordModel>();
                    csvWriter.NextRecord();

                    foreach (string errorRow in errorRows)
                    {
                        streamWriter.Write(errorRow);
                    }
                }
            }
        }
    }
}