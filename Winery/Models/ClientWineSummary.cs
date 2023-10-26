using System;

namespace Winery.Models
{
    public class ClientWineSummary : IComparable<ClientWineSummary>
    {
        public int Age { get; set; }
        public string Variety { get; set; }
        public int Quantity { get; set; }

        public int CompareTo(ClientWineSummary other)
        {
            return Quantity.CompareTo(other.Quantity);
        }
    }
}
