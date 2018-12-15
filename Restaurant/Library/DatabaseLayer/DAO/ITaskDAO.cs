using Library.Utils.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DatabaseLayer.DAO
{
    internal interface ITaskDAO
    {
        TaskEntity GetOneTask(int recipe_id, int step);
    }
}
