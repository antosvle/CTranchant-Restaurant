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

        public Row(HashSet<Table> tbls)
        {
            tables = tbls;
        }

        public void AddTable(Table tbl)
        {
            tables.Add(tbl);
        }
    }
}
