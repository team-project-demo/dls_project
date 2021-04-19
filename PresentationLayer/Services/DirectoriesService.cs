using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer;
using PresentationLayer.ViewModels;
using DataLayer.Entities;
using System.Linq;

namespace PresentationLayer.Services
{
    public class DirectoriesService
    {
        private DataManager _dataManager;
        private MaterialsService _materialsService;

        public DirectoriesService(DataManager dataManager)
        {
            _dataManager = dataManager;
            _materialsService = new MaterialsService(dataManager);
        }

        public List<DirectoryViewModel> TransitDirectoriesToView()
        {
            var dirs = _dataManager.DirRepos.GetAllDirectories();
            List<DirectoryViewModel> dirs_list = new List<DirectoryViewModel>();
            foreach (var item in dirs)
                dirs_list.Add(TransitDirectoryToView(item.Id));
            return dirs_list;
        }

        public DirectoryViewModel TransitDirectoryToView(int directory_id)
        {
            var dir = _dataManager.DirRepos.GetDirectoryById(directory_id, true);
            List<MaterialViewModel> mats_list = new List<MaterialViewModel>();
            foreach (var item in dir.Materials)
                mats_list.Add(_materialsService.TransitMaterialToView(directory_id));
            DirectoryViewModel vm = new DirectoryViewModel()
            {
                Directory = dir,
                Materials = mats_list
            };
            return vm;
        }
    }
}
