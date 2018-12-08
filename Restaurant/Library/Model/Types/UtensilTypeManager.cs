using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Model.Types
{
    class UtensilTypeManager : TypeManager<UtensilType>
    {
        protected override UtensilType NewType(string name)
        {
            return new UtensilType(name);
        }
    }
}
