using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winery.GraphsModels
{
    public class ClientExpensesModel
    {
        private string name;
        private string sex;
        private int age;
        private string country;
        private int expenses;

        public ClientExpensesModel(string name,
                                   string sex,
                                   int age,
                                   string country,
                                   int expenses)
        {
            this.name = name;
            this.sex = sex;
            this.age = age;
            this.country = country;
            this.expenses = expenses;
        }
        
        public string Name => name;
        public string Sex => sex;
        public int Age => age; 
        public string Country => country ;
        public int Expenses => expenses ;

        public int CompareTo(ClientExpensesModel other)
        {
            return this.expenses.CompareTo(other.expenses);
        }
    }
}
