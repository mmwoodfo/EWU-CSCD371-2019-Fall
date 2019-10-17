using System;

namespace Inheritance
{
    public class Raj : Actor
    {
        public bool WomenArePresent { get; set; }

        public Raj(bool womenArePresent)
        {
            WomenArePresent = womenArePresent;
        }

        public string Speak(string say)
        {
            if(WomenArePresent == true)
            {
                return $"Raj : ";
            }
            else
            {
                return $"Raj : {say}";
            }
        }
    }
}
