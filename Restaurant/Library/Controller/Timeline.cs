using System.Collections.Generic;
using System.Threading;
using System.Collections.Specialized;

namespace Library.Controller
{
    class Timeline
    {
        private static IDictionary<long, List<ManualResetEvent>> Locks = new SortedDictionary<long, List<ManualResetEvent>>();

        private static int UnitDuration { get; set; } = 0;

        private static long CurrentTimestamp = 0;
        
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
            long timestamp = Timeline.CurrentTimestamp + units;

            List<ManualResetEvent> threads = Timeline.Locks[timestamp];

            if (threads == null)
            {
                threads.Add(new ManualResetEvent(false));
            }
            else
            {
                List<ManualResetEvent> locks = new List<ManualResetEvent>();

                locks.Add(new ManualResetEvent(false));

                Locks.Add(timestamp, locks);
            }


            Thread.CurrentThread.Resume();
            Thread.CurrentThread.Suspend();
        }

        private static void Advance()
        {
            Timeline.CurrentTimestamp++;
        }
    }
}
