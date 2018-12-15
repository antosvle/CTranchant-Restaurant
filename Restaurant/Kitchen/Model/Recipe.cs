using Library.Utils.DTO;
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
                RecipeDTO recipeDTO = Program.Service.GetOneRecipe(name);

                Recipe recipe = new Recipe(name);

                foreach (IngredientDTO ingredientDTO in recipeDTO.Ingredients)
                {
                    recipe.Ingredients.Add(new Ingredient(ingredientDTO.Name, ingredientDTO.Quantity));
                }

                for (int i=1; true; i++)
                {
                    try
                    {
                        InstructionDTO instruction = Program.Service.GetOneInstruction(recipeDTO.Name, i);
                        recipeDTO.Instructions.Add(instruction);
                    }
                    catch(Exception)
                    {
                        break;
                    }
                }

                foreach (InstructionDTO instructionDTO in recipeDTO.Instructions)
                {
                    Instruction instruction = new Instruction(instructionDTO.Furniture, instructionDTO.Time);

                    foreach (string utensil in instructionDTO.Utensils)
                    {
                        instruction.Utensils.Add(utensil);
                    }

                    recipe.Instructions.Add(instruction);
                }

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
