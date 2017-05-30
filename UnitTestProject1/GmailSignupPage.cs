using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;


namespace SeleniumTest
{
    public class GmailSignupPage
    {
        IWebDriver driver = new ChromeDriver(@"C:\Selenium");
        string url = @"https://accounts.google.com/SignUp?";
  

        public GmailSignupPage(IWebDriver browser)
        {
            this.driver = browser;
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            PageFactory.InitElements(browser, this);
        }

        [FindsBy (How = How.Name, Using = "FirstName")]
        public IWebElement firstName { get; set; }

        [FindsBy(How = How.Name, Using = "LastName")]
        public IWebElement lastName { get; set; }

        [FindsBy(How = How.Name, Using = "GmailAddress")]
        public IWebElement gmailAddress { get; set; }

        [FindsBy(How = How.Name, Using = "Passwd")]
        public IWebElement passwd { get; set; }

        [FindsBy(How = How.Name, Using = "PasswdAgain")]
        public IWebElement passwdAgain { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//div[@role='listbox']")]
        public IWebElement birthMonth { get; set; }
        
        [FindsBy(How = How.Name, Using = "BirthDay")]
        public IWebElement birthDay { get; set; }

        [FindsBy(How = How.Name, Using = "BirthYear")]
        public IWebElement birthYear { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@aria-activedescendant=':d']")]
        public IWebElement gender { get; set; }

        [FindsBy(How = How.Name, Using = "RecoveryPhoneNumber")]
        public IWebElement recoveryPhoneNumber { get; set; }

        [FindsBy(How = How.Name, Using = "RecoveryEmailAddress")]
        public IWebElement recoveryEmailAddress { get; set; }

        [FindsBy(How = How.Name, Using = "submitbutton")]
        public IWebElement submitButton { get; set; }

        public void ValidateEmail(string strEmail)
        {
            gmailAddress.Clear();
            gmailAddress.SendKeys(strEmail);
            passwd.Click();
            TimeSpan t = new TimeSpan(0, 0, 5);
            WebDriverWait wait = new WebDriverWait(driver, t);
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("username-errormsg-and-suggestions")));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("username-errormsg-and-suggestions")));
            string actualError = driver.FindElement(By.Id("username-errormsg-and-suggestions")).Text;
            Console.Write("\n" + actualError);
            if (strEmail == "")
            {
                wait.Equals(10);
                Assert.AreEqual(actualError, "You can't leave this empty.");
                Console.Write("\nBlank Email address is not valid");
            }
            else if (strEmail == ".test.com")
            {
                wait.Equals(20);
                Assert.AreEqual(actualError, "The first character of your username should be a letter (a-z) or number.");
                Console.Write("\nFirst character of email is not a letter");
            }
            else if (strEmail == "email@domain@domain.com")
            {
                wait.Equals(20);
                Assert.AreEqual(actualError, "Please use only letters (a-z), numbers, and periods.");
                Console.Write("\nEmail address contains special characters");
            }
            else if (strEmail == "test123@domain.com")
            {
                wait.Equals(40);
                Assert.AreEqual(actualError, "That looks like your email address. You can enter that below. Choose a new Google username (which will also be your new gmail.com address).");
                Console.Write("\nEmail address contains special characters");
            }
            gmailAddress.Click();
            return;

        }  
    }
}
