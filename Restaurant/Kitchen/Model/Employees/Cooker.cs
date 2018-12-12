using Library.Controller;

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

            Shell.Log("COOKER START TASK: " + recipe.Description() + ".");

            Kitchen.Instance.WaitAvailableLackey().GatherIngredients(recipe.Ingredients);

            foreach (Instruction instruction in recipe.Instructions)
            {
                instruction.Execute();
            }

            Shell.Log("COOKER END TASK: " + recipe.Description() + "." );

            Available = true;
        }
    }
}
