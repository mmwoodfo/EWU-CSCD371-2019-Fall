using System;

namespace Mailbox
{
    public class MailBox
    {
        public Sizes MailSize { get; }
        public (int X, int Y) Location { get; }
        public Person Owner { get; }

        public MailBox(Sizes size, ValueTuple<int, int> location, Person owner)
        {
            if (size.Equals(Sizes.Premium))
            {
                throw new ArgumentException("Mailbox size must be set as a premium size, not just as premium");
            }

            MailSize = size;
            Location = location;
            Owner = owner;
        }

        public override string ToString()
        {
            string mailboxString = $"Mailbox Owner: {Owner.ToString()}, Location: x = {Location.Item1}, y = {Location.Item2}";
            if (MailSize == Sizes.Unspecfied)
            {
                return mailboxString;
            }
            else
            {
                return mailboxString+$", BoxSize: {MailSize}";
            }
        }
    }
}
