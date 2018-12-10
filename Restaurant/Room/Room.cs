using Room.Components;
using Room.Events;
using Room.Persons;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Room
{
    public class Room
    {
        static Room instance;
        private Reception reception;
        public Reception Reception { get => reception; } 
        HashSet<Area> areas;
        private HashSet<Table> tables;
        public HashSet<Table> Tables { get => tables; }
        readonly HashSet<Customer> customers;

        readonly Butler butler;
        RoomClerk roomClerk;

        Thread tButler;
        Thread tClerk;
        Thread t;
        
        static Queue<RoomClerkEvent> roomClerkEvents;

        private Room()
        {
            butler = new Butler(this);
            roomClerk = new RoomClerk();

            customers = new HashSet<Customer>(0);
            roomClerkEvents = new Queue<RoomClerkEvent>();
            BuildRoom();

            tButler = new Thread(new ThreadStart(butler.Run));
            tButler.Start();

            tClerk = new Thread(new ThreadStart(roomClerk.Run));
            tClerk.Start();
        }

        private void BuildRoom()
        {
            reception = new Reception(40);
            areas = new HashSet<Area>(2);
            tables = new HashSet<Table>();
            for(int i = 0; i < 7; i++)
            {
                tables.Add(new Table(i, 2*i+2, ""));
            }
        }

        public static Room GetInstance()
        {
            return instance ?? (instance = new Room());
        }

        public void DeleteClient(Customer cust)
        {
            customers.Remove(cust);
            cust = null;
        }

        public static void AddRoomClerkEvent(RoomClerkEvent evt)
        {
            roomClerkEvents.Enqueue(evt);
        }

        public static RoomClerkEvent GetRoomClerkEvent()
        {
            if(roomClerkEvents.Count > 0)
                return roomClerkEvents.Dequeue();
            else
                return null;
        }

        public void Run()
        {
            int i = 0;
            while(i++ < 7)
            {
                Console.WriteLine("");
                Customer cust = new Customer(5, "");
                customers.Add(cust);
                reception.AddCustomer(cust);
                t = new Thread(new ThreadStart(cust.Run));
                t.Start();
                Thread.Sleep(500);

            }
            while(true);
        }
    }
}
