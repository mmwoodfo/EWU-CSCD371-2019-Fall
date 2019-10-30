using System;
using System.Diagnostics.CodeAnalysis;

namespace Mailbox
{
    public struct Person : IEquatable<Person>
    {
        public string firstName, lastName;

        public bool Equals([AllowNull] Person other)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{firstName} {lastName}";
        }
    }
}