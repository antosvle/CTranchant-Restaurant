using Library.Utils;
using Library.Utils.DTO;
using Library.Utils.Nomenclature;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Kitchen.Model
{
    public static class Bar
    {
        public static TransportationService TransportationService;

        public static void InitListener(TransportationService transportationService)
        {
            TransportationService = transportationService;

            new Thread(delegate () {

                while (true)
                {
                    Thread.Sleep(1000);
                    CommandeDTO commande = transportationService.ReceiveUpdate();

                    if(commande != null)
                    {
                        switch (commande.CommandeType)
                        {
                            case CommandeEnum.ORDER:

                                int table = int.Parse(commande.Argument.Split(' ')[0]);
                                List<String> dishesList = new List<String>();

                                for(int i=1; i < commande.Argument.Split(' ').Length; i++)
                                {
                                    dishesList.Add(commande.Argument.Split(' ')[i]);
                                }

                                Kitchen.Instance.Chief.Manage(new Order(table, dishesList));
                                break;
                        }
                    }
                }
            }).Start();
        }

        public static void Send(Order order, LocationEnum destination)
        {
            String argument = order.Table + " ";

            foreach(String dishes in order.Dishes) { argument += dishes + " "; }

            TransportationService.UpdateExternalSide(
                destination, 
                CommandeEnum.ORDER_COOKED,
                argument
                );
        }
    }
}
