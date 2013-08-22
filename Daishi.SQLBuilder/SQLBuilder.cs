#region Includes

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

#endregion

namespace Daishi.SQLBuilder {
    public class SQLBuilder : ICommand, IDisposable {
        private bool disposed;
        protected SQLCommand command;

        public object Result { get; protected set; }
        public SqlParameter[] Parameters { get { return command.Parameters; } }
        public SQLCommandType CommandType { get { return command.CommandType; } }

        public SQLBuilder(string connectionString, SQLCommandType commandType) {
            command = new SQLCommand(connectionString) {CommandType = commandType};
        }

        public virtual void Execute() {
            command.Execute();
            Result = command.Result;
        }

        public void Undo() {
            throw new NotImplementedException();
        }

        #region Builders

        public SQLBuilder Select(params string[] columnNames) {
            command.CommandText = string.Concat(@"select ", string.Join(@",", columnNames), command.CommandText);
            return this;
        }

        public SQLBuilder Select(IEnumerable<string> columnNames) {
            command.CommandText = string.Concat(@"select ", string.Join(@",", columnNames), command.CommandText);
            return this;
        }

        public SQLBuilder Select(params SQLParameter[] parameters) {
            var formatter = new SQLParameterFormatter(parameters);
            formatter.Execute();

            command.Parameters = parameters.Select(p => p.Parameter).ToArray();
            command.CommandText = string.Concat(formatter.Result, command.CommandText);

            return this;
        }

        public SQLBuilder Select(IEnumerable<SQLParameter> parameters) {
            var @params = parameters.ToList();

            var formatter = new SQLParameterFormatter(@params);
            formatter.Execute();

            command.Parameters = @params.Select(p => p.Parameter).ToArray();
            command.CommandText = string.Concat(formatter.Result, command.CommandText);

            return this;
        }

        public SQLBuilder From(params string[] tableNames) {
            command.CommandText = string.Concat(command.CommandText, @" from ", string.Join(@",", tableNames.Select(tn => string.Concat(@"dbo.", tn))));
            return this;
        }

        public SQLBuilder Insert(string tableName, IEnumerable<string> parameters, params object[] values) {
            var stringBuilder = new StringBuilder(@" values (");
            var formattedValues = new List<string>();

            foreach (var value in values) {
                if (value is int || value is byte || value.ToString().StartsWith(@"@")) formattedValues.Add(value.ToString());
                else formattedValues.Add(string.Concat(@"'", value, @"'"));
            }

            stringBuilder.Append(string.Join(@",", formattedValues));
            stringBuilder.Append(@")");

            command.CommandText = string.Concat(command.CommandText, @"insert dbo.", tableName, @" (", string.Join(@",", parameters), @")", stringBuilder);
            return this;
        }

        public SQLBuilder Delete() {
            command.CommandText = string.Concat(command.CommandText, @"delete");
            return this;
        }

        public SQLBuilder Delete(string tableName) {
            command.CommandText = string.Concat(command.CommandText, @"delete ", @"dbo.", tableName);
            return this;
        }

        public SQLBuilder Where(string columnName) {
            command.CommandText = string.Concat(command.CommandText, @" where ", columnName);
            return this;
        }

        public SQLBuilder Where(string tableName, string columnName) {
            command.CommandText = string.Concat(command.CommandText, @" where ", tableName, @".", columnName);
            return this;
        }

        public SQLBuilder EqualTo(int identifier) {
            command.CommandText = string.Concat(command.CommandText, @"=", identifier);
            return this;
        }

        public SQLBuilder EqualTo(string identifier) {
            command.CommandText = string.Concat(command.CommandText, @"=", string.Concat(@"'", identifier, @"'"));
            return this;
        }

        public SQLBuilder NotEqualTo(int identifier) {
            command.CommandText = string.Concat(command.CommandText, @"!=", identifier);
            return this;
        }

        public SQLBuilder NotEqualTo(string identifier) {
            command.CommandText = string.Concat(command.CommandText, @"!=", string.Concat(@"'", identifier, @"'"));
            return this;
        }

        public SQLBuilder In(params int[] constraints) {
            command.CommandText = string.Concat(command.CommandText, @" in (", string.Join(@",", constraints), @")");
            return this;
        }

        public SQLBuilder In(IEnumerable<int> constraints) {
            command.CommandText = string.Concat(command.CommandText, @" in (", string.Join(@",", constraints), @")");
            return this;
        }

        public SQLBuilder In(params string[] constraints) {
            command.CommandText = string.Concat(command.CommandText, @" in (", string.Join(@",", constraints.Select(c => string.Concat(@"'", c, @"'"))), @")");
            return this;
        }

        public SQLBuilder In(IEnumerable<string> constraints) {
            command.CommandText = string.Concat(command.CommandText, @" in (", string.Join(@",", constraints.Select(c => string.Concat(@"'", c, @"'"))), @")");
            return this;
        }

        public SQLBuilder And(string columnName) {
            command.CommandText = string.Concat(command.CommandText, @" and ", columnName);
            return this;
        }

        public SQLBuilder Or(string columnName) {
            command.CommandText = string.Concat(command.CommandText, @" or ", columnName);
            return this;
        }

        public SQLBuilder InnerJoin(
            string rightTableName,
            string leftTableName,
            string leftColumnName,
            string rightColumnName
            ) {
            command.CommandText = string.Concat(command.CommandText, @" inner join dbo.",
                                                rightTableName, @" on dbo.", leftTableName, @".",
                                                leftColumnName, @"=dbo.", rightTableName, @".", rightColumnName);
            return this;
        }

        public SQLBuilder LeftJoin(
            string rightTableName,
            string leftTableName,
            string leftColumnName,
            string rightColumnName
            ) {
            command.CommandText = string.Concat(command.CommandText, @" left join dbo.",
                                                rightTableName, @" on dbo.", leftTableName, @".",
                                                leftColumnName, @"=dbo.", rightTableName, @".", rightColumnName);
            return this;
        }

        public SQLBuilder Raw(string sql) {
            command.CommandText = string.Concat(sql, command.CommandText);
            return this;
        }

        #endregion

        public override string ToString() {
            return command.CommandText;
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) {
            if (disposed || !disposing) return;
            if (command != null) command.Dispose();

            command = null;
            disposed = true;
        }
    }
}