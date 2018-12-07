using System;
using System.Collections.Generic;
using System.Text;
using Library;
using Library.DatabaseLayer.DAO;
using Library.Utils.DTO;
using Library.Utils.Entity;

namespace Library.DatabaseLayer
{
    /*
     * Data manager for kitchen elements
     */
    public class KitchenService
    {
        //Factory attribute
        private DataFactory Injector;
        //List of needed Data access object (DAO)
        private IIngredientDAO Dao;


        //Constructor
        public KitchenService(DataFactory Injector)
        {
            this.Injector = Injector;
            //DAO creation thanks to Factory and dependency injection
            Dao = Injector.GetIngredientDAO();
        }


        //Ingredients recuperation
        public List<IngredientDTO> GetIngredients()
        {
            List<IngredientEntity> listDao = Dao.GetAllIngredients();

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
