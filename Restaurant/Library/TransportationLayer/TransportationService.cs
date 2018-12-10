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


        public TransportationService(LocationEnum hote, LocationEnum destination)
        {
            this.Hote = hote;
            this.Destination = destination;
            Client = new ClientSocket(hote, destination);
        }


        public bool UpdateExternalSide(CommandeEnum commande, String arg)
        {
            String SocketString = '$' + commande + '&' + arg + '$';
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

            TransportationFactory ModelInjector = TransportationFactory.GetInstance();

            switch (Commande)
            {
                //Case pour les commandes.
            }
        }
    }
}
