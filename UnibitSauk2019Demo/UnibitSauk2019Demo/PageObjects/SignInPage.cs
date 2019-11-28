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
        private IWebElement errorMessage;
        private IWebDriver driver;

        public SignInPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement EmailAddress
        {
            get
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
                emailAddress = wait.Until(d => d.FindElement(By.Id("email")));

                return emailAddress;
            }
        }

        private IWebElement Password
        {
            get
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
                password = wait.Until(d => d.FindElement(By.Id("passwd")));

                return password;
            }
        }

        private IWebElement SignInButton
        {
            get
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
                signInButton = wait.Until(d => d.FindElement(By.Id("SubmitLogin")));
                
                return signInButton;
            }
        }

        public string GetErrorMessageText()
        {
            return ErrorMessage.Text;
        }

        public IWebElement ErrorMessage
        {
            get
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
                errorMessage = wait.Until(d => d.FindElement(By.CssSelector("ol > li")));

                return errorMessage;
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
