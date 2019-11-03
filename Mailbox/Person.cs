using System;
using System.Diagnostics.CodeAnalysis;

namespace Mailbox
{
    public struct Person : IEquatable<Person>
    {
        public string FirstName { get; }
        public string LastName { get; }

        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            this.LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        }

        public bool Equals([AllowNull] Person other)
        {
            return FirstName == other.FirstName &&
            LastName == other.LastName;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Person?);
        }

        public override int GetHashCode()
        {
            return (FirstName, LastName).GetHashCode();
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}