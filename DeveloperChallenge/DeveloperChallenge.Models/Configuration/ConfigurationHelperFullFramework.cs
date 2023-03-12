using System.Collections.Specialized;
using System.Configuration;

namespace LP.Shared.Configuration
{
    class ConfigurationHelperFullFramework : IConfigurationHelper
    {
        static ConfigurationHelperFullFramework() { }

        public object GetSection(string sectionName, string propertyName)
        {
            var section = (NameValueCollection) ConfigurationManager.GetSection("appSettings");
            return section[propertyName];
        }
    }
}
