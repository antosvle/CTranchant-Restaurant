using Room.Components;
using Room.Events;
using System;
using System.Threading;

namespace Room.Persons
{
    enum EStatus
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

        private string name;
        public string Name { get => name; set => name = value; }

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
            Room.AddRoomClerkEvent(new RoomClerkEvent());
        }

        public void AskWater()
        {
            Room.AddRoomClerkEvent(new RoomClerkEvent());
        }

        public void Run()
        {
            Console.WriteLine("Run : " + name);
            Thread.Sleep(2000);
            status = EStatus.waitingPaying;
            
        }
    }
}
