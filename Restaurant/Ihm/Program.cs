using Library;
using Library.DatabaseLayer;
using Library.Utils;
using Library.Utils.DTO;
using System;
using System.Collections.Generic;

namespace Ihm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TEST");

            DataFactory injector = DataFactory.GetInstance();

            KitchenService test = injector.GetKitchenService();

            InstructionDTO dto = test.GetOneInstruction("Burger Maison",1);

            Console.WriteLine(dto.Furniture);
            Console.WriteLine(dto.Utensils[0]);
            Console.WriteLine("done");
            Console.Read();
        }
    }
}
