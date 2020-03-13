using AbvBg.Objects;
using TechTalk.SpecFlow;

namespace AbvBg.Tests.SendNewMessage
{
    [Binding]
    class SendNewMessage_Steps : BaseTest
    {
        static HomePage homePage;
        static MailboxPage mailboxPage;

        [BeforeFeature]
        public static void BeforeFeature()
        {
            homePage = new HomePage(driver);
            mailboxPage = null;
        }

        [AfterScenario]
        public static void AfterScenarioBlock()
        {
            driver.Manage().Cookies.DeleteAllCookies();
        }

        [Given(@"I am logged in and on the mailbox page")]
        public void GivenIAmLoggedInAndOnTheMailboxPage()
        {
            mailboxPage = homePage.NavigateAndLogin();
        }

        [When(@"I click on New Message button")]
        public void WhenIClickOnNewMessageButton()
        {
            mailboxPage.ClickOnNewMessageButton();
        }

        [When(@"write '(.*)' in the message box")]
        public void WriteNewMessage(string newMessage)
        {
            mailboxPage.WriteNewMessage(newMessage);
        }

        [When(@"fill receiver '(.*)', subject '(.*)' and click on Send button")]
        public void SendMessage(string receiver, string subject)
        {
            mailboxPage.SendMessage(receiver, subject);
        }

        [Then(@"I should see a confirmation message for successfully sent email")]
        public void ThenIShouldSeeAConfirmationMessageForSuccessfullySentEmail()
        {
            mailboxPage.ConfirmationMessageForSentEmail_Assertion();
        }
    }
}
