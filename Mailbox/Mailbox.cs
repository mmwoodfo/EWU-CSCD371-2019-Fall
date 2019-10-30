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
            Location = location;
            Owner = owner;
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
