using Library.Controller;
using System.Collections.Generic;

namespace Kitchen.Model
{
    public class Lackey : Waitable
    {
        public Lackey():
            base()
        {}

        public void GatherIngredients(ISet<Ingredient> ingredients)
        {
            Available = false;
            
            Timeline.Wait(20);

            foreach (Ingredient ingredient in ingredients)
            {
                Timeline.Wait(5);

                Shell.Log("A lackey is picking up: " + ingredient.Description() + ".");
            }
            
            Available = true;
        }
    }
}
