using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Library.TransportationLayer.Socket
{
    internal class ServerSocket
    {
        private TcpListener Server = null;
        private Byte[] ByteBufffer;
        private String Data;
        private Thread WaitConnection;
        private Thread ListenClient;
        private TcpClient Client;


        internal ServerSocket()
        {
            IPAddress localAddr = IPAddress.Parse(NetworkConfig.LOCAL_IP);
            Server = new TcpListener(localAddr, NetworkConfig.PORT);

            try { Init(); }
            catch (SocketException e) { Console.WriteLine("SOCKET_SERVER <> Exception: {0}", e); }
            finally { Server.Stop(); }
        }


        internal void Init()
        {
            Server.Start();
            ByteBufffer = new byte[256];
            Data = null;
            Client = null;


            WaitConnection = new Thread(delegate ()
            {
                while (true)
                {
                    Console.Write("SOCKET_SERVER <>  Waiting for a connection... ");
                    Client = Server.AcceptTcpClient();
                    Console.WriteLine("SOCKET_SERVER <> Connected!");

                    ListenClient.Start();
                }
            });

            

            ListenClient = new Thread(delegate ()
            {
                if(Client != null)
                {
                    NetworkStream stream = Client.GetStream();
                    int i;

                    while((i = stream.Read(ByteBufffer, 0, ByteBufffer.Length)) != 0)
                    {
                        Data = Encoding.ASCII.GetString(ByteBufffer, 0, i);
                        Console.WriteLine("SOCKET_SERVER <> Received: {0}", Data);
                    }

                    Client.Close();
                }
            });
        }


        internal void Start()
        {
            try { WaitConnection.Start(); }
            catch (SocketException e) { Console.WriteLine("SOCKET_SERVER <> Exception: {0}", e); }
            finally { Server.Stop(); }
        }
    }
}
