using System;

namespace Mailbox
{
    [Flags]
    public enum Sizes
    {
        Unspecfied = 0b_0000,
        Small = 0b_0001,
        Medium = 0b_0010,
        Large = 0b_0011,
        Premium = 0b_0100,

        PremiumSmall = Small | Premium,
        PremiumMedium = Medium | Premium,
        PremiumLarge = Large | Premium
    }
}
