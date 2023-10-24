using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Winery.DataSet2TableAdapters;

namespace Winery.Data
{

    internal class Wines
    {
        private static DataSet2.WINESDataTable data = null;
        public Wines()
        {
            WINESTableAdapter adapter = new WINESTableAdapter();
            DataSet2.WINESDataTable data = adapter.GetData();
            foreach (var x in data)
            {
                Console.WriteLine(x);
            }
        }

        public static DataSet2.WINESDataTable getWines()
        {
            if(data != null)
            {
                return data;
            }

            return new WINESTableAdapter().GetData();
        }
    }
}
