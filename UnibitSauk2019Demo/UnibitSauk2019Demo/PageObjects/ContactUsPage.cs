using System;
using OpenQA.Selenium;

namespace UnibitSauk2019Demo.PageObjects
{
    public class ContactUsPage
    {
        private const string Url = "http://automationpractice.com/index.php?controller=contact";
        private IWebDriver driver;
        private IWebElement sendButton;
        private IWebElement messageTextArea;
        private IWebElement errorMessage;

        public ContactUsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement SendButton
        {
            get
            {
                sendButton = driver.FindElement(By.Id("submitMessage"));
                return sendButton;
            }
        }

        private IWebElement MessageTextArea
        {
            get
            {
                messageTextArea = driver.FindElement(By.Id("message"));
                return messageTextArea;
            }
        }

        private IWebElement ErrorMessage
        {
            get
            {
                errorMessage = driver.FindElement(By.CssSelector("ol > li"));
                return errorMessage;
            }
        }

        public void GoToIndex()
        {
            driver.Navigate().GoToUrl(Url);
        }

        public void SendMessage(string messageText)
        {
            MessageTextArea.Click();
            MessageTextArea.Clear();
            MessageTextArea.SendKeys(messageText);
            SendButton.Click();
        }

        public string GetErrorMessageText()
        {
            return ErrorMessage.Text;
        }
    }
}
