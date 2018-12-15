using Library;
using Library.DatabaseLayer;
using Library.Utils;
using Library.Utils.DTO;
using System;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            /*DataFactory factory = DataFactory.GetInstance();
            KitchenService service = factory.GetKitchenService();
            RecipeDTO recipe = service.GetOneRecipe("Cheesecake");

            Console.WriteLine("GO :");
            Console.WriteLine(recipe.Ingredients.Count);
            Console.WriteLine(recipe.Name);
            Console.WriteLine("DONE");
            Console.Read();*/

            TransportationService com = new TransportationService(LocationEnum.ROOM);

            com.UpdateExternalSide(
                LocationEnum.KITCHEN, 
                Library.Utils.Nomenclature.CommandeEnum.ORDER,
                "2|Burger Maison"
                );
        }
    }
}
