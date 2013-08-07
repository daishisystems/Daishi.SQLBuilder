Feature: SQLCommandReader
	Ensure that datasets returned from SQLCommand in SQLCommandType.Reader are persisted to a SQLDataReader

Scenario: Read data
	Given I have invoked a select command
	And SQLCommand is in read-mode
	When the requested data is returned
	Then the rows are persisted to a SQLDataReader
