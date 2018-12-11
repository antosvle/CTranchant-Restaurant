using Room.Persons;
using System;
using System.Collections.Generic;
using System.Text;

namespace Room.Events
{
    public enum RowChiefEventEnum
    {
        menu,
        getOrder,
    }

    public class RowChiefEvent
    {
        private readonly RowChiefEventEnum evt;
        public RowChiefEventEnum Event { get => evt; }

        public RowChiefEvent(RowChiefEventEnum evnt)
        {
            evt = evnt;
        }
    }
}
