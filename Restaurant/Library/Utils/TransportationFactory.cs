using System;
using System.Collections.Generic;
using System.Text;

namespace Library.TransportationLayer
{
    public class TransportationFactory
    {
        private static TransportationFactory Instance = null;

        
        private TransportationFactory() { }


        public static TransportationFactory GetInstance()
        {
            if(Instance == null)
            {
                Instance = new TransportationFactory();
            }

            return Instance;
        }
    }
}
