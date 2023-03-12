namespace LP.Shared.Configuration
{
    public interface IDbConfig
    {
        string GetConnection(string name);
    }

    public class Email
    {
        public string SMTPHost { get; set; }
    }

    public interface IEmailConfig
    {
        Email GetEmailSettings();
    }

}