using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Configuration
{
    // MMM Comment: I love the fact that you attempted this.  Great job!  
    // The usage isn't quite right but that is mostly becuse Evironment 
    // doesn't make for a good Async API.  The better choice would have been File.
    // Also, why not put these methods on EnvironmentConfig rather than an entirely
    // new class?
    public class AsyncEnvironmentConfig : IConfigAsync
    {
        /// MMM Comment: Should be _SetNames (or _setNames)
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
