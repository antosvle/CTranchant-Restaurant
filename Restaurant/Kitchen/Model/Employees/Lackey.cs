using Library.Controller;
using System.Collections.Generic;

namespace Kitchen.Model
{
    public class Lackey
    {
        public ISet<Ingredient> GatherIngredients(IDictionary<string, int> entries)
        {
            ISet<Ingredient> ingredients = new HashSet<Ingredient>();

            Timeline.Wait(60);

            foreach (KeyValuePair<string, int> entry in entries)
            {
                Ingredient.Get(entry.Key, entry.Value);
            }

            return ingredients;
        }
    }
}
