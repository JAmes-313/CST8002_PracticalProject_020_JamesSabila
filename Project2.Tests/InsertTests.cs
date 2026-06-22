using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project2.Models;

namespace Project2.Tests
{
    public class InsertTests
    {
        [Fact]
        public void AddRecord_IncreasesRecordCount()
        {
            // Arrange
            var data = new List<CsvFullModel>();

            var newRecord = new CsvFullModel
            {
                Id = 1,
                Year = "2024",
                Species = "Test Species",
                CommonName = "Test Common Name",
                StudySite = "Test Site",
                AssociatedCommunity = "Test Community",
                Retinol = "100"
            };

            // Act
            data.Add(newRecord);

            // Assert
            Assert.Single(data);
            Assert.Equal("Test Species", data[0].Species);
        }
    }
}
