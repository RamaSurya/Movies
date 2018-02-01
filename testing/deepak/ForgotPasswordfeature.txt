
@ForgotPassword
Feature: Checking the functionality of Forgot Password Page
Background: 
Given User is on Forgot Password Page

@title
Scenario: Checking the title of the Forgot Password page
When User is on the Forgot Password Page
Then Title of page should be Forgot Password

@Cancel
Scenario: checking the functionality of  Cancel link in Forgot Password
When User clicks on Cancel link
Then USER should Redirected to Cinema Café page 

@Answer
Scenario: checking the functionality of Forgot Password page with valid User ID and Answer
When User enters valid User ID, vaid Answer and click on Submit button
Then User should  Redirect to Customer Home page for valid login

@blankuserid
Scenario: checking the functionality of Forgot Password page with blank User ID
When User enters Answer and click on Submit button
Then User gets message - User Id is blank. Please provide a User Id


@invaliduserid
Scenario:  checking the functionality of Registration page with invalid User ID
When user enters invalid User ID and Answer and click  on Submit button
Then User gets message - User Id should be an email id (or) user Id did not already exists
 


@Answerblank
Scenario: checking the functionality of Forgot Password page with blank Answer
When User enters User ID and click on Submit button
Then User gets message - Answer is blank.Please provide the answer for security question


@Answer<5
Scenario: checking the functionality of Forgot Password page with  Answer less than 5 characters
When User enters User ID, Answer less than 5 characters andclick on Submit button
Then User gets message -Answer is less than 5.Please provide a valid answer for security checking.

@Answer>100
Scenario: checking the functionality of Forgot Password page with  Answer greater than 100 characters
When User enters User ID, Answer greater than 100 characters and click on Submit button
Then User gets message -Answer is greater than 100.Please provide a valid answer for security checking.

@Answerspecial
Scenario: checking the functionality of Forgot Password page with  Answer having special characters
When User enters User ID, Answer having special characters and click on Submit button
Then User gets message -Answer is having special characters.Please provide a valid answer for security checking.

@nooflinks
Scenario: Checking no. of links is equal to 1 

When User counts no. of links
Then links should be equal to 1 

@nooftextboxes
Scenario: Checking no. of textboxes is equal to 2 
When User counts no. of text boxes
Then Textboxes should be equal to 2

@noofbuttons
Scenario: Checking no. of buttons is equal to 1

When User counts no. of buttons
Then B should be equal to 1

