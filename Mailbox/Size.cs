using System;

namespace Mailbox
{
    [Flags]
    public enum Size
    {
        Unspecfied = 0,
        Small,
        Medium,
        Large,
        Premium
    }
}
