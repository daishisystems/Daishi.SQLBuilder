#region Includes

using System;
using System.Linq;

#endregion

namespace Daishi.SQLBuilder {
    public class SQLBatchBuilder : ICommand {
        private readonly string connectionString;
        private readonly SQLBuilder[] sqlBuilders;

        public object Result { get; private set; }

        public SQLBatchBuilder(string connectionString, params SQLBuilder[] sqlBuilders) {
            this.connectionString = connectionString;
            this.sqlBuilders = sqlBuilders;
        }

        public void Execute() {
            var sqlBuilder = new SQLBuilder(connectionString) {Command = {CommandText = ToString()}};
            sqlBuilder.Command.CommandType = SQLCommandType.Writer;

            sqlBuilder.Command.Execute();
            Result = sqlBuilder.Command.Result;
        }

        public void Undo() {
            throw new NotImplementedException();
        }

        public override string ToString() {
            return string.Concat(string.Join(@";", sqlBuilders.Select(sb => sb.Command.CommandText)), @";");
        }
    }
}