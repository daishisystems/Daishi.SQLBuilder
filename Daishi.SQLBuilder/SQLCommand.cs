#region Includes

using System;
using System.Data.SqlClient;

#endregion

namespace Daishi.SQLBuilder {
    public class SQLCommand : ICommand {
        private readonly string connectionString;

        public object Result { get; private set; }
        public string CommandText { get; set; }
        public SQLCommandType CommandType { get; set; }

        public SQLCommand(string connectionString) {
            this.connectionString = connectionString;
        }

        public void Execute() {
            switch (CommandType) {
                case SQLCommandType.Reader:
                    throw new NotImplementedException();
                case SQLCommandType.Writer:
                    using (var connection = new SqlConnection(connectionString)) {
                        connection.Open();

                        using (var command = connection.CreateCommand()) {
                            command.CommandText = CommandText;
                            Result = command.ExecuteScalar();
                        }
                    }
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public void Undo() {
            throw new NotImplementedException();
        }
    }
}