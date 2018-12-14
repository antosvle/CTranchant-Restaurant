using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

namespace Library.DatabaseLayer.DAO
{
    internal class GenericDAO
    {
        protected SqlConnection driverSql;
        protected DataFactory injector;
        protected SqlDataReader sdr = null;
        private static Semaphore _pool = new Semaphore(0, 1);

        internal GenericDAO(SqlConnection driverSql, DataFactory injector)
        {
            this.driverSql = driverSql;
            this.injector = injector;
        }

        protected void OpenConnection()
        {
            driverSql.Open();
            _pool.WaitOne();
        }

        protected void CloseConnection()
        {
            if(driverSql != null)
            {
                driverSql.Close();
                sdr.Close();
                _pool.Release();
            }        
        }

        protected SqlDataReader InitDatabaseService(String sqlRequest)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand(sqlRequest, driverSql);
                sdr = cmd.ExecuteReader();
                
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
