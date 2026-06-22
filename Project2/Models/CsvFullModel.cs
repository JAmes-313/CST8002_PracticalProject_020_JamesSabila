using CsvHelper.Configuration.Attributes;

namespace Project2.Models
{
    public class CsvFullModel
    {
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

        [Name("Lat")]
        public string Lat { get; set; }

        [Name("Long")]
        public string Long { get; set; }

        [Name("delta13C")]
        public string delta13C { get; set; }

        [Name("delta13Cc")]
        public string delta13Cc { get; set; }

        [Name("delta15N")]
        public string delta15N { get; set; }

        [Name("delta15Nc")]
        public string delta15Nc { get; set; }

        [Name("TP")]
        public string TP { get; set; }

        [Name("C:N")]
        public string CN { get; set; }

        [Name("Astaxanthin/Astaxanthine (mg/kg)")]
        public string Astaxanthin { get; set; }

        [Name("Canthaxanthin/Canthaxanthine (mg/kg)")]
        public string Canthaxanthin { get; set; }

        [Name("Retinol/R�tinol (mg/kg)")]
        public string Retinol { get; set; }
    }
}
