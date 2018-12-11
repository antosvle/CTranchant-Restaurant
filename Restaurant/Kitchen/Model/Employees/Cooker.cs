using Library.Controller;
using System;

namespace Kitchen.Model
{
    public class Cooker
    {
        private bool available;

        public Cooker()
        {
            available = true;
        }

        public bool Available
        {
            get { return available; }
            set
            {
                available = value;

                if (available)
                {
                    Kitchen.Instance.UpdateCookersAvailability();
                }
            }
        }

        public void Prepare(Recipe recipe)
        {
            this.Available = false;

            Console.WriteLine("A cooker is preparing the recipe {" + recipe.Name + "}.");

            Timeline.Wait(300);

            Console.WriteLine("A cooker has prepared the recipe {" + recipe.Name + "}.");

            this.Available = true;
        }
    }
}
