using CsvHelper.Configuration.Attributes;

///<summary>
///Author: James Sabila
///Subject: Prgramming Language Research - Practical Project 2
///Link: [1] Microsoft Learn (n.d.) ASP.NET MVC Controllers Overview (C#). learn.microsoft.com. [online] Available at: https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/controllers-and-routing/aspnet-mvc-controllers-overview-cs [Accessed on June 21, 2026].
///</summary>

namespace Project2.Models
{
    /// <summary>
    /// CSV model class for the csv file
    /// </summary>
    public class CsvFullModel
    {
        //prperties
        [Ignore]
        public int Id { get; set; }

        //Added name properties for getting the name of the CSV file header
        [Name("Year/Année")]
        public string Year { get; set; }
        [Name("Species/Espèce")]
        public string Species { get; set; }

        [Name("Common name/Nom commun")]
        public string CommonName { get; set; }
        [Name("Study site/Site d’étude")]
        public string StudySite { get; set; }
        [Name("Associated community/Collectivité associée")]
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

        [Name("Retinol/Rétinol (mg/kg)")]
        public string Retinol { get; set; }
    }
}
