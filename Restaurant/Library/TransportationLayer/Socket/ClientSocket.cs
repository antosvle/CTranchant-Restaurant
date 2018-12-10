using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using Library.Utils;

namespace Library.TransportationLayer.Socket
{
    public class ClientSocket
    {
        private LocationEnum Destination;
        private LocationEnum Acteur;
            

        public ClientSocket(LocationEnum acteur, LocationEnum destination)
        {
            this.Destination = destination;
            this.Acteur = acteur;
        }


        public void Send(String message)
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

                TcpClient Client = new TcpClient(ipAdress, port);
                Byte[] Data = Encoding.ASCII.GetBytes(message);
                NetworkStream stream = Client.GetStream();

                stream.Write(Data, 0, Data.Length);
                Console.WriteLine("SOCKET_CLIENT <> Sent: {0}\n", message);

                stream.Close();
                Client.Close();
            }
            catch (SocketException e) { Console.WriteLine("SOCKET_CLIENT <> SocketException: {0}", e); }
        }
    }
}
