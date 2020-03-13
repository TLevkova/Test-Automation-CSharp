using NUnit.Framework;

namespace AbvBg.Objects
{
    partial class HomePage
    {
        public void ErrorMessageDisplayed_Assertion()
        {
            Assert.IsTrue(LoginErrorMessage.Displayed);
        }
    }
}