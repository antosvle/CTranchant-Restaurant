using Library.TransportationLayer.Socket;
using System;
using System.Threading;
using Library.Utils;


namespace Room
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Room room = Room.GetInstance();
            room.Run();*/

            ClientSocket Client = new ClientSocket(LocationEnum.ROOM, LocationEnum.KITCHEN);
            Client.Send("Bigoune a un gros penis");

            Client.Send("Whallahsss");
        }
    }
}
