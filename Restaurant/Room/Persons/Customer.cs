using Room.Components;

namespace Room.Persons
{
    enum EStatus
    {
        arriving,
        waiting,
        paying,
        waitingPaying,
        eating,
        gone
    }

    public class Customer
    {
        private EStatus status;
        internal EStatus Status { get => status; set => status = value; }
        private int nbrOfPeople;
        public int NbrOfPeople { get => nbrOfPeople; }

        private Table table;
        internal Table Table { get => table; set => table = value; }


        public Customer(int nbr)
        {
            nbrOfPeople = nbr;
        }


    }
}
