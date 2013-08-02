Feature: SQLBuilderInsert
	Ensure that SQL commands are correctly applied by the SQLCommand component.

Scenario: Insert data
	Given I have provided a SQL insert command	
	When I invoke the command
	Then a row is added to the database