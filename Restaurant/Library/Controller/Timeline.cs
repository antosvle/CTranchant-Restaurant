using System;
using System.Collections.Generic;
using System.Threading;

namespace Library.Controller
{
    public class Timeline
    {
        private static IDictionary<long, List<ManualResetEvent>> lockers = new SortedDictionary<long, List<ManualResetEvent>>();

        public static int UnitDuration { get; set; } = 1000;

        private static long CurrentTime = 0;
        
        public static void Start()
        {
            while (true)
            {
                Thread.Sleep(UnitDuration);

                Timeline.Advance();
            }
        }

        public static void Wait(long units)
        {
            Timeline.AddLocker(Timeline.CurrentTime + units).WaitOne();
        }

        private static void Advance()
        {
            Timeline.CurrentTime++;

            List<ManualResetEvent> lockers = Timeline.GetLocker(Timeline.CurrentTime);

            if (lockers != null)
            {
                foreach (ManualResetEvent locker in lockers)
                {
                    locker.Set();
                }

                Timeline.lockers.Remove(Timeline.CurrentTime);
            }
        }

        private static ManualResetEvent AddLocker(long time)
        {
            List<ManualResetEvent> lockers = Timeline.GetLocker(time);

            ManualResetEvent locker = new ManualResetEvent(false);

            if (lockers != null)
            {
                lockers.Add(locker);
            }
            else
            {
                List<ManualResetEvent> locks = new List<ManualResetEvent>();

                locks.Add(locker);

                Timeline.lockers.Add(time, locks);
            }

            return locker;
        }

        private static List<ManualResetEvent> GetLocker(long time)
        {
            List<ManualResetEvent> lockers;

            try
            {
                lockers = Timeline.lockers[time];
            }
            catch(Exception)
            {
                lockers = null;
            }

            return lockers;
        }
    }
}
