using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Threading;

namespace Library.TransportationLayer.Socket
{
    internal class ClientSocket
    {
        private TcpClient Client = null;
        private Thread Sender;
        private String message;


        internal ClientSocket()
        {
            Client = new TcpClient(NetworkConfig.SERVER_IP, NetworkConfig.PORT);
            message = null;

            try { Init(); }
            catch (SocketException e) { Console.WriteLine("SOCKET_CLIENT <> SocketException: {0}", e); }
        }


        private void Init()
        {
            message = null;

            Sender = new Thread(delegate ()
            {
                Byte[] Data = Encoding.ASCII.GetBytes(message);
                NetworkStream stream = Client.GetStream();

                stream.Write(Data, 0, Data.Length);
                Console.WriteLine("SOCKET_CLIENT <> Sent: {0}", message);
            });
        }


        internal void Send(String message)
        {
            this.message = message;
            try { Sender.Start(); }
            catch (SocketException e) { Console.WriteLine("SOCKET_CLIENT <> SocketException: {0}", e); }
        }
    }
}
