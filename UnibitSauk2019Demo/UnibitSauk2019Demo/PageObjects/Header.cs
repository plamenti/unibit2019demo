using OpenQA.Selenium;

namespace UnibitSauk2019Demo.PageObjects
{
    class Header
    {
        private IWebDriver driver;
        private IWebElement signInButton;

        public Header(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement SignInButton
        {
            get
            {
                signInButton = driver.FindElement(By.LinkText("Sign in"));
                return signInButton;
            }
        }
    }
}
