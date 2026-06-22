using CsvHelper.Configuration;

namespace Project2.Models
{
    public class CsvDataMap : ClassMap<CsvDataModel>
    {
        public CsvDataMap()
        {
            Map(m => m.Year).Name("Year/Année");
            Map(m => m.Species).Name("Species/Espèce");
            Map(m => m.CommonName).Name("Common name/Nom commun");
            Map(m => m.StudySite).Name("Study site/Site d’étude");
            Map(m => m.AssociatedCommunity).Name("Associated community/Collectivité associée");
            Map(m => m.Retinol).Name("Retinol/R�tinol (mg/kg)");
        }
    }
}
