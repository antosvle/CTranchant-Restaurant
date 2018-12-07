using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Library.DatabaseLayer.DAO;

namespace Library.DatabaseLayer.DAOimpl
{
    internal class TaskDAO : GenericDAO, ITaskDAO
    {
        internal TaskDAO(SqlConnection driverSql, DataFactory injector) : base(driverSql, injector) { }
    }
}
