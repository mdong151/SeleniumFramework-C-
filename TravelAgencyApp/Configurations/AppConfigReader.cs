using System;
using System.Configuration;
using TravelAgencyApp.Settings;

namespace TravelAgencyApp.Configurations
{
    public class AppConfigReader
    {
        public static BrowserTypes GetBrowser()
        {
            string browser = ConfigurationManager.AppSettings.Get(AppConfigKeys.Browser);
            return (BrowserTypes)Enum.Parse(typeof(BrowserTypes), browser);
        }

        public static TestEnvironmentTypes GetTestEnvironment()
        {
            string testEnv = ConfigurationManager.AppSettings.Get(AppConfigKeys.TestEnvironment);
            return (TestEnvironmentTypes)Enum.Parse(typeof(TestEnvironmentTypes), testEnv);
        }

        public static string GetUsername()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.Username);
        }

        public static string GetPassword()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.Password);
        }

        public static int GetTimeout()
        {
            string value = ConfigurationManager.AppSettings.Get(AppConfigKeys.Timeout);
            return int.Parse(value);
        }
    }
}
