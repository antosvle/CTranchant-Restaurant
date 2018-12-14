using Library.Utils;
using System;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            TransportationService service = new TransportationService(LocationEnum.ROOM);

            service.UpdateExternalSide(LocationEnum.KITCHEN,
               Library.Utils.Nomenclature.CommandeEnum.ORDER,
                  "45|Burger Maison"
                );
        }
    }
}
