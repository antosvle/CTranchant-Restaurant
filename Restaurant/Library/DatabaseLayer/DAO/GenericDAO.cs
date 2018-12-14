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
        private static Semaphore _pool;

        internal GenericDAO(SqlConnection driverSql, DataFactory injector)
        {
            this.driverSql = driverSql;
            this.injector = injector;
            _pool = new Semaphore(0, 2);
        }

        protected void OpenConnection()
        {
            _pool.WaitOne();
            driverSql.Open();
        }

        protected void CloseConnection()
        {
            if(driverSql != null)
            {
                driverSql.Close();
                sdr.Close();
                _pool.Release(1);
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
