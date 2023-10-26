using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winery.Models
{
    public class Wine
    {
        public string Name { get; set; }
        public string Variety { get; set; }
        public string Winery { get; set; }
        public int Price { get; set; }
        public string CountryName { get; set; }
    }
}
