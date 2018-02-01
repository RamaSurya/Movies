@customerhome
Feature: checking the functionality of Customer Home page
Background: 
Given user should be on the Cuatomer Home page

@title
Scenario: checking the title
When user is on Customer Home page
Then title of the page should be Customer Home
 
@home
Scenario: checking the functionality of HOME link
When HOME link is displayed on Customer Home page and user clicks on HOME link
Then user should Redirect to same (Customer Home) page

@editprofile
Scenario: checking the functionality of EDIT PROFILE link
When EDIT PROFILE link is displayed on Customer Home page and user clicks on EDIT PROFILE link
Then user should Redirect to Edit Profile Page

@moviebooking
Scenario: checking the functionality of MOVIE BOOKING link
When SHOW DETAILS link is displayed on Customer Home page and user clicks on SHOW DETAILS Link
Then user should Redirect to Show Details page

@cancelbooking
Scenario: checking the functionaity of CANCEL BOOKING link
When CANCEL BOOKING link is displayed on Customer Home page and user clicks on CANCEL BOOKING link
Then user should Redirect to Cancel Booking page

@logout
Scenario: checking the functionality of LOGOUT link
When LOGOUT link is displayed on Customer Home page and user clicks on LOGOUT link
Then user should Redirect to Cinema Cafe page

@links
Scenario: Checking if the no. of links in the Customer Home Page is equal to 5
When user counts the no. of the links on the Customer Home page
Then the no. of the links should be equals to 5 