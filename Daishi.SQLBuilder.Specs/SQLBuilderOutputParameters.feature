Feature: SQLBuilderOutputParameters
	Ensures that SqpParameters applied to SQLBuilder are applied and returned as output.

Scenario: Add two output parameters to a query
	Given I have generated a SqlCommand
	And I have applied 2 SqlParameters to the command
	When I invoke the parameterised command
	Then the SqlParameters should be output with the command result
