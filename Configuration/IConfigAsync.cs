using System.Threading.Tasks;

namespace Configuration
{
    public interface IConfigAsync
    {
        public Task<bool> GetConfigValue(string name, out string? value);

        public Task<bool> SetConfigValue(string name, string? value);
    }
}
