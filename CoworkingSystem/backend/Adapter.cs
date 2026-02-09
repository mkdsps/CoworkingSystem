using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem.backend
{
    internal abstract class DatabaseAdapter
    {
        // zajednicko za sve baze, svaka ima svoje funkcije
        // Konstruktor
        protected DatabaseAdapter()
        {
        }
        //vracanje poslednjeg unetog id - ja(automatski generisan)
        public abstract string GetLastInsertIdQuery();
        // getdate() / now()
        public abstract string GetCurrentDateTimeFunction();
        // drugaciji auto inkrement 
        public abstract string GetAutoIncrementDefinition();
        // drugaciji uid
        public abstract string GetUid();
        //MSSQL: true/false, MYSQL: 1/0
        public abstract bool GetBooleanValue(object dbValue);
        // kreiranje parametara za svaku bazu je drugacije
        public abstract object CreateParameter(string name, object value);

        public virtual string FormatDateTimeParameter(DateTime value)
        {
            return value.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}