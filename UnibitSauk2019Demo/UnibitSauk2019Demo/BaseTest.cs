using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UnibitSauk2019Demo.PageObjects;

namespace UnibitSauk2019Demo
{
    [TestClass]
    public class BaseTest
    {
        protected Header header;
        protected MainPage mainPage;
        protected SignInPage signInPage;
        protected ContactUsPage contactUsPage;
        protected IWebDriver driver;

        public BaseTest()
        {
            driver = new ChromeDriver();
            header = new Header(driver);
            mainPage = new MainPage(driver);
            signInPage = new SignInPage(driver);
            contactUsPage = new ContactUsPage(driver);
        }

        [TestInitialize]
        public void TestSetup()
        {
            driver.Manage().Window.Maximize();
        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
