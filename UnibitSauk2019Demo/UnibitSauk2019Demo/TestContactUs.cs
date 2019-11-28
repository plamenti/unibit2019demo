using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnibitSauk2019Demo
{
    [TestClass]
    public class TestContactUs : BaseTest
    {
        [TestMethod]
        public void InvalidEmail()
        {
            contactUsPage.GoToIndex();
            
            contactUsPage.SendMessage("");

            Assert.AreEqual(contactUsPage.GetErrorMessageText(), "Invalid email address.");
        }
    }
}
