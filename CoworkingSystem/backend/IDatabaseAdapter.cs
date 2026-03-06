using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem.backend
{
    public interface IDatabaseAdapter
    {
        // Komentar
        string GetLastInsertIdQuery();

        string GetCurrentDateTimeFunction();

        string GetAutoIncrementDefinition();

        bool GetBooleanValue(object dbValue);

        object CreateParameter(string name, object value);

        string GetLimitClause(int limit, int offset);

        string GetTimeDifferenceInHours(string startColumn, string endColumn);
    }
}