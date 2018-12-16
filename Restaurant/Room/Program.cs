using Library.TransportationLayer.Socket;
using System;
using System.Threading;
using Library.Utils;
using Library.Controller;
using Library.DatabaseLayer;

namespace Room
{
    class Program
    {
        static void Main(string[] args)
        {
            LogService.WriteLog(LocationEnum.ROOM, "MainProcess Room Class: Program.cs Method: Main Message: Start the Room");

            Thread.Sleep(5000);
            GlobalFactory factory = GlobalFactory.GetInstance();

            Room.socketManager = factory.GetTransportationService(LocationEnum.ROOM);
            Room room = Room.GetInstance();

            new Thread(() =>
            {
                LogService.WriteLog(LocationEnum.ROOM, "Class: Program.cs Method: Main Message: Start the room");
                room.Run();
            }).Start();

            Restaurant.Start();
        }
    }
}
