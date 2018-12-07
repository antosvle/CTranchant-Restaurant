using System;
using System.Collections.Generic;
using System.Text;
using Library;
using Library.DatabaseLayer.DAO;
using Library.Utils.DTO;
using Library.Utils.Entity;

namespace Library.DatabaseLayer
{
    public class KitchenService
    {
        private DataFactory Injector;
        private IIngredientDAO Dao;

        public KitchenService(DataFactory Injector)
        {
            this.Injector = Injector;
            Dao = Injector.GetIngredientDAO();
        }

        public List<IngredientDTO> GetIngredients()
        {
            List<IngredientEntity> listDao = Dao.GetAllIngredient();

            List<IngredientDTO> ingredientList = new List<IngredientDTO>();

            for(int i=0; i < listDao.Count; i++)
            {
                IngredientDTO dto = Injector.GetIngredientDTO();
                dto.Name = listDao[i].Ingredient_name;
                ingredientList.Add(dto);
            }

            return ingredientList;
        }
    }
}
