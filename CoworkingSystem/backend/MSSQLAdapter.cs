using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem.backend
{
    internal class MSSQLAdapter : DatabaseAdapter
    {
        public MSSQLAdapter() : base()
        {
        }
        public override object CreateParameter(string name, object value)
        {
            return new SqlParameter(name, value);
        }

        public override string GetLastInsertIdQuery()
        {
            return "SELECT SCOPE_IDENTITY()";
        }

        public override string GetCurrentDateTimeFunction()
        {
            return "GETDATE()";
        }

        public override string GetAutoIncrementDefinition()
        {
            return "IDENTITY(1,1)";
        }

        public override string GetUid()
        {
            return "UNIQUEIDENTIFIER";
        }

        public override bool GetBooleanValue(object dbValue)
        {
            if (dbValue == null || dbValue == DBNull.Value)
                return false;

            return Convert.ToBoolean(dbValue);
        }

        
    }
}
