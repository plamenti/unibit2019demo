using OpenQA.Selenium;

namespace UnibitSauk2019Demo.PageObjects
{
    class MainPage
    {
        private const string Url = "http://automationpractice.com/index.php";
        private IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Window.Maximize();
        }

        public void GoToIndex()
        {
            driver.Navigate().GoToUrl(Url);
        }
    }
}
