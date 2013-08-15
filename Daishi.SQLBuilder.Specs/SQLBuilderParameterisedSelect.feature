Feature: SQLBuilderParameterisedSelect
	Ensures that parameterised Select commands are formatted correctly

Scenario: Invoke parameterised Select command
	Given I have generated a parameterised Select command	
	When I view the raw command text
	Then the command text should be formatted correctly
