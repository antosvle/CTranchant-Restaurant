using Library.Utils;
using System.Threading;

namespace Library.Controller
{
    public static class Restaurant
    {

        public static void Start()
        {
            new Thread(() =>
            {
                while (true)
                {
                    Shell.Interprete();
                }

            }).Start();

            Timeline.Start();
        }
    }
}
