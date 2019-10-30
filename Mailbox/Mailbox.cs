using System;

namespace Mailbox
{
    public class MailBox
    {
        public Size MailSize { get; set; }
        public ValueTuple<int, int> Location { get; set; }
        public Person Owner { get; set; }

        public MailBox(Size size, ValueTuple<int, int> location, Person owner)
        {
            MailSize = size;
            Location = location;
            Owner = owner;
        }

        public override string ToString()
        {
            if(MailSize == Size.Unspecfied)
            {
                return $"{Owner} : {Location}";
            }
            else
            {
                return $"Mailbox Owner: {Owner.ToString()}\nLocation: x = {Location.Item1}, y = {Location.Item2}\nBoxSize: {MailSize}";
            }
        }
    }
}
