using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace UnibitSauk2019Demo.PageObjects
{
    class Header
    {
        private IWebDriver driver;
        private IWebElement signInButton;
        private IWebElement userInfo;

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

        public IWebElement UserInfo
        {
            get
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
                userInfo = wait.Until(d => d.FindElement(By.CssSelector(".account > span")));

                return userInfo;
            }
        }

        public void GoToSignIn()
        {
            SignInButton.Click();
        }
    }
}
