using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscTests.TestClasses
{
    public class CustomerController
    {
        public List<(string name, string lastname, DateTime renewed)> GetCustomers()
        {
            var customers = new List<(string name, string lastname, DateTime renewed)>
            {
                ("John 1", "Doe 1", DateTime.Now),
                ("John 2", "Doe 2", DateTime.Parse("2024-01-01"))
            };

            return customers;
        }

        public static bool CheckExpireDate(DateTime start, int intervall)
        {
            return (DateTime.Now - start).Days > intervall;
        }
    }
}
