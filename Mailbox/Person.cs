using System;
using System.Diagnostics.CodeAnalysis;

namespace Mailbox
{
    public struct Person : IEquatable<Person>
    {
        public string firstName, lastName;

        public Person(string firstName, string lastName)
        {
            this.firstName = firstName ?? throw new ArgumentException("Name cannot be null");
            this.lastName = lastName ?? throw new ArgumentNullException("Name cannot be null");
        }

        public bool Equals([AllowNull] Person other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            if(ReferenceEquals(this, other))
            {
                return true;
            }

            return firstName == other.firstName &&
            lastName == other.lastName;
        }

        public override string ToString()
        {
            return $"{firstName} {lastName}";
        }
    }
}