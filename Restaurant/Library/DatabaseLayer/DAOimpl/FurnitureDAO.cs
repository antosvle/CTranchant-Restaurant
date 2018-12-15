using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Library.DatabaseLayer.DAO;
using Library.Utils.Entity;

namespace Library.DatabaseLayer.DAOimpl
{
    internal class FurnitureDAO : GenericDAO, IFurnitureDAO
    {
        internal FurnitureDAO(SqlConnection driverSql, DataFactory injector) : base(driverSql, injector) {}

        FurnitureEntity IFurnitureDAO.GetOneFurniture(int furniture_id)
        {
            FurnitureEntity entity = null;
            sdr = InitDatabaseService("SELECT * FROM Furniture WHERE id = " + furniture_id);

            while (sdr.Read())
            {
                entity = injector.GetFurnitureEntity(sdr.GetInt32(0), sdr.GetString(1), sdr.GetInt32(2));
            }

            CloseConnection(sdr);
            return entity;
        }
    }
}
