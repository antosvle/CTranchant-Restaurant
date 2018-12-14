using Library.Controller;
using Library.Utils;
using Room.Components;
using Room.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Room.Persons
{
    class RowChief
    {
        private Room room;
        private Row row;

        public RowChief(Room rooom, Row roow)
        {
            room = rooom;
            row = roow;
        }

        public void Run()
        {
            while (true)
            {
                Customer cust = room.Reception.GetNextCustomerInQueue();
                RowChiefEvent evt;
                if (cust != null)
                {
                    // call IHM 
                }
                else if((evt = row.GetRowChiefEvent()) != null)
                {
                    lock (evt)
                    {
                        if (evt.Event == RowChiefEventEnum.getMenu)
                        {
                            if(room.Reception.MenusLeft >= evt.Table.Customer.NbrOfPeople)
                            {
                                room.Reception.MenusLeft -= evt.Table.Customer.NbrOfPeople;
                                evt.Table.Customer.Status = EStatus.nothing;
                                evt.Table.Customer.HaveMenus = true;
                                Console.WriteLine("giving " + evt.Table.Customer.NbrOfPeople.ToString() + " menus to table " + evt.Table.Customer.Name + ", " + room.Reception.MenusLeft.ToString() + " menus left");
                            }
                            else
                            {
                                evt.Table.Customer.Status = EStatus.waitingForMenus;
                                row.AddRowChiefEvent(new RowChiefEvent(RowChiefEventEnum.getMenu, evt.Table));
                                Console.WriteLine("Customers " + evt.Table.Customer.Name + " are  waiting for menus");
                            }
                            Timeline.Wait(60);
                        }
                        else if(evt.Event == RowChiefEventEnum.getOrder)
                        {
                            Console.WriteLine("Taking Order of Table " + evt.Table.Customer.Name);
                            Order order = evt.Table.Customer.GetOrder();
                            room.Reception.MenusLeft += evt.Table.Customer.NbrOfPeople;
                            evt.Table.Customer.HaveMenus = false;
                            Timeline.Wait(2 * evt.Table.Customer.NbrOfPeople);
                            evt.Table.Customer.Status = EStatus.nothing;
                            evt.Table.Row.Area.AddWaiterEvent(new WaiterEvent(WaiterEventEnum.mealReady, evt.Table));

                            // send order to socket
                            //Room.socketManager.UpdateExternalSide(LocationEnum.KITCHEN, Library.Utils.Nomenclature.CommandeEnum.SEND_ORDER, "");
                        }
                    }
                }
            }
        }
    }
}
