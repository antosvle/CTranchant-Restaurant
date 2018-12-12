using Room.Components;
using Room.Events;
using System;
using System.Threading;
using Library.Controller;

namespace Room.Persons
{
    public enum EStatus
    {
        nothing,
        arriving,
        waiting,
        paying,
        waitingPaying,
        waitingForEmployee,
        waitingForMenus,
        eating,
        gone
    }

    public class Customer
    {
        private EStatus status;
        internal EStatus Status { get => status; set => status = value; }

        readonly private int nbrOfPeople;
        public int NbrOfPeople { get => nbrOfPeople; }

        private readonly string name;
        public string Name { get => name; }

        private Table table;
        internal Table Table { get => table; set => table = value; }

        private bool haveMenus;
        public bool HaveMenus { get => haveMenus; set => haveMenus = value; }

        private bool haveOrdered;
        public bool HaveOrdered { get => haveOrdered; set => haveOrdered = value; }

        private readonly Order order;

        public Customer(int nbr, string eman, Order ordre)
        {
            name = eman;
            nbrOfPeople = nbr;
            order = ordre;
            status = EStatus.arriving;
            haveMenus = false;
            table = null;
        }

        public void AskBread()
        {
            Room.AddRoomClerkEvent(new RoomClerkEvent(RCEvent.Bread, this));
            status = EStatus.waitingForEmployee;
            while (status == EStatus.waitingForEmployee);
        }

        public void AskWater()
        {
            Room.AddRoomClerkEvent(new RoomClerkEvent(RCEvent.Water, this));
            status = EStatus.waitingForEmployee;
            while (status == EStatus.waitingForEmployee);
        }

        public void AskWine()
        {
            Room.AddRoomClerkEvent(new RoomClerkEvent(RCEvent.Wine, this));
            status = EStatus.waitingForEmployee;
            while (status == EStatus.waitingForEmployee);
        }

        public void GiveOrder()
        {
            table.Row.AddRowChiefEvent(new RowChiefEvent(RowChiefEventEnum.getOrder, table));
            status = EStatus.waitingForEmployee;
            while (status == EStatus.waitingForEmployee);
            haveOrdered = true;
        }

        public void IWannaPay()
        {
            Room.GetInstance().Reception.AddCustomerToQueue(this);
        }

        public Order GetOrder()
        {
            return order;
        }

        public void Run()
        {
            if (table != null)
            {
                // ask for bread
                AskBread();
                Timeline.Wait(200);

                // order the meal
                if (haveMenus)
                {
                    order.Table = table.Id;
                    GiveOrder();
                }

                if(haveOrdered)
                {
                    Console.WriteLine("Customer " + name + " is eating");
                    Timeline.Wait(200);
                    Console.WriteLine("Customer " + name + " have finished eating");
                    status = EStatus.waitingPaying;
                    IWannaPay();
                }
            }
        }
    }
}
