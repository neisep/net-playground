using System;

namespace DefensiveProgrammingTests.Domain
{
    public class EstateCustomer : Customer
    {
        private Privilege _privilege;

        public EstateCustomer(string name, Privilege privilege) : base(name)
        {
            _privilege = privilege;
        }

        public Privilege GetCurrentPrivilege()
        {
            return _privilege;
        }
    }


    ///<summary>
    /// Encapsuleted code makes it abit easier to prevent wrong data into your code or even worse errors in database layer, This makes it also abit better to prevent control of data, lets say you had 3 integer values
    /// You would then need to control if the input is 1 or 2 or 3 but in our case we make uses of the entire class that has everything for us pretty neat and pretty usefull depending on the architecuture of the code itself.
    /// </summary>
    public class Privilege
    {
        private readonly int _userLevel;

        public Privilege(int userLevel)
        {
            _userLevel = userLevel;
        }

        public int GetUserLevel()
        {
            return _userLevel;
        }

        public static Privilege Admin { get; } = new Privilege(3);
        public static Privilege Moderator { get; } = new Privilege(2);
        public static Privilege User { get; } = new Privilege(1);
    }
}