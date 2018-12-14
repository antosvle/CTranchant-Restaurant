using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Utils.Entity
{
    internal class Task_IngredientEntity
    {
        private int task_id;
        private List<int> ingredient_id;
        private List<int> nb_ingredient;

        internal Task_IngredientEntity(int task_id)
        {
            this.task_id = task_id;
        }

        public int Task_id { get => task_id; set => task_id = value; }
        public List<int> Ingredient_id { get => ingredient_id; set => ingredient_id = value; }
        public List<int> Nb_ingredient { get => nb_ingredient; set => nb_ingredient = value; }
    }
}
