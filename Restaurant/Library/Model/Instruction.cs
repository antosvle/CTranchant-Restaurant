using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Model
{
    class Instruction
    {
        protected HashSet<Utensils> Utensils { get; }

        protected HashSet<Ingredients> Ingredients { get; }

        protected Furniture Furniture { get; }

        Instruction()
        {}
    }
}
