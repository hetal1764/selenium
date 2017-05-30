using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace SeleniumTest
{
    [TestClass]
    public class GmailLoginTest
    {
        IWebDriver driver = new ChromeDriver(@"C:/Selenium");

        [Given(@"valid email address and password are entered")]
        [When(@"I click on Next")]
        [Then(@"Email page is displayed.")]


        [TestMethod]

        public void Login()
        {
            TimeSpan t = new TimeSpan(0, 0, 5);
            WebDriverWait wait = new WebDriverWait(driver, t);
            GmailLoginPage gmailLoginPage = new GmailLoginPage(driver);

            //Enter Email Address
            gmailLoginPage.username.SendKeys("test45345345342@gmail.com");
            gmailLoginPage.next.Click();
            
            //Enter Password
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name("password")));
            gmailLoginPage.password.SendKeys("Test!2345");
            gmailLoginPage.passwordNext.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(":3t")));
            string title = driver.Title;
            Assert.IsTrue(title.Contains("Inbox"));
            Console.Write("Logged in Successfully");

            //Logput
            driver.Navigate().GoToUrl(@"https://accounts.google.com/Logout");
            driver.Close();
        }

    }
}
