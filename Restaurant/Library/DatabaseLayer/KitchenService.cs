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
        private IFurnitureDAO DaoFurniture;
        private IUstensilDAO DaoUstensil;


        //Constructor
        public KitchenService(DataFactory Injector)
        {
            this.Injector = Injector;

            //DAO creation thanks to Factory and dependency injection
            DaoIngredient = Injector.GetIngredientDAO();
            DaoRecipe = Injector.GetRecipeDAO();
            DaoTask = Injector.GetTaskDAO();
            DaoFurniture = Injector.GetFurnitureDAO();
            DaoUstensil = Injector.GetUstensilDAO();
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


        //Task Recuperation
        public InstructionDTO GetOneInstruction(String recipe_name, int step)
        {
            InstructionDTO instructionDTO = Injector.GetInstructionDTO();
            
            //Query builder for task table
            TaskEntity task = DaoTask.GetOneTask(DaoRecipe.GetOneRecipe(recipe_name).Recipe_id, step);
            instructionDTO.Time = task.Task_time;

            //Query builder for furniture table
            FurnitureEntity furniture = DaoFurniture.GetOneFurniture(task.Furniture_id);
            instructionDTO.Furniture = furniture.Furniture_name;

            //Query builder for Utensils table
            List<UstensilEntity> ustensil_list = DaoUstensil.GetUstensilEntities(task.Task_id);
            foreach(UstensilEntity ustensilEntity in ustensil_list)
            {
                instructionDTO.Utensils.Add(ustensilEntity.Ustensil_name);
            }

            return instructionDTO;
        }
    }
}
