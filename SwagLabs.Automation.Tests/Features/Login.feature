Feature: Login

Checks the login process for each user.

Scenario: Valid user can log in and see the Products page
	Given I navigate to the website
	And I see the Login page
	When I log in as '<Username>' with the password '<Password>'
	Then I see the Products page
Examples:
	| Username        | Password     |
	| standard_user   | secret_sauce |
	| problem_user    | secret_sauce |
	
Scenario: Locked out user cannot log in
	Given I navigate to the website
	And I see the Login page
	When I log in as 'locked_out_user' with the password 'secret_sauce'
	Then I see an error message telling me I am locked out
