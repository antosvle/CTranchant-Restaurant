using Library.Controller;
using System.Threading;

namespace Kitchen.Model
{
    public class Chief
    {
        public void Manage(Order order)
        {
            Shell.Log("The chief is managing an order.");

            new Thread(() =>
            {
                int count = order.Dishes.Count;

                Semaphore semaphore = new Semaphore(0, count);

                foreach (string name in order.Dishes)
                {
                    new Thread(() =>
                    {
                        Shell.Log("The chief is distributing a recipe {" + name + "}.");

                        Kitchen.Instance.WaitAvailableCooker().Prepare(Recipe.Get(name));

                        semaphore.Release();

                    }).Start();

                    Timeline.Wait(5);
                }

                for (int i = 0, n = order.Dishes.Count; i < n; i++)
                {
                    semaphore.WaitOne();
                }

                Shell.Log("The chief has satisfied an order.");

            }).Start();
        }
    }
}
