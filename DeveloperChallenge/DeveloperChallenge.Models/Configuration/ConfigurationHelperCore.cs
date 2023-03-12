using Microsoft.Extensions.Configuration;
using System.IO;

namespace LP.Shared.Configuration
{
    class ConfigurationHelperCore : IConfigurationHelper
    {
        private static readonly IConfiguration Configuration;

        static ConfigurationHelperCore()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }

        public object GetSection(string sectionName, string propertyName)
        {
            return Configuration.GetSection(sectionName)[propertyName];
        }
    }
}
