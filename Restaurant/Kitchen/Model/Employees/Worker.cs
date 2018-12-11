namespace Kitchen.Model
{
    public abstract class Worker
    {
        private bool available;

        protected Worker()
        {
            available = true;
        }

        public bool Available
        {
            get { return available; }
            set
            {
                available = value;

                if (available)
                {
                    Kitchen.Instance.UpdateWorkersAvailability();
                }
            }
        }
    }
}
