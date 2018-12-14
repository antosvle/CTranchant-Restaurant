using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Utils.Entity
{
    internal class UstensilEntity
    {
        private int ustensil_id;
        private String ustensil_name;
        private int ustensil_quantity;

        internal UstensilEntity(int id, String name, int quantity)
        {
            this.ustensil_id = id;
            this.ustensil_name = name;
            this.ustensil_quantity = quantity;
        }

        internal int Ustensil_id { get => ustensil_id; set => ustensil_id = value; }

        internal string Ustensil_name { get => ustensil_name; set => ustensil_name = value; }

        internal int Ustensil_quantity { get => ustensil_quantity; set => ustensil_quantity = value; }
    }
}
