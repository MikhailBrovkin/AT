Feature: Remove new product

I'm removing a new product to the Nordwind database

Scenario: Remove product
	Given I'm logging
	When I go to products page and remove product
	Then All right
