using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Utils
{
    public class GlobalFactory
    {
        private static GlobalFactory Instance = null;

        private GlobalFactory() { }

        public static GlobalFactory GetInstance()
        {
            if(Instance == null)
            {
                Instance = new GlobalFactory();
            }
            return Instance;
        }

        public TransportationService GetTransportationService(LocationEnum hote)
        {
            return new TransportationService(hote);
        }
    }
}
