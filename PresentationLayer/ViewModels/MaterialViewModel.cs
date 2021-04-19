using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Entities;

namespace PresentationLayer.ViewModels
{
    public class MaterialViewModel : PageViewModel
    {
        public Material Material { get; set; }
        public Material NextMaterial { get; set; }
        public Material PrevMaterial { get; set; }
        public int DirectoryId { get; set; }        
    }
}
