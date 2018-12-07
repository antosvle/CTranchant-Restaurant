using System.Collections.Generic;

namespace Library.Model
{
    public abstract class Holding<Holdable> where Holdable : IHoldable
    {
        private HashSet<Holdable> holdables;

        private IHolder holder;

        public Holding(IHolder holder)
        {
            this.holdables = new HashSet<Holdable>();
            this.holder = holder;
        }

        public IHolder Holder
        {
            get { return this.holder; }
        }

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
