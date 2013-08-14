#region Includes

using System;
using System.Collections.Generic;
using System.Configuration;
using NUnit.Framework;
using TechTalk.SpecFlow;

#endregion

namespace Daishi.SQLBuilder.Specs {
    [Binding]
    public class SQLBuilderInsertSteps {
        private static string connectionString = ConfigurationManager.ConnectionStrings[@"ePlanner"].ConnectionString;
        private static SQLBatchBuilder sqlBatchBuilder;

        [Given(@"I have provided a SQL insert command")]
        public void GivenIHaveProvidedASQLInsertCommand() {
            connectionString = ConfigurationManager.ConnectionStrings[@"ePlanner"].ConnectionString;
            var sqlInsertor = new SQLBuilder(connectionString, SQLCommandType.NotSet);

            var parameters = new List<string> {@"Member_ExternalId", @"Member_ConsumerId"};
            sqlInsertor.Insert(@"member", parameters, Guid.NewGuid().ToString().Replace(@"-", string.Empty), Guid.NewGuid().ToString().Replace(@"-", string.Empty));

            var sqlSelector = new SQLBuilder(connectionString, SQLCommandType.NotSet);
            sqlSelector.Select(@"scope_identity()");

            sqlBatchBuilder = new SQLBatchBuilder(connectionString, SQLCommandType.Scalar, sqlInsertor, sqlSelector);
        }

        [When(@"I invoke the command")]
        public void WhenIInvokeTheCommand() {
            sqlBatchBuilder.Execute();
        }

        [Then(@"a row is added to the database")]
        public void ThenARowIsAddedToTheDatabase() {
            Assert.IsTrue((decimal) sqlBatchBuilder.Result > 0);
        }

        [After(@"requires_teardown")]
        public static void CleanUp() {
            var sqlDeletor = new SQLBuilder(connectionString, SQLCommandType.Scalar);

            sqlDeletor
                .Delete()
                .From(@"member")
                .Where(@"Member_MemberId")
                .EqualTo(Convert.ToInt32(sqlBatchBuilder.Result));

            sqlDeletor.Execute();
        }
    }
}