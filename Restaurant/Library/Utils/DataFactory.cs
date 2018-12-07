using System;
using System.Collections.Generic;
using System.Text;
using Library.Utils.Entity;
using Library.DatabaseLayer;
using Library.DatabaseLayer.DAO;
using Library.DatabaseLayer.DAOimpl;
using Library.Utils.DTO;

namespace Library
{
    public class DataFactory
    {
        private static DataFactory Instance = null;


        private DataFactory() {}

           
        public static DataFactory GetInstance()
        {         
            if (Instance == null) return new DataFactory();

            else return Instance;
        }


        // DATABASE SERVICES

        public KitchenService GetKitchenService(DataFactory Injector)
        {
            return new KitchenService(Injector);
        }

        public LogService GetLogService()
        {
            return new LogService();
        }

        public RoomService GetRoomService()
        {
            return new RoomService();
        }


        // DAO GETTERS

        internal IFurnitureDAO GetFurnitureDAO()
        {
            return new FurnitureDAO();
        }

        internal IIngredientDAO GetIngredientDAO()
        {
            return new IngredientDAO();
        }

        internal ILogDAO GetLogDAO()
        {
            return new LogDAO();
        }

        internal IRecipeDAO GetRecipeDAO()
        {
            return new RecipeDAO();
        }

        internal IStockDAO GetStockDAO()
        {
            return new StockDAO();
        }

        internal ITablewareDAO GetTablewareDAO()
        {
            return new TablewareDAO();
        }

        internal ITaskDAO GetTaskDAO()
        {
            return new TaskDAO();
        }


        // DTO GETTERS

        public IngredientDTO GetIngredientDTO()
        {
            return new IngredientDTO();
        }


        // ENTITIES GETTERS

        internal FurnitureEntity GetFurnitureEntity(int id, String name, int quantity)
        {
            return new FurnitureEntity(id, name, quantity);
        }

        internal TaskEntity GetTaskEntity(int id, int time, String description, int step, int recipe_id, int furniture_id)
        {
            return new TaskEntity(id, time, description, step, recipe_id, furniture_id);
        }

        internal TablewareEntity GetTablewareEntity(int id, String name, int quantity)
        {
            return new TablewareEntity(id, name, quantity);
        }

        internal StockEntity GetStockEntity(int id, DateTime date)
        {
            return new StockEntity(id, date);
        }

        internal RecipeEntity GetRecipeEntity(int id, String category, String name, int nb_people, String speciality, String description)
        {
            return new RecipeEntity(id, category, name, nb_people, speciality, description);
        }

        internal LogEntity GetLogEntity(int id, DateTime date, String source, String message)
        {
            return new LogEntity(id, date, source, message);
        }

        internal IngredientEntity GetIngredientEntity(int id, String name, int fresh)
        {
            return new IngredientEntity(id, name, fresh);
        }

        internal UstensilEntity GetUstensilEntity(int id, String name, int quantity)
        {
            return new UstensilEntity(id, name, quantity);
        }

    }
}
