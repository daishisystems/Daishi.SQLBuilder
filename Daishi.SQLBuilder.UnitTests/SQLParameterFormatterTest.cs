#region Includes

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using NUnit.Framework;

#endregion

namespace Daishi.SQLBuilder.UnitTests {
    [TestFixture]
    internal class SQLParameterFormatterTest {
        [Test]
        public void SQLParameterFormatterFormatsSelectStatementWithParameters() {
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

            var formatter = new SQLParameterFormatter(parameters);
            formatter.Execute();

            Assert.AreEqual(Resources.ParameterisedSQL, formatter.Result.ToString());
        }
    }
}