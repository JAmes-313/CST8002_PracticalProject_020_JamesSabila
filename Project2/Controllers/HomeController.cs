using System.Diagnostics;
using CsvHelper;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Project2.Models;
using Project2.Services;

namespace Project2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly CSVHelper _csvService;
        private readonly IWebHostEnvironment _env;

        private string fileName = "Prey collection & analysis - raw data.csv";

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

            var data = _csvService.LoadData(filePath);

            return View(data);
        }

        public IActionResult CreateRecord()
        {
            //string filePath = FileHelper.GetFilePath(_env, fileName);
            //var data = _csvService.GetFirstRecord(filePath);
            return View();
        }

        [HttpPost]
        public IActionResult Create(CsvFullModel model)
        {
            string filePath = Path.Combine(_env.WebRootPath, "data", fileName);

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
