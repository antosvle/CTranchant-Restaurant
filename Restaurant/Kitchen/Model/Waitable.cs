namespace Kitchen.Model
{
    public abstract class Waitable
    {
        private bool available = true;
        
        public bool Available
        {
            get { return available; }
            set
            {
                available = value;

                if (available)
                {
                    Kitchen.Instance.UpdateWaitables();
                }
            }
        }
    }
}
