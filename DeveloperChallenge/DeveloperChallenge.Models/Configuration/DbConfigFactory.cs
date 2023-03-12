using System.Runtime.InteropServices;

namespace LP.Shared.Configuration
{
    public class DbConfigFactory
    {
        public static IDbConfig GetDbConfig()
        {
            if (RuntimeInformation.FrameworkDescription.ToLower().Contains(".net core"))
            {
                return new DbConfigCore();
            }

            return new DbConfigFullFramework();
        }

        public static IEmailConfig EmailConfig()
        {
            if (RuntimeInformation.FrameworkDescription.ToLower().Contains(".net core"))
            {
                return new DbConfigCore();
            }

            return new DbConfigFullFramework();
        }

    }
}