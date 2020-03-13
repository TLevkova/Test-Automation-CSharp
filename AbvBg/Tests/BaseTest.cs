using AbvBg.Utils;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace AbvBg.Tests
{
    [Binding]
    public abstract class BaseTest
    {
        public static IWebDriver driver = DriverFactory.GetWebDriver();

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            BrowserManage(5, 5);
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            driver.Quit();
        }

        public static void BrowserManage(int pageLoadInSec, int implicitWaitInSec)
        {
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(pageLoadInSec);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWaitInSec);
        }
    }
}
