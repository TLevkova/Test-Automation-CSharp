Feature: Send New Message
	In order to send new message
	As a logged user
	I want to go to the Create New Message page
	And to be able to create new message

Background:
	Given I am logged in and on the mailbox page

@positive
Scenario: Send new message
	When I click on the 'New Message' button
	And write in the message box the following message:
		"""
		Dear user,
		
		This is a multiple lines test message.

		Best regards,
		SpecFlow Test User
		"""
	And send the message with the following message data:
		| Receiver                  | Subject    |
		| tlevkova@qualityhouse.com | Test Email |
	Then I should see a confirmation message for successfully sent email

@positive @test
Scenario Outline: Send new personalized message
	When I click on the 'New Message' button
	And write in the message box the following message:
		"""
		Dear <Receiver Name>,
		
		This is a multiple lines test message.

		Best regards,
		SpecFlow Test User
		"""
	And send the message with the following message data:
		| Receiver   | Subject   |
		| <Receiver> | <Subject> |
	Then I should see a confirmation message for successfully sent email

	Examples:
		| Receiver                  | Subject    | Receiver Name   |
		| tlevkova@qualityhouse.com | Test Email | Teodora Levkova |