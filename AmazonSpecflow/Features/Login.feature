Feature: Amazon Login
		As a User I can login to my Amazon account to view User Amazon Page

@mytag
Scenario: User should be able to login using valid credentials
	Given User Navigated to Amazon Url Page
	When User enetered valid Credentials
	And  Click on SignIn button
	Then the application displays Users Amazon Home Page.
