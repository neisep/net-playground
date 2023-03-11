using Microsoft.VisualStudio.TestTools.UnitTesting;
using PriorityList.Domain;
using PriorityList.Extensions;
using System.Collections.Generic;

namespace PriorityList
{
    [TestClass]
    public class PriorityTest
    {
        private List<Supplier> _list;

        [TestInitialize]
        public void Initialize()
        {
            _list = new List<Supplier>();

            var supplier1 = CreateSupplier(1, "1001", "1001");
            var supplier2 = CreateSupplier(2, "1001", "1002");

            _list.Add(supplier1);
            _list.Add(supplier2);
        }

        /// <summary>
        /// This Test was written to try out a theory i had in my head for sometime.
        /// The problem is i have got multiple suppliers when i search for example 1001 i get two records but one of them are unique but depends on different properties
        /// Look here
        /// Supplier1 got number 1 and Account1 is 1001 and Account2 is 1001
        /// Supplier2 got number 1 and Account1 is 1001 and Account2 is 1002
        /// Now you see we have a unique records thanks too the properties.
        /// </summary>
        [TestMethod]
        public void TestPriority_Return1002()
        {
            var supplier = _list.GetSupplier("1000", "1001", "1002");

            Assert.AreEqual("1002", supplier.Account2);
        }

        [TestMethod]
        public void TestPriority_Return1001()
        {
            var supplier = _list.GetSupplier("1000", "1001", "1001");

            Assert.AreEqual("1001", supplier.Account2);
        }

        private Supplier CreateSupplier(int globalIdentification, string account1, string account2)
        {
            return new Supplier
            {
                Number = "1000",
                GlobalIdentification = globalIdentification,
                Account1 = account1,
                Account2 = account2
            };
        }
    }
}
