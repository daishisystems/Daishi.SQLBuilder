#region Includes

using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

#endregion

namespace Daishi.SQLBuilder.UnitTests {
    [TestFixture]
    internal class SQLBuilderTest {
        [Test]
        public void SQLBuilderWritesCorrectSelectCommand() {
            var sqlBuilder = new SQLBuilder(string.Empty);
            const string correctSQL = @"select *";

            Assert.AreEqual(correctSQL, sqlBuilder.Select(@"*").Command.CommandText);
        }

        [Test]
        public void SQLBuilderWritesCorrectSelectCommandWithMultipleParameters() {
            var sqlBuilder = new SQLBuilder(string.Empty);
            const string correctSQL = @"select FirstName,Surname";

            Assert.AreEqual(correctSQL, sqlBuilder.Select(@"FirstName", @"Surname").Command.CommandText);
        }

        [Test]
        public void SQLBuilderAppendsCorrectFromClause() {
            var sqlBuilder = new SQLBuilder(string.Empty);
            const string correctSQL = @" from dbo.myTable";

            Assert.AreEqual(correctSQL, sqlBuilder.From(@"myTable").Command.CommandText);
        }

        [Test]
        public void SQLBuilderAppendsCorrectFromClauseWithMultipleTables() {
            var sqlBuilder = new SQLBuilder(string.Empty);
            const string correctSQL = @" from dbo.myTable1,dbo.myTable2";

            Assert.AreEqual(correctSQL, sqlBuilder.From(@"myTable1", @"myTable2").Command.CommandText);
        }

        [Test]
        public void SQLBuilderWritesCorrectInsertCommand() {
            var sqlBuilder = new SQLBuilder(string.Empty);

            var dummyPoco = new DummyPOCO {
                Id = 1,
                FirstName = @"Dummy",
                Surname = @"POCO"
            };

            var parameters = new List<string> {@"id", @"firstname", @"surname"};
            const string correctSQL = @"insert into dbo.myTable (id,firstname,surname) values (1,'Dummy','POCO')";

            Assert.AreEqual(correctSQL, sqlBuilder.Insert(@"myTable", parameters, dummyPoco.Id, dummyPoco.FirstName, dummyPoco.Surname).Command.CommandText);
        }

        [Test]
        public void SQLBuilderAppendsEqualsClauseWithIntegerBasedIdentifiers() {
            var sqlBuilder = new SQLBuilder(string.Empty);
            const string correctSQL = @"=1";

            var dummyPOCOWithIntId = new DummyPOCO {Id = 1};
            Assert.AreEqual(correctSQL, sqlBuilder.EqualTo(dummyPOCOWithIntId.Id).Command.CommandText);
        }

        [Test]
        public void SQLBuilderAppendsEqualsClauseWithStringBasedIdentifiers() {
            var sqlBuilder = new SQLBuilder(string.Empty);
            const string correctSQL = @"='Dummy'";

            var dummyPOCOWithIntId = new DummyPOCO {FirstName = @"Dummy"};
            Assert.AreEqual(correctSQL, sqlBuilder.EqualTo(dummyPOCOWithIntId.FirstName).Command.CommandText);
        }

        [Test]
        public void SQLBuilderWritesCorrectDeleteCommand() {
            var sqlBuilder = new SQLBuilder(string.Empty);
            const string correctSQL = @"delete";

            Assert.AreEqual(correctSQL, sqlBuilder.Delete().Command.CommandText);
        }

        [Test]
        public void SQLBuilderAppendsWhereClause() {
            var sqlBuilder = new SQLBuilder(string.Empty);
            const string correctSQL = @" where myColumn";

            Assert.AreEqual(correctSQL, sqlBuilder.Where(@"myColumn").Command.CommandText);
        }

        [Test]
        public void SQLBuilderAppendsInClauseWithIntegerBasedIdentifiers() {
            var sqlBuilder = new SQLBuilder(string.Empty);
            const string correctSQL = @" in (1,2,3)";

            var dummyPOCOsWithIntIds = new List<DummyPOCOWithIntId> {
                new DummyPOCOWithIntId {Id = 1},
                new DummyPOCOWithIntId {Id = 2},
                new DummyPOCOWithIntId {Id = 3}
            };

            Assert.AreEqual(correctSQL, sqlBuilder.In(dummyPOCOsWithIntIds.Select(d => d.Id)).Command.CommandText);
        }

        [Test]
        public void SQLBuilderAppendsInClauseWithStringBasedIdentifiers() {
            var sqlBuilder = new SQLBuilder(string.Empty);
            const string correctSQL = @" in ('One','Two','Three')";

            var dummyPOCOsWithStringIds = new List<DummyPOCOWithStringId> {
                new DummyPOCOWithStringId {Id = @"One"},
                new DummyPOCOWithStringId {Id = @"Two"},
                new DummyPOCOWithStringId {Id = @"Three"}
            };

            Assert.AreEqual(correctSQL, sqlBuilder.In(dummyPOCOsWithStringIds.Select(d => d.Id)).Command.CommandText);
        }
    }
}