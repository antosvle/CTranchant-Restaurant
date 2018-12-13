using Library.Controller;
using Room.Components;
using Room.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Room.Persons
{
    class Waiter
    {
        private readonly Area area;
        public Area Area { get => area; }

        public Waiter(Area areea)
        {
            area = areea;
        }

        public void Run()
        {
            while(true)
            {
                WaiterEvent evt = area.GetWaiterEvent();
                if (evt == null)
                    continue;

                if(evt.Event == WaiterEventEnum.cleanTable)
                {
                    Console.WriteLine("Cleaning table " + evt.Table.Customer.Name);
                    Timeline.Wait(10 * evt.Table.Customer.NbrOfPeople);
                    Console.WriteLine("table " + evt.Table.Customer.Name + " cleaned");
                    evt.Table.Customer = null; // free the table
                }
                else if(evt.Event == WaiterEventEnum.mealReady)
                {
                    // Goto bar and get meals
                    Console.WriteLine("Meals " + evt.Table.Customer.Name + " ready");
                    evt.Table.Customer.HaveReceivedFood = true;
                }
            }
        }
    }
}
