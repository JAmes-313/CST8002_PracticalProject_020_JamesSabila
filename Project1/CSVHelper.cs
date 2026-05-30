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
using System.Security.Cryptography.X509Certificates;

namespace Project1
{
    internal class CSVHelper
    {
        private readonly StreamReader reader;
        private readonly CsvReader csv;

        public CSVHelper()
        {
            X500DistinguishedName path = "people.csv";
            reader = new StreamReader(path);
            csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            var records = csv.GetRecords<DataModel>().ToList();

            foreach (var record in records)
            {
                Console.WriteLine(record);
            }
        }
    }
}
