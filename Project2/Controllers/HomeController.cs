using System.Diagnostics;
using CsvHelper;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Project2.Models;
using Project2.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

///<summary>
///Author: James Sabila
///Subject: Prgramming Language Research - Practical Project 2
///Link: [1] Microsoft Learn (n.d.) ASP.NET MVC Controllers Overview (C#). learn.microsoft.com. [online] Available at: https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/controllers-and-routing/aspnet-mvc-controllers-overview-cs [Accessed on June 21, 2026].
///</summary>

namespace Project2.Controllers
{
    /// <summary>
    /// The Home controller class from the MVC Architecture
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Fields and properties
        /// </summary>
        private readonly ILogger<HomeController> _logger;

        private readonly CSVHelper _csvService;
        private readonly IWebHostEnvironment _env;

        private string fileName = "Prey collection & analysis - raw data.csv";

        private string ext = ".csv";
        private string preFileName = "DataSet_";
        private string fileNameGuiId = "";

        private List<CsvFullModel> dataSet;

        /// <summary>
        /// HomeController Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="csvService"></param>
        /// <param name="env"></param>
        public HomeController(ILogger<HomeController> logger, CSVHelper csvService, IWebHostEnvironment env)
        {
            _logger = logger;
            _csvService = csvService;
            _env = env;
        }

        /// <summary>
        /// The Index which is the default for MVC project
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            //properties
            string fileSelector = DataHelper._guidId != null ? DataHelper._guidId : fileName;
            string filePath = FileHelper.GetFilePath(_env, fileSelector);

            if (!FileHelper.IsExtensionFileValid(fileName))
            {
                return BadRequest("Invalid file");
            }

            dataSet = _csvService.LoadData(filePath);

            //save data on memoprry even when going to other pages
            DataHelper._dataModel = dataSet;

            return View(dataSet);
        }

        /// <summary>
        /// CraeteRecord method that returns the View
        /// </summary>
        /// <returns></returns>
        public IActionResult CreateRecord()
        {
            return View();
        }

        /// <summary>
        /// a Crate method with HTTPPost for creating the record of the CSV
        /// a new file will be craeted for the purpose of showing the GUIID method
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(CsvFullModel model)
        {
            //properties
            fileNameGuiId = GenerateGuiID();
            string filePath = Path.Combine(_env.WebRootPath, "data", fileNameGuiId);

            //GUIID creation
            DataHelper._guidId = fileNameGuiId;

            try
            {
                dataSet = DataHelper._dataModel;
                //craeting new id for the newly crated record
                model.Id = dataSet.Count() + 1;
                dataSet.Add(model);

                _csvService.SaveAll(filePath, dataSet);


                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        /// <summary>
        /// Delete method for deleteing the record on csv file
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Delete(int id)
        {
            //guiid selector
            string fileSelector = DataHelper._guidId != null ? DataHelper._guidId : fileName;
            string filePath = FileHelper.GetFilePath(_env, fileSelector);

            var data = DataHelper._dataModel;

            var item = data.FirstOrDefault(x => x.Id == id);

            if (item != null)
            {
                data.Remove(item);
            }

            _csvService.SaveAll(filePath, data);

            return View("Index", data);
        }
        
        /// <summary>
        /// the method for redirecting to editRecord view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult EditRecord(int id)
        {
            var data = DataHelper._dataModel;

            var item = data.FirstOrDefault(x => x.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        /// <summary>
        /// Update record methoid for updating the csv file
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(CsvFullModel model)
        {
            string fileSelector = DataHelper._guidId != null ? DataHelper._guidId : fileName;
            string filePath = FileHelper.GetFilePath(_env, fileSelector);
            var data = DataHelper._dataModel;

            var item = data.FirstOrDefault(x => x.Id == model.Id);

            if (item != null)
            {
                //getting the model for display
                item.Year = model.Year;
                item.Species = model.Species;
                item.CommonName = model.CommonName;
                item.StudySite = model.StudySite;
                item.AssociatedCommunity = model.AssociatedCommunity;
                item.Retinol = model.Retinol;

                
            }

            _csvService.SaveAll(filePath, data);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Advance Lesson - Sorting
        /// </summary>
        /// <param name="filterOption"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult FilterBy(string filterOption)
        {
            var data = DataHelper._dataModel;

            var sortedListDesc = new List<CsvFullModel>();

            //order the list descending based on the selected selector
            switch (filterOption)
            {
                case "Year":
                    sortedListDesc = data.OrderByDescending(x => x.Year).ToList();
                    break;
                case "Species":
                    sortedListDesc = data.OrderByDescending(x => x.Species).ToList();
                    break;
                case "Common Name":
                    sortedListDesc = data.OrderByDescending(x => x.CommonName).ToList();
                    break;
                case "Study Site":
                    sortedListDesc = data.OrderByDescending(x => x.StudySite).ToList();
                    break;
                case "Associated Community":
                    sortedListDesc = data.OrderByDescending(x => x.AssociatedCommunity).ToList();
                    break;
                case "Retinol":
                    sortedListDesc = data.OrderByDescending(x => x.Retinol).ToList();
                    break;
                default:
                    sortedListDesc = data;
                    break;
            }
            

            return View("Index", sortedListDesc);
        }

        /// <summary>
        /// methiod for generating the GUIID
        /// </summary>
        /// <returns></returns>
        private string GenerateGuiID()
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
