using System;
using System.Collections.Generic;

namespace Kitchen.Model
{
    public class Recipe
    {
        private static ISet<Recipe> recipes = new HashSet<Recipe>();

        public string Name { get; private set; }

        public ISet<Ingredient> Ingredients { get; private set; } = new HashSet<Ingredient>();

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
                
                recipe.Ingredients.Add(Ingredient.Get("Potato", 30));

                recipes.Add(recipe);

                return recipe;
            }
        }
    }
}
