using AbvBg.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;
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
            var env = TestContext.Parameters.Get<String>("env", "no-env");

            BrowserManage(5, 5);
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            TakeScreenshootIfTestStepFails();
            driver.Manage().Cookies.DeleteAllCookies();
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

        //Take screen-shot if any test fails
        private static void TakeScreenshootIfTestStepFails()
        {

#pragma warning disable CS0618 // Type or member is obsolete
            if (ScenarioContext.Current.TestError == null)
#pragma warning restore CS0618 // Type or member is obsolete
            {
                return;
            }

            var screenshoot = ((ITakesScreenshot)driver).GetScreenshot();
            string path = Path.GetFullPath(@"..\..\..\Screenshots\");
            string testName = TestContext.CurrentContext.Test.Name.Replace(' ', '_');
            string testRuntime = DateTime.Now.ToString("dd-MM-yyyy_THHmmss");

            try
            {
                if (!File.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                screenshoot.SaveAsFile(path + $"{testName}_{testRuntime}.png", ScreenshotImageFormat.Png);
            }
            catch
            {
                throw new DirectoryNotFoundException();
            }

        }
    }
}
