using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.IO;
using System.Reflection;

namespace AbvBg.Utils
{
    class DriverFactory
    {
        private static IWebDriver _theWebDriver;

        public static IWebDriver GetWebDriver()
        {
            Console.WriteLine("Getting a WebDriver");
            //string driverType = Properties.Settings.Default.driver;
            string driverType = TestConfig.Browser;

            if (_theWebDriver == null)
            {
                Console.WriteLine("There is no existing driver instance, creating new one:");
                switch (driverType.ToLower())
                {
                    case "chrome":
                        _theWebDriver = createChromeDriver();
                        break;
                    case "firefox":
                        _theWebDriver = createFireFoxDriver();
                        break;
                    case "ie":
                        _theWebDriver = createIEDriver();
                        break;
                    case "remote":
                        _theWebDriver = createRemoteDriver();
                        break;
                }
            }

            Console.WriteLine("There is already existing driver instance");
            return _theWebDriver;
        }

        private static IWebDriver createChromeDriver()
        {
            Console.WriteLine("Creating a Chrome driver");
            return new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        private static IWebDriver createFireFoxDriver()
        {
            return new FirefoxDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        private static IWebDriver createIEDriver()
        {
            throw new NotImplementedException();
        }

        private static IWebDriver createRemoteDriver()
        {
            string remoteBrowser = TestConfig.RemoteBrowser;
            string RemoteDriverURL = TestConfig.RemoteDriverHost;

            Console.WriteLine("Creating remote web driver of type " + remoteBrowser);
            Console.WriteLine("Setting remote host: " + RemoteDriverURL);

            switch (remoteBrowser)
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    return new RemoteWebDriver(new Uri(RemoteDriverURL), chromeOptions);
                case "firefox":
                    /// to be continued:  :)
                    break;
                default: throw new NotImplementedException();
            }

            throw new NotImplementedException();
        }
    }
}
