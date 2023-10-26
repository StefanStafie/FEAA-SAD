using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winery.Models
{
    public class Winery
    {
        public string Name { get; set; }
        public List<Wine> Wines { get; set; } = new List<Wine>();
    }
}
