using System;
using System.Collections.Generic;
using System.Text;
using Library.DatabaseLayer.DAO;
using Library.Utils.Entity;
using System.Data;
using System.Data.SqlClient;

namespace Library.DatabaseLayer.DAOimpl
{
    internal class IngredientDAO : GenericDAO, IIngredientDAO
    {

        internal IngredientDAO(SqlConnection driverSql, DataFactory injector) : base(driverSql, injector) {}
        

        public List<IngredientEntity> GetAllIngredient()
        {
            SqlDataReader sdr = null;
            List<IngredientEntity> list = new List<IngredientEntity>();
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("select * from Ingredients", driverSql);
                sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    list.Add(injector.GetIngredientEntity(sdr.GetInt16(0), sdr.GetString(1), sdr.GetInt16(2)));
                }

            }
            finally
            {
                sdr.Close();
                CloseConnection();
            }

            return list;
        }
    }
}
