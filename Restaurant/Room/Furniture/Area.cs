using Room.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Room.Components
{
    public class Area
    {
        private int id;
        public int Id { get => id; set => id = value; }

        private List<Row> rows;
        private Queue<WaiterEvent> waiterEvents;

        public Area()
        {
            rows = new List<Row>();
            waiterEvents = new Queue<WaiterEvent>();
        }

        public Area(List<Row> rws)
        {
            rows = rws;
            waiterEvents = new Queue<WaiterEvent>();
        }

        public void AddRow(Row rw)
        {
            rows.Add(rw);
        }

        public void AddWaiterEvent(WaiterEvent evt)
        {
            waiterEvents.Enqueue(evt);
        }

        public WaiterEvent GetWaiterEvent()
        {
            lock(waiterEvents)
            {
                if (waiterEvents.Count > 0)
                    return waiterEvents.Dequeue();
                else
                    return null;
            }
        }
    }
}
