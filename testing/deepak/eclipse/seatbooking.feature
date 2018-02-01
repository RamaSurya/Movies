@moviebooking
Feature: checking the functionality of Movie Booking page
Background:
Given user should be on Movie Booking page

@HOME
Scenario: checking the functionality of HOME link
When user clicks on the HOME link displayed on the Customer Home page
Then user will redirect to the Customer Home page

@EDITPROFILE
Scenario: checking the functionality of EDIT PROFILE link
When user clicks on the EDIT PROFILE link displayed on the Customer Home page
Then user will redirect to the EDIT PROFILE page

@MOVIEBOOKING
Scenario: checking the functionality of MOVIE BOOKING link
When user clicks on the MOVIE BOOKING link displayed on the Customer Home page
Then user will redirect to the MOVIE BOOKING page

@CANCELBOOKING
Scenario: checking the functionality of CANCEL BOOKING link
When user clicks on the CANCEL BOOKING link displayed on the Customer Home page
Then user will redirect to the CANCEL BOOKING page

@LOGOUT
Scenario: checking the functionality of LOGOUT link
When user clicks on the LOGOUT link displayed on the Customer Home page
Then user will redirect to the Cinema Cafe page

@clickseat
Scenario: checking if colour of the seat is changing from yellow to green on click
When user clicks on a seat displayed in the Seat Booking page
Then the colour of seat changes to green

@clickseat2
Scenario: checking if colour of the seat is changing from green to yellow by clicking again on selected seat
When user clicks on a selected seat 
Then the colour of seat changes to yellow

@blueseat
Scenario: checking if a user can book already booked seat
When user clicks on a booked seat
Then user gets message -This seat is already reserved

@confirmseat
Scenario: checking the functionality of confirm button
When user selects a seat and click on the confirm button
Then the details of the ticket will be displayed at the textboxes

@cofirmseat1
Scenario: checking the functionality of confirm button with no seat is selected
When user has not selected any seat and clicks on the confirm button
Then user gets message-no seat is selected