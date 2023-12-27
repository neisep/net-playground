using System;

namespace DefensiveProgrammingTests.Domain
{
    public class EstateCustomer : Customer
    {
        public EstateCustomer(string name) : base(name)
        {

        }
    }

    //INSTEAD OF ENUM YOU COULD USE A CLASS LIKE ABOW!
    //public enum Privilege
    //{
    //    Administrator,
    //    Moderator,
    //    User,
    //}

    public class Privilege
    {
        private readonly int _privilageNumeric;

        public Privilege(int privilageNumeric)
        {
            _privilageNumeric = privilageNumeric;
        }

        public static Privilege Admin { get; } = new Privilege(3);
        public static Privilege Moderator { get; } = new Privilege(2);
        public static Privilege User { get; } = new Privilege(1);
    }
}