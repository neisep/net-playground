using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using PriorityList.Domain;
using PriorityList.Extensions;
using System.Collections;
using System.Linq;

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

            var supplier1 = CreateSupplier("1", "1001", "1001");
            var supplier2 = CreateSupplier("2", "1001", "1002");

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

            Assert.AreEqual("1002", supplier.AccountNumber2);
        }

        [TestMethod]
        public void TestPriority_Return1001()
        {
            var supplier = _list.GetSupplier("1000", "1001", "1001");

            Assert.AreEqual("1001", supplier.AccountNumber2);
        }

        /// <summary>
        /// Just a small test too try out another kind of sorting.
        /// </summary>
        [TestMethod]
        public void TestPriority_Sorting()
        {
            _list.Clear();
            var supplier1 = CreateSupplier("1", "1001", "1001");
            //var supplier2 = CreateSupplier("1", "1001", "1002");
            //var supplier3 = CreateSupplier("1", "1002", "1002");

            _list.Add(supplier1);
            //_list.Add(supplier2);
            //_list.Add(supplier3);

            var supplier = _list.GetSupplier( "1002", "1002", "1002", false).First();

            Assert.AreEqual(supplier1.ContactNumber, supplier.ContactNumber);

        }

        private Supplier CreateSupplier(string orgnumber, string account1, string account2)
        {
            return new Supplier
            {
                ContactNumber = Guid.NewGuid(),
                OrganizationNumber = orgnumber,
                AccountNumber = account1,
                AccountNumber2 = account2
            };
        }
    }
}
