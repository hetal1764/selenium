using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace SeleniumTest
{
    //[Binding]
    [TestClass]
    public class GmailSignupTest
        {
        IWebDriver driverGC = new ChromeDriver(@"C:/Selenium");


        [TestMethod]

        [Given(@"First Name, Last Name, Valid Email address and all the required information is provided")]
        [When(@"I press Submit")]
        [Then(@"Privacy and Terms dialog is displayed")]
        [When(@"I click on Agree")]
        public void Register()
        {

            // Specify the first name here
            Random rnd = new Random();
            int prefix = rnd.Next(1, 999);
            String firstName = "Test" + prefix;
            string password = "Test!23456";

            GmailSignupPage gmailPage = new GmailSignupPage(driverGC);
            gmailPage.firstName.SendKeys("John");
            gmailPage.lastName.SendKeys("Smith");
            gmailPage.ValidateEmail("");
            gmailPage.ValidateEmail(".test.com");
            gmailPage.ValidateEmail("email@domain@domain.com");
            gmailPage.ValidateEmail("test123@domain.com");
            gmailPage.gmailAddress.Clear();
            gmailPage.gmailAddress.SendKeys("Test4534534534" + prefix);
            gmailPage.passwd.SendKeys(password);
            gmailPage.passwdAgain.SendKeys(password);
            gmailPage.birthMonth.SendKeys("January");
            gmailPage.birthDay.SendKeys("25");
            gmailPage.birthYear.SendKeys("1981");
            gmailPage.gender.SendKeys("Male");
            gmailPage.recoveryPhoneNumber.SendKeys("908-343-5778");
            gmailPage.recoveryEmailAddress.SendKeys("abc@test.com");

            //Click on Next Step
            gmailPage.submitButton.Click();

            //Scroll and click on I Agree button in Privacy dialog
            IWebElement scroll = driverGC.FindElement(By.Id("tos-scroll"));
            scroll.SendKeys(Keys.PageDown);
            scroll.SendKeys(Keys.PageDown);

            TimeSpan t = new TimeSpan(0, 0, 5);
            WebDriverWait wait = new WebDriverWait(driverGC, t);
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("iagreebutton")));
            driverGC.FindElement(By.Id("iagreebutton")).Click();

            // Closing the browser
            driverGC.Close();
        }

    }
}
