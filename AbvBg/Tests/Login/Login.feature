Feature: Login
	In order to access my e-mail box
	As a registered user
	I want to login into abv.bg

Background:
	Given I am on the Home page

#------------------------------------------------
@positive
Scenario Outline: Login with registered user
	When I enter my '<username>', '<password>' and click on the Login button
	Then I should be logged in successfully and see greeting message with my '<name>'

	Examples:
		| username                    | password  | name           |
		| davidspecflowqhtest1@abv.bg | specflow1 | Specflow User1 |
		| davidspecflowqhtest2@abv.bg | specflow2 | Specflow User2 |

#------------------------------------------------
@negative
Scenario: Try to login with unregistered user
	When I enter my 'NonExistentUser', 'NonExistentPassword' and click on the Login button
	Then I shouldn't be able to login and should see an error message