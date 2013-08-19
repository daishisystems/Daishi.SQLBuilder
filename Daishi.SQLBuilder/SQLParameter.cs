#region Includes

using System.Data;
using System.Data.SqlClient;

#endregion

namespace Daishi.SQLBuilder {
    public class SQLParameter {
        private readonly string columnMapping;

        public string ColumnMapping { get { return columnMapping; } }
        public SqlParameter Parameter { get; private set; }

        public SQLParameter(string columnMapping, string parameterName, SqlDbType sqlDbType, ParameterDirection parameterDirection) {
            this.columnMapping = columnMapping;
            Parameter = new SqlParameter(parameterName, sqlDbType) {
                Direction = parameterDirection
            };
        }

        public SQLParameter(string columnMapping, string parameterName, SqlDbType sqlDbType, int size, ParameterDirection parameterDirection) {
            this.columnMapping = columnMapping;
            Parameter = new SqlParameter(parameterName, sqlDbType, size) {
                Direction = parameterDirection
            };
        }
    }
}