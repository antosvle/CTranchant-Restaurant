using Library.Controller;
using Library.DatabaseLayer;
using Library.Utils;
using System.Threading;

namespace Kitchen.Model
{
    public class Chief
    {
        public void Manage(Order order)
        {
            Shell.Log("CHIEF START TASK");

            new Thread(() =>
            {
                LogService.WriteLog(LocationEnum.KITCHEN, "Class: Chief.cs Method: Manage Message: Chief start task");

                int count = order.Dishes.Count;

                Semaphore semaphore = new Semaphore(0, count);

                foreach (string name in order.Dishes)
                {
                    new Thread(() =>
                    {
                        Kitchen.Instance.WaitAvailableCooker().Prepare(Recipe.Get(name));

                        semaphore.Release();

                    }).Start();

                    Timeline.Wait(5);
                }

                for (int i = 0, n = order.Dishes.Count; i < n; i++)
                {
                    semaphore.WaitOne();
                }

                Shell.Log("CHIEF END TASK");

                Bar.Send(order, Library.Utils.LocationEnum.IHM);

            }).Start();
        }
    }
}
