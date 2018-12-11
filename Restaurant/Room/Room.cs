using Room.Components;
using Room.Events;
using Room.Persons;
using Library.Controller;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Room
{
    public class Room
    {
        static Room instance;

        private readonly Reception reception;
        public Reception Reception { get => reception; } 

        private List<Table> tables;
        public List<Table> Tables { get => tables; }

        private readonly List<Row> rows;
        public List<Row> Rows { get => rows; }

        private readonly List<Area> areas;
        public List<Area> Areas { get => areas; }

        private readonly Dictionary<Customer, Thread> customers;
        private readonly Dictionary<RowChief, Thread> rowChiefs;

        readonly Butler butler;
        readonly RoomClerk roomClerk;

        Thread tButler;
        Thread tClerk;
        
        static Queue<RoomClerkEvent> roomClerkEvents;

        private Room()
        {
            // Furnitures
            reception = new Reception(40);

            rows = new List<Row>();
            for(int i = 0; i < 4; i++)
            { rows.Add(new Row()); }

            tables = new List<Table>();
            for(int i = 0; i < 7; i++)
            {
                tables.Add(new Table(i, 2 + 2 * i, ""));
                tables[i].Row = rows[i%4];
            }

            areas = new List<Area>();
            areas.Add(new Area());
            areas[0].AddRow(rows[0]);
            areas[0].AddRow(rows[1]);
            areas.Add(new Area());
            areas[1].AddRow(rows[2]);
            areas[1].AddRow(rows[3]);
            
            // Events
            roomClerkEvents = new Queue<RoomClerkEvent>();

            // People
            customers = new Dictionary<Customer, Thread>();
            butler = new Butler(this);
            roomClerk = new RoomClerk();

            rowChiefs = new Dictionary<RowChief, Thread>();
            for(int i = 0; i < rows.Count; i++)
            {
                RowChief rc = new RowChief(this, rows[i]);
                rowChiefs.Add(rc, new Thread(new ThreadStart(rc.Run)));
                rowChiefs[rc].Start();
            }

            tButler = new Thread(new ThreadStart(butler.Run));
            tButler.Start();

            tClerk = new Thread(new ThreadStart(roomClerk.Run));
            tClerk.Start();
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
                Customer cust = new Customer(5, i.ToString());
                reception.AddCustomer(cust);
                customers.Add(cust, new Thread(new ThreadStart(cust.Run)));
                customers.GetValueOrDefault(cust).Start();
                Timeline.Wait(30);
            }
            while(true);
        }
    }
}
