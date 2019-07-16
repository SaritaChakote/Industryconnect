Feature: SpecFlowFeature1
	In order to update my profile 
	As a skill trader
	I want to add the languages that I know

@mytag
Scenario Outline: Check if user could able to add a language 
	Given I clicked on the Language tab under the Profile page
	When  Fill the form by using "<Language>" and "<Level>"
	Then  added language should be displayed on my listings
	Examples:
	| TestCase | Language | Level        |
	| A        | Marathi  | Basic        |
	| B        | Hindi    | Fluent       |
	| C        | English  | Fluent       |
	| D        | Marathi  | Intermediate |
	| E        | Kanada   | Basic        |