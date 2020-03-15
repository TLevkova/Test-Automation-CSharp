using AbvBg.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AbvBg.Objects
{
    public abstract class BaseObject
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public BaseObject(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));
        }

        public IWebDriver Driver => _driver;
        public WebDriverWait Wait => _wait;

        public virtual string PagePath { get; }
        public string BaseUrl { get; set; } = TestConfig.BaseUrl;
        public string Title => Driver.Title;


        //COMMON METHODS
        public void Navigate()
        {
            Driver.Url = BaseUrl + PagePath;
        }

        public void TypeInto(IWebElement field, string text)
        {
            field.Clear();
            field.SendKeys(text);
        }

        public string GetTextFrom(IWebElement field, string attributeName)
        {
            string text = field.GetAttribute(attributeName);
            return text;
        }

        public bool IsElementClickable(IWebElement element)
        {
            try
            {
#pragma warning disable CS0618 // Type or member is obsolete
                ExpectedConditions.ElementToBeClickable(element);
#pragma warning restore CS0618 // Type or member is obsolete

                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public IWebElement FluentWaitByName(IWebDriver driver, string nameLocator)
        {
            var fluentWait = new DefaultWait<IWebDriver>(_driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(2);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            var searchElement = fluentWait.Until(x => x.FindElement(By.Name(nameLocator)));
            return searchElement;
        }

        public void HandleGdprFrame(IWebDriver driver)
        {
            try
            {
                Thread.Sleep(5000);

                IWebElement frame = driver.FindElement(By.Id("abv-GDPR-frame"));

                bool frameNotDisplayed = frame.GetAttribute("style").Contains("none");

                if (!frameNotDisplayed)
                {
                    driver.SwitchTo().Frame("abv-GDPR-frame").SwitchTo().Frame("cmp-faktor-io");
                    var acceptButton = driver.FindElement(By.Id("acceptAll"));
                    if (IsElementClickable(acceptButton))
                    {
                        acceptButton.Click();
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
            }
        }
    }
}