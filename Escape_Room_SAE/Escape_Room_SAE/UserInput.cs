using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room_SAE
{
    internal class UserInput
    {
        private static int userInput;
        private static bool isValidInput = false;
        internal static bool isRunning = false;
        internal static int InputMapSize;

        internal static void MapSize()
        // Es kommt nicht auf die Größe an... Hab ich gehört! - Hier wird der Spieler aufgefordert die Map Größe zu bestimmen, ja auch TryParse ist mit drin ^^ weil Doofheit der Menschen und so.
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Please enter a number for the room size. (");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("number between 5-15");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("):");


                if (int.TryParse(Console.ReadLine(), out userInput))
                {
                    if (userInput >= 5 && userInput <= 15)
                    {
                        InputMapSize = userInput;
                        isValidInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Oops, that wasn't right... Try again :(");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            } while (!isValidInput);

            Console.Clear();
        }

        internal static void HandleUserInput(ConsoleKeyInfo keyInput)
        // Push the Button... Hier werden Nägel mit Köpf... äh knöpfen gemacht, oh und die Spieler Position wird Aktualisiert.
        {
            int prevPlayerX = Player.playerX;
            int prevPlayerY = Player.playerY;

            switch (keyInput.Key)
            {
                case ConsoleKey.Escape:
                    isRunning = false;
                    Console.Clear();
                    break;
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    Player.playerY--;
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    Player.playerX--;
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    Player.playerY++;
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    Player.playerX++;
                    break;
            }

            Player.CheckCharacterPosition();

            Collectables.HandleKeyCollection();

            if (Map.hasExitedDoor)
            {
                Console.Clear();
                Console.WriteLine("Congratulations! You have escaped the room! ╰(°▽°)╯");
                isRunning = false;
            }
        }
    }
}
