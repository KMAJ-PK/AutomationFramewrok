@SwagLabs
Feature: Removing Products FromAn Online Order
	A subscribed user can remove product(s) from the cart, ensuring the cart contains the wanted items

Background:
    Given that i am on the login page
		And that I have entered a valid username and password

Scenario: Removing an item from the basket will show option to add again
	Given that I am on the inventory page with items in my basket
	When I click 'Remove' on an item I have in my basket
	Then it will change the 'Remove' button to 'Add to cart'
		And it will reduce the basket counter icon accordingly

Scenario: Option to Remove products from baskets individually
	Given that I have multiple items in my basket
	When I visit the basket page
	Then I can see options to remove each product present from the basket

Scenario: Remove a product from the basket
	Given that I am on the basket page with multiple items in it
	When I click to 'Remove' a product
	Then it will remove the item from the basket
		And it will reduce the basket counter icon by 1

Scenario: Remove the only item from the basket will close the basket
	Given that I am on the basket page with an item in it
	When I click to 'Remove' a product
	Then it will remove the item from the basket
		And it will remove the basket counter icon