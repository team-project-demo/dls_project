using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using PresentationLayer;
using PresentationLayer.ViewModels;
using static DataLayer.Enums.PageEnums;

namespace DLS_Project.Controllers
{
    public class PageController : Controller
    {
        private DataManager _dataManager;
        private ServicesManager _servicesManager;

        public PageController(DataManager dataManager)
        {
            _dataManager = dataManager;
            _servicesManager = new ServicesManager(dataManager);
        }
        
        public IActionResult Index(int pageId, PageType pageType)
        {
            PageViewModel viewModel;
            switch (pageType)
            {
                case PageType.Directory:
                    viewModel = _servicesManager.DirService.TransitDirectoryToView(pageId);
                    break;
                case PageType.Material:
                    viewModel = _servicesManager.MatService.TransitMaterialToView(pageId);
                    break;
                default:
                    viewModel = null;
                    break;
            }
            ViewBag.PageType = pageType;
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult PageEditor(int pageId, PageType pageType, int directoryId = 0)
        {
            PageViewModel viewModel;
            switch (pageType)
            {
                case PageType.Directory:
                    if (pageId != 0)
                        viewModel = _servicesManager.DirService.GetDirectoryEditModel(pageId);
                    else
                        viewModel = _servicesManager.DirService.CreateNewDirectoryModel();
                    break;
                case PageType.Material:
                    if (pageId != 0)
                        viewModel = _servicesManager.MatService.GetMaterialEditModel(pageId);
                    else
                        viewModel = _servicesManager.MatService.CreateNewMaterialEditModel(directoryId);
                    break;
                default:
                    viewModel = null;
                    break;
            }
            ViewBag.PageType = pageType;
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult SaveDirectory(DirectoryViewModel model)
        {
            _servicesManager.DirService.SaveDirectoryEditModel(model);            
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult SaveMaterial(MaterialViewModel model)
        {
            _servicesManager.MatService.SaveMaterialToDb(model);
            return RedirectToAction("Index", "Home");
        }
    }
}
