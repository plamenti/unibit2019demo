using OpenQA.Selenium;

namespace UnibitSauk2019Demo.PageObjects
{
    public class MainPage
    {
        private const string Url = "http://automationpractice.com/index.php";
        private IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void GoToIndex()
        {
            driver.Navigate().GoToUrl(Url);
        }
    }
}
