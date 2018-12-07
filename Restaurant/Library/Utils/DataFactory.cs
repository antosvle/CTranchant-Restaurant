﻿using System;
using System.Collections.Generic;
using System.Text;
using Library.Utils.Entity;
using Library.DatabaseLayer;
using Library.DatabaseLayer.DAO;
using Library.DatabaseLayer.DAOimpl;
using Library.Utils.DTO;
using System.Data.SqlClient;

namespace Library
{
    public class DataFactory
    {
        private static DataFactory instance = null;
        private static SqlConnection driverSql = null;
        readonly private static String connectionString = "Data Source=tcp:192.168.1.1,1433;Initial Catalog = Restaurant_simulator_2018; User ID = DATABASELAYER; Password=BIGOUNE;";


        private DataFactory() {}


        // SINGLETON
           
        public static DataFactory GetInstance()
        {
            if (instance == null)
            {
                instance = new DataFactory();
                return instance;
            }
            else return instance;
        }

        public static SqlConnection GetSqlDriver()
        {
            if (driverSql == null)
            {
                driverSql = new SqlConnection(connectionString);
                return driverSql;
            }

            else return driverSql;
        }


        // DATABASE SERVICES

        public KitchenService GetKitchenService()
        {
            return new KitchenService(GetInstance());
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
            return new FurnitureDAO(GetSqlDriver(), GetInstance());
        }

        internal IIngredientDAO GetIngredientDAO()
        {
            return new IngredientDAO(GetSqlDriver(), GetInstance());
        }

        internal ILogDAO GetLogDAO()
        {
            return new LogDAO(GetSqlDriver(), GetInstance());
        }

        internal IRecipeDAO GetRecipeDAO()
        {
            return new RecipeDAO(GetSqlDriver(), GetInstance());
        }

        internal IStockDAO GetStockDAO()
        {
            return new StockDAO(GetSqlDriver(), GetInstance());
        }

        internal ITablewareDAO GetTablewareDAO()
        {
            return new TablewareDAO(GetSqlDriver(), GetInstance());
        }

        internal ITaskDAO GetTaskDAO()
        {
            return new TaskDAO(GetSqlDriver(), GetInstance());
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
