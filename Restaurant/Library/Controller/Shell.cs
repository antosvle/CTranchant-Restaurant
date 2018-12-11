using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Controller
{
    public class Shell
    {
        public static void Log(string message)
        {
            Console.WriteLine(message);
        }

        public static void Interprete()
        {
            string message = Console.ReadLine();

            string[] tokens = message.Split(' ');

            switch (tokens[0])
            {
                case "pause":
                    Timeline.Pause();
                    break;

                case "resume":
                    Timeline.Resume();
                    break;

                case "speed":

                    int speed;

                    if (tokens.Length >= 2 && int.TryParse(tokens[1], out speed))
                    {
                        if (speed > 0)
                        {
                            Timeline.UnitDuration = speed;
                        }
                    }

                    break;

                default:
                    break;
            }
        }
    }
}
