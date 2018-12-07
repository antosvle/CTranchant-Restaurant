using System.Collections.Generic;

namespace Library.Model.Types
{
    public abstract class TypeManager<SpecificType> where SpecificType : Type
    {
        private HashSet<SpecificType> types;

        public TypeManager()
        {
            this.types = new HashSet<SpecificType>();
        }

        public abstract SpecificType NewType(string name);
        
        public SpecificType CreateType(string name)
        {
            foreach (Type type in types)
            {
                if (name == type.Name.String)
                {
                    return null;
                }
            }

            return this.NewType(name);
        }
    }
}
