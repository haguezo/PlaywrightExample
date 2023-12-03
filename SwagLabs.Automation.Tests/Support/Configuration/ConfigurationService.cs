using Microsoft.Extensions.Configuration;

namespace SwagLabs.Automation.Tests.Support.Configuration
{
    public static class ConfigurationService
    {
        private static readonly IConfigurationRoot _configRoot = InitializeConfiguration();

        private static IConfigurationRoot InitializeConfiguration()
        {
            return new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true).Build();
        }

        public static T Get<T>(ConfigurationItem configurationItem)
        {
            return _configRoot.GetValue<T>(configurationItem.ToString()) ?? throw new InvalidOperationException($"{configurationItem} not found in appsettings.");
        }
    }
}
