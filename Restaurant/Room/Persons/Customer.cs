﻿using Room.Components;
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
        }

        public void Run()
        {
            Console.WriteLine("customer : " + name);
            if (table != null)
            {
                // ask for bread
                AskBread();
                Timeline.Wait(300);

                // order the meal
                GiveOrder();

                status = EStatus.waitingPaying;
            }
        }
    }
}
