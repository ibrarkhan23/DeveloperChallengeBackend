using System.Runtime.InteropServices;

namespace LP.Shared.Configuration
{
    public class ConfigurationHelper
    {
        public static IConfigurationHelper GetConfiguration()
        {
            if (RuntimeInformation.FrameworkDescription.ToLower().Contains(".net core"))
            {
                return new ConfigurationHelperCore();
            }

            return new ConfigurationHelperFullFramework();
        }
    }
}
