@SwagLabs
Feature: Login Form Navigation
	A Subscribed user can use keyboard controls to navigate the login form to verify the page meets accessibility guidelines

Background:
    Given that i am on the login page

Scenario: Clicking the tab control navigates a user from username field to the password field
	Given that I am currently focused on the username field
	When I hit the tab key on username field
	Then it will take me to the password field

Scenario: Clicking the tab control navigates a user from password field to the submit button
	Given that I am currently focused on the password field
	When I hit the tab key on password field
	Then it will take me to the submit button

Scenario: Clicking enter control on a submit button will try to login the user
	Given that I have the submit button in focus
	When I hit the enter key
	Then it will try to log me in
		And an error will be thorwn below the form stating 'Epic sadface: Username is required'