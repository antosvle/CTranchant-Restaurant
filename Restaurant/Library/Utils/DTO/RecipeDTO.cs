using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Utils.DTO
{
    public class RecipeDTO
    {
        public string Name { get; set; } = null;

        public ISet<IngredientDTO> Ingredients { get; set; } = new HashSet<IngredientDTO>();

        public IList<InstructionDTO> = new List<InstructionDTO>();
    }
}
