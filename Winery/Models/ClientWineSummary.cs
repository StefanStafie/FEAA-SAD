using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winery.Models
{
    public class ClientWineSummary : IComparable<ClientWineSummary>
    {
        public int Age { get; set; }
        public string Variety { get; set; }
        public int Quantity { get; set; }

        public int CompareTo(ClientWineSummary other)
        {
            return this.Quantity.CompareTo(other.Quantity);
        }
    }
}
