#region Includes

using System;

#endregion

namespace Daishi.SQLBuilder {
    public class SQLBuilder : ICommand {
        public SQLCommand Command { get; private set; }
        public object Result { get; protected set; }

        public SQLBuilder(string connectionString) {
            Command = new SQLCommand(connectionString);
        }

        public virtual void Execute() {
            Command.Execute();
            Result = Command.Result;
        }

        public void Undo() {
            throw new NotImplementedException();
        }
    }
}