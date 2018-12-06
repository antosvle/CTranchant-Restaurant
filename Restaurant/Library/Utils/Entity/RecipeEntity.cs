using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Utils.Entity
{
    internal class RecipeEntity
    {
        private int recipe_id;
        private String recipe_category;
        private String recipe_name;
        private int nb_people;
        private String recipe_speciality;
        private String recipe_description;

        internal RecipeEntity(int id, String category, String name, int nb_people, String speciality, String description)
        {
            this.recipe_id = id;
            this.recipe_name = name;
            this.recipe_category = category;
            this.nb_people = nb_people;
            this.recipe_speciality = speciality;
            this.recipe_description = description;
        }

        internal int Recipe_id { get => recipe_id; set => recipe_id = value; }

        internal string Recipe_category { get => recipe_category; set => recipe_category = value; }

        internal string Recipe_name { get => recipe_name; set => recipe_name = value; }

        internal int Nb_people { get => nb_people; set => nb_people = value; }

        internal string Recipe_speciality { get => recipe_speciality; set => recipe_speciality = value; }

        internal string Recipe_description { get => recipe_description; set => recipe_description = value; }
    }
}
