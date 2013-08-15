#region Includes

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using NUnit.Framework;
using TechTalk.SpecFlow;

#endregion

namespace Daishi.SQLBuilder.Specs {
    [Binding]
    public class SQLBuilderParameterisedSelectSteps {
        private SQLBuilder builder;
        private string rawCommandText;

        [Given(@"I have generated a parameterised Select command")]
        public void GivenIHaveGeneratedAParameterisedSelectCommand() {
            builder = new SQLBuilder(string.Empty, SQLCommandType.NotSet);

            var parameters = new List<SQLParameter> {
                new SQLParameter {
                    ColumnMapping = @"Holiday_Date",
                    Parameter = new SqlParameter(@"@date", SqlDbType.Date)
                },
                new SQLParameter {
                    ColumnMapping = @"Holiday_Description",
                    Parameter = new SqlParameter(@"@description", SqlDbType.NVarChar, 60)
                }
            };

            builder.Select(parameters);
        }

        [When(@"I view the raw command text")]
        public void WhenIViewTheRawCommandText() {
            rawCommandText = builder.ToString();
        }

        [Then(@"the command text should be formatted correctly")]
        public void ThenTheCommandTextShouldBeFormattedCorrectly() {
            Assert.AreEqual(Resources.ParameterisedSQL, rawCommandText);
        }
    }
}