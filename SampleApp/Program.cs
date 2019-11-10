using MockConfiguration;
using System;

namespace SampleApp
{
    // MMM Comment: Program is never tested?  :(
    internal class Program
    {
        private static void Main()
        {
            MockConfig mockConfig = new MockConfig(true);

            for (int i = 0; i < 4; i++)
            {
                string? valueOut;
                mockConfig.GetConfigValue($"NAME{i + 1}", out valueOut);
                Console.WriteLine($"NAME{i + 1} = {valueOut}");
            }
        }
    }
}
