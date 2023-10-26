using System;

namespace Winery.GraphsModels
{
    public class WineryDailySalesModel : IComparable<WineryDailySalesModel>
    {
        private DateTime date;
        private string name;
        private int sales;

        public WineryDailySalesModel(string name, DateTime date, int sales)
        {
            this.name = name;
            this.date = date;
            this.sales = sales;
        }

        public string Name => name;
        public DateTime Date => date;
        public int Sales => sales;

        public int CompareTo(WineryDailySalesModel other)
        {
            return sales.CompareTo(other.sales);
        }
    }
}
