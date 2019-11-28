using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnibitSauk2019Demo
{
    [TestClass]
    public class TestLogin : BaseTest
    {
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
