Feature: NavigateHomePage
	In order to test funcionality of side bar navigation
	As a user
	I want to verify the side bar navigation works

@profile
Scenario: View profile
	Given I am on the home page
	When I click the 'My Profile' button
	Then I should see the 'my profile' page

@reports
Scenario: View reports
	Given I am on the home page
	When I click the 'Reports' button
	Then I should see the 'reports' page