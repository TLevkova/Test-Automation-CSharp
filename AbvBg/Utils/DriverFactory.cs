using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.IO;
using System.Reflection;
using NLog;

namespace AbvBg.Utils
{
    class DriverFactory
    {
        private static IWebDriver _webDriver;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static IWebDriver GetWebDriver()
        {
            logger.Info("Getting a WebDriver");
            string driverType = TestConfig.Browser;

            if (_webDriver == null)
            {
                logger.Info("There is no existing driver instance, creating new one:");
                switch (driverType.ToLower())
                {
                    case "chrome":
                        _webDriver = createChromeDriver();
                        break;
                    case "firefox":
                        _webDriver = createFireFoxDriver();
                        break;
                    case "ie":
                        _webDriver = createIEDriver();
                        break;
                    case "remote":
                        _webDriver = createRemoteDriver();
                        break;
                    default:
                        throw new ArgumentNullException("WebDriver is not set");
                }
            }

            logger.Info($"There is already existing driver instance: {_webDriver}");
            return _webDriver;
        }

        private static IWebDriver createChromeDriver()
        {
            logger.Info("Creating a Chrome driver");
            return new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        private static IWebDriver createFireFoxDriver()
        {
            logger.Info("Creating a Firefox driver");
            return new FirefoxDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        private static IWebDriver createIEDriver()
        {
            logger.Info("Creating an Internet Explorer driver");
            return new InternetExplorerDriver(Assembly.GetExecutingAssembly().Location);
        }

        private static IWebDriver createRemoteDriver()
        {
            string remoteBrowser = TestConfig.RemoteBrowser;
            string remoteDriverURL = TestConfig.RemoteDriverHost;

            logger.Info($"Creating a remote web driver of type {remoteBrowser}");
            logger.Info($"Setting remote host: {remoteDriverURL}");

            switch (remoteBrowser)
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    return new RemoteWebDriver(new Uri(remoteDriverURL), chromeOptions);
                case "firefox":
                    var firefoxOptions = new FirefoxOptions();
                    return new RemoteWebDriver(new Uri(remoteDriverURL), firefoxOptions);
                case "ie":
                    var internetExplorerOptions = new InternetExplorerOptions();
                    return new RemoteWebDriver(new Uri(remoteDriverURL), internetExplorerOptions);
                default:
                    throw new ArgumentNullException("Remote WebDriver is not set");
            }
        }
    }
}
