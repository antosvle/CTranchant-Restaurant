using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Utils.Entity
{
    internal class TablewareEntity
    {
        private int tableware_id;
        private String tableware_name;
        private int tableware_quantity;

        internal TablewareEntity(int id, String name, int quantity)
        {
            this.tableware_id = id;
            this.tableware_name = name;
            this.tableware_quantity = quantity;
        }

        internal int Tableware_id { get => tableware_id; set => tableware_id = value; }

        internal string Tableware_name { get => tableware_name; set => tableware_name = value; }

        internal int Tableware_quantity { get => tableware_quantity; set => tableware_quantity = value; }
    }
}
