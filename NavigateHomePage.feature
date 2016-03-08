# Feature for navigating the home page
Feature: NavigateHomePage
	In order to test funcionality of side bar navigation
	As a user
	I want to verify the side bar navigation works

# View the profile view
@profile
Scenario: View profile
	Given I am on the home page
	When I click the 'My Profile' button
	Then I should see the 'my profile' page

# View the reports view
@reports
Scenario: View reports
	Given I am on the home page
	When I click the 'Reports' button
	Then I should see the 'reports' page

# View the application users view
@app-users
Scenario: View app users
	Given I am on the home page
	When I click the 'Application Users' button
	Then I should see the 'application users' page
