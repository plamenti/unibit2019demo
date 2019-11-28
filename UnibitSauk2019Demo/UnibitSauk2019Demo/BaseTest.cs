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
        protected IWebDriver driver;

        public BaseTest()
        {
            driver = new ChromeDriver();
            header = new Header(driver);
            mainPage = new MainPage(driver);
            signInPage = new SignInPage(driver);
        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
