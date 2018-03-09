Feature: CreateAccount
	Amazon New User Account Registration

@mytag
Scenario:User should be able to create new account
    Given User Navigated to Amazon Url Page
	When Clicked on New User the browser should be redirected to createAccount page
	And User User entered Name,email, passowrd, re-password
	And Clicked on CreateAccount Button
	Then the application displays Users Amazon Home Page.
