using Configuration;
using System;
using System.Collections.Generic;

namespace MockConfig
{
    public class MockConfig : IConfig
    {

        private List<Tuple<string, string?>> configList;

        public MockConfig(bool createTestList)
        {
            configList = new List<Tuple<string, string?>>();

            if (createTestList)
            {
                configList.Add(new Tuple<string, string?>("NAME1", "VALUE1"));
                configList.Add(new Tuple<string, string?>("NAME2", "VALUE2"));
                configList.Add(new Tuple<string, string?>("NAME3", "VALUE3"));
                configList.Add(new Tuple<string, string?>("NAME4", "VALUE4"));
            }
        }

        public bool GetConfigValue(string name, out string? value)
        {
            foreach (Tuple<string, string?> item in configList)
            {
                if (item.Item1.Contains(name))
                {
                    value = item.Item2;
                    return true;
                }
            }

            value = null;
            return false;
        }

        public bool SetConfigValue(string name, string? value)
        {
            if (ValidateNameAndValue(name, value))
            {
                Tuple<string, string?> configItem = new Tuple<string, string?>(name, value);
                configList.Add(configItem);
                return true;
            }
            else
            {
                return false;
            }
        }

#pragma warning disable CA1822 // Mark members as static
        public bool ValidateNameAndValue(string name, string? value)
#pragma warning restore CA1822 // Mark members as static
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"{nameof(name)} should not be null or empty");
            }
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException($"{nameof(value)} should not be null or empty");
            }
            if (name.Contains(' ') || name.Contains('='))
            {
                throw new ArgumentException($"{nameof(name)} is invalid formatting = and whitespace is not allowed");
            }
            if (value.Contains(' ') || value.Contains('='))
            {
                throw new ArgumentException($"{nameof(value)} is invalid formatting = and whitespace is not allowed");
            }
            return true;
        }
    }
}
