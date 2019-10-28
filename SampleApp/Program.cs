using MockConfiguration;
using System;
using System.Collections.Generic;

namespace SampleApp
{
    internal class Program
    {
        private static void Main()
        {
            MockConfig mockConfig = new MockConfig(true);

            for (int i = 0; i < 4; i++)
            {
                string? valueOut;
                mockConfig.GetConfigValue($"NAME{i + 1}", out valueOut);
                Console.WriteLine($"NAME{i+1} = {valueOut}");
            }
        }
    }
}
