using System;
using System.Collections.Generic;

namespace Configuration
{
    public sealed class EnvironmentConfig : IConfig
    {
        private List<string> setNames;

        public EnvironmentConfig()
        {
            setNames = new List<string>();
        }

        public bool GetConfigValue(string name, out string? value)
        {
            value = Environment.GetEnvironmentVariable(name);

            // MMM Comment: Why not just return "(value is object)" (or !(value is null)).
            if (value is null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool SetConfigValue(string name, string? value)
        {
            if (value is null)
            {
                return false;
            }
            else
            {
                setNames.Add(name);
                Environment.SetEnvironmentVariable(name, value);
                return true;
            }
        }


        // MMM Comment: This needs to also implement IDisposable
        ~EnvironmentConfig()
        {
            foreach (string name in setNames)
            {
                Environment.SetEnvironmentVariable(name, null);
            }
        }
    }
}
