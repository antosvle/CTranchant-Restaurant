using Library.Utils.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DatabaseLayer.DAO
{
    internal interface IFurnitureDAO
    {
        FurnitureEntity GetOneFurniture(int furniture_id);
    }
}
