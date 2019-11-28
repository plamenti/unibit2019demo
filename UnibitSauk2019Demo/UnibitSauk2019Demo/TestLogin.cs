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
        private SignInPage signInPage;
        private IWebDriver driver;

        [TestInitialize]
        public void SetUp()
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

        [TestMethod]
        public void SuccessfulLogin()
        {
            // Arrane
            // Given
            mainPage.GoToIndex();
            header.GoToSignIn();

            // Act
            // When
            signInPage.Login("d2041118@urhen.com", "123456");
            
            // Assert
            // Then
            Assert.AreEqual(header.UserInfo.Text, "Unibit Test");
        }

        [TestMethod]
        public void EmptyFields()
        {
            mainPage.GoToIndex();
            header.GoToSignIn();

            signInPage.Login("", "");

            Assert.AreEqual(signInPage.GetErrorMessageText(), "An email address required.");
        }

        [TestMethod]
        public void NonExistingMail()
        {
            mainPage.GoToIndex();
            header.GoToSignIn();

            signInPage.Login("non_existing_mail@test.com", "123456");

            Assert.AreEqual(signInPage.GetErrorMessageText(), "Authentication failed.");
        }
    }
}
