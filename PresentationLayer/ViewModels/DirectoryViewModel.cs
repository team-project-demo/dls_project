using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Entities;

namespace PresentationLayer.ViewModels
{
    public class DirectoryViewModel : PageViewModel
    {
        public Directory Directory { get; set; }
        public List<MaterialViewModel> Materials { get; set; }
    }
}
