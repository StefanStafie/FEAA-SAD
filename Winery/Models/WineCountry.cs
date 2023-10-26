using System.Collections.Generic;

namespace Winery.Models
{
    public class WineCountry
    {
        public string Name { get; set; }
        public List<Winery> Wineries { get; set; } = new List<Winery>();
    }
}
