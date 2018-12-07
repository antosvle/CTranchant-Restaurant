using System;
using System.Collections.Generic;
using System.Text;
using Library.DatabaseLayer.DAO;
using Library.Utils.Entity;

namespace Library.DatabaseLayer.DAOimpl
{
    internal class IngredientDAO : IIngredientDAO, IGenericDAO
    {



        public List<IngredientEntity> GetAllIngredient()
        {
            List<IngredientEntity> list = new List<IngredientEntity>();
            list.Add(new IngredientEntity(1, "Pomme", 5));

            return list;
        }
    }
}
