using Library.Utils.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DatabaseLayer.DAO
{
    internal interface IUstensilDAO
    {
        List<UstensilEntity> GetUstensilEntities(int task_id);
    }
}
