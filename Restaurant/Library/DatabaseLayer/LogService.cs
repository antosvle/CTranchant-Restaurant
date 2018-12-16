using Library.DatabaseLayer.DAO;
using Library.Utils;
using System;

namespace Library.DatabaseLayer
{
    public class LogService
    {
        //Factory attribute
        private DataFactory Injector;
        //List of needed Data access object (DAO)
        private static ILogDAO Dao;


        //Constructor
        public LogService(DataFactory injector)
        {
            this.Injector = injector;
            //DAO creation thanks to Factory and dependency injection
            Dao = Injector.GetLogDAO();
        }


        //Logs storage
        public static void WriteLog(LocationEnum source, String message)
        {
            String messageQuery = source + " <> " + message;
            Dao.AddLog(messageQuery, source);
        }
    }
}
