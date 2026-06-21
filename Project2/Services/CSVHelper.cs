using CsvHelper;
using Project2.Models;
using System.Globalization;

namespace Project2.Services
{
    public class CSVHelper
    {
        public List<CsvDataModel> LoadData(string filePath)
        {
            try
            {
                int id = 1;

                using var reader = new StreamReader(filePath);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

                var records = csv.GetRecords<CsvDataModel>()
                                  .Take(100)
                                  .ToList();
                
                foreach (CsvDataModel? item in records)
                {
                    item.Id = id++;
                }

                return records;
            }
            catch (FileNotFoundException)
            {
                return new List<CsvDataModel>();
            }
            catch (Exception)
            {
                return new List<CsvDataModel>();
            }
        }
    }
}
