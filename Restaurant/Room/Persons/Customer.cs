using Room.Components;
using Room.Events;
using System;
using System.Threading;
using Library.Controller;

namespace Room.Persons
{
    public enum EStatus
    {
        arriving,
        waiting,
        paying,
        waitingPaying,
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


        public Customer(int nbr, string eman)
        {
            name = eman;
            nbrOfPeople = nbr;
            status = EStatus.arriving;
            table = null;
        }

        public void AskBread()
        {
            Room.AddRoomClerkEvent(new RoomClerkEvent(RCEvent.Bread, this));
        }

        public void AskWater()
        {
            Room.AddRoomClerkEvent(new RoomClerkEvent(RCEvent.Water, this));
        }

        public void AskWine()
        {
            Room.AddRoomClerkEvent(new RoomClerkEvent(RCEvent.Wine, this));
        }

        public void GiveOrder()
        {
            table.Row.AddRowChiefEvent(new RowChiefEvent(RowChiefEventEnum.getOrder, table));
        }

        public void Run()
        {
            Console.WriteLine("customer : " + name);
            if (table != null)
            {
                AskBread();
                Timeline.Wait(300);
                GiveOrder();

                status = EStatus.waitingPaying;
            }
        }
    }
}
