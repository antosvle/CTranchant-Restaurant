using Library.Controller;
using Library.Utils;
using Library.Utils.Nomenclature;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kitchen.Model
{
    public static class Bar
    {
        public static void Receive(Order order)
        {
            Kitchen.Instance.Chief.Manage(order);
        }

        public static void Send(Order order)
        {
            
        }
    }
}
