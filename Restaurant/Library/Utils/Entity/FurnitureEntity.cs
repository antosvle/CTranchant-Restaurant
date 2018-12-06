using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Utils.Entity
{
    internal class FurnitureEntity
    {
        private int furniture_id;
        private String furniture_name;
        private int furniture_quantity;

        internal FurnitureEntity(int id, String name, int quantity)
        {
            this.furniture_id = id;
            this.furniture_name = name;
            this.furniture_quantity = quantity;
        }

        internal int Furniture_id { get => furniture_id; set => furniture_id = value; }

        internal string Furniture_name { get => furniture_name; set => furniture_name = value; }

        internal int Furniture_quantity { get => furniture_quantity; set => furniture_quantity = value; }
    }
}
