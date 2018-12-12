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
        
        private ClientSocket ClientIHM;
        private ClientSocket ClientROOM;
        private ClientSocket ClientKITCHEN;
        private ServerSocket HoteServer;


        public TransportationService(LocationEnum hote)
        {
            this.Hote = hote;
            HoteServer = new ServerSocket(hote, this);
            HoteServer.Start();

            ClientROOM = new ClientSocket(Hote, LocationEnum.ROOM);
            ClientKITCHEN = new ClientSocket(Hote, LocationEnum.KITCHEN);
            ClientIHM = new ClientSocket(Hote, LocationEnum.IHM);
        }


        public bool UpdateExternalSide(LocationEnum destination, CommandeEnum commande, String arg)
        {
            String SocketString = "$" + (int)commande + "&" + arg + "$";
         
            try
            {
                if(destination == LocationEnum.IHM)
                    ClientIHM.Send(SocketString);
                else if (destination == LocationEnum.KITCHEN)
                    ClientKITCHEN.Send(SocketString);
                else
                    ClientROOM.Send(SocketString);
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

            //appeler classe du module
        }
    }
}
