﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Library.DatabaseLayer.DAO;
using Library.Utils.Entity;

namespace Library.DatabaseLayer.DAOimpl
{
    internal class TaskDAO : GenericDAO, ITaskDAO
    {
        internal TaskDAO(SqlConnection driverSql, DataFactory injector) : base(driverSql, injector) { }


        Task_IngredientEntity ITaskDAO.GetIngredient_Task(int task_id)
        {
            Task_IngredientEntity ingredient_TaskEntity = injector.GetTask_EntityEntity(task_id);
            sdr = InitDatabaseService("SELECT * FROM Ingredient_task WHERE task_id = " + task_id);

            while (sdr.Read())
            {
                ingredient_TaskEntity.SetIngredientData(sdr.GetInt32(1), sdr.GetInt32(2));
            }

            CloseConnection();
            return ingredient_TaskEntity;
        }


        List<TaskEntity> ITaskDAO.GetRecipeTasks(int recipe_id)
        {
            List<TaskEntity> taskEntities = null;
            sdr = InitDatabaseService("SELECT * FROM Tasks WHERE recipe_id = " + recipe_id);

            while (sdr.Read())
            {
                taskEntities.Add(injector.GetTaskEntity(
                  sdr.GetInt32(0),
                  sdr.GetInt32(1),
                  sdr.GetString(2),
                  sdr.GetInt32(3),
                  sdr.GetInt32(4),
                  sdr.GetInt32(5)
                    ));
            }

            CloseConnection();
            return taskEntities;
        }
    }
}
