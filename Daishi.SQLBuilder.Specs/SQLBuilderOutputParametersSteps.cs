#region Includes

using System.Collections.Generic;
using System.Configuration;
using System.Data;
using NUnit.Framework;
using TechTalk.SpecFlow;

#endregion

namespace Daishi.SQLBuilder.Specs {
    [Binding]
    public class SQLBuilderOutputParametersSteps {
        private SQLBuilder builder;

        [Given(@"I have generated a SqlCommand")]
        public void GivenIHaveGeneratedASqlCommand() {
            var connectionString = ConfigurationManager.ConnectionStrings[@"ePlanner"].ConnectionString;
            builder = new SQLBuilder(connectionString, SQLCommandType.Scalar);
        }

        [Given(@"I have applied (.*) SqlParameters to the command")]
        public void GivenIHaveAppliedSqlParametersToTheCommand(int p0) {
            var parameters = new List<SQLParameter> {
                new SQLParameter(@"Holiday_Date", @"date", SqlDbType.Date, ParameterDirection.Output),
                new SQLParameter(@"Holiday_Description", @"description", SqlDbType.NVarChar, 60, ParameterDirection.Output)
            };

            builder.Select(parameters)
                   .From(@"Holiday")
                   .Where(@"Holiday_HolidayId")
                   .EqualTo(1);
        }

        [When(@"I invoke the parameterised command")]
        public void WhenIInvokeTheParameterisedCommand() {
            builder.Execute();
        }

        [Then(@"the SqlParameters should be output with the command result")]
        public void ThenTheSqlParametersShouldBeOutputWithTheCommandResult() {
            Assert.AreEqual(SqlDbType.Date, builder.Parameters[0].SqlDbType);
            Assert.AreEqual(SqlDbType.NVarChar, builder.Parameters[1].SqlDbType);

            Assert.NotNull(builder.Parameters[0].Value);
            Assert.NotNull(builder.Parameters[1].Value);
        }
    }
}