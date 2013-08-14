#region Includes

using System.Collections.Generic;
using System.Linq;

#endregion

namespace Daishi.SQLBuilder {
    public class SQLBatchBuilder : SQLBuilder {
        private readonly IEnumerable<SQLBuilder> sqlBuilders;

        public SQLBatchBuilder(string connectionString, SQLCommandType commandType, params SQLBuilder[] sqlBuilders) : base(connectionString, commandType) {
            this.sqlBuilders = sqlBuilders;
        }

        public SQLBatchBuilder(string connectionString, SQLCommandType commandType, IEnumerable<SQLBuilder> sqlBuilders) : base(connectionString, commandType) {
            this.sqlBuilders = sqlBuilders;
        }

        public override void Execute() {
            Command.CommandText = ToString();

            Command.Execute();
            Result = Command.Result;
        }

        public override string ToString() {
            return string.Concat(string.Join(@";", sqlBuilders.Select(sb => sb.ToString())), @";");
        }
    }
}