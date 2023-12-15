using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Dynamic;

namespace Backend.Helpers
{
    public static class SPHelper
    {
        public static async Task<IList<IList<ExpandoObject>>> GetAllAsync(
            DbContext context,
            string storedProcedureName,
            IEnumerable<SqlParameter> parameters)
        {
            IList<IList<ExpandoObject>> data = new List<IList<ExpandoObject>>();

            var command = context.Database.GetDbConnection().CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = storedProcedureName;
            command.CommandTimeout = 120;

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
                using (var reader = await command.ExecuteReaderAsync())
                {
                    do
                    {
                        var temp = new List<ExpandoObject>();
                        while (await reader.ReadAsync())
                        {
                            var row = new ExpandoObject();
                            var rowData = (IDictionary<string, object>)row;

                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                rowData.Add(reader.GetName(i), reader[i]);
                            }

                            temp.Add(row);
                        }
                        data.Add(temp);
                    } while (await reader.NextResultAsync());
                }
            }

            return data;
        }

    }
}
