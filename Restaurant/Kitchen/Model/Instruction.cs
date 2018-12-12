using Library.Controller;

namespace Kitchen.Model
{
    public class Instruction
    {
        public int Time { get; private set; }

        public string Furniture { get; private set; }

        public Instruction(int time, string furniture)
        {
            Time = time;
            Furniture = furniture;
        }

        public void Execute()
        {
            Furniture furniture = Kitchen.Instance.WaitAvailableFurniture(Furniture);

            furniture.Available = false;

            Timeline.Wait(Time);

            furniture.Available = true;
        }
    }
}
