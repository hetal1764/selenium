using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace SeleniumTest
{
    public class GmailLoginPage
    {
        IWebDriver driver = new ChromeDriver(@"C:\Selenium");
        string url = @"https://gmail.com/";

        public GmailLoginPage(IWebDriver browser)
        {
            this.driver = browser;
            driver.Navigate().GoToUrl(url);
            PageFactory.InitElements(browser, this);
        }

        [FindsBy (How = How.CssSelector, Using = "#identifierLink>div.vdE7Oc.f3GIQ>p")]
        public IWebElement UseAnotherAccount { get; set; }

        [FindsBy(How = How.Id, Using = "identifierId")]
        public IWebElement username;

        [FindsBy(How = How.Id, Using = "identifierNext")]
        public IWebElement next;

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement password;

        [FindsBy(How = How.Id, Using = "passwordNext")]
        public IWebElement passwordNext;

        [FindsBy(How = How.Id, Using = "yDmH0d")]
        public IWebElement myAccount;

    }

}
