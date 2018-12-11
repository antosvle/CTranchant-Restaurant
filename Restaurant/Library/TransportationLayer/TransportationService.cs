using Library.TransportationLayer;
using Library.TransportationLayer.Socket;
using Library.Utils.Nomenclature;
using System;
using System.Net.Sockets;

namespace Library.Utils
{
    public class TransportationService
    {
        private LocationEnum Hote;
        private LocationEnum Destination;
        private ClientSocket Client;
        private ServerSocket HoteServer;


        public TransportationService(LocationEnum hote, LocationEnum destination)
        {
            this.Hote = hote;
            this.Destination = destination;
            Client = new ClientSocket(hote, destination);

            HoteServer = new ServerSocket(hote, this);
            HoteServer.Start();
        }


        public bool UpdateExternalSide(CommandeEnum commande, String arg)
        {
            String SocketString = "$" + (int)commande + "&" + arg + "$";
         
            try
            {
                Client.Send(SocketString);
            }
            catch(SocketException e)
            {
                Console.WriteLine(e.GetBaseException());
                return false;
            }
            
            return true;
        }


        internal void UpdateHostSide(String socketData)
        {
            socketData = socketData.Replace("$", "");
            int Commande = int.Parse(socketData.Split('&')[0]);
            String arg = socketData.Split('&')[1];

            GlobalFactory Injector = GlobalFactory.GetInstance();

            switch (Commande)
            {
                
            }
        }
    }
}
