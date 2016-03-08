# Feature for loggin in
# Represents high level reason for tests
Feature: Login
	In order to verify the login process functions correctly
	As a user
	I want to make sure the login process is working

# Login scenario
# this will generate 2 scenarios during compilation,
# one for each row in the 'Examples:' table
@login
Scenario Outline: Login to frakworx2
	Given I am at the login page
	When I login with '<type>' credentials
	Then I should be '<status>' logged into the program

	Examples:
		| type    | status         |
		| valid   | successfully   |
		| invalid | unsuccessfully |
