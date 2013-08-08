#region Includes

using System;
using System.Data.SqlClient;

#endregion

namespace Daishi.SQLBuilder {
    public class SQLTransactionBuilder : ICommand {
        private readonly string connectionString;
        private readonly SQLBuilder[] sqlBuilders;

        public object Result { get; private set; }

        public SQLTransactionBuilder(string connectionString, params SQLBuilder[] sqlBuilders) {
            this.connectionString = connectionString;
            this.sqlBuilders = sqlBuilders;
        }

        public void Execute() {
            using (var connection = new SqlConnection(connectionString)) {
                connection.Open();

                using (var transaction = connection.BeginTransaction()) {
                    try {
                        foreach (var sqlBuilder in sqlBuilders) {
                            using (var command = connection.CreateCommand()) {
                                command.CommandText = sqlBuilder.ToString();
                                command.Transaction = transaction;
                                command.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        Result = true;
                    }
                    catch (Exception) {
                        transaction.Rollback();
                        Result = false;

                        throw;
                    }
                }
            }
        }

        public void Undo() {
            throw new NotImplementedException();
        }
    }
}