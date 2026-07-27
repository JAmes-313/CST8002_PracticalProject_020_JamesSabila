using Project2.Models;

namespace Project2.Services
{
    /// <summary>
    /// a method for storing the csv model data and guiid
    /// </summary>
    public class DataHelper
    {
        public static List<CsvFullModel> _dataModel  { get; set; }
        public static string _guidId { get; set; }

    }
}
