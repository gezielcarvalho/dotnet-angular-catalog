using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Dynamic;

namespace Backend.Helpers
{
    public static class SPHelper
    {
        private const int COMMAND_TIMEOUT = 120;

        public static async Task<IList<IList<ExpandoObject>>> GetAllAsync(
            DbContext context,
            string storedProcedureName,
            IEnumerable<SqlParameter> parameters)
        {
            IList<IList<ExpandoObject>> data = new List<IList<ExpandoObject>>();

            var command = context.Database.GetDbConnection().CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = storedProcedureName;
            command.CommandTimeout = COMMAND_TIMEOUT;

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }

            using (command)
            {
                await context.Database.OpenConnectionAsync();
                using var reader = await command.ExecuteReaderAsync();
                do
                {
                    var temp = new List<ExpandoObject>();
                    while (await reader.ReadAsync())
                    {
                        var row = new ExpandoObject();
                        var rowData = row as IDictionary<string, object>;

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            rowData.Add(reader.GetName(i), reader[i]);
                        }

                        temp.Add(row);
                    }
                    data.Add(temp);
                } while (await reader.NextResultAsync());
            }

            return data;
        }

        public static async Task<ExpandoObject> GetOneOrExecAsync(
        DbContext context,
        string storedProcedureName,
        IEnumerable<SqlParameter> parameters)
        {
            ExpandoObject result = null!;

            var command = context.Database.GetDbConnection().CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = storedProcedureName;
            command.CommandTimeout = COMMAND_TIMEOUT;

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }

            using (command)
            {
                await context.Database.OpenConnectionAsync();
                using var reader = await command.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    result = new ExpandoObject();
                    var rowData = result as IDictionary<string, object>;

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        rowData.Add(reader.GetName(i), reader[i]);
                    }
                }
            }

            return result;
        }

        public static IList<IList<ExpandoObject>> GetAll(
        DbContext context,
        string storedProcedureName,
        IEnumerable<SqlParameter> parameters)
        {
            IList<IList<ExpandoObject>> data = new List<IList<ExpandoObject>>();

            var command = context.Database.GetDbConnection().CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = storedProcedureName;
            command.CommandTimeout = COMMAND_TIMEOUT;

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }

            using (command)
            {
                context.Database.OpenConnection();
                using var reader = command.ExecuteReader();
                do
                {
                    var temp = new List<ExpandoObject>();
                    while (reader.Read())
                    {
                        var row = new ExpandoObject();
                        var rowData = row as IDictionary<string, object>;

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            rowData.Add(reader.GetName(i), reader[i]);
                        }

                        temp.Add(row);
                    }
                    data.Add(temp);
                } while (reader.NextResult());
            }

            return data;
        }

        public static ExpandoObject GetOneOrExec(
            DbContext context,
            string storedProcedureName,
            IEnumerable<SqlParameter> parameters)
        {
            ExpandoObject result = null!;

            var command = context.Database.GetDbConnection().CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = storedProcedureName;
            command.CommandTimeout = COMMAND_TIMEOUT;

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }

            using (command)
            {
                context.Database.OpenConnection();
                using var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = new ExpandoObject();
                    var rowData = result as IDictionary<string, object>;

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        rowData.Add(reader.GetName(i), reader[i]);
                    }
                }
            }

            return result;
        }

    }
}
