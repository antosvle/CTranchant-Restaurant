using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Utils.Entity
{
    internal class LogEntity
    {
        private int log_id;
        private DateTime log_date;
        private String log_source;
        private String log_message;

        internal LogEntity(int id, DateTime date, String source, String message)
        {
            this.log_id = id;
            this.log_date = date;
            this.log_source = source;
            this.log_message = message;
        }

        internal int Log_id { get => log_id; set => log_id = value; }

        internal DateTime Log_date { get => log_date; set => log_date = value; }

        internal string Log_source { get => log_source; set => log_source = value; }

        internal string Log_message { get => log_message; set => log_message = value; }
    }
}
