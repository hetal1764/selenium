using System;
using TechTalk.SpecFlow;

namespace UnitTestProject1
{
    [Binding]
    public class LoginToGmailAccountSteps
    {
        [Given(@"valid email address and password are entered")]
        public void GivenValidEmailAddressAndPasswordAreEntered()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I click on Next")]
        public void WhenIClickOnNext()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Email page is displayed.")]
        public void ThenEmailPageIsDisplayed_()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
