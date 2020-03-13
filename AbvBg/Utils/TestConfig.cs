using Microsoft.Extensions.Configuration;

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
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .Build()
                .GetSection("env")
                .GetSection("qa");

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
