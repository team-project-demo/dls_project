using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Directory : Page
    {
        public List<Material> Materials { get; set; }
    }
}
