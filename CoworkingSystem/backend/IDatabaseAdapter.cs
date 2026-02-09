using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem.backend
{
    internal interface IDatabaseAdapter
    {
        string GetLastInsertIdQuery();

        string GetCurrentDateTimeFunction();

        string GetAutoIncrementDefinition();

        bool GetBooleanValue(object dbValue);

        object CreateParameter(string name, object value);

        string GetLimitClause(int limit, int offset);
    }
}