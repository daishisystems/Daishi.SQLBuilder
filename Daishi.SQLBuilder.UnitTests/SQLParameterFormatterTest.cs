#region Includes

using System.Collections.Generic;
using System.Data;
using NUnit.Framework;

#endregion

namespace Daishi.SQLBuilder.UnitTests {
    [TestFixture]
    internal class SQLParameterFormatterTest {
        [Test]
        public void SQLParameterFormatterFormatsSelectStatementWithParameters() {
            var parameters = new List<SQLParameter> {
                new SQLParameter(@"Holiday_Date", @"date", SqlDbType.Date, ParameterDirection.Output),
                new SQLParameter(@"Holiday_Description", @"description", SqlDbType.NVarChar, 60, ParameterDirection.Output)
            };

            var formatter = new SQLParameterFormatter(parameters);
            formatter.Execute();

            Assert.AreEqual(Resources.ParameterisedSQL, formatter.Result.ToString());
        }
    }
}