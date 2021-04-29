@SwagLabs
Feature: Login Success
	A subscribed member can log-in using credentials, so that the account is securely accessible

Background:
    Given that i am on the login page

Scenario: Login attempt with null credentials produces an error
	When i click login with no username and password
	Then an error will be thorwn below the form stating 'Epic sadface: Username is required'

Scenario: Login attempt with no password produces an error
	Given that I have entered a username but no password
	When i click login 
	Then an error will be thorwn below the form stating 'Epic sadface: Password is required'

Scenario: Login attempt with an incorrect credentials produces an error
	Given that I have entered an incorrect username and password
	When i click login
	Then an error will be thorwn below the form stating 'Epic sadface: Username and password do not match any user in this service'

Scenario: Login with valid credentials results successfully access the inventory
	Given that I have entered a valid username and password
	When I attempt to login
	Then it will successfully redirect me to 'inventory.html'