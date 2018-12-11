﻿using System;
using System.Threading;
using Library.Controller;
using Kitchen.Model;
using System.Collections.Generic;

namespace Kitchen
{
    class Program
    {
        static void Main(string[] args)
        {
            new Thread(() =>
            {
                Random random = new Random();

                string[] recipes = {"Carbonara Pasta", "Pasta Bolognese", "Norvegian Pizza", "Squeegee", "Sushis", "Nems", "Pancakes"};

                while (true)
                {
                    Timeline.Wait(random.Next(120, 240));

                    IList<string> dishes = new List<string>();

                    for (int i = 0, n = random.Next(1, 10); i < n; i++)
                    {
                        dishes.Add(recipes[random.Next(0, 4)]);
                    }

                    string message = "A new order has been asked:";

                    foreach (string dish in dishes)
                    {
                        message += " {" + dish + "}";
                    }

                    message += ".";

                    Console.WriteLine(message);

                    Model.Kitchen.Instance.Chief.Manage(new Order(dishes));
                }

            }).Start();
            
            Timeline.Start();

        }
    }
}
