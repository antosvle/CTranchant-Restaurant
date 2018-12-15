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
            Thread.Sleep(5000);
            GlobalFactory factory = GlobalFactory.GetInstance();

            Room.socketManager = factory.GetTransportationService(LocationEnum.ROOM);
            Room room = Room.GetInstance();

            new Thread(() =>
            {
                room.Run();
            }).Start();

            Restaurant.Start();
        }
    }
}
