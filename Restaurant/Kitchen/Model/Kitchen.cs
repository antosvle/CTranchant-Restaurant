using System.Collections.Generic;
using System.Threading;

namespace Kitchen.Model
{
    public class Kitchen
    {
        private static int cookersNumber = 6;

        private static int lackeysNumber = 1;

        private static int washersNumber = 2;

        public static Kitchen Instance { get; } = new Kitchen();

        public Chief Chief { get; private set; }

        public ISet<Cooker> Cookers { get; private set; } = new HashSet<Cooker>();

        public ISet<Lackey> Lackeys { get; private set; } = new HashSet<Lackey>();

        public ISet<Washer> Washers { get; private set; } = new HashSet<Washer>();

        public ManualResetEvent cookersAvailability = new ManualResetEvent(false);
        
        private Kitchen()
        {
            Chief = new Chief();

            for (int i = 0; i < cookersNumber; i++)
            {
                Cookers.Add(new Cooker());
            }

            for (int i = 0; i < lackeysNumber; i++)
            {
                Lackeys.Add(new Lackey());
            }

            for (int i = 0; i < washersNumber; i++)
            {
                Washers.Add(new Washer());
            }
        }

        public Cooker WaitAvailableCooker()
        {
            while(true)
            {
                foreach (Cooker cooker in Cookers)
                {
                    if (cooker.Available)
                    {
                        cookersAvailability.Reset();

                        return cooker;
                    }
                }

                lock (cookersAvailability)
                {
                    cookersAvailability.WaitOne();
                }
            }
        }

        public void UpdateCookersAvailability()
        {
            cookersAvailability.Set();
        }
    }
}
