using System;
using System.Collections.Generic;
using System.Text;

namespace Room.Components
{
    public class Area
    {
        private int id;
        public int Id { get => id; set => id = value; }

        private HashSet<Row> rows;

        public Area(HashSet<Row> rws)
        {
            rows = rws;
        }

        public void AddRow(Row rw)
        {
            rows.Add(rw);
        }
    }
}
