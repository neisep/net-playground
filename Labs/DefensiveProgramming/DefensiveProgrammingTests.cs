//ONLY FOR TRAINING PURPOSE DO NOT FOLLOW OR USE IN ANY KIND
//LOL LIKE ANYONE WOULD EVER READ THIS LMAO

//Guarding code should be avoided i guess.
//defense by design steer the operation so that it never gets stuck
using System;
using System.Diagnostics;
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

    public class Customer
    {
        public string Name { get; }

        public Customer(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException();

            this.Name = name;
        }
    }
}
