using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Configuration
{
    public class AsyncEnvironmentConfig : IConfigAsync
    {
        private System.Collections.Generic.List<string> setNames;

        public AsyncEnvironmentConfig()
        {
            setNames = new List<string>();
        }

        public Task<bool> GetConfigValue(string name, out string? value)
        {
            value = Environment.GetEnvironmentVariable(name);
            if (value is null)
            {
                return Task.FromResult<bool>(false);
            }
            else
            {
                return Task.FromResult<bool>(true);
            }
        }

        public Task<bool> SetConfigValue(string name, string? value)
        {
            if (value is null)
            {
                return Task.FromResult<bool>(false);
            }
            else
            {
                setNames.Add(name);
                Environment.SetEnvironmentVariable(name, value);
                return Task.FromResult<bool>(true);
            }
        }

        ~AsyncEnvironmentConfig()
        {
            foreach (string name in setNames)
            {
                Environment.SetEnvironmentVariable(name, null);
            }
        }
    }
}
