using AbvBg.Objects;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace AbvBg.Tests.Login
{
    [Binding]
    class Login_Steps : BaseTest
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

        [Given(@"I am on the Home page")]
        public void GivenIAmOnTheHomePage()
        {
            homePage.Navigate();
            homePage.HandleGdprFrame(driver);

        }

        [When(@"I enter my '(.*)', '(.*)' and click on the Login button")]
        public void WhenIEnterMyCredentialsAndClickOnLoginButton(string username, string password)
        {
            mailboxPage = homePage.Login(username, password);
        }

        [Then(@"I should be logged in successfully and see greeting message with my '(.*)'")]
        public void ThenIShouldBeLoggedInSuccessfullyAndSeeGreetingMessage(string userGreeting)
        {
            mailboxPage.SuccessfulLogin_Assertion(userGreeting);
        }

        [Then(@"I shouldn't be able to login and should see an error message")]
        public void ThenIShouldnTBeAbleToLoginAndShouldSeeAnErrorMessage()
        {
            homePage.ErrorMessageDisplayed_Assertion();
        }
    }
}
