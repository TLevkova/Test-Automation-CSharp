using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace AbvBg.Utils
{
    class TestConfig
    {

        private static IConfiguration _config = InitConfiguration();

        private TestConfig()
        {
        }

        public static IConfiguration InitConfiguration()
        {
            string appSettings = TestContext.Parameters.Get("appSettings", "appsettings.test.json");
            string param = TestContext.Parameters.Get<string>("env", "qa");

            var config = new ConfigurationBuilder()
                .AddJsonFile(appSettings)
                .Build()
                .GetSection("env")
                .GetSection(param);
            
            return config;
        }

        public static string BaseUrl
        {
            get => _config["baseUrl"];
        }

        public static string Browser
        {
            get => _config["browser"];
        }

        public static string RemoteBrowser
        {
            get => _config["remoteBrowser"];
        }

        public static string RemoteDriverHost
        {
            get => _config["remoteDriverHost"];
        }

        public static string LoginUsername
        {
            get => _config["loginUsername"];
        }

        public static string LoginPassword
        {
            get => _config["loginPassword"];
        }
    }
}
