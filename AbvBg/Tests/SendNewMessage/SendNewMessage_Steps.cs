using AbvBg.Objects;
using TechTalk.SpecFlow;

namespace AbvBg.Tests.SendNewMessage
{
    [Binding]
    class SendNewMessage_Steps : BaseTest
    {
        static HomePage homePage;
        static MailboxPage mailboxPage;

        [Scope(Tag = "sendNewMessage")]
        [BeforeFeature]
        public static void BeforeFeature()
        {
            homePage = new HomePage(driver);
            mailboxPage = null;
        }

        [Given(@"I am logged in and on the mailbox page")]
        public void GivenIAmLoggedInAndOnTheMailboxPage()
        {
            mailboxPage = homePage.NavigateAndLogin();
        }

        [When(@"I click on the '(?:.*)' button")]
        public void WhenIClickOnTheButton()
        {
            mailboxPage.ClickOnNewMessageButton();
        }

        [When(@"write in the message box the following message:")]
        public void WhenWriteInTheMessageBoxTheFollowingMessage(string multilineMessage)
        {
            mailboxPage.WriteNewMessage(multilineMessage);
        }

        [When(@"send the message with the following message data:")]
        public void WhenSendTheMessageWithTheFollowingMessageData(Table messageData)
        {
            mailboxPage.SendMessage(messageData);
        }


        [Then(@"I should see a confirmation message for successfully sent email")]
        public void ThenIShouldSeeAConfirmationMessageForSuccessfullySentEmail()
        {
            mailboxPage.ConfirmationMessageForSentEmail_Assertion();
        }
    }
}
