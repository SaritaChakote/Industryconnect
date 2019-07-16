Feature: ProfilePageFeature
	In order to update my profile 
	As a skill trader
	I want to update the language that I added

@mytag
Scenario: Update Language
	Given i am on Language tab
	And language is available in list
	When I try to edit and update language
	Then the language should get updated successfully

Scenario: add duplicate Language
	Given i am on Language tab
	And added Marathi language with Basic lavel
	When i am adding Marathi language again with Fluent
	Then it should show the message Duplicate data

Scenario: Validate if more than 5th language get added
	Given i am on Language tab
	When 4 languages were already added
	Then Add button should get invisible

Scenario: Add duplicate Skill
	Given i am on skills tab
	And C is already added with Basic level
	When i try to add c with Basic level again
	Then it should trough some message