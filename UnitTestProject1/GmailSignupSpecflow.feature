Feature: Signup for google account
In order to be able to login to gmail
as a user, first create google account

@Test
Scenario: Create google account
Given First Name, Last Name, Valid Email address 
And all the required information is provided
When I press Submit
Then Privacy and Terms dialog is displayed
When I click on Agree
Then I am redirected to next page.