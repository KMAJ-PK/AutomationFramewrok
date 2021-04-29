@SwagLabs
Feature: Building UpOnline Order
	A subscribed user can add products to a cart to build up an online order

Background:
   Given that i am on the login page
		And that I have entered a valid username and password

Scenario: Clicking Add cart button initiates online order
	Given that I am on the inventory shop page with an empty basket
	When I click 'Add to cart' on a product
	Then it will change the 'Add to cart' button to a 'Remove' button
		And it creates a counter on the basket icon with the value '1' in it

Scenario: Clicking Add cart button increments the product counter
	Given that I am on the inventory shop page with an item in my basket
	When I click 'Add to cart' on a different product
	Then it will increment the basket counter by 1