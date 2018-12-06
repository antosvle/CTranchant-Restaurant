using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class DataFactory
    {
        private static DataFactory instance = null;


        private DataFactory() {}

           
        public static DataFactory getInstance()
        {         
            if (instance == null) return new DataFactory();

            else return instance;
        }
    }
}
