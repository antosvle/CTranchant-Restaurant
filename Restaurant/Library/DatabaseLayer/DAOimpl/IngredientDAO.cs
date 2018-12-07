using System;
using System.Collections.Generic;
using Library.DatabaseLayer.DAO;
using Library.Utils.Entity;
using System.Data.SqlClient;

namespace Library.DatabaseLayer.DAOimpl
{
    internal class IngredientDAO : GenericDAO, IIngredientDAO
    {

        internal IngredientDAO(SqlConnection driverSql, DataFactory injector) : base(driverSql, injector) {}
        

        public List<IngredientEntity> GetAllIngredients()
        {
            List<IngredientEntity> list = new List<IngredientEntity>();

            sdr = InitDatabaseService("select * from Ingredients");

            while (sdr.Read())
            {
                list.Add(injector.GetIngredientEntity(sdr.GetInt32(0), sdr.GetString(1), sdr.GetInt32(2)));
            }

            CloseConnection();
           
            return list;
        }
    }
}
