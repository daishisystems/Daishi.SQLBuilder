#region Includes

using System.Linq;

#endregion

namespace Daishi.SQLBuilder {
    public class SQLBatchBuilder : SQLBuilder {
        private readonly SQLBuilder[] sqlBuilders;

        public SQLBatchBuilder(string connectionString, params SQLBuilder[] sqlBuilders) : base(connectionString) {
            this.sqlBuilders = sqlBuilders;
        }

        public override void Execute() {
            Command.CommandText = ToString();
            Command.CommandType = SQLCommandType.Writer;

            Command.Execute();
            Result = Command.Result;
        }

        public override string ToString() {
            return string.Concat(string.Join(@";", sqlBuilders.Select(sb => sb.Command.CommandText)), @";");
        }
    }
}