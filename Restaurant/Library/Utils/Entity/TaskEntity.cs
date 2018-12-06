using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Utils.Entity
{
    internal class TaskEntity
    {
        private int task_id;
        private int task_time;
        private String task_description;
        private int step;
        private int recipe_id;
        private int furniture_id;

        internal TaskEntity(int id, int time, String description, int step, int recipe_id, int furniture_id)
        {
            this.task_id = id;
            this.task_time = time;
            this.task_description = description;
            this.step = step;
            this.recipe_id = recipe_id;
            this.furniture_id = furniture_id;
        }

        internal int Task_id { get => task_id; set => task_id = value; }

        internal int Task_time { get => task_time; set => task_time = value; }

        internal string Task_description { get => task_description; set => task_description = value; }

        internal int Step { get => step; set => step = value; }

        internal int Recipe_id { get => recipe_id; set => recipe_id = value; }

        internal int Furniture_id { get => furniture_id; set => furniture_id = value; }
    }
}
