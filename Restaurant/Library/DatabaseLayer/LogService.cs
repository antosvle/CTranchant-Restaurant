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
        private ILogDAO Dao;


        //Constructor
        public LogService(DataFactory injector)
        {
            this.Injector = injector;
            //DAO creation thanks to Factory and dependency injection
            Dao = Injector.GetLogDAO();
        }


        //Logs storage
        public void WriteLog(LocationEnum source, Type objectType, String message)
        {
            String messageQuery = objectType.ToString() + " <> " + message;
            Dao.AddLog(messageQuery, source);
        }
    }
}
