using Library.TransportationLayer.Socket;
using System;
using System.Threading;
using Library.Utils;
using Library.Utils.Nomenclature;

namespace Room
{
    class Program
    {
        static void Main(string[] args)
        {
            //Room room = Room.GetInstance();
            //room.Run();

            GlobalFactory injector = GlobalFactory.GetInstance();

            TransportationService test = injector.GetTransportationService(LocationEnum.ROOM, LocationEnum.KITCHEN);
            Thread.Sleep(8000);
            test.UpdateExternalSide(CommandeEnum.RECIPE_READY, "arg_custom_from_ROOM");
            Thread.Sleep(4000);
            test.UpdateExternalSide(CommandeEnum.RECIPE_READY, "arg1_custom_from_ROOM");
            Thread.Sleep(4000);
            test.UpdateExternalSide(CommandeEnum.RECIPE_READY, "arg2_custom_from_ROOM");
        }
    }
}
