using System;

namespace Mailbox
{
    public class MailBox
    {
        public ValueTuple<int, int> Location { get; set; }
        public Person Owner { get; set; }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
