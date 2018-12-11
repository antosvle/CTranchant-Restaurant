using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using Library.Utils;

namespace Library.TransportationLayer.Socket
{
    internal class ClientSocket
    {
        private LocationEnum Destination;
        private LocationEnum Hote;


        internal ClientSocket(LocationEnum hote, LocationEnum destination)
        {
            this.Destination = destination;
            this.Hote = hote;
        }


        internal void Send(String message)
        {
            int port;
            String ipAdress;

            if (Destination == LocationEnum.KITCHEN)
            {
                port = NetworkConfig.PORT_KITCHEN;
                ipAdress = NetworkConfig.IP_SERVER_KITCHEN;
            }
            else
            {
                port = NetworkConfig.PORT_ROOM;
                ipAdress = NetworkConfig.IP_SERVER_ROOM;
            }


            try {
                new Thread(delegate ()
                {
                    TcpClient Client = new TcpClient(ipAdress, port);
                    Byte[] Data = Encoding.ASCII.GetBytes(message);
                    NetworkStream stream = Client.GetStream();

                    stream.Write(Data, 0, Data.Length);
                    Console.WriteLine("-----> CLIENT_" + Hote + " <> Sent: {0}\n", message);

                    stream.Close();
                    Client.Close();
                }).Start();
            }
            catch (SocketException e) { Console.WriteLine("(!)  CLIENT_" + Hote + " <> SocketException: {0}\n", e); }
        }
    }
}
