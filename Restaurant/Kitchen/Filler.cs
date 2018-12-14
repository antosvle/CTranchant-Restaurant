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

            recipe1.Ingredients.Add(new Ingredient("Mushroom", 600));
            recipe1.Ingredients.Add(new Ingredient("Garlic", 1));
            recipe1.Ingredients.Add(new Ingredient("Shallot", 2));
            recipe1.Ingredients.Add(new Ingredient("Water", 1000));
            recipe1.Ingredients.Add(new Ingredient("Cream", 200));
            recipe1.Ingredients.Add(new Ingredient("Butter", 100));
            var instruction1 = new Instruction("Workshop", 120);
            instruction1.Utensils.Add("Kitchen Knife");
            var instruction2 = new Instruction("Fire", 300);
            instruction2.Utensils.Add("Pan");
            instruction2.Utensils.Add("Wooden Spoon");
            recipe1.Instructions.Add(instruction2);
            recipe1.Instructions.Add(new Instruction("Mixer", 120));
            recipe1.Instructions.Add(instruction1);

            var recipe2 = Recipe.Get("Mashed Potatoes");
            recipe2.Ingredients.Add(new Ingredient("Potato", 1000));
            recipe2.Ingredients.Add(new Ingredient("Milk", 20));
            recipe2.Ingredients.Add(new Ingredient("Butter", 200));
            recipe2.Ingredients.Add(new Ingredient("Pepper", 5));
            var instruction3 = new Instruction("Workshop", 90);
            instruction3.Utensils.Add("Wooden Spoon");
            var instruction4 = new Instruction("Workshop", 90);
            instruction4.Utensils.Add("Pan");
            recipe2.Instructions.Add(instruction3);
            recipe2.Instructions.Add(new Instruction("Mixer", 200));
            recipe2.Instructions.Add(instruction4);

            var recipe3 = Recipe.Get("Chicken");
            recipe3.Ingredients.Add(new Ingredient("Chicken", 1));
            recipe3.Ingredients.Add(new Ingredient("Garlic", 2));
            recipe3.Instructions.Add(new Instruction("Workshop", 200));
            recipe3.Instructions.Add(new Instruction("Oven", 300));
        }
    }
}
