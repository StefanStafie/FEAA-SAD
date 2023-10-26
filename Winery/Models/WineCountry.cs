using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winery.Models
{
    public class WineCountry
    {
        public string Name { get; set; }
        public List<Winery> Wineries { get; set; } = new List<Winery>();
    }
}
