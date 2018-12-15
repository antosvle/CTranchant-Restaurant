using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

namespace Library.DatabaseLayer.DAO
{
    internal class GenericDAO
    {
        protected static SqlConnection DriverSql;
        protected DataFactory injector;
        protected SqlDataReader sdr = null;
        private static Semaphore _pool = new Semaphore(1, 1);

        internal GenericDAO(SqlConnection driverSql, DataFactory injector)
        {
            DriverSql = driverSql;
            this.injector = injector;
        }

        protected static void OpenConnection()
        {
            _pool.WaitOne(1000);
            DriverSql.Open();
        }

        protected static void CloseConnection(SqlDataReader sdr)
        {
            if(DriverSql != null)
            {
                DriverSql.Close();
                sdr.Close();
                _pool.Release();
            }        
        }

        protected SqlDataReader InitDatabaseService(String sqlRequest)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand(sqlRequest, DriverSql);
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
