using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UnibitSauk2019Demo
{
    [TestClass]
    public class TestLogin
    {
        private IWebDriver driver;
        public IDictionary<string, object> vars { get; private set; }
        private IJavaScriptExecutor js;

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
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
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            driver.Manage().Window.Size = new System.Drawing.Size(1552, 840);
            driver.FindElement(By.LinkText("Sign in")).Click();
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
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            driver.Manage().Window.Size = new System.Drawing.Size(1552, 840);
            driver.FindElement(By.LinkText("Sign in")).Click();
            driver.FindElement(By.CssSelector("#SubmitLogin > span")).Click();
            Assert.AreEqual(driver.FindElement(By.CssSelector("ol > li")).Text, "An email address required.");
        }
        [TestMethod]
        public void NonExistingMail()
        {
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            driver.Manage().Window.Size = new System.Drawing.Size(1552, 840);
            driver.FindElement(By.LinkText("Sign in")).Click();
            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("email")).SendKeys("non_existing_mail@test.com");
            driver.FindElement(By.Id("passwd")).Click();
            driver.FindElement(By.Id("passwd")).SendKeys("123456");
            driver.FindElement(By.CssSelector("#SubmitLogin > span")).Click();
            Assert.AreEqual(driver.FindElement(By.CssSelector("ol > li")).Text, "Authentication failed.");
        }
    }
}
