using System;
using TechTalk.SpecFlow;

namespace UnitTestProject1
{
    [Binding]
    public class SignupForGoogleAccountSteps
    {
        [Given(@"First Name, Last Name, Valid Email address")]
        public void GivenFirstNameLastNameValidEmailAddress()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"all the required information is provided")]
        public void GivenAllTheRequiredInformationIsProvided()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I press Submit")]
        public void WhenIPressSubmit()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I click on Agree")]
        public void WhenIClickOnAgree()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Privacy and Terms dialog is displayed")]
        public void ThenPrivacyAndTermsDialogIsDisplayed()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I am redirected to next page\.")]
        public void ThenIAmRedirectedToNextPage_()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
