using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Utils.Entity
{
    internal class IngredientEntity
    {
        private int ingredient_id;
        private String ingredient_name;
        private int fresh_duration;


        internal IngredientEntity(int id, String name, int fresh)
        {
            this.Ingredient_id = id;
            this.Ingredient_name = name;
            this.fresh_duration = fresh;
        }

        internal int Fresh_duration { get => fresh_duration; set => fresh_duration = value; }

        internal string Ingredient_name { get => ingredient_name; set => ingredient_name = value; }

        internal int Ingredient_id { get => ingredient_id; set => ingredient_id = value; }
    }
}
