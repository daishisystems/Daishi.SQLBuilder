#region Includes

using System.Configuration;
using System.Data.SqlClient;
using NUnit.Framework;
using TechTalk.SpecFlow;

#endregion

namespace Daishi.SQLBuilder.Specs {
    [Binding]
    public class SQLBuilderInnerJoinSteps {
        private SQLBuilder builder;

        [Given(@"I have generated a SQL Command")]
        public void GivenIHaveGeneratedASQLCommand() {
            var connectionString = ConfigurationManager.ConnectionStrings[@"ePlanner"].ConnectionString;
            builder = new SQLBuilder(connectionString);

            builder.Select(@"TimeSlot.TimeSlot_TimeSlotId", @"Recurrence.Recurrence_RecurrenceId")
                   .From(@"TimeSlot");
        }

        [Given(@"I have applied an Inner Join to the command")]
        public void GivenIHaveAppliedAnInnerJoinToTheCommand() {
            builder.InnerJoin(@"Recurrence", @"TimeSlot", @"TimeSlot_RecurrenceId", @"Recurrence_RecurrenceId");
        }

        [When(@"I invoke the joined command")]
        public void WhenIInvokeTheJoinedCommand() {
            builder.Execute();
        }

        [Then(@"the Inner Join should be applied to the returned dataset")]
        public void ThenTheInnerJoinShouldBeAppliedToTheReturnedDataset() {
            SqlDataReader reader = null;

            try {
                reader = builder.Result as SqlDataReader;
                Assert.IsNotNull(reader);

                Assert.AreEqual(2, reader.FieldCount);
            }
            finally {
                if (reader != null && !reader.IsClosed) reader.Close();
                if (builder.Command.Connection != null) builder.Command.Connection.Dispose();
            }
        }
    }
}