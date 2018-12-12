using Library;
using Library.DatabaseLayer;
using Library.Utils.DTO;
using System;
using System.Collections.Generic;

namespace Ihm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TEST");

            DataFactory injector = DataFactory.GetInstance();

            KitchenService test = injector.GetKitchenService();

            RecipeDTO dto = test.GetOneRecipe("Cheesecake");
  
            foreach (IngredientDTO ingredient in dto.Ingredients)
            {
                Console.WriteLine(ingredient.Name);
            }
            Console.Read();

        }
    }
}
