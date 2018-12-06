using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Utils.Entity
{
    internal class StockEntity
    {
        private int stock_id;
        private DateTime expiration_date;

        internal StockEntity(int id, DateTime date)
        {
            this.stock_id = id;
            this.expiration_date = date;
        }

        internal DateTime Expiration_date { get => expiration_date; set => expiration_date = value; }

        internal int Stock_id { get => stock_id; set => stock_id = value; }
    }
}
