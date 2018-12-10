using System;
using System.Collections.Generic;
using System.Threading;
using Library;
using Library.DatabaseLayer;
using Library.Utils.DTO;
using Library.Controller;

namespace Kitchen
{
    class Program
    {
        private static DataFactory Injector;

        private static EventWaitHandle wh = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            /*Injector = DataFactory.GetInstance();
            KitchenService KitchenDB = Injector.GetKitchenService();

            List<IngredientDTO> listIngredient = KitchenDB.GetIngredients();

            Console.WriteLine("-- Test --\n");

            for(int i=0; i<listIngredient.Count; i++)
            {
                Console.WriteLine(listIngredient[i].Name);
            }
            
            Console.ReadLine();*/

            new Thread(() =>
            {
                Console.WriteLine("0");

                Timeline.Wait(5);
                
                Console.WriteLine("5");

            }).Start();

            new Thread(() => {

                Timeline.Wait(2);
                
                Console.WriteLine("2");

                new Thread(() => {

                    Timeline.Wait(2);
                    
                    Console.WriteLine("4");

                    Timeline.Wait(2);
                    
                    Console.WriteLine("6");

                }).Start();

            }).Start();
            
            Timeline.Start();
        }
    }
}
