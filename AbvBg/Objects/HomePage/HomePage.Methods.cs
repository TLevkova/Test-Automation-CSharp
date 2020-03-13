using AbvBg.Utils;

namespace AbvBg.Objects
{
    partial class HomePage
    {
        public MailboxPage Login(string username, string password)
        {
            TypeInto(Username, username);
            TypeInto(Password, password);
            LoginButton.Click();

            return new MailboxPage(Driver);
        }

        public MailboxPage NavigateAndLogin()
        {
            Navigate();
            HandleGdprFrame(Driver);
            TypeInto(Username, TestConfig.LoginUsername);
            TypeInto(Password, TestConfig.LoginPassword);
            LoginButton.Click();

            return new MailboxPage(Driver);
        }
    }
}