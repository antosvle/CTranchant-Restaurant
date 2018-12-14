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
        private LocationEnum Hote;
        private TransportationService Callback;


        internal ServerSocket(LocationEnum hote, TransportationService callback)
        {
            this.Hote = hote;
            this.Callback = callback;

            if(hote == LocationEnum.KITCHEN) Server = new TcpListener(
                IPAddress.Parse(NetworkConfig.IP_SERVER_KITCHEN), NetworkConfig.PORT);

            else if (hote == LocationEnum.ROOM) Server = new TcpListener(
                IPAddress.Parse(NetworkConfig.IP_SERVER_ROOM), NetworkConfig.PORT);

            else Server = new TcpListener(
                IPAddress.Parse(NetworkConfig.IP_SERVER_IHM), NetworkConfig.PORT);

            try { InitServerTask(); }
            catch (SocketException e) { Console.WriteLine("(!)  SERVER_" + Hote + " <> Exception: {0}\n", e); }
            finally { Server.Stop(); }
        }


        private void InitServerTask()
        { 
            WaitConnection = new Thread(delegate ()
            {
                Server.Start();
    
                while (true)
                {
                    Thread.Sleep(1000);
                    Console.Write("(?)  SERVER_" + Hote + " <> Waiting for a connection...\n\n");
                    TcpClient Client = Server.AcceptTcpClient();

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
                        Console.WriteLine("----->  SERVER_" + Hote + " <> Received: {0}\n", Data);
                        Callback.UpdateHostSide(Data);
                    }
                }
            }).Start();
        }


        internal void Start()
        {
            try { WaitConnection.Start(); }
            catch (SocketException e) { Console.WriteLine("(!)  SERVER_" + Hote + " <> Exception: {0}\n", e); }
            finally { Server.Stop(); }
        }
    }
}
