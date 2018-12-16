using Library.DatabaseLayer;
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
                LogService.WriteLog(LocationEnum.LIBRARY, "Class: Restaurant.cs Method: Start Message: Load shell session.");

                while (true)
                {
                    Shell.Interprete();
                }

            }).Start();

            Timeline.Start();
        }
    }
}
