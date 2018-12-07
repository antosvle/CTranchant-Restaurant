using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Utils.DTO
{
    public class IngredientDTO
    {
        private String name;
        private int fresh_duration;

        public IngredientDTO() { }

        public string Name { get => name; set => name = value; }

        public int Fresh_duration { get => fresh_duration; set => fresh_duration = value; }
    }
}
