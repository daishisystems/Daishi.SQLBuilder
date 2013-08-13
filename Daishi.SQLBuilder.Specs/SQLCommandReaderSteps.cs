#region Includes

using System.Configuration;
using System.Data.SqlClient;
using NUnit.Framework;
using TechTalk.SpecFlow;

#endregion

namespace Daishi.SQLBuilder.Specs {
    [Binding]
    public class SQLCommandReaderSteps {
        private SQLBuilder builder;

        [Given(@"I have invoked a select command")]
        public void GivenIHaveInvokedASelectCommand() {
            var connectionString = ConfigurationManager.ConnectionStrings[@"ePlanner"].ConnectionString;
            builder = new SQLBuilder(connectionString) {Command = {CommandType = SQLCommandType.Reader}};
            ;

            builder.Select(@"*").From(@"holiday");
        }

        [Given(@"SQLCommand is in read-mode")]
        public void GivenSQLCommandIsInRead_Mode() {
            Assert.AreEqual(SQLCommandType.Reader, builder.Command.CommandType);
        }

        [When(@"the requested data is returned")]
        public void WhenTheRequestedDataIsReturned() {
            builder.Execute();
        }

        [Then(@"the rows are persisted to a SQLDataReader")]
        public void ThenTheRowsArePersistedToASQLDataReader() {
            var reader = builder.Command.Result as SqlDataReader;

            try {
                Assert.IsNotNull(reader);
                reader.Read();

                var id = reader.GetInt32(0);
                var description = reader.GetString(2);

                Assert.AreEqual(1, id);
                Assert.AreEqual(@"New Years Day", description);
            }
            finally {
                if (reader != null && !reader.IsClosed) reader.Close();
                if (builder.Command.Connection != null) builder.Command.Connection.Dispose();
            }
        }
    }
}