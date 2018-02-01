@UpdatePrice
Feature: checking the functionality of UpdatePrice page
Background: 
Given user should be on the UpdatePrice page


@Home
Scenario: checking the functionality of Home link in Update Price page


When Admin clicks on Home link
Then Admin should be Redirected to the Admin Home page

@AddMovie
Scenario: checking the functionality of Add Movie link in Update Price page


When Admin clicks on Add Movie link
Then Admin should be Redirected to the Update movie Page

@UpdateMovie
Scenario: checking the functionality of Update Movie link in Update Price page

When Admin clicks on Update Movie link
Then Admin should be Redirected to  the Update movie Page

@UpdatePrice
Scenario: checking the functionality of Update Price link in Update Price page


When Admin clicks on Update Price link
Then Admin should be Redirected to same (Update Price )Page

@LOGOUT
Scenario: checking the functionality of LOGOUT link in Update Price page


When Admin clicks on LOGOUT link
Then Admin should be Redirected to the Cinema Cafe Page

@validdata
Scenario: checking the functionality of Update Price page with valid data

When Admin selects Seat type and Admin enters Price and Admin clicks on Update button
Then Admin gets message - Updated the price


@blankPrice
Scenario: checking the functionality of Update Price page with blank Price
When Admin selects Seat type and Admin clicks on Update button
Then Admin gets message - Price is blank.Please provide a price for seats



@Pricealphabet
Scenario: checking the functionality of Update Price page with Price having alphabets

When Admin selects Seat type and Admin enters Price having alphabets and Admin clicks on Update button
Then User gets message -Please enter a number

@Pricespecial
Scenario: checking the functionality of Update Price page with Price having special characters

When Admin enters Seat type and Admin enters Price having special cahracters and Admin clicks on Update button
Then Admin gets message -Please enter a number

@Price<100
Scenario: checking the functionality of Update Price page with Price less than 100

When User enters Seat type and user enters Price less than 100 and user clicks on Update button
Then User gets message -Price must be greater than or equal to 100

@Price>1000
Scenario: checking the functionality of Update Price page with Price greater than 1000

When User enters Seat type  and user enters Price greater than 1000 and user clicks on Update button
Then User gets message -value must be less than or equal to 1000


@dropdown
Scenario: checking the no. of options in Seat type dropdown in Update Price page

When  clicks the Seat type dropdown 
Then User gets 3 options - platinum, silver and gold

@dropdownselect
Scenario: checking the selection of options in Seat type dropdown in Update Price page

When User clicks on Seat type dropdown
Then User gets to select only one options

@nooflinks
Scenario: Checking no. of links is equal to 2 

When User counts number  of linkss
Then links should  be equal to 2 

@noofdropdown
Scenario: Checking no. of dropdowns is equal to 1
When User counts no. of the dropdowns
Then no of dropdowns must be equal to 1

@nooftextboxes
Scenario: Checking no. of textboxes  is equal to 5
When User counts no. of textboxes
Then textboxes should  be equal to 5

@noofbuttons
Scenario: Checking no. of buttons is equal to 1

When user counts total number of buttons in UpdatePrice page
Then B should  be equal to 1