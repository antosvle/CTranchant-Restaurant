using Library.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DatabaseLayer.DAO
{
    internal interface ILogDAO
    {
         void AddLog(String messageQuery, LocationEnum source);
    }
}
