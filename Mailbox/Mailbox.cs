using System;

namespace Mailbox
{
    public class MailBox
    {
        public Sizes MailSize { get; set; }
        public ValueTuple<int, int> Location { get; set; }
        public Person Owner { get; set; }

        public MailBox(Sizes size, ValueTuple<int, int> location, Person owner)
        {
            ValidateLocation(location);

            if (size.Equals(Sizes.Premium))
            {
                size = Sizes.Unspecfied;
            }

            MailSize = size;
            Location = location;
            Owner = owner;
        }

        public MailBox(ValueTuple<int, int> location, Person owner)
        {
            ValidateLocation(location);
            Location = location;
            Owner = owner;
        }

        private void ValidateLocation(ValueTuple<int, int> location)
        {
            int x = 30;
            int y = 10;

            if (location.Item1 <= 0 || location.Item2 <= 0 || location.Item1 > 30 || location.Item2 > 10)
            {
                throw new ArgumentException($"The location of the mailbox must be somewhere within a {x}x{y} grid");
            }

        }

        public override string ToString()
        {
            if(MailSize == Sizes.Unspecfied)
            {
                return $"Mailbox Owner: {Owner.ToString()}, Location: x = {Location.Item1}, y = {Location.Item2}";
            }
            else
            {
                return $"Mailbox Owner: {Owner.ToString()}, Location: x = {Location.Item1}, y = {Location.Item2}, BoxSize: {MailSize}";
            }
        }
    }
}
