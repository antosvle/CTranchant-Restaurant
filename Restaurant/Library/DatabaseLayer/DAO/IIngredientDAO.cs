using System;
using System.Collections.Generic;
using System.Text;
using Library.Utils.Entity;

namespace Library.DatabaseLayer.DAO
{
    internal interface IIngredientDAO
    {
        List<IngredientEntity> GetAllIngredient();
    }
}
