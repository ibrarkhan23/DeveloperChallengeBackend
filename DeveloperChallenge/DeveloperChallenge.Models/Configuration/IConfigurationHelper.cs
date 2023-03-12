namespace LP.Shared.Configuration
{
    public interface IConfigurationHelper
    {
        object GetSection(string sectionName, string propertyName);
    }
}
