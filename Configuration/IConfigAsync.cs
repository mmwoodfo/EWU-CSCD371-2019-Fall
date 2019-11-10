using System.Threading.Tasks;

namespace Configuration
{
    // MMM Comment: This is the correct declaration.  Great job!!
    public interface IConfigAsync
    {
        public Task<bool> GetConfigValue(string name, out string? value);

        public Task<bool> SetConfigValue(string name, string? value);
    }
}
