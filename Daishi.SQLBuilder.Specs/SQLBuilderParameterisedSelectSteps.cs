#region Includes

using System.Collections.Generic;
using System.Data;
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
                new SQLParameter(@"Holiday_Date", @"date", SqlDbType.Date, ParameterDirection.Output),
                new SQLParameter(@"Holiday_Description", @"description", SqlDbType.NVarChar, 60, ParameterDirection.Output)
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