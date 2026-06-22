using CsvHelper;
using CsvHelper.Configuration;
using Project2.Models;
using System.Globalization;
using System.Text;

namespace Project2.Services
{
    public class CSVHelper
    {
        public List<CsvFullModel> LoadData(string filePath)
        {
            try
            {
                int id = 1;

                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Encoding = Encoding.UTF8,
                    MissingFieldFound = null,
                    HeaderValidated = null
                };

                using var reader = new StreamReader(filePath, Encoding.UTF8);
                using var csv = new CsvReader(reader, config);

                var records = csv.GetRecords<CsvFullModel>().ToList();
                
                foreach (CsvFullModel? item in records)
                {
                    item.Id = id++;
                }

                return records;
            }
            catch (FileNotFoundException)
            {
                return new List<CsvFullModel>();
            }
            catch (Exception)
            {
                return new List<CsvFullModel>();
            }
        }

        public void SaveAll(string filePath, List<CsvFullModel> data)
        {
            using var writer = new StreamWriter(filePath, false); // overwrite file
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

            csv.WriteHeader<CsvFullModel>();
            csv.NextRecord();

            csv.WriteRecords(data);
        }

        public CsvDataModel GetFirstRecord(string filePath)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Encoding = Encoding.UTF8,
                MissingFieldFound = null,
                HeaderValidated = null
            };

            using var reader = new StreamReader(filePath, Encoding.UTF8);
            using var csv = new CsvReader(reader, config);

            // STEP 3 → register mapping
            csv.Context.RegisterClassMap<CsvDataMap>();

            // STEP 4 → read data
            var record = csv.GetRecords<CsvDataModel>().FirstOrDefault();

            return record;
        }
    }
}
