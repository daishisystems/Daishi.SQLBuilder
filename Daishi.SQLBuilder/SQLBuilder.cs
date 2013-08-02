namespace Daishi.SQLBuilder {
    public class SQLBuilder {
        public SQLBuilder(string connectionString) {
            Command = new SQLCommand(connectionString);
        }

        public SQLCommand Command { get; set; }
    }
}