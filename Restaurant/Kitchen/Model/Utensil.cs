using System;
using System.Collections.Generic;
using System.Text;

namespace Kitchen.Model
{
    public class Utensil : Waitable
    {
        public string Name { get; private set; }

        public Utensil(string name):
            base()
        {
            Name = name;
        }

        public string Description()
        {
            return "{" + Name + "}";
        }
    }
}
