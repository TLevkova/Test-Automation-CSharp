using OpenQA.Selenium;

namespace AbvBg.Objects
{
    partial class HomePage : BaseObject
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public override string PagePath => "";

        //ELEMENTS
        private IWebElement Username => Driver.FindElement(By.Name("username"));
        private IWebElement Password => Driver.FindElement(By.Name("password"));
        private IWebElement LoginButton => Driver.FindElement(By.Name("loginBut"));
        private IWebElement LoginErrorMessage => Driver.FindElement(By.Id("form.errors"));
    }
}