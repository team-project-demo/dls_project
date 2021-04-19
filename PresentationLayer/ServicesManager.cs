using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer;
using PresentationLayer.Services;

namespace PresentationLayer
{
    public class ServicesManager
    {
        private DirectoriesService _dirService;
        private MaterialsService _matService;
        private DataManager _dm;

        public ServicesManager(DataManager dm)
        {
            _dm = dm;
            _dirService = new DirectoriesService(_dm);
            _matService = new MaterialsService(_dm);
        }

        public DirectoriesService DirService { get { return _dirService; } }
        public MaterialsService MatService { get { return _matService; } }
    }
}
