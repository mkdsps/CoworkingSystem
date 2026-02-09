using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem.backend
{
    internal class MySQLAdapter : DatabaseAdapter
    {
        public MySQLAdapter() : base()
        {
        }

        public override object CreateParameter(string name, object value)
        {
            return new MySqlParameter(name, value);
        }

        public override string GetLastInsertIdQuery()
        {
            return "SELECT LAST_INSERT_ID()";
        }

        public override string GetCurrentDateTimeFunction()
        {
            return "NOW()";
        }

        public override string GetAutoIncrementDefinition()
        {
            return "AUTO_INCREMENT";
        }

        public override string GetUid()
        {
            return "CHAR(36)";
        }

        public override bool GetBooleanValue(object dbValue)
        {
            if (dbValue == null || dbValue == DBNull.Value)
                return false;

            // MySQL čuva boolean kao TINYINT(1) - 0 ili 1
            return Convert.ToInt32(dbValue) == 1;
        }

        
    }
}
