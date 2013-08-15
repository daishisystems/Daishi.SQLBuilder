#region Includes

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace Daishi.SQLBuilder {
    public class SQLParameterFormatter : ICommand {
        private readonly IEnumerable<SQLParameter> parameters;

        public object Result { get; private set; }

        public SQLParameterFormatter(IEnumerable<SQLParameter> parameters) {
            this.parameters = parameters;
        }

        public void Execute() {
            var builder = new StringBuilder(@"select ");

            foreach (var parameter in parameters)
                builder.Append(string.Concat(parameter.Parameter.ParameterName, @"=", parameter.ColumnMapping, @","));

            Result = builder.ToString().TrimEnd(',');
        }

        public void Undo() {
            throw new NotImplementedException();
        }
    }
}