using System;

namespace Mailbox
{
    [Flags]
    internal enum Size
    {
        Unspecfied = 0,
        Small,
        Medium,
        Large,
        Premium
    }
}
