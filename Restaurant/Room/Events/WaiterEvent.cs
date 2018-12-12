using Room.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Room.Events
{
    public enum WaiterEventEnum
    {
        cleanTable,
        mealReady,
    }

    public class WaiterEvent
    {
        private readonly WaiterEventEnum evt;
        public WaiterEventEnum Event { get => evt; }

        private readonly Table table;
        public Table Table { get => table; }

        public WaiterEvent(WaiterEventEnum state, Table tabl)
        {
            evt = state;
            table = tabl;
        }
    }
}
