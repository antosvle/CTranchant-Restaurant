using Library.Controller;

namespace Kitchen.Model
{
    public class Cooker : Worker
    {
        public Cooker():
            base()
        {}

        public void Prepare(Recipe recipe)
        {
            Available = false;

            Shell.Log("COOKER START TASK: " + recipe.Description() + ".");

            Kitchen.Instance.WaitAvailableLackey().GatherIngredients(recipe.Ingredients);

            Timeline.Wait(600); 

            Shell.Log("COOKER END TASK: " + recipe.Description() + "." );

            Available = true;
        }
    }
}
