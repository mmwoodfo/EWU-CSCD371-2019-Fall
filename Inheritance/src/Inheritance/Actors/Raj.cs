using System;

namespace Inheritance
{
    public class Raj : Actor
    {
        private bool WomenArePresent;
        

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
