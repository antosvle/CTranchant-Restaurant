using System;
using System.Collections.Generic;
using System.Threading;

namespace Library.Controller
{
    public class Timeline
    {
        private static volatile IDictionary<long, List<ManualResetEvent>> lockers = new SortedDictionary<long, List<ManualResetEvent>>();

        private static volatile int unitDuration = 1000;

        private static volatile int CurrentTime = 0;
        
        public static int UnitDuration
        {
            get { return Timeline.unitDuration; }
            set { Timeline.unitDuration = value;  }
        }

        public static void Start()
        {
            while (true)
            {
                Thread.Sleep(unitDuration);

                Timeline.Advance();
            }
        }

        public static void Wait(int units)
        {
            Timeline.AddLocker(Timeline.CurrentTime + units).WaitOne();
        }

        private static void Advance()
        {
            lock (Timeline.lockers)
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
        }

        private static ManualResetEvent AddLocker(int time)
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

                lock (Timeline.lockers)
                {
                    Timeline.lockers.Add(time, locks);
                }
            }

            return locker;
        }

        private static List<ManualResetEvent> GetLocker(int time)
        {
            lock (Timeline.lockers)
            {
                if (!Timeline.lockers.ContainsKey(time))
                {
                    return null;
                }

                return Timeline.lockers[time];
            }
        }
    }
}
