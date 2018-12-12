using System;
using System.Collections.Generic;
using System.Text;
using Library;
using Library.DatabaseLayer.DAO;
using Library.Utils.DTO;
using Library.Utils.Entity;

namespace Library.DatabaseLayer
{
    /*
     * Data manager for kitchen elements
     */
    public class KitchenService
    {
        //Factory attribute
        private DataFactory Injector;
        //List of needed Data access object (DAO)
        private IIngredientDAO DaoIngredient;
        private IRecipeDAO DaoRecipe;
        private ITaskDAO DaoTask;

        //Constructor
        public KitchenService(DataFactory Injector)
        {
            this.Injector = Injector;
            //DAO creation thanks to Factory and dependency injection
            DaoIngredient = Injector.GetIngredientDAO();
            DaoRecipe = Injector.GetRecipeDAO();
            DaoTask = Injector.GetTaskDAO();
        }


        //Ingredients recuperation
        public List<IngredientDTO> GetIngredients()
        {
            List<IngredientEntity> listDao = DaoIngredient.GetAllIngredients();

            List<IngredientDTO> ingredientList = new List<IngredientDTO>();

            for(int i=0; i < listDao.Count; i++)
            {
                IngredientDTO dto = Injector.GetIngredientDTO();
                dto.Name = listDao[i].Ingredient_name;
                ingredientList.Add(dto);
            }

            return ingredientList;
        }


        //Recipe recuperation
        public RecipeDTO GetOneRecipe(String name)
        {
            RecipeDTO recipe = Injector.GetRecipeDTO();
            recipe.Name = name;

            RecipeEntity recipeEntity = DaoRecipe.GetOneRecipe(name);
            Recipe_IngredientEntity recipe_Ingredients = DaoRecipe.GetAllRecipeIngredients(recipeEntity.Recipe_id);

            if (recipe_Ingredients.Ingredient_id != null)
            {
   
                for (int i = 0; i < recipe_Ingredients.Ingredient_id.Count; i++)
                {
                    IngredientEntity ingredient = DaoIngredient.GetOneIngredients(recipe_Ingredients.Ingredient_id[i]);
                    IngredientDTO ingredientDTO = Injector.GetIngredientDTO();
                    ingredientDTO.Name = ingredient.Ingredient_name;
                    ingredientDTO.Quantity = recipe_Ingredients.Quantity[i];

                    recipe.Ingredients.Add(ingredientDTO);
                }
            }
            return recipe;
        }
    }
}
