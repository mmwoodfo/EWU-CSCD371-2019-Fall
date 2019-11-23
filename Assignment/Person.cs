using System;

namespace Assignment
{
    public class Person : IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public IAddress Address { get; set; }

        public Person(string firstName, string lastName, string email, IAddress address)
        {
            if (string.IsNullOrEmpty(firstName))
                throw new ArgumentNullException(nameof(firstName));
            if (string.IsNullOrEmpty(lastName))
                throw new ArgumentNullException(nameof(lastName));
            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException(nameof(email));
            if (address is null)
                throw new ArgumentNullException(nameof(address));

            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = address;
        }
    }
}
