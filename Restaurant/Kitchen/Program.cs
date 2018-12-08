using System;
using System.Collections.Generic;
<<<<<<< Updated upstream
using Library;
using Library.DatabaseLayer;
using Library.Utils.DTO;


=======
using System.Threading;
>>>>>>> Stashed changes

namespace Kitchen
{
    class Program
    {
<<<<<<< Updated upstream
        private static DataFactory Injector;


=======
        //private static DataFactory Injector;
        
>>>>>>> Stashed changes
        static void Main(string[] args)
        {
            Injector = DataFactory.GetInstance();
            KitchenService KitchenDB = Injector.GetKitchenService();

            List<IngredientDTO> listIngredient = KitchenDB.GetIngredients();

            Console.WriteLine("-- Test --\n");

            for(int i=0; i<listIngredient.Count; i++)
            {
                Console.WriteLine(listIngredient[i].Name);
            }
            
            Console.ReadLine();
        }
    }
}