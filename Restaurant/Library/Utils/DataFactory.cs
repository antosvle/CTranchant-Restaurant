using System;
using System.Collections.Generic;
using System.Text;
using Library.Utils.Entity;

namespace Library
{
    public class DataFactory
    {
        private static DataFactory instance = null;


        private DataFactory() {}

           
        public static DataFactory getInstance()
        {         
            if (instance == null) return new DataFactory();

            else return instance;
        }


        //ENTITY GETTERS

        internal FurnitureEntity getFurnitureEntity(int id, String name, int quantity)
        {
            return new FurnitureEntity(id, name, quantity);
        }

        internal TaskEntity getTaskEntity(int id, int time, String description, int step, int recipe_id, int furniture_id)
        {
            return new TaskEntity(id, time, description, step, recipe_id, furniture_id);
        }

        internal TablewareEntity getTablewareEntity(int id, String name, int quantity)
        {
            return new TablewareEntity(id, name, quantity);
        }

        internal StockEntity getStockEntity(int id, DateTime date)
        {
            return new StockEntity(id, date);
        }

        internal RecipeEntity getRecipeEntity(int id, String category, String name, int nb_people, String speciality, String description)
        {
            return new RecipeEntity(id, category, name, nb_people, speciality, description);
        }

        internal LogEntity getLogEntity(int id, DateTime date, String source, String message)
        {
            return new LogEntity(id, date, source, message);
        }

        internal IngredientEntity getIngredientEntity(int id, String name, int fresh)
        {
            return new IngredientEntity(id, name, fresh);
        }

        internal UstensilEntity getUstensilEntity(int id, String name, int quantity)
        {
            return new UstensilEntity(id, name, quantity);
        }

    }
}
