using System;
using System.Diagnostics.CodeAnalysis;

namespace Mailbox
{
    public struct Person : IEquatable<Person>
    {
        public string firstName, lastName;

        public Person(string firstName, string lastName)
        {
            if(firstName is null || lastName is null)
            {
                throw new ArgumentNullException("Name cannot be null");
            }
            else
            {
                this.firstName = firstName;
                this.lastName = lastName;
            }
        }

        public bool Equals([AllowNull] Person other)
        {
            if(ReferenceEquals(other, null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override string ToString()
        {
            return $"{firstName} {lastName}";
        }
    }
}