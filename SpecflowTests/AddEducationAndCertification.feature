Feature: Add Education and Certifications
	In order to add education and certification

@mytag
Scenario: Add Education
	Given I clicked on the Education tab on profile page
	When I add a new Education
	Then It should be displayed under Education on my profile

@mytag
Scenario: Add Certification
	Given I clicked on the Certification tab on profile page
	When I add a new Certification
	Then It should be displayed under Certification on my profile
