using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Model
{
    class Utensils : ITyped<UtensilType>
    {
       public UtensilType Type { get; }
    }
}
