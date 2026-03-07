using Microsoft.Data.SqlClient;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem.backend
{
    internal class MySqlAdapter : IDatabaseAdapter
    {
        public string GetLastInsertIdQuery()
        {
            return "SELECT LAST_INSERT_ID()";
        }

        public string GetCurrentDateTimeFunction()
        {
            return "NOW()";
        }

        public string GetAutoIncrementDefinition()
        {
            return "AUTO_INCREMENT";
        }

        public bool GetBooleanValue(object dbValue)
        {
            return Convert.ToInt32(dbValue) == 1;
        }

        public object CreateParameter(string name, object value)
        {
            if (value == null)
            {
                value = DBNull.Value;
            }

            return new MySqlParameter(name, value);
        }

        public string GetLimitClause(int limit, int offset)
        {
            return $"LIMIT {limit} OFFSET {offset}";
        }

        public string GetTimeDifferenceInHours(string start, string end)
        {
            return $"TIMESTAMPDIFF(HOUR, {start}, {end})";
        }

        public string GetTimePartExpression(string expression)
        {
            return $"TIME({expression})";
        }

        public string GetRadnoVremeStartExpression(string columnName)
        {
            return $"STR_TO_DATE(SUBSTRING({columnName}, 1, 5), '%H:%i')";
        }

        public string GetRadnoVremeEndExpression(string columnName)
        {
            return $"STR_TO_DATE(SUBSTRING({columnName}, 7, 5), '%H:%i')";
        }
    }
}
