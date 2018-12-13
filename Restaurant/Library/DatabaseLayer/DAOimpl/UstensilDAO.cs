using Library.DatabaseLayer.DAO;
using Library.Utils.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Library.DatabaseLayer.DAOimpl
{
    internal class UstensilDAO : GenericDAO, IUstensilDAO
    {
        internal UstensilDAO(SqlConnection driverSql, DataFactory injector) : base(driverSql, injector) { }

        private UstensilEntity GetOneUstensil(int utensil_id)
        {
            UstensilEntity utensil = null;
            sdr = InitDatabaseService("SELECT * FROM Utensils WHERE id = " + utensil_id);

            while (sdr.Read())
            {
                utensil = injector.GetUstensilEntity(sdr.GetInt32(0), sdr.GetString(1), sdr.GetInt32(2));
            }

            CloseConnection();
            return utensil;
        }


        List<UstensilEntity> IUstensilDAO.GetUstensilEntities(int task_id)
        {
            List<int> list_ustensil_id = new List<int>();
            sdr = InitDatabaseService("SELECT * FROM Task_utensil WHERE task_id = " + task_id);

            while (sdr.Read())
            {
                list_ustensil_id.Add(sdr.GetInt32(0));
            }

            CloseConnection();

            List<UstensilEntity> entities = new List<UstensilEntity>();
            foreach(int utensil_id in list_ustensil_id)
            {
                entities.Add(this.GetOneUstensil(utensil_id));
            }

            return entities;
        }
    }
}
