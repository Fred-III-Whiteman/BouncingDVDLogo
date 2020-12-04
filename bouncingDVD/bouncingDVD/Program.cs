using System;
using System.IO;

namespace bouncingDVD
{
    class Program
    {
        static void Main(string[] args)
        {
            // read ASCII art
            string[] logo = File.ReadAllLines("../../../Logo20.txt"); // if changed to logo25 the logic must also change

            //rng for start position
            Random rng = new Random();

            // start x and y position, speed, times the loop runs, and random start colour
            int x = rng.Next(1, 181), y = rng.Next(1, 61), xSpeed = 10, ySpeed = 10, time = 0, colour = rng.Next(1, 14);

            while (time != 500) // value is the times the loop will run
            {

                //top border
                for (int px = 0; px < 200; px++)
                {
                    Console.Write("-");
                }
                Console.WriteLine();

                // find right border
                int rightBorder = (200 - x);
                string side = "|";

                // draw initial y lines
                for (int px = 0; px < y; px++)
                {
                    Console.Write("|");
                    for (int pixel = 0; pixel < 198; pixel++)
                    {
                        Console.Write(" ");
                    }
                    Console.WriteLine("|");
                }

                // sides and logo
                foreach (string line in logo)
                {
                    Console.Write("|");
                    ReColour(colour, line.PadLeft(x - 2, ' '));
                    Console.WriteLine(side.PadLeft(rightBorder, ' '));
                }

                // draw remaing y lines
                for (int px = 0; px < 60 - y; px++)
                {
                    Console.Write("|");
                    for (int pixel = 0; pixel < 198; pixel++)
                    {
                        Console.Write(" ");
                    }
                    Console.WriteLine("|");
                }

                // draw bottom of screen
                for (int px = 0; px < 200; px++)
                {
                    Console.Write("-");
                }

                // I like to move it move it
                x += xSpeed;
                y += ySpeed;

                // x-axis collision
                if (x >= 200)
                {
                    xSpeed = -xSpeed;
                    x = 200;
                    colour = rng.Next(1, 14);
                }
                else if (x <= 20)
                {
                    xSpeed = -xSpeed;
                    x = 20;
                    colour = rng.Next(1, 14);
                }

                // y-axis collision
                if (y + 10 >= 70)
                {
                    ySpeed = -ySpeed;
                    colour = rng.Next(1, 14);
                }
                else if (y <= 0)
                {
                    ySpeed = -ySpeed;
                    y = 0;
                    colour = rng.Next(1, 14);
                }

                time++;
                System.Threading.Thread.Sleep(150);
                Console.Clear();
            } // end of main loop
        } // end of main

        // method to change the logo colour
        static void ReColour(int colour, string message)
        {

            switch (colour)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 7:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case 8:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case 9:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
                case 10:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case 11:
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    break;
                case 12:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case 13:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("NO COLOUR FOUND");
                    break;
            }
            Console.Write(message);
            Console.ResetColor();
        } // end of ReColour
    }
}
