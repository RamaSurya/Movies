@Registration
Feature: Check the functionality of Registration page
Background: 
Given User is on Registration Page

@CANCEL
Scenario: check the functionality of  CANCEL link
Given CANCEL is displayed on the Registration page
When User clicks on CANCEL link
Then USER should redirect to the Cinema Cafe page

@title
Scenario: checking the title
When user is on Registration page
Then the title should be Registration
	
@validRegistration
Scenario: Checking the functionality of Registration page with valid credentials
When User enters valid User ID, valid Name, valid Mobile, valid Password, valid Answer and click on Register button
Then It should redirect to Cinema Cafe Page

@blankuserid
Scenario: checking the functionality of Registration page with blank User ID
When User enters valid Name, valid Mobile, valid Password, valid Answer and click on Register button
Then User gets message - User Id is blank. Please provide a User Id

@blankname
Scenario: checking the functionality of Registration page with blank Name
When User enters valid User ID, valid Mobile, valid Password, valid Answer and click  on Register button
Then User gets message - Name is blank. Please provide a Name.

@blankpassword
Scenario:  checking the functionality of Registration page with blank Password
When User enters valid User ID, valid Name, valid Mobile, valid Answer and click  on Register button
Then User gets message - Password is blank Please provide a Password.

@blankmobile
Scenario: checking the functionality of Registration page with blank Mobile
When User enters valid User ID,valid Name,valid Password,valid Answer and click on Register button
Then It should redirect to Cinema Cafe Page too

@blankanswer
Scenario:  checking the functionality of Registration page with blank Answer
When User enters valid User ID, valid Name, valid Mobile, valid Password and click  on Register button
Then User gets message - Answer is blank. Please provide an Answer.

@invaliduserid
Scenario:  checking the functionality of Registration page with invalid User ID
When user enters invalid User ID, valid Name, valid Mobile, valid Password, valid Answer and click  on Register button
Then User gets message - User Id should be an email id (or) user Id already exists
 

@Name<5
Scenario: checking the functionality of Registration page with Name less than 5 charecters
When User enters valid User ID, Name less than 5 charecters, valid Mobile, valid Password, valid Answer and click  on Register button
Then User gets message - Name is less than 5 characters



@Name>20
Scenario: checking the functionality of Registration page with Name greater than 20 charecters
When User enters valid User ID, Name greater than 20 charecters, valid Mobile, valid Password, valid Answer and click  on Register button
Then User gets message - Name is greater than 20 characters

@Namedigit
Scenario: checking the functionality of Registration page with Name having number
When User enters valid User ID, Name with numbers, valid Mobile, valid Password, valid Answer and click  on Register button
Then User gets message - Name is invalid

@Namespecial
Scenario: checking the functionality of Registration page with Name having special characters
When User enters valid User ID, Name with special characters, valid Mobile, valid Password, valid Answer and click  on Register button
Then User gets message - Name is having special characters

@Mobile<10
Scenario: checking the functionality of Registration page with Mobile less than 10 numbers
When User enters valid User ID, valid Name, Mobile less than 10 numbers, valid Password, valid Answer and click  on Register button
Then User gets message - Mobile number is less than 10 numbers

@Mobile>12
Scenario: checking the functionality of Registration page with Mobile greater than 12 charecters
When User enters valid User ID, valid Name, Mobile greater than 12 numbers, valid Password, valid Answer and click  on Register button
Then User gets message - Mobile number is greater than 10 numbers

@Mobile11
Scenario: checking the functionality of Registration page with Mobile having 11 numbers
When User enters valid User Id,valid Name,Mobile having 11 numbers,valid Password,valid Answer and click on Register button
Then User gets message-Mobile is having 11 numbers 

@Mobilealphabet
Scenario: checking the functionality of Registration page with Mobile having alphabets
When User enters valid User ID, valid Name, having alphabet, valid Password, valid Answer and click  on Register button
Then User gets message - Mobile number is invalid

@Mobilespecial
Scenario: checking the functionality of Registration page with Mobile having special characters
When User enters valid User ID, valid Name, Mobile which includes special characters, valid Password, valid Answer and click on Register button
Then User gets message - Mobile number is having specail characters


@Password<5
Scenario: checking the functionality of Registration page with Password less than 5 charecters
When User enters valid User ID, valid Name, valid Mobile, Password less than 5 charecters, valid Answer and click  on Register button
Then User gets message - Password is less than 5 characters

@Password>20
Scenario: checking the functionality of Registration page with Password greater than 20 charecters
When User enters valid User ID, valid Name, valid Mobile, Password greater than 20 characters, valid Answer and click  on Register button
Then User gets message - Password is greater than 20 characters

@Passwordspecial
Scenario: checking the functionality of Registration page with Password having special character
When User enters valid User ID, valid Name, valid Mobile, Password with special characters, valid Answer and click  on  Register button
Then User gets message - Password is having special characters

@Answer<5
Scenario: checking the functionality of Registration page with Answer less than 5 charecters
When User enters valid User ID, valid Name, valid Mobile, valid Password, Answer less than 5 charecters and click  on Register button
Then User gets message - Answer is less than 5 characters

@Answer>100
Scenario: checking the functionality of Registration page with Answer greater than 100 charecters
When User enters valid User ID, valid Name, valid Mobile, valid Password, Answer greater than 100 charecters and click  on Register button
Then User gets message - Answer is greater than 100 characters


@Answerspecial
Scenario: checking the functionality of Registration page with Answer having special charcaters
When User enters valid User ID, valid Name, valid Mobile, valid Password, Answer having special character and click  on Register button
Then User gets message - Answer is invalid Please enter a valid Answer

@no.oflinks
Sceanrio: checking the number of links in Registration page
When user counts the number of links
Then the number of links should be 1