using Library.Controller;
using System.Collections.Generic;
using System.Threading;

namespace Kitchen.Model
{
    public class Cooker : Waitable
    {
        public Cooker():
            base()
        {}

        public void Prepare(Recipe recipe)
        {
            Available = false;

            Kitchen.Instance.WaitAvailableLackey().GatherIngredients(recipe.Ingredients);

            foreach (Instruction instruction in recipe.Instructions)
            {
                ISet<Utensil> utensils = new HashSet<Utensil>();

                foreach (string name in instruction.Utensils)
                {
                    utensils.Add(Kitchen.Instance.WaitAvailableUtensil(name));
                }

                Shell.Log("A cooker is going to use a {" + instruction.Furniture + "} for {" + instruction.Time + "}s.");

                instruction.Execute();

                new Thread(() =>
                {
                    Kitchen.Instance.WaitAvailableWasher().Wash(utensils);

                }).Start();
            }

            Available = true;
        }
    }
}
