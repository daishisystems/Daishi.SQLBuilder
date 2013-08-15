#region Includes

using System.Data.SqlClient;

#endregion

namespace Daishi.SQLBuilder {
    public class SQLParameter {
        public string ColumnMapping { get; set; }
        public SqlParameter Parameter { get; set; }
    }
}