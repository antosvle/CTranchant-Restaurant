using Library.Controller;
using System.Collections.Generic;

namespace Kitchen.Model
{
    public class Washer : Waitable
    {
        public Washer():
            base()
        {}

        public void Wash(ISet<Utensil> utensils)
        {
            foreach (Utensil utensil in utensils)
            {
                Timeline.Wait(10);

                utensil.Available = true;

                Shell.Log("A washer has washed a " + utensil.Description() + ".");
            }
        }
    }
}
