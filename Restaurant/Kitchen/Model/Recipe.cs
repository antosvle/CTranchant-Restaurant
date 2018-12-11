using System;
using System.Collections.Generic;
using System.Text;

namespace Kitchen.Model
{
    public class Recipe
    {
        private static ISet<Recipe> recipes = new HashSet<Recipe>();

        public string Name { get; private set; }

        private Recipe(string name)
        {
            this.Name = name;
        }

        public static Recipe Get(string name)
        {
            foreach (Recipe recipe in recipes)
            {
                if (recipe.Name == name)
                {
                    return recipe;
                }
            }

            {
                Recipe recipe = new Recipe(name);

                recipes.Add(recipe);

                return recipe;
            }
        }
    }
}
