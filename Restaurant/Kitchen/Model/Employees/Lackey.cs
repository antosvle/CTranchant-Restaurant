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

            string message = "LACKEY START TASK: "; foreach (Ingredient ingredient in ingredients) { message += ingredient.Description(); } message += ".";

            Shell.Log(message);

            Timeline.Wait(20);

            foreach (Ingredient ingredient in ingredients)
            {
                Ingredient.Get(ingredient);
            }

            message = "LACKEY END TASK: "; foreach (Ingredient ingredient in ingredients) { message += ingredient.Description(); } message += ".";

            Shell.Log(message);

            Available = true;
        }
    }
}
