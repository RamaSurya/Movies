@ForgotPassword
Feature: Forgot Password
Background: 
Given: User is on Forgot Password Page

@title
Scenario: Checking the title of the Forgot Password page
When User is on the Forgot Password Page
Then Title of page should be Forgot Password

@Cancel
Scenario: checking the functionality of  Cancel link in Forgot Password
Given Cancel is displayed on the Forgot Password page
When User clicks on Cancel link
Then USER should Redirected to Cinema Café page 

@Answer
Scenario: checking the functionality of Forgot Password page with valid Answer
When User enters the Answer 
And click on Submit button
Then User should  Redirect to Customer Home page for valid login

@blankuserid
Scenario: checking the functionality of Forgot Password page with blank User ID
When User enters Answer
And click on Submit button
Then User gets message - User Id is blank. Please provide a User Id


@invaliduserid
Scenario:  checking the functionality of Registration page with invalid User ID
When user enters invalid User ID
And User enters Answer
And click  on Submit button
Then User gets message - User Id should be an email id (or) user Id did not already exists
 


@Answerblank
Scenario: checking the functionality of Forgot Password page with blank Answer
When click on Submit button
Then User gets message - Answer is blank.Please provide the answer for security question


@Answer<5
Scenario: checking the functionality of Forgot Password page with  Answer less than 5 characters
When User enters Answer less than 5 characters
And click on Submit button
Then User gets message -Invalid answer.Please provide a valid answer for security checking.

@Answer>100
Scenario: checking the functionality of Forgot Password page with  Answer greater than 100 characters
When User enters Answer greater than 100 characters
And click on Submit button
Then User gets message -Invalid answer.Please provide a valid answer for security checking.

@Answerspecial
Scenario: checking the functionality of Forgot Password page with  Answer having special characters
When User enters Answer having special characters
And click on Submit button
Then User gets message -Invalid answer.Please provide a valid answer for security checking.

@nooflinks
Scenario: Checking no. of links is equal to 1 

When User counts no. of links
Then It should not be equal to 1 

@nooftextboxes
Scenario: Checking no. of links is equal to 2 
When User counts no. of text boxes
Then It should not be equal to 2

@noofbuttons
Scenario: Checking no. of buttons is equal to 1

When User counts no. of buttons
Then It should not be equal to 1

