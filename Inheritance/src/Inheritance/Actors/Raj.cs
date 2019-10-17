using System;

namespace Inheritance
{
    public class Raj : Actor
    {
        public bool WomenArePresent { get; set; }
        public string Says { get; set; }

        public Raj(bool womenArePresent)
        {
            WomenArePresent = womenArePresent;
        }
    }
}
