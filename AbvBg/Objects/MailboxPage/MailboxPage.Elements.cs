using OpenQA.Selenium;

namespace AbvBg.Objects
{
    partial class MailboxPage : BaseObject
    {
        public MailboxPage(IWebDriver driver) : base(driver)
        {
        }

        //ELEMENTS
        private IWebElement UserGreeting => Driver.FindElement(By.ClassName("userName"));
        private IWebElement NewMessageButton => Driver.FindElement(By.ClassName("abv-button"));
        private IWebElement TextArea => Driver.FindElement(By.ClassName("gwt-RichTextArea"));
        private IWebElement ReceiverField => Driver.FindElement(By.CssSelector("tr:nth-child(2) td.clientField div input"));
        private IWebElement SubjectField => Driver.FindElement(By.ClassName("gwt-TextBox"));
        private IWebElement SendMessageButton => Driver.FindElement(By.CssSelector(".sendMenuContent .abv-button"));
        private string ConfirmationMessage => Driver.FindElement(By.CssSelector("#middlePagePanel > :first-child .abv-h2")).Text;

    }
}
