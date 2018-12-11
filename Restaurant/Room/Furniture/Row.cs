using Room.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Room.Components
{
    public class Row
    {
        private int id;
        public int Id { get => id; set => id = value; }

        private readonly Area area;
        public Area Area { get => area; }

        HashSet<Table> tables;
        public Queue<RowChiefEvent> rowChiefEvents;

        public Row()
        {
            tables = new HashSet<Table>();
            rowChiefEvents = new Queue<RowChiefEvent>();
        }

        public Row(Area are)
        {
            area = are;
            rowChiefEvents = new Queue<RowChiefEvent>();
        }

        public void AddTable(Table tbl)
        {
            tables.Add(tbl);
        }

        public void AddRowChiefEvent(RowChiefEvent evt)
        {
            rowChiefEvents.Enqueue(evt);
        }

        public RowChiefEvent GetRowChiefEvent()
        {
            if(rowChiefEvents.Count > 0)
                return rowChiefEvents.Dequeue();
            else
                return null;
        }
    }
}
