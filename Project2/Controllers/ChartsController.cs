using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Project2.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Project2.Controllers
{
    public class ChartsController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GenerateChart(string selector)
        {
            var data = DataHelper._dataModel;

            Dictionary<string, object> datus = new Dictionary<string, object>();

            switch (selector)
            {
                case "speciesByStudySite":

                    var studySiteData = data
                        .Where(x => !string.IsNullOrEmpty(x.StudySite))
                        .GroupBy(x => x.StudySite)
                        .Select(g => new
                        {
                            StudySite = g.Key,
                            SpeciesCount = g.Select(x => x.Species)
                                             .Distinct()
                                             .Count()
                        })
                        .ToList();

                    datus.Add(selector, studySiteData);

                    break;


                case "speciesByYear":

                    var yearData = data
                        .Where(x => !string.IsNullOrEmpty(x.Year))
                        .GroupBy(x => x.Year)
                        .Select(g => new
                        {
                            Year = g.Key,
                            SpeciesCount = g.Select(x => x.Species)
                                             .Distinct()
                                             .Count()
                        })
                        .ToList();

                    datus.Add(selector, yearData);

                    break;


                case "speciesByCommunity":

                    var communityData = data
                        .Where(x => !string.IsNullOrEmpty(x.AssociatedCommunity))
                        .GroupBy(x => x.AssociatedCommunity)
                        .Select(g => new
                        {
                            AssociatedCommunity = g.Key,
                            SpeciesCount = g.Select(x => x.Species)
                                             .Distinct()
                                             .Count()
                        })
                        .ToList();

                    datus.Add(selector, communityData);

                    break;
            }

            TempData["ChartData"] = JsonSerializer.Serialize(datus);

            return View("Index");
        }
    }
}
