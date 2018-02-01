@aadminhome
Feature: checking the functionality of Add Movies page
Background: 
Given user should be on Add Movies page

@title
Scenario: checking the title of the Admin Home Page
When Admin Home page is opened
Then the title of page should be Admin Home

@Home
Scenario: checking the functionality of Home link
When Home link is displayed on Admin Home page and admin clicks on Home link
Then admin will redirect to the same(Admin Home) page

@addmovie
Scenario: checking the functionality of Add Movie link
When Add movie link is displayed on Admin Home page and admin clicks on Add Movie link
Then admin will redirect to the Add Movie Page

@Updatemovie
Scenario: checking the fuctionality of Update Movie link
When Update Movie link is displayed on Admin Home page and admin clicks on Update Movie link
Then admin will redirect to the Update Movie Page

@Updateprice
Scenario: checking the functionality of Update Price link
When Update Price link is displayed on Admin Home page and admin clicks on Update Price link
Then admin will redirect to the Update Price Page

@logout
Scenario: checking the functionality of LOGOUT link
When LOGOUT link is displayed on Add Movies page and admin clicks on LOGOUT link
Then admin will Redirect to the Cinema Cafe Page

@links
Scenario: checking if the no. of links in the Admin Home Page is equal to 5
When Admin counts the no. of links in Admin Home Page
Then No. of links should be equal to 5