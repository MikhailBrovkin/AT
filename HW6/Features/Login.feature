Feature: Login

I want to connect to Northwind database

Scenario: Connect to DB
	Given I open "http://localhost:5000" url
	When I write in the login field "user" and in the passwor field "user" and click btn
	Then I connect to db
