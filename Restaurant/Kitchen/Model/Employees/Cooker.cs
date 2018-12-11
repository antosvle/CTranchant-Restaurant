using Library.Controller;

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

            Shell.Log("A cooker is preparing the recipe {" + recipe.Name + "}.");

            Timeline.Wait(600);

            Shell.Log("A cooker has prepared the recipe {" + recipe.Name + "}.");

            this.Available = true;
        }
    }
}
