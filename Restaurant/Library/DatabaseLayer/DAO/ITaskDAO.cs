using Library.Utils.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DatabaseLayer.DAO
{
    internal interface ITaskDAO
    {
        List<TaskEntity> GetRecipeTasks(int recipe_id);
        Task_IngredientEntity GetIngredient_Task(int task_id);
    }
}
