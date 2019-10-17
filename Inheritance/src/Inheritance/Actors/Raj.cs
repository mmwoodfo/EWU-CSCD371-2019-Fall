using System;

namespace Inheritance
{
    public class Raj : Actor
    {
        private bool WomenArePresent;
        public string _Say;
        public string Say
        {
            get
            {
                AreThereWoman();
                return _Say;
            }
            set
            {
                _Say = value;
            }
        }
        

        public Raj(bool womenArePresent)
        {
            WomenArePresent = womenArePresent;
        }

        public void AreThereWoman()
        {
            if(WomenArePresent == true)
            {
                _Say = "";
            }
        }
    }
}
