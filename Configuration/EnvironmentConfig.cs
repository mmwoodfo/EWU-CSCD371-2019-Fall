using System;
using System.Collections.Generic;

namespace Configuration
{
    public sealed class EnvironmentConfigAsync : IConfig
    {
        private List<string> setNames;

        public EnvironmentConfigAsync()
        {
            setNames = new List<string>();
        }

        public bool GetConfigValue(string name, out string? value)
        {
            value = Environment.GetEnvironmentVariable(name);
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

        ~EnvironmentConfigAsync()
        {
            foreach (string name in setNames)
            {
                Environment.SetEnvironmentVariable(name, null);
            }
        }
    }
}
