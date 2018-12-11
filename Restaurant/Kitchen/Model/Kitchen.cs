using System.Collections.Generic;
using System.Threading;

namespace Kitchen.Model
{
    public class Kitchen
    {
        private static int cookersNumber = 6;

        private static int lackeysNumber = 2;

        private static int washersNumber = 2;

        public static Kitchen Instance { get; } = new Kitchen();

        public Chief Chief { get; private set; }

        public ISet<Cooker> Cookers { get; private set; } = new HashSet<Cooker>();

        public ISet<Lackey> Lackeys { get; private set; } = new HashSet<Lackey>();

        public ISet<Washer> Washers { get; private set; } = new HashSet<Washer>();

        public ManualResetEvent workersAvailability = new ManualResetEvent(false);

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
                        workersAvailability.Reset();

                        return cooker;
                    }
                }

                lock (workersAvailability)
                {
                    workersAvailability.WaitOne();
                }
            }
        }

        public Lackey WaitAvailableLackey()
        {
            while (true)
            {
                foreach (Lackey lackey in Lackeys)
                {
                    if (lackey.Available)
                    {
                        workersAvailability.Reset();

                        return lackey;
                    }
                }

                lock (workersAvailability)
                {
                    workersAvailability.WaitOne();
                }
            }
        }

        public void UpdateWorkersAvailability()
        {
            workersAvailability.Set();
        }
    }
}
