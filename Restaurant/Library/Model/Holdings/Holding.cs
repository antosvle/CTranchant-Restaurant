using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Model
{
    class Holding<Holdable> where Holdable : IHoldable
    {
        private HashSet<Holdable> holdables;

        public Holdable Give(Holdable holdable)
        {
            if (holdables.Contains(holdable))
            {
                return holdable;
            }
            else
            {
                return default(Holdable);
            }
        }

        public void Take(Holdable holdable)
        {
            holdables.Add(holdable);
        }
    }
}
