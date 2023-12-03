Feature: Products

Validates the Products page.

Scenario: Standard user can view the expected products.
	Given I navigate to the website
	And I log in as 'standard_user' with the password 'secret_sauce'
	When I am viewing the Products page
	Then I see the '<Product>' with the price $'<Price>'
Examples:
	| Product                  | Price |
	| Sauce Labs Backpack      | 29.99 |
	| Sauce Labs Bike Light    | 9.99  |
	| Sauce Labs Bolt T-Shirt  | 15.99 |
	| Sauce Labs Fleece Jacket | 49.99 |
	| Sauce Labs Onesie        | 7.99  |
	| Sauce Labs T-Shirt (Red) | 15.99 |