using Library.Utils.DTO;
using Library.Utils.Nomenclature;
using Room.Components;
using Room.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Room
{
    public class Bar
    {
        public static void InitListener()
        {
            new Thread(delegate () {

                while (true)
                {
                    Thread.Sleep(1000);
                    CommandeDTO commande = Room.socketManager.ReceiveUpdate();

                    if (commande != null)
                    {
                        switch (commande.CommandeType)
                        {
                            case CommandeEnum.ORDER_COOKED:

                                int table = int.Parse(commande.Argument.Split('|')[0]);
                                List<String> dishesList = new List<String>();

                                for (int i = 1; i < commande.Argument.Split('|').Length; i++)
                                {
                                    dishesList.Add(commande.Argument.Split('|')[i]);
                                }

                                GetResponseFromKitchen(table.ToString());
                                break;
                        }
                    }
                }
            }).Start();
        }

        public static void GetResponseFromKitchen(string answer)
        {
            Room room = Room.GetInstance();

            Table table = null;
            string[] msg = answer.Split(' ', 2);

            if(msg[0] == "done")
            {
                foreach(Table toble in room.Tables)
                {
                    if(toble.Id.ToString() == msg[1])
                    {
                        table = toble;
                    }
                }

                if(table != null)
                    table.Row.Area.AddWaiterEvent(new WaiterEvent(WaiterEventEnum.mealReady, table));
            }
        }
    }
}
