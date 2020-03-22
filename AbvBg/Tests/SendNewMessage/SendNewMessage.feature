Feature: Send New Message
	In order to send new message
	As a logged user
	I want to go to the Create New Message page
	And to be able to create new message

Background:
	Given I am logged in and on the mailbox page

@positive
Scenario: Send new message
	When I click on New Message button
	And write in the message box the following message
		"""
		Hi! This is a multiple lines test message.

		Best regards,
		SpecFlow Test User
		"""
	And send the message with the following message info:
		| Receiver                  | Subject    |
		| tlevkova@qualityhouse.com | Test Email |
	Then I should see a confirmation message for successfully sent email