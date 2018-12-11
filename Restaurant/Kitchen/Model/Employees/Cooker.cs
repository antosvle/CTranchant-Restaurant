namespace Kitchen.Model
{
    public class Cooker
    {
        private bool available;

        public Cooker()
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
                    Kitchen.Instance.UpdateCookersAvailability();
                }
            }
        }

        public void Prepare(Recipe recipe)
        {

        }
    }
}
