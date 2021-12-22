Feature: Add new product

I'm adding a new product to the Nordwind database


Scenario: Add product
	Given I'm logging in
	When I go to products page and add product
	Then All good
