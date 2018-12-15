using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Library.DatabaseLayer.DAO;
using Library.Utils.Entity;

namespace Library.DatabaseLayer.DAOimpl
{
    internal class RecipeDAO : GenericDAO, IRecipeDAO
    {
        internal RecipeDAO(SqlConnection driverSql, DataFactory injector) : base(driverSql, injector) { }


        Recipe_IngredientEntity IRecipeDAO.GetAllRecipeIngredients(int recipe_id)
        {
            Recipe_IngredientEntity recipe_ingredients = injector.GetRecipe_IngredientEntity(recipe_id);
            sdr = InitDatabaseService("SELECT * FROM Recipe_ingredient WHERE recipe_id = '" + recipe_id + "'");

            while (sdr.Read())
            {
                recipe_ingredients.Ingredient_id.Add(sdr.GetInt32(1));
                recipe_ingredients.Quantity.Add(sdr.GetInt32(2));
            }

            CloseConnection(sdr);
            return recipe_ingredients;
        }


        RecipeEntity IRecipeDAO.GetOneRecipe(String name)
        {
            RecipeEntity recipeEntity = null;
            sdr = InitDatabaseService("SELECT * FROM Recipes WHERE name = '" + name + "'");

            while (sdr.Read())
            {
                recipeEntity = injector.GetRecipeEntity(
                    sdr.GetInt32(0),
                    sdr.GetString(1),
                    sdr.GetString(2),
                    sdr.GetInt32(3),
                    sdr.GetString(4),
                    sdr.GetString(5)
                    );
            }

            CloseConnection(sdr);
            return recipeEntity;
        }
    }
}
