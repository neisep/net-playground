//ONLY FOR TRAINING PURPOSE DO NOT FOLLOW OR USE IN ANY KIND
//LOL LIKE ANYONE WOULD EVER READ THIS LMAO

//Guarding code should be avoided i guess.
//defense by design steer the operation so that it never gets stuck
//this is only for testing for my own there is no assert because i only test run the code no assert is needed in my case, for this purpose atleast not right now.
//No property setter, no need to defense
using System;
using System.Collections.Generic;
using System.Diagnostics;
using DefensiveProgrammingTests.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DefensiveProgrammingTests
{
    [TestClass]
    public class DefensiveProgrammingTests
    {
        [TestMethod]
        public void DefensiveProgramming_GoodWay()
        {
            var good = new LicenseGoodExample();
            var entity = new RenewLicense(DateTime.Now);

            good.RenewLicense(entity);
        }

        [TestMethod]
        public void DefensiveProgramming_BadWay()
        {
            var bad = new LicenseBadExample();
            bad.RenewLicense(DateTime.Now);

            List<string> test = new List<string>
            {
                "",
                "",
            };
        }

        /// <summary>
        /// This test is testing that the validation is working properly by not setting any data to the object.
        /// </summary>
        [TestMethod]
        public void DefensiveProgramming_BuildCustomer_fail()
        {
            var customerBuilder = new CustomerBuilder();

            Assert.IsFalse(customerBuilder.IsValid());
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void DefensiveProgramming_BuildCustomer_NameInitial_NullReferenceException_fail()
        {
            var customerBuilder = new CustomerBuilder();
            var nameIntial = customerBuilder.NameInitial;
        }

        /// <summary>
        /// Crap code when we done this weird thing i think it is most common, but pretty bad.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void DefensiveProgramming_BuildCustomer_NameInitial_IndexOutOfRangeException_fail()
        {
            var customerBuilder = new CustomerBuilder();
            customerBuilder.Name = "";
            var dummy = customerBuilder.NameInitial;
        }

        /// <summary>
        /// This validate the state of the object and makes sure the data is valid.
        /// </summary>
        [TestMethod]
        public void DefensiveProgramming_BuildCustomer_success()
        {
            var dummy = new CustomerBuilder();
            dummy.Name = "ThisIsAValidNameIThink";
            dummy.StreetAdress = "ThisIsAnAdressThatIsNotValid";

            Assert.IsTrue(dummy.IsValid());
        }

        [TestMethod]
        public void DefensiveProgramming_EstateCustomer_OK()
        {
            var dummy = new EstateCustomer("Jimmie");

            Assert.IsFalse(dummy.Id == Guid.Empty);
            Assert.AreEqual("Jimmie", dummy.Name);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DefensiveProgramming_EstateCustomer_Fail()
        {
            var dummy = new EstateCustomer("");
        }

        [TestMethod]
        public void DefensiveProgramming_EstateCustomer_NotSureWhatThisTestDo()
        {

        }
    }

    #region WorseExample

    public class LicenseBadExample
    {
        private DateTime licenseStartDate => DateTime.Now.AddYears(-2); //2021-?-?
        public void RenewLicense(DateTime renewDateTime)
        {
            if (renewDateTime == DateTime.MinValue)
                throw new Exception("wrong date");

            if (renewDateTime == DateTime.MaxValue)
                throw new Exception("wrong date");

            Trace.WriteLine("License renewed");
        }
    }

    #endregion


    #region BetterExample

    public class RenewLicense
    {
        private DateTime _renewDateTime;
        public RenewLicense(DateTime renewDateTime)
        {
            if (renewDateTime == DateTime.MinValue)
                throw new Exception("to low");

            if (renewDateTime == DateTime.MaxValue)
                throw new Exception("to high");

            _renewDateTime = renewDateTime;
        }
    }
    public class LicenseGoodExample
    {
        private DateTime licenseStartDate => DateTime.Now.AddYears(-2); //2021-?-?
        public void RenewLicense(RenewLicense renewLicense)
        {
            Trace.WriteLine("License renewed");
        }
    }

    #endregion
}
