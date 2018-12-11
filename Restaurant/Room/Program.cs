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
            Room room = Room.GetInstance();
            new Thread(() =>
            {
                room.Run();
            }).Start();
            Restaurant.Start();
        }
    }
}
