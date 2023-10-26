using System.Collections.Generic;

namespace Winery.Models
{
    public class Winery
    {
        public string Name { get; set; }
        public List<Wine> Wines { get; set; } = new List<Wine>();
    }
}
