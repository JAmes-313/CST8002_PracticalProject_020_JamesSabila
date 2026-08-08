///<summary>
///Author: James Sabila
///Subject: Prgramming Language Research - Practical Project 2
///Link: [1] Josh Close (n.d.) Examples – CsvHelper. joshclose.github.io. [online] Available at: https://joshclose.github.io/CsvHelper/examples/ [Accessed on June 21, 2026].
//////
///Dataset Source:Fisheries and Oceans Canada. (Nov 29, 2024). Spatiotemporal variation in anadromous Arctic char (Salvelinus alpinus) foraging ecology and its influence on muscle pigmentation along western Hudson Bay, Nunavut, Canada. open.canada.ca. [online] Available at https://open.canada.ca/data/en/dataset/9cbcf710-a2a1-11ef-8ccf-55cc7f028297 [last accessed April 30, 2026]
///Dataset file name: Prey collection & analysis - raw data.csv
///Contains information licensed under the Open Government Licence – Canada. https://open.canada.ca/en/open-government-licence-canada
///</summary>

using CsvHelper;
using CsvHelper.Configuration;
using Project2.Models;
using System.Globalization;
using System.Text;

namespace Project2.Services
{
    /// <summary>
    /// a class for the CSVHelper nuget package
    /// </summary>
    public class CSVHelper
    {
        /// <summary>
        /// LoadData m,etghod for getting the data using the package
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public List<CsvFullModel> LoadData(string filePath)
        {
            try
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                int id = 1;

                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    MissingFieldFound = null,
                    HeaderValidated = null
                };

                //reading the csv file location
                using var reader = new StreamReader(filePath, Encoding.GetEncoding(1252));
                using var csv = new CsvReader(reader, config);

                var records = csv.GetRecords<CsvFullModel>().ToList();
                //added a custom id for the model
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

        /// <summary>
        /// save the newly crtaeted method record
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="data"></param>
        public void SaveAll(string filePath, List<CsvFullModel> data)
        {
            using var writer = new StreamWriter(filePath, false, Encoding.GetEncoding(1252));
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

            csv.WriteHeader<CsvFullModel>();
            csv.NextRecord();

            csv.WriteRecords(data);
        }
    }
}
