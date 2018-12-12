using Library.TransportationLayer.Socket;
using System;
using System.Threading;
using Library.Utils;
using Library.Controller;

namespace Room
{
    class Program
    {
        static void Main(string[] args)
        {
            GlobalFactory factory = GlobalFactory.GetInstance();

            Room room = Room.GetInstance();
            //Room.socketManager = factory.GetTransportationService(LocationEnum.ROOM);
            new Thread(() =>
            {
                room.Run();
            }).Start();

            Restaurant.Start();
        }
    }
}
