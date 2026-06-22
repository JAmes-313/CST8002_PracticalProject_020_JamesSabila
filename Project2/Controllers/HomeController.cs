using System.Diagnostics;
using CsvHelper;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Project2.Models;
using Project2.Services;

///<summary>
///Author: James Sabila
///Subject: Prgramming Language Research - Practical Project 2
///Link: [1] Microsoft Learn (n.d.) ASP.NET MVC Controllers Overview (C#). learn.microsoft.com. [online] Available at: https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/controllers-and-routing/aspnet-mvc-controllers-overview-cs [Accessed on June 21, 2026].
///</summary>

namespace Project2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly CSVHelper _csvService;
        private readonly IWebHostEnvironment _env;

        private string fileName = "Prey collection & analysis - raw data.csv";

        private String ext = ".csv";
        private String preFileName = "DataSet_";
        private String fileNameGuiId = "";

        private List<CsvFullModel> dataSet;

        public HomeController(ILogger<HomeController> logger, CSVHelper csvService, IWebHostEnvironment env)
        {
            _logger = logger;
            _csvService = csvService;
            _env = env;
        }

        public IActionResult Index()
        {

            string filePath = FileHelper.GetFilePath(_env, fileName);

            if (!FileHelper.IsExtensionFileValid(fileName))
            {
                return BadRequest("Invalid file");
            }

            dataSet = _csvService.LoadData(filePath);

            return View(dataSet);
        }

        public IActionResult CreateRecord()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CsvFullModel model)
        {
            fileNameGuiId = GenerateGuiID();
            string filePath = Path.Combine(_env.WebRootPath, "data", fileNameGuiId);

            try
            {
                using var stream = new StreamWriter(filePath, append: true);
                using var csv = new CsvWriter(stream, CultureInfo.InvariantCulture);


                csv.WriteRecord(model);
                stream.WriteLine();


                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            string filePath = FileHelper.GetFilePath(_env, fileName);

            var data = _csvService.LoadData(filePath);

            var item = data.FirstOrDefault(x => x.Id == id);

            if (item != null)
            {
                data.Remove(item);
            }

            _csvService.SaveAll(filePath, data);

            return View("Index", data);
        }
        
        public IActionResult EditRecord(int id)
        {
            string filePath = FileHelper.GetFilePath(_env, fileName);

            var data = _csvService.LoadData(filePath);

            var item = data.FirstOrDefault(x => x.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(CsvFullModel model)
        {
            string filePath = FileHelper.GetFilePath(_env, fileName);

            var data = _csvService.LoadData(filePath);

            var item = data.FirstOrDefault(x => x.Id == model.Id);

            if (item != null)
            {
                item.Year = model.Year;
                item.Species = model.Species;
                item.CommonName = model.CommonName;
                item.StudySite = model.StudySite;
                item.AssociatedCommunity = model.AssociatedCommunity;
                item.Retinol = model.Retinol;

                // update any other fields you allow editing
            }

            _csvService.SaveAll(filePath, data);

            return RedirectToAction("Index");
        }

        private String GenerateGuiID()
        {
            Guid myuuid = Guid.NewGuid();
            return preFileName + myuuid + ext ;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }        
    }
}
