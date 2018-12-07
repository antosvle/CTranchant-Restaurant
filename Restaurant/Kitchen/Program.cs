using System;
using System.Collections.Generic;
using Library;
using Library.DatabaseLayer;
using Library.Utils.DTO;



namespace Kitchen
{
    class Program
    {
        private static DataFactory Injector;


        static void Main(string[] args)
        {
            Injector = DataFactory.GetInstance();
            KitchenService KitchenDB = Injector.GetKitchenService();

            List<IngredientDTO> listIngredient = KitchenDB.GetIngredients();

            Console.WriteLine("-- Test --");
            Console.WriteLine(listIngredient[0].Name);
            Console.ReadLine();
        }
    }
}