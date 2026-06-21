using CsvHelper.Configuration.Attributes;

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

        [Ignore]
        public int Id { get; set; } 

        [Name("Year/Ann�e")]
        public string Year { get; set; }

        [Name("Species/Esp�ce")]
        public string Species { get; set; }

        [Name("Common name/Nom commun")]
        public string CommonName { get; set; }

        [Name("Study site/Site d��tude")]
        public string StudySite { get; set; }

        [Name("Associated community/Collectivit� associ�e")]
        public string AssociatedCommunity { get; set; }

        [Name("Retinol/R�tinol (mg/kg)")]
        public string Retinol { get; set; }
    }
}
