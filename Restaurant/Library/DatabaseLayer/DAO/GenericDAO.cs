using System;
using System.Data;
using System.Data.SqlClient;

namespace Library.DatabaseLayer.DAO
{
    internal class GenericDAO
    {
        protected SqlConnection driverSql;
        protected DataFactory injector;
        protected SqlDataReader sdr = null;
        private readonly object _locker = new object();

        internal GenericDAO(SqlConnection driverSql, DataFactory injector)
        {
            this.driverSql = driverSql;
            this.injector = injector;
        }

        protected void OpenConnection()
        {
            driverSql.Open();
        }

        protected void CloseConnection()
        {
            if(driverSql != null)
            {
                driverSql.Close();
                sdr.Close();
            }        
        }

        protected SqlDataReader InitDatabaseService(String sqlRequest)
        {
            try
            {
                lock(_locker) 
                {
                    OpenConnection();
                    SqlCommand cmd = new SqlCommand(sqlRequest, driverSql);
                    sdr = cmd.ExecuteReader();
                }
                return sdr;
            }
            catch(DataException e)
            {
                Console.WriteLine(e.Source);
                Environment.Exit(0);
                return null;
            }
        }
    }
}
