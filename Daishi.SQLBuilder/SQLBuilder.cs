#region Includes

using System;

#endregion

namespace Daishi.SQLBuilder {
    public class SQLBuilder : ICommand {
        public SQLCommand Command { get; private set; }
        public object Result { get; protected set; }

        public SQLBuilder(string connectionString, SQLCommandType commandType) {
            Command = new SQLCommand(connectionString) {CommandType = commandType};
        }

        public virtual void Execute() {
            Command.Execute();
            Result = Command.Result;
        }

        public void Undo() {
            throw new NotImplementedException();
        }

        public override string ToString() {
            return Command.CommandText;
        }
    }
}