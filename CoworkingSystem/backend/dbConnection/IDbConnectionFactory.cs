using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace CoworkingSystem.backend.dbConnection
{
    internal interface IDbConnectionFactory
    {
        DbConnection CreateConnection();
    }
}
