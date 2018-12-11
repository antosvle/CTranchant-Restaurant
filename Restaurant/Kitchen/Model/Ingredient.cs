using System;
using System.Collections.Generic;
using System.Text;

namespace Kitchen.Model
{
    public class Ingredient
    {
        public string Name { get; private set; }
        public int Quantity { get; private set; }

        private Ingredient(string name, int quantity)
        {
            this.Name = name;
            this.Quantity = quantity;
        }

        public static Ingredient Get(string name, int quantity)
        {
            return new Ingredient(name, quantity);
        }
    }
}
