using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Utils.Entity
{
    internal class Recipe_IngredientEntity
    {
        private int recipe_id;
        private List<int> ingredient_id = new List<int>();
        private List<int> quantity = new List<int>();

        internal Recipe_IngredientEntity(int recipe_id)
        {
            this.recipe_id = recipe_id;
        }

        public int Recipe_id { get => recipe_id; set => recipe_id = value; }
        public List<int> Ingredient_id { get => ingredient_id; set => ingredient_id = value; }
        public List<int> Quantity { get => quantity; set => quantity = value; }
    } 
}
