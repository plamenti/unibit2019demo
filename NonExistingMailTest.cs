// Generated by Selenium IDE
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
[TestFixture]
public class NonexistingmailTest {
  private IWebDriver driver;
  public IDictionary<string, object> vars {get; private set;}
  private IJavaScriptExecutor js;
  [SetUp]
  public void SetUp() {
    driver = new ChromeDriver();
    js = (IJavaScriptExecutor)driver;
    vars = new Dictionary<string, object>();
  }
  [TearDown]
  protected void TearDown() {
    driver.Quit();
  }
  [Test]
  public void nonexistingmail() {
    driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
    driver.Manage().Window.Size = new System.Drawing.Size(1552, 840);
    driver.FindElement(By.LinkText("Sign in")).Click();
    driver.FindElement(By.Id("email")).Click();
    driver.FindElement(By.Id("email")).SendKeys("non_existing_mail@test.com");
    driver.FindElement(By.Id("passwd")).Click();
    driver.FindElement(By.Id("passwd")).SendKeys("123456");
    driver.FindElement(By.CssSelector("#SubmitLogin > span")).Click();
    Assert.That(driver.FindElement(By.CssSelector("ol > li")).Text, Is.EqualTo("Authentication failed."));
  }
}