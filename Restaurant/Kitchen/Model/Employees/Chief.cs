using System.Threading;

namespace Kitchen.Model
{
    public class Chief
    {
        public void Manage(Order order)
        {
            new Thread(() =>
            {
                foreach (string name in order.Dishes)
                {
                    Kitchen.Instance.WaitAvailableCooker().Prepare(Recipe.Get(name));
                }

            }).Start();
        }
    }
}
