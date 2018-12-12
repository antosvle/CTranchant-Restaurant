using System;
using System.Collections.Generic;
using System.Text;
using Kitchen.Model;

namespace Kitchen
{
    public static class Filler
    {
        public static void Fill()
        {
            var recipe1 = Recipe.Get("Mushroom Soop");

            recipe1.Ingredients.Add(Ingredient.Get("Mushroom", 600));
            recipe1.Ingredients.Add(Ingredient.Get("Garlic", 1));
            recipe1.Ingredients.Add(Ingredient.Get("Shallot", 2));
            recipe1.Ingredients.Add(Ingredient.Get("Water", 1000));
            recipe1.Ingredients.Add(Ingredient.Get("Cream", 200));
            recipe1.Ingredients.Add(Ingredient.Get("Butter", 100));
            var instruction1 = new Instruction("Fire", 300);
            instruction1.Ustensils.Add("Pan");
            recipe1.Instructions.Add(new Instruction("Workshop", 120));
            recipe1.Instructions.Add(new Instruction("Mixer", 120));
            recipe1.Instructions.Add(instruction1);

            var recipe2 = Recipe.Get("Mashed Potatoes");
            recipe2.Ingredients.Add(Ingredient.Get("Potato", 1000));
            recipe2.Ingredients.Add(Ingredient.Get("Milk", 20));
            recipe2.Ingredients.Add(Ingredient.Get("Butter", 200));
            recipe2.Ingredients.Add(Ingredient.Get("Pepper", 5));

            recipe2.Instructions.Add(new Instruction("Workshop", 90));
            recipe2.Instructions.Add(new Instruction("Mixer", 200));
            recipe2.Instructions.Add(new Instruction("Fire", 90));

            var recipe3 = Recipe.Get("Chicken");
            recipe3.Ingredients.Add(Ingredient.Get("Chicken", 1));
            recipe3.Ingredients.Add(Ingredient.Get("Garlic", 2));

            recipe3.Instructions.Add(new Instruction("Workshop", 200));
            recipe3.Instructions.Add(new Instruction("Oven", 300));
        }
    }
}
