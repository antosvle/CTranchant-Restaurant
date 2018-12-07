using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Library.DatabaseLayer.DAO;

namespace Library.DatabaseLayer.DAOimpl
{
    internal class LogDAO : GenericDAO, ILogDAO
    {
        internal LogDAO(SqlConnection driverSql, DataFactory injector) : base(driverSql, injector) { }
    }
}
