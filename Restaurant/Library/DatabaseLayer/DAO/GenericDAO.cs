using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Library.DatabaseLayer.DAO
{
    internal class GenericDAO
    {
        protected SqlConnection driverSql;
        protected DataFactory injector;

        internal GenericDAO(SqlConnection driverSql, DataFactory injector)
        {
            this.driverSql = driverSql;
            this.injector = injector;
        }

        internal void OpenConnection()
        {
            driverSql.Open();
        }

        internal void CloseConnection()
        {
            if(driverSql != null)
            {
                driverSql.Close();
            }        
        }
    }
}
