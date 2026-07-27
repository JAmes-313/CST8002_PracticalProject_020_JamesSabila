using CsvHelper.Configuration.Attributes;

///<summary>
///Author: James Sabila
///Subject: Prgramming Language Research - Practical Project 2
///Link: [1] Microsoft Learn (n.d.) ASP.NET MVC Controllers Overview (C#). learn.microsoft.com. [online] Available at: https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/controllers-and-routing/aspnet-mvc-controllers-overview-cs [Accessed on June 21, 2026].
//////
///Dataset Source:Fisheries and Oceans Canada. (Nov 29, 2024). Spatiotemporal variation in anadromous Arctic char (Salvelinus alpinus) foraging ecology and its influence on muscle pigmentation along western Hudson Bay, Nunavut, Canada. open.canada.ca. [online] Available at https://open.canada.ca/data/en/dataset/9cbcf710-a2a1-11ef-8ccf-55cc7f028297 [last accessed April 30, 2026]
///Dataset file name: Prey collection & analysis - raw data.csv
///Contains information licensed under the Open Government Licence – Canada. https://open.canada.ca/en/open-government-licence-canada
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
