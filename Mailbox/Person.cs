using System;
using System.Diagnostics.CodeAnalysis;

namespace Mailbox
{
    public struct Person : IEquatable<Person>
    {
        private string _FirstName, _LastName;

        public Person(string firstName, string lastName)
        {
            this._FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            this._LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        }

        public bool Equals([AllowNull] Person other)
        {
            return _FirstName == other._FirstName &&
            _LastName == other._LastName;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Person?);
        }

        public override int GetHashCode()
        {
            return (_FirstName, _LastName).GetHashCode();
        }

        public override string ToString()
        {
            return $"{_FirstName} {_LastName}";
        }
    }
}