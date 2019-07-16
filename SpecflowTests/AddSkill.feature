Feature: AddSkillFeature
	In order to update my profile 
	As a skill trader
	I want to add the Skills that I know

@mytag
Scenario Outline: Check if user could able to add a Skill
	Given I clicked on the Skills tab under the Profile page
	When Fill Form using "<Skill>" and "<Level>"
	Then  added Skill should be displayed on my listings
	Examples:
	| TestCase | Skill  | Level  |
	| A        | C      | Beginner  |
	| B        | C++    | Intermediate |
	| c        | C#     | Expert |
	| D        | Java   | Beginner  |
	| E        | QC     | Expert |
	| F        | C  | Expert |

@mytag
Scenario Outline: user want to edit Skill
Given i am on skill tab and "<Skill>" is available
When i edit skill and update using "<Skill>" or "<Level>"
Then updated skill should get displayed on my skill list
Examples:
| TestCase | Skill | Level        |
| A        | C     | Intermediate |
| B        | C++  | Expert |

@mytag
Scenario Outline: user want to delete Skill
Given i am on skill tab and "<Skill>" is available
When i user delete "<Skill>"
Then skill should get deleted from my skill list
Examples:
| TestCase | Skill | Level        |
| A        | C     | Intermediate |

