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

        List<IngredientEntity> IIngredientDAO.GetAllIngredients()
        {
            List<IngredientEntity> list = new List<IngredientEntity>();
            sdr = InitDatabaseService("SELECT * FROM Ingredients");

            while (sdr.Read())
            {
                list.Add(injector.GetIngredientEntity(sdr.GetInt32(0), sdr.GetString(1)));
            }

            CloseConnection();
            return list;
        }

        IngredientEntity IIngredientDAO.GetOneIngredients(int ingredient_id)
        {
            IngredientEntity ingredient = null;
            sdr = InitDatabaseService("SELECT * FROM Ingredients WHERE id = " + ingredient_id);

            while (sdr.Read())
            {
                ingredient = injector.GetIngredientEntity(sdr.GetInt32(0), sdr.GetString(1));
            }

            CloseConnection();
            return ingredient;
        }
    }
}
