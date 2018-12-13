using System.Collections.Generic;
using System.Threading;

namespace Kitchen.Model
{
    public class Kitchen
    {
        private static int cookersNumber = 6;
        private static int lackeysNumber = 2;
        private static int washersNumber = 2;
        private static int fireNumber = 5;
        private static int ovenNumber = 1;
        private static int mixerNumber = 1;
        private static int pressurerNumber = 1;
        private static int workshopNumber = 4;
        private static int panNumber = 5;
        private static int woodenSpoonNumber = 3;
        private static int kitchenKnifeNumber = 2;

        public static Kitchen Instance { get; } = new Kitchen();

        public Chief Chief { get; private set; }

        public ISet<Cooker> Cookers { get; private set; } = new HashSet<Cooker>();

        public ISet<Lackey> Lackeys { get; private set; } = new HashSet<Lackey>();

        public ISet<Washer> Washers { get; private set; } = new HashSet<Washer>();

        public ISet<Furniture> Furnitures { get; private set; } = new HashSet<Furniture>();

        public ISet<Utensil> Utensils { get; private set; } = new HashSet<Utensil>();

        public ManualResetEvent waiting = new ManualResetEvent(false);

        private Kitchen()
        {
            Chief = new Chief();

            for (int i = 0; i < cookersNumber; i++)
                Cookers.Add(new Cooker());

            for (int i = 0; i < lackeysNumber; i++)
                Lackeys.Add(new Lackey());

            for (int i = 0; i < washersNumber; i++)
                Washers.Add(new Washer());

            for (int i = 0; i < fireNumber; i++)
                Furnitures.Add(new Furniture("Fire"));

            for (int i = 0; i < ovenNumber; i++)
                Furnitures.Add(new Furniture("Oven"));

            for (int i = 0; i < mixerNumber; i++)
                Furnitures.Add(new Furniture("Mixer"));

            for (int i = 0; i < pressurerNumber; i++)
                Furnitures.Add(new Furniture("Pressurer"));

            for (int i = 0; i < workshopNumber; i++)
                Furnitures.Add(new Furniture("Workshop"));

            for (int i = 0; i < panNumber; i++)
                Utensils.Add(new Utensil("Pan"));

            for (int i = 0; i < woodenSpoonNumber; i++)
                Utensils.Add(new Utensil("Wooden Spoon"));

            for (int i = 0; i < kitchenKnifeNumber; i++)
                Utensils.Add(new Utensil("Kitchen Knife"));
        }

        public Cooker WaitAvailableCooker()
        {
            while(true)
            {
                foreach (Cooker cooker in Cookers)
                {
                    if (cooker.Available)
                    {
                        waiting.Reset();

                        return cooker;
                    }
                }

                lock (waiting)
                {
                    waiting.WaitOne();
                }
            }
        }

        public Lackey WaitAvailableLackey()
        {
            while (true)
            {
                foreach (Lackey lackey in Lackeys)
                {
                    if (lackey.Available)
                    {
                        waiting.Reset();

                        return lackey;
                    }
                }

                lock (waiting)
                {
                    waiting.WaitOne();
                }
            }
        }

        public Washer WaitAvailableWasher()
        {
            while (true)
            {
                foreach (Washer washer in Washers)
                {
                    if (washer.Available)
                    {
                        waiting.Reset();

                        return washer;
                    }
                }

                lock (waiting)
                {
                    waiting.WaitOne();
                }
            }
        }

        public Furniture WaitAvailableFurniture(string name)
        {
            while (true)
            {
                foreach (Furniture furniture in Furnitures)
                {
                    if (furniture.Name == name && furniture.Available)
                    {
                        waiting.Reset();

                        return furniture;
                    }
                }

                lock (waiting)
                {
                    waiting.WaitOne();
                }
            }
        }

        public Utensil WaitAvailableUtensil(string name)
        {
            while (true)
            {
                foreach (Utensil utensil in Utensils)
                {
                    if (utensil.Name == name && utensil.Available)
                    {
                        waiting.Reset();

                        return utensil;
                    }
                }

                lock (waiting)
                {
                    waiting.WaitOne();
                }
            }
        }

        public void UpdateWaitables()
        {
            waiting.Set();
        }
    }
}
