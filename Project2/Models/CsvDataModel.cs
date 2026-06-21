namespace Project2.Models
{
    public class CsvDataModel
    {
        private string yearData;
        private string speciesData;
        private string commonNameData;
        private string studySiteData;
        private string associatedCommunityData;
        private string retinolData;

        public string year { get; set; }

        public string species { get; set; }

        public string commonName { get; set; }

        public string studySite { get; set; }

        public string associatedCommunity { get; set; }

        public string retinol { get; set; }
    }
}
