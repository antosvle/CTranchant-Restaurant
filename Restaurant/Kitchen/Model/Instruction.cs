using Library.Controller;
using System.Collections.Generic;

namespace Kitchen.Model
{
    public class Instruction
    {
        public string Furniture { get; private set; }

        public ISet<string> Utensils = new HashSet<string>();

        public int Time { get; private set; }

        public Instruction(string furniture, int time)
        {
            Furniture = furniture;
            Time = time;
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
