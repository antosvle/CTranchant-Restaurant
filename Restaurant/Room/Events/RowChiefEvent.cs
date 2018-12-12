using Room.Components;
using Room.Persons;
using System;
using System.Collections.Generic;
using System.Text;

namespace Room.Events
{
    public enum RowChiefEventEnum
    {
        getMenu,
        getOrder,
    }

    public class RowChiefEvent
    {
        private readonly RowChiefEventEnum evt;
        public RowChiefEventEnum Event { get => evt; }

        private readonly Table table;
        public Table Table { get => table; }

        public RowChiefEvent(RowChiefEventEnum evnt, Table tabl)
        {
            evt = evnt;
            table = tabl;
        }
    }
}
