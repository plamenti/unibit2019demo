using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UnibitSauk2019Demo.PageObjects;

namespace UnibitSauk2019Demo
{
    [TestClass]
    public class TestLogin
    {
        private Header header;
        private MainPage mainPage;
        private IWebDriver driver;
        public IDictionary<string, object> vars { get; private set; }
        private IJavaScriptExecutor js;

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            header = new Header(driver);
            mainPage = new MainPage(driver);
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<string, object>();
        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }

        [TestMethod]
        public void SuccessfulLogin()
        {
            mainPage.GoToIndex();
            header.SignInButton.Click();

            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("email")).SendKeys("d2041118@urhen.com");
            driver.FindElement(By.Id("passwd")).Click();
            driver.FindElement(By.Id("passwd")).SendKeys("123456");
            driver.FindElement(By.CssSelector("#SubmitLogin > span")).Click();
            Assert.AreEqual(driver.FindElement(By.CssSelector(".account > span")).Text, "Unibit Test");
        }

        [TestMethod]
        public void EmptyFields()
        {
            mainPage.GoToIndex();
            header.SignInButton.Click();

            driver.FindElement(By.CssSelector("#SubmitLogin > span")).Click();
            Assert.AreEqual(driver.FindElement(By.CssSelector("ol > li")).Text, "An email address required.");
        }

        [TestMethod]
        public void NonExistingMail()
        {
            mainPage.GoToIndex();
            header.SignInButton.Click();

            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("email")).SendKeys("non_existing_mail@test.com");
            driver.FindElement(By.Id("passwd")).Click();
            driver.FindElement(By.Id("passwd")).SendKeys("123456");
            driver.FindElement(By.CssSelector("#SubmitLogin > span")).Click();
            Assert.AreEqual(driver.FindElement(By.CssSelector("ol > li")).Text, "Authentication failed.");
        }
    }
}
