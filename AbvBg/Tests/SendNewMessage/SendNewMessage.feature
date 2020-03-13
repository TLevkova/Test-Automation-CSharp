Feature: Send New Message
	In order to send new message
	As a logged user
	I want to go to the Create New Message page
	And create new message

Background:
	Given I am logged in and on the mailbox page

@positive
Scenario: Send new message
	When I click on New Message button
	And write 'Hi! This is a test message.' in the message box
	And fill receiver 'tlevkova@qualityhouse.com', subject 'Test Email' and click on Send button
	Then I should see a confirmation message for successfully sent email