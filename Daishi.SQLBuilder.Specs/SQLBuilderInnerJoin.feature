Feature: SQLBuilderInnerJoin
	Ensure that Inner Joins are correctly applied to SQL commands.

Scenario: Apply an Inner Join to a SQL Command
	Given I have generated a SQL Command
	And I have applied an Inner Join to the command
	When I invoke the joined command
	Then the Inner Join should be applied to the returned dataset
