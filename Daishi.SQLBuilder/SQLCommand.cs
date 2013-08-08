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
        public SqlConnection Connection { get; private set; }

        public SQLCommand(string connectionString) {
            this.connectionString = connectionString;
        }

        public void Execute() {
            switch (CommandType) {
                case SQLCommandType.Reader:
                    Connection = new SqlConnection(connectionString);
                    Connection.Open();

                    using (var command = Connection.CreateCommand()) {
                        command.CommandText = CommandText;
                        Result = command.ExecuteReader();
                    }

                    break;
                case SQLCommandType.Writer:
                    using (Connection = new SqlConnection(connectionString)) {
                        Connection.Open();

                        using (var command = Connection.CreateCommand()) {
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