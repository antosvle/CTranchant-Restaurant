using Library.Utils;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Library.TransportationLayer.Socket
{
    internal class ServerSocket
    {
        private TcpListener Server = null;
        private Thread WaitConnection;
        private LocationEnum Acteur;


        internal ServerSocket(LocationEnum acteur)
        {
            this.Acteur = acteur;
            IPAddress localAddr = IPAddress.Parse(NetworkConfig.LOCAL_IP);
            if(acteur == LocationEnum.KITCHEN) Server = new TcpListener(localAddr, NetworkConfig.PORT_KITCHEN);
            else Server = new TcpListener(localAddr, NetworkConfig.PORT_ROOM);

            try { InitServerTask(); }
            catch (SocketException e) { Console.WriteLine("SOCKET_SERVER <> Exception: {0}", e); }
            finally { Server.Stop(); }
        }


        private void InitServerTask()
        { 
            WaitConnection = new Thread(delegate ()
            {
                Server.Start();

                while (true)
                {
                    Console.Write("SOCKET_SERVER <> Waiting for a connection...\n");
                    TcpClient Client = Server.AcceptTcpClient();
                    Console.WriteLine("SOCKET_SERVER <> Connected!\n");

                    ListenClient(Client);
                }
            });
        }


        private void ListenClient(TcpClient Client)
        {
            new Thread(delegate ()
            { 
                if (Client != null)
                {
                    Byte[] ByteBufffer = new byte[256];
                    String Data;
                    NetworkStream stream = Client.GetStream();
                    int i;

                    while ((i = stream.Read(ByteBufffer, 0, ByteBufffer.Length)) != 0)
                    {
                        Data = Encoding.ASCII.GetString(ByteBufffer, 0, i);
                        Console.WriteLine("     SOCKET_SERVER <> Received: {0}\n", Data);
                            
                    }
                }
            }).Start();
        }


        internal void Start()
        {
            try { WaitConnection.Start(); }
            catch (SocketException e) { Console.WriteLine("SOCKET_SERVER <> Exception: {0}\n", e); }
            finally { Server.Stop(); }
        }
    }
}
