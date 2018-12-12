using System;
using System.Collections.Generic;

namespace Kitchen.Model
{
    public class Recipe
    {
        public static ISet<Recipe> Recipes { get; private set; } = new HashSet<Recipe>();

        public string Name { get; private set; }

        public IList<Instruction> Instructions { get; private set; } = new List<Instruction>();

        public ISet<Ingredient> Ingredients { get; private set; } = new HashSet<Ingredient>();

        private Recipe(string name)
        {
            this.Name = name;
        }

        public static Recipe Get(string name)
        {
            foreach (Recipe recipe in Recipes)
            {
                if (recipe.Name == name)
                {
                    return recipe;
                }
            }

            {
                Recipe recipe = new Recipe(name);

                Recipes.Add(recipe);

                return recipe;
            }
        }

        public string Description()
        {
            return "{" + Name + "}";
        }
    }
}
