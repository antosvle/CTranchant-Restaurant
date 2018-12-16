using Library.Controller;
using Library.DatabaseLayer;
using Library.Utils;
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
                    LogService.WriteLog(LocationEnum.KITCHEN, "Class: Coocker.cs Method: Prepare Message: Wait an available washer to wash an utensil");
                    Kitchen.Instance.WaitAvailableWasher().Wash(utensils);

                }).Start();
            }

            Available = true;
        }
    }
}
