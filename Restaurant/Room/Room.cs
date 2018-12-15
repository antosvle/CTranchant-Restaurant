using Room.Components;
using Room.Events;
using Room.Persons;
using Library.Controller;
using System;
using System.Collections.Generic;
using System.Threading;
using Library.Utils;

namespace Room
{
    public class Room
    {
        static Room instance;

        public static TransportationService socketManager;

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
        private readonly Dictionary<Waiter, Thread> waiters;

        readonly Butler butler;
        readonly RoomClerk roomClerk;

        Thread tButler;
        Thread tClerk;
        
        static Queue<RoomClerkEvent> roomClerkEvents;

        private Room()
        {
            // Furnitures
            reception = new Reception(40);

            Bar.InitListener();

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

            rows[0].Area = areas[0];
            rows[1].Area = areas[0];
            rows[2].Area = areas[1];
            rows[3].Area = areas[1];
            
            // Events
            roomClerkEvents = new Queue<RoomClerkEvent>();

            // People
            customers = new Dictionary<Customer, Thread>();
            butler = new Butler(this);
            roomClerk = new RoomClerk();
            waiters = new Dictionary<Waiter, Thread>();

            for(int i = 0; i < 4; i++)
            {
                Waiter waiter = new Waiter(areas[i % 2]);
                waiters.Add(waiter, new Thread(new ThreadStart(waiter.Run)));
                waiters[waiter].Start();
            }

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
            if(cust.Table != null)
                cust.Table.Row.Area.AddWaiterEvent(new WaiterEvent(WaiterEventEnum.cleanTable, cust.Table));
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
            while(i++ < 3)
            {
                Console.WriteLine("");
                List<string> dishes = null;

                //Scenario (voir script sur git)
                //if (i == 1) dishes = new List<string>() { "Salade de cabilaud", "Gigot d agneau", "Tarte aux pommes"};
                if(true) dishes = new List<string>() { "Burger Maison"};
                //else dishes = new List<string>() { "Salade de cabilaud", "Flan coco"};

                Customer cust = new Customer(2, i.ToString(), new Order(dishes));
                reception.AddCustomer(cust);
                customers.Add(cust, new Thread(new ThreadStart(cust.Run)));
                customers.GetValueOrDefault(cust).Name = "customer " + cust.Name;
                customers.GetValueOrDefault(cust).Start();
                Timeline.Wait(50);
            }
            while(true);
        }
    }
}
