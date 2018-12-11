using System;
using System.Collections.Generic;
using System.Text;

namespace Kitchen.Model
{
    public class Kitchen
    {
        public static Kitchen Instance { get; } = new Kitchen();

        private static int CookersNumber = 6;

        private static int LackeysNumber = 1;

        private static int WashersNumber = 2;

        public Chief Chief { get; private set; }

        public ISet<Cooker> Cookers { get; private set; } = new HashSet<Cooker>();

        public ISet<Lackey> Lackeys { get; private set; } = new HashSet<Lackey>();

        public ISet<Washer> Washers { get; private set; } = new HashSet<Washer>();

        private Kitchen()
        {
            for (int i = 0; i < CookersNumber ; i++)
            {
                Cookers.Add(new Cooker());
            }

            for (int i = 0; i < LackeysNumber; i++)
            {
                Lackeys.Add(new Lackey());
            }

            for (int i = 0; i < WashersNumber; i++)
            {
                Washers.Add(new Washer());
            }
        }

        public Cooker WaitAvailableCooker()
        {
            return null;
        }

        public void UpdateCookersAvailability()
        {}
    }
}
