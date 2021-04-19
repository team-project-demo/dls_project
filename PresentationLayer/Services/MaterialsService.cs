using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer;
using PresentationLayer.ViewModels;
using DataLayer.Entities;
using System.Linq;

namespace PresentationLayer.Services
{
    public class MaterialsService
    {
        private DataManager _dataManager;

        public MaterialsService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public MaterialViewModel TransitMaterialToView(int materialId)
        {
            var vm = new MaterialViewModel()
            {
                Material = _dataManager.MatRepos.GetMaterialById(materialId)
            };

            var dir_id = vm.Material.DirectoryId;
            var dir = _dataManager.DirRepos.GetDirectoryById(dir_id, true);
            vm.DirectoryId = dir_id;

            var current = dir.Materials.FirstOrDefault(x => x.Id == vm.Material.Id);
            var current_index = dir.Materials.IndexOf(current);
            var N = dir.Materials.Count();

            if (current_index != 0)
                vm.PrevMaterial = dir.Materials[current_index - 1];

            if (current_index != N - 1)
                vm.NextMaterial = dir.Materials[current_index + 1];

            return vm;
        }

        public MaterialViewModel SaveMaterialToDb(MaterialViewModel vm)
        {
            Material material = null;

            if (vm.Id != 0)
                material = _dataManager.MatRepos.GetMaterialById(vm.Id);
            else
                material = new Material();

            material.Title = vm.Title;
            material.Html = vm.Html;
            material.DirectoryId = vm.DirectoryId;

            _dataManager.MatRepos.SaveMaterial(material);

            return TransitMaterialToView(material.Id);
        }
    
        public MaterialViewModel GetMaterialEditModel(int materialId)
        {
            var dbModel = _dataManager.MatRepos.GetMaterialById(materialId);
            var editModel = new MaterialViewModel()
            {
                Id = dbModel.Id,
                DirectoryId = dbModel.DirectoryId,
                Title = dbModel.Title,
                Html = dbModel.Html
            };
            return editModel;
        }

        public MaterialViewModel CreateNewMaterialEditModel(int directoryId)
        {
            return new MaterialViewModel() { DirectoryId = directoryId };
        }

        public void DeleteMaterialFromDb(int materialId)
        {
            var delMaterial = _dataManager.MatRepos.GetMaterialById(materialId);
            _dataManager.MatRepos.DeleteMaterial(delMaterial);
        }
    }
}
