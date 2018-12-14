using Library.Utils.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DatabaseLayer.DAO
{
    internal interface IRecipeDAO
    {
        RecipeEntity GetOneRecipe(String name);

        Recipe_IngredientEntity GetAllRecipeIngredients(int recipe_id);
    }
}
