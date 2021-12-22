Feature: Logout

I want to disconnect to Northwind database

Scenario: Disconnect from DB
	Given I connect to db
	When I click logout
	Then I disconnect from db
