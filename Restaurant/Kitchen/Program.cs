using System;
using System.Threading;
using Library.Controller;
using Kitchen.Model;
using System.Collections.Generic;
using Library.Utils;
using Library.Utils.DTO;
using Library.DatabaseLayer;
using Library;

namespace Kitchen
{
    class Program
    {
        public static KitchenService Service { get; } = new KitchenService(DataFactory.GetInstance());

        static void Main(string[] args)
        {
            LogService.WriteLog(LocationEnum.KITCHEN, "MainProcess Kitchen Class: Program.cs Method: Main Message: Start the Kitchen");

            Thread.Sleep(5000);
            TransportationService transportationService = new TransportationService(LocationEnum.KITCHEN);
            Model.Bar.InitListener(transportationService);

  

            /*
            new Thread(() =>
            {
                Random random = new Random();

                Filler.Fill();

                string[] recipes = {"Chicken",  "Mashed Potatoes", "Mushroom Soop"};

                while (true)
                {
                    Timeline.Wait(random.Next(300, 420));

                    IList<string> dishes = new List<string>();

                    for (int i = 0, n = random.Next(1, 6); i < n; i++)
                    {
                        dishes.Add(recipes[random.Next(0, 3)]);
                    }

                    string message = "ORDER EMITTED: ";

                    foreach (string dish in dishes)
                    {
                        message += "{" + dish + "}";
                    }

                    message += ".";

                    Shell.Log(message);
                    
                    //Model.Bar.Receive(new Order(0, dishes));
                }

            }).Start();*/

            Restaurant.Start();
        }
    }
}
