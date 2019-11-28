using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace UnibitSauk2019Demo.PageObjects
{
    class SignInPage
    {
        private IWebElement emailAddress;
        private IWebElement password;
        private IWebElement signInButton;
        private IWebDriver driver;

        public SignInPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement EmailAddress
        {
            get
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
                emailAddress = wait.Until(d => d.FindElement(By.Id("email")));

                return emailAddress;
            }
        }

        public IWebElement Password
        {
            get
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
                password = wait.Until(d => d.FindElement(By.Id("passwd")));

                return password;
            }
        }

        public IWebElement SignInButton
        {
            get
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
                signInButton = wait.Until(d => d.FindElement(By.Id("SubmitLogin")));
                
                return signInButton;
            }
        }

        public void Login(string emailAddress, string password)
        {
            EmailAddress.Click();
            EmailAddress.Clear();
            EmailAddress.SendKeys(emailAddress);

            Password.Click();
            Password.Clear();
            Password.SendKeys(password);

            SignInButton.Click();
        }
    }
}
