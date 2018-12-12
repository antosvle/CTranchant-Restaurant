using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Library.DatabaseLayer.DAO;
using Library.Utils;

namespace Library.DatabaseLayer.DAOimpl
{
    internal class LogDAO : GenericDAO, ILogDAO
    {

        internal LogDAO(SqlConnection driverSql, DataFactory injector) : base(driverSql, injector) { }


        void ILogDAO.AddLog(string messageQuery, LocationEnum source)
        {
            try
            {
                sdr = InitDatabaseService("INSERT INTO Logs VALUES (" + DateTime.Now + ", " + source + ", " + messageQuery + ")");
                CloseConnection();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.StackTrace);
            }
            
        }
    }
}
