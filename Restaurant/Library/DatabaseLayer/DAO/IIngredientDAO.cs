using System.Collections.Generic;
using Library.Utils.Entity;

namespace Library.DatabaseLayer.DAO
{
    internal interface IIngredientDAO
    {
        List<IngredientEntity> GetAllIngredients();
    }
}
