using NUnit.Framework;

namespace AbvBg.Objects
{
    partial class MailboxPage
    {

        public void SuccessfulLogin_Assertion(string userGreeting)
        {
            Assert.AreEqual(userGreeting, UserGreeting.Text);
        }

        public void ConfirmationMessageForSentEmail_Assertion()
        {
            Assert.AreEqual("Писмото беше изпратено успешно!", ConfirmationMessage);
        }
    }
}
