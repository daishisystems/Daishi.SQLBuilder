#region Includes

using System;
using System.Data.SqlClient;

#endregion

namespace Daishi.SQLBuilder {
    public class SQLCommand : ICommand, IDisposable {
        private readonly string connectionString;
        private bool disposed;
        private SqlConnection connection;
        private SqlCommand command;

        public object Result { get; private set; }
        public string CommandText { get; set; }
        public SQLCommandType CommandType { get; set; }
        public SqlParameter[] Parameters { get; set; }

        public SQLCommand(string connectionString) {
            this.connectionString = connectionString;
        }

        public void Execute() {
            switch (CommandType) {
                case SQLCommandType.Reader:
                    connection = new SqlConnection(connectionString);
                    connection.Open();

                    using (command = connection.CreateCommand()) {
                        command.CommandText = CommandText;
                        if (Parameters != null) command.Parameters.AddRange(Parameters);
                        Result = command.ExecuteReader();
                    }

                    break;
                case SQLCommandType.Scalar:
                    using (connection = new SqlConnection(connectionString)) {
                        connection.Open();

                        using (command = connection.CreateCommand()) {
                            command.CommandText = CommandText;
                            if (Parameters != null) command.Parameters.AddRange(Parameters);
                            Result = command.ExecuteScalar();
                        }
                    }
                    break;
                default:
                    throw new NotImplementedException(@"Unspecified SQLCommandType.");
            }
        }

        public void Undo() {
            throw new NotImplementedException();
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) {
            if (disposed || !disposing) return;

            if (command != null) command.Dispose();
            if (connection != null) connection.Dispose();

            command = null;
            connection = null;
            disposed = true;
        }
    }
}