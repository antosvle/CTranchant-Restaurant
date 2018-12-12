using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Utils.DTO
{
    public class RecipeDTO
    {
        public string Name { get; set; }

        public ISet<IngredientDTO> Ingredients { get; set; }
    }
}
