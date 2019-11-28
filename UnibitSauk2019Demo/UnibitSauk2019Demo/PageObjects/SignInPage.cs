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
                //emailAddress = driver.FindElement(By.Id("email"));
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
                emailAddress = wait.Until(d => d.FindElement(By.Id("email")));

                return emailAddress;
            }
        }

        public IWebElement Password
        {
            get
            {
                //password = driver.FindElement(By.Id("passwd"));
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
    }
}
