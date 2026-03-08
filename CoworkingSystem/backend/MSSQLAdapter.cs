using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem.backend
{
    internal class MsSqlAdapter : IDatabaseAdapter
    {
        public string GetLastInsertIdQuery()
        {
            return "SELECT CAST(SCOPE_IDENTITY() AS int)";
        }

        public string GetCurrentDateTimeFunction()
        {
            return "GETDATE()";
        }

        public string GetAutoIncrementDefinition()
        {
            return "IDENTITY(1,1)";
        }

        public bool GetBooleanValue(object dbValue)
        {
            return Convert.ToBoolean(dbValue);
        }

        public object CreateParameter(string name, object value)
        {
            if (value == null)
            {
                value = DBNull.Value;
            }

            return new SqlParameter(name, value);
        }

        public string GetLimitClause(int limit, int offset)
        {
            return $"OFFSET {offset} ROWS FETCH NEXT {limit} ROWS ONLY";
        }

        public string GetTimeDifferenceInHours(string start, string end)
        {
            return $"DATEDIFF(HOUR, {start}, {end})";
        }

        public string GetTimePartExpression(string expression)
        {
            return $"CAST({expression} AS TIME)";
        }

        public string GetRadnoVremeStartExpression(string columnName)
        {
            return $"CAST(SUBSTRING({columnName}, 1, 5) AS TIME)";
        }

        public string GetRadnoVremeEndExpression(string columnName)
        {
            return $"CAST(SUBSTRING({columnName}, 7, 5) AS TIME)";
        }
    }
}
