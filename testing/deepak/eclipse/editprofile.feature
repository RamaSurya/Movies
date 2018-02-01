
@editprofilepage
Feature: Checking the functionality of Edit Profile Page
Background:
Given User should be on Edit Profile Page

@title
Scenario: checking the title
When user on Edit Profile page
Then title of page should be Edit Profile
 
@HOME
Scenario: checking the functionality of HOME link
When user clicks on  HOME link  displayed on Edit Pofile page
Then user will Redirect to Customer Home 

@EDITPROFILE
Scenario: checking the functionality of EDIT PROFILE link
When user clicks on EDIT PROFILE link displayed on Edit Profile page 
Then user will Redirect to same(Edit Profile) Page

@SHOWDETAILS
Scenario: checking the functionality of SHOW DETAILS link
When user clicks on SHOW DETAILS link  displayed on Edit profile page
Then user will redirect to SHOW DETAILS link

@CANCELBOOKING
Scenario: checking the functionaity of CANCEL BOOKING link
When user clicks on CANCEL BOOKING link  displayed on Edit Profile page
Then user will Redirect to Cancel Booking page

@LOGOUT
Scenario: checking the functionality of LOGOUT link
When user clicks on LOGOUT link displayed on Edit Profile page
Then user will redirect to Cinema Cafe page

@validedit
Scenario: checking the functionality of Edit Profile with valid data
When user enters valid Name, valid Mobile, valid Password, valid Answer and click on Submit button
Then user gets message-Data updated successfully

@nameblank
Scenario: checking the functionality of Edit Profile with blank name
When user enters valid Mobile, valid Password, valid Answer and click on Submit button
Then user gets message-Username is blank

@name<5
Scenario: checking the functionaity of Edit Profile with name less than 5 characters
When user enters name with less than 5 characters, valid Mobile, valid Password, valid Answer and click on Submit button
Then user gets message-Name is out of range.Name exceeding range.


@name>20
Scenario: checking the functionaity of Edit Profile with name greater than 20 characters
When user enters name with greater than 20 characters, valid Mobile, valid Password, enters valid Answer and click on Submit button
Then user gets message-Name is out of range. Name exceeding range.


@namespecial
Scenario: checking the functionaity of Edit Profile with name having special character
When user enters name with special character, valid Mobile, valid Password, valid Answer and click on submit button
Then user gets message-Name is having special characters


@mobile<10
Scenario: checking the functionality of Edit Profile with mobile less than 10 numbers
When user enters valid Name, mobile with less than 10 numbers, valid Password, valid Answer and click on Submit button
Then user gets message-Mobile number is out of range.Please give a valid mobile number.



@mobile>12
Scenario: checking the functionality of Edit Profile with mobile less than 12 numbers
When user enters valid Name, mobile with greater than 12 numbers, valid Password, valid Answer and click on Submit button
Then user gets message-Mobile number is greater than 12 numbers

@mobilealphabet
Scenario: checking the functionality of Edit Profile with mobile having alphabets
When user enters valid Name, mobile with mobile having alphabets, valid Password, valid Answer and click on Submit button
Then user gets message-Mobile number is having alphabet

@mobilespecial
Scenario: checking the functionality of Edit Profile with mobile having special characters
When user enters valid Name, mobile having special characters, valid Password, valid Answer and click on Submit button
Then user gets message-Mobile number is having special character

@blankmobile
Scenario:checking the functionality of Edit Profile with blank mobile
When user enters valid Name, valid Password, valid Answer and click on Submit button
Then user gets message-Inserted the record

@passwordblank
Scenario: checking the functionality of Edit Profile with blank password 
When user enters valid Name, valid Mobile, valid Answer and click on Submit button
Then user gets message-Password is blank


@password<8
Scenario: checking the functionality of Edit Profile with password less than 8 characters
When user enters valid Name, valid Mobile, Password with less than 8 characters, valid Answer and click on Submit button
Then user gets message-Password is less than 8 characters


@password>20
Scenario: checking the functionality of Edit Profile with Password greater than 20 characters
When user enters valid Name, valid Mobile, Password with greater than 20 characters, valid Answer and click on Submit button
Then user gets message-Password is greater than 20 characters


@passwordspecial
Scenario: checking the functionality of Edit Profile with Password having special characters
When  user enters valid Name, valid Mobile, Password with special characters, valid Answer and click on Submit button
Then user gets message-password is having special character

@answerblank
Scenario: checking the functionality of Edit Profile with blank Answer 
When user enters valid Name, valid Mobile, valid Password and click on Submit button
Then user gets message-Answer is blank.Please provide an answer to security question.


@answer<5
Scenario: checking the functionality of Edit Profile with Answer having less than 5 characters
When user enters valid Name, valid Mobile, valid Password, Answer having less than 5 characters and click on Submit button
Then user gets message-Answer is less than 5 characters



@answer>100
Scenario: checking the functionality of Edit Profile with Answer having greater than 100 characters
When user enters valid Name, valid Mobile, valid Password, Answer having greater than 100 characters and click on Submit button
Then user gets message-Answer is greater than 100 characters




@answerspecial
Scenario: checking the functionality of Edit Profile with Answer having special characters
When user enters valid Name, valid Mobile, valid Password, Answer having special characters and click on Submit button
Then user gets message-Answer is having special character

@no.oflinks
Scenario: checking the number of links in Edit Profile page
When user counts number of links
Then number of links should be 5

@no.oftxtbox
Scenario: checking the number of textboxes in Edit Profile page
When user counts number of text boxes
Then the number of text boxes should be 4

@no.ofbutton
Scenario: checking the number of buttons in Edit Profile page
When user counts number of buttons
Then the number of buttons should be 1




