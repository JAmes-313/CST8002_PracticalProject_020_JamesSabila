using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.IO;
using Project1.Model;


///Author James Sabila
///Practical Project 1
///<summary>
///This is the CSV helper  that will read and display the data on the console
///the CSVHelper is from a nuget package
///</summary>
namespace Project1
{
    internal class CSVHelper
    {
        //private fields
        private readonly StreamReader reader;
        private readonly CsvReader csv;
        private readonly FileHelper fileHelper;

        //constructor for the CSVhelper
        public CSVHelper()
        {
            var path = Path.Combine(AppContext.BaseDirectory, "Prey collection & analysis - raw data.csv");
            fileHelper = new FileHelper();

            bool fileExist = fileHelper.FileExists(path);
            if (fileExist)
            {
                //instantiating the Steramreader - using the IO
                reader = new StreamReader(path);
                //using the CSVReader from the nuget package
                csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            }
            else
            {
                Console.WriteLine("File Not Found");
            }
        }
        
        public void displayData()
        {
            try
            {
                //put the CSV Records on the List - using
                var records = csv.GetRecords<DataModel>().ToList();

                //header format
                string headerFormat = String.Format("{0}\t {1, -25} {2, -21} {3,-23} {4,-25} {5,-5}", "Year", "Species", "Common Name", "Study Site", "Associated Community", "Retinol");

                Console.WriteLine(headerFormat);

                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine();


                //loop through the records
                foreach (var record in records)
                {

                    String format = String.Format("{0}\t {1, -25} {2, -21} {3,-23} {4,-25} {5,-5}", record.year, record.species, record.commonName, record.studySite, record.associatedCommunity, record.retinol);

                    Console.WriteLine(format);
                }
            }
            //exception handling
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
