using Room.Components;
using Room.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Room
{
    public class Bar
    {
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
