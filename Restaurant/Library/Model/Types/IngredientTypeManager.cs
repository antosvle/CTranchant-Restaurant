using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Model.Types
{
    class IngredientTypeManager : TypeManager<IngredientType>
    {
        protected override IngredientType NewType(string name)
        {
            return new IngredientType(name);
        }
    }
}
