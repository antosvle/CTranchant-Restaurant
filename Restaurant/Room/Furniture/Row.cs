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

        HashSet<Table> tables;
        Queue<RowChiefEvent> rowChiefEvents;

        public Row(HashSet<Table> tbls)
        {
            tables = tbls;
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
            return rowChiefEvents.Dequeue();
        }
    }
}
