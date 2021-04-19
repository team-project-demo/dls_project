using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DLS_Project.Models;
using BusinessLayer;
using PresentationLayer;

namespace DLS_Project.Controllers
{
    public class HomeController : Controller
    {
        private DataManager _dataManager;
        private ServicesManager _serviceManager;

        public HomeController(DataManager dataManager)
        {
            _dataManager = dataManager;
            _serviceManager = new ServicesManager(_dataManager);
        }

        public IActionResult Index()
        {
            var dirs = _serviceManager.DirService.TransitDirectoriesToView();
            return View(dirs);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
