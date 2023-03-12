using System.IO;
using Microsoft.Extensions.Configuration;

namespace LP.Shared.Configuration
{
    class DbConfigCore : IDbConfig, IEmailConfig
    {
        private static readonly IConfiguration Configuration;
        static string SQLSERVER;

        static DbConfigCore()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            SQLSERVER = Configuration["SQLServer"];
        }

        public string GetConnection(string name)
        {
            var result = Configuration.GetConnectionString(name);

            result = result.Replace("{SQLServer}", SQLSERVER);

            return result;
        }

        public Email GetEmailSettings()
        {
            var SMTPServer = Configuration["SMTPServer"].ToString();

            return new Email
            {
                SMTPHost = SMTPServer
            };
        }

    }
}