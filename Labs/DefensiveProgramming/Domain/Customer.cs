using System;

namespace DefensiveProgrammingTests.Domain
{
    public class Customer
    {
        public Guid Id { get; }
        public string Name { get; }

        public Customer(string name)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;

            if (!IsValid())
                throw new ArgumentException("Can't be used, something is not set.");
        }

        //Could contain defensive rules.
        public bool IsValid()
        {
            if (string.IsNullOrEmpty(this.Name))
                return false;

            return true;
        }
    }
}