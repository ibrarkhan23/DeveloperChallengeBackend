using System.Configuration;

namespace LP.Shared.Configuration
{
    class DbConfigFullFramework : IDbConfig, IEmailConfig
    {
        static readonly string SQLSERVER;

        static DbConfigFullFramework()
        {
            SQLSERVER = ConfigurationManager.AppSettings["SQLServer"];
        }

        public string GetConnection(string name)
        {
            var result = ConfigurationManager.ConnectionStrings[name].ToString();

            result = result.Replace("{SQLServer}", SQLSERVER);

            return result;
        }

        public Email GetEmailSettings()
        {
            var SMTPServer = ConfigurationManager.AppSettings["SMTPServer"].ToString();

            return new Email
            {
                SMTPHost = SMTPServer
            };
        }
    }
}