using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiscTests.codeToTest;
using MiscTests.TestClasses;
using System;
using System.Linq;

namespace MiscTests
{
    //Miscellaneous tests just a placeholder for tests that makes no sense anywhere else
    [TestClass]
    public class MiscTests
    {
        private ValueInBetween _valueInBetween;

        [TestInitialize]
        public void TestInit()
        {
            _valueInBetween = new ValueInBetween(10, 100);
        }

        //This test will try to validate number if it is between 10 and 100 or 200
        [TestMethod]
        public void Linq_Validate_Number_InBetween10_100_or_just_200_return_valid()
        {
            var isRangeValid = _valueInBetween.ValidateWithLinq(29);
            Assert.IsTrue(isRangeValid);

            isRangeValid = _valueInBetween.ValidateWithLinq(10);
            Assert.IsTrue(isRangeValid);

            isRangeValid = _valueInBetween.ValidateWithLinq(200);
            Assert.IsTrue(isRangeValid);
        }

        [TestMethod]
        public void NotLinq_Validate_Number_InBetween10_100_or_just_200_return_valid()
        {
            var isRangeValid = _valueInBetween.ValidateWithouthLinq(29);
            Assert.IsTrue(isRangeValid);

            isRangeValid = _valueInBetween.ValidateWithouthLinq(10);
            Assert.IsTrue(isRangeValid);

            isRangeValid = _valueInBetween.ValidateWithouthLinq(200);
            Assert.IsTrue(isRangeValid);
        }

        [TestMethod]
        public void CustomClass_Validate_Number_InBetween10_100_or_just_200_return_valid()
        {
            var isRangeValid = _valueInBetween.ValidateWithCustomClass(29);
            Assert.IsTrue(isRangeValid);

            isRangeValid = _valueInBetween.ValidateWithCustomClass(10);
            Assert.IsTrue(isRangeValid);

            isRangeValid = _valueInBetween.ValidateWithCustomClass(200);
            Assert.IsTrue(isRangeValid);
        }

        [TestMethod]
        public void Linq_Validate_Number_InBetween10_100_or_just_200_return_Invalid()
        {
            var isRangeValid = _valueInBetween.ValidateWithLinq(101);
            Assert.IsFalse(isRangeValid);

            isRangeValid = _valueInBetween.ValidateWithLinq(9);
            Assert.IsFalse(isRangeValid);

            isRangeValid = _valueInBetween.ValidateWithLinq(201);
            Assert.IsFalse(isRangeValid);
        }

        [TestMethod]
        public void NotLinq_Validate_Number_InBetween10_100_or_just_200_return_Invalid()
        {
            var isRangeValid = _valueInBetween.ValidateWithouthLinq(101);
            Assert.IsFalse(isRangeValid);

            isRangeValid = _valueInBetween.ValidateWithouthLinq(9);
            Assert.IsFalse(isRangeValid);

            isRangeValid = _valueInBetween.ValidateWithouthLinq(201);
            Assert.IsFalse(isRangeValid);
        }

        [TestMethod]
        public void CustomClass_Validate_Number_InBetween10_100_or_just_200_return_Invalid()
        {
            var isRangeValid = _valueInBetween.ValidateWithCustomClass(101);
            Assert.IsFalse(isRangeValid);

            isRangeValid = _valueInBetween.ValidateWithCustomClass(9);
            Assert.IsFalse(isRangeValid);

            isRangeValid = _valueInBetween.ValidateWithCustomClass(201);
            Assert.IsFalse(isRangeValid);
        }



        /// <summary>
        /// Simple test how to use StringJoin could be useful if you make SQL queries for example.
        /// </summary>
        [TestMethod]
        public void ExampleOfStringJoin()
        {
            var exampleData = new[] { "FirstName", "Cellphone", "Adress" };
            var joinString = string.Join(",", exampleData);

            Assert.AreEqual("FirstName,Cellphone,Adress", joinString);
        }

        [TestMethod]
        public void Customer_Return_As_Tuple()
        {
            var customerController = new CustomerController();
            var customers = customerController.GetCustomers();

            Assert.AreEqual("John 1", customers[0].name);
            Assert.AreEqual("John 2", customers[1].name);
            Assert.AreEqual("Doe 1", customers[0].lastname);
            Assert.AreEqual("Doe 2", customers[1].lastname);
        }

        //Example code to check expiration date in .net
        [TestMethod]
        public void Customer_Membership_Expire()
        {
            //Has date passed 30 days?
            Assert.AreEqual(true, CustomerController.CheckExpireDate(DateTime.Now.AddDays(-31), 30));

            //Has date passed 30 days
            Assert.AreEqual(false, CustomerController.CheckExpireDate(DateTime.Now.AddDays(-30), 30));
        }

        [TestMethod]
        public void StopUsingMultipleStringReplace()
        {
            var message = "This is an example string, we use + and ? they should be removed";
            var santizedMessage = Replace(message);
        }

        public string Replace(string inputValue)
        {
            char[] disallowedCharacters = { '+', '$', '\\', '?' };
            return new string(inputValue.Where(x => !disallowedCharacters.Contains(x)).ToArray());
        }
    }
}
