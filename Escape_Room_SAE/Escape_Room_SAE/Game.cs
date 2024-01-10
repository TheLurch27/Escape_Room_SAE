using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room_SAE
{
    internal class Game
    {
        private enum EMapTiles
        {
            free = -1,
            wall
        }

        private static string[] mapTileChar = new string[]
        {
            "  ",
            "██"
        };

        private const int MAP_SIZE = 9;

        private static int[,] map;
        private static int playerX;
        private static int playerY;
        private const string playerCharacter = ":)";

        public void Run() // Neue "Main"
        {
            WelcomeMessage();
            UserInputMapSize();
            DrawMap();
            PrintMap();

            // __________________________________________________________
            // Trouple - Einfach NEIN!

            // (int Left, int Top) cursorPos = Console.GetCursorPosition();
            // Console.SetCursorPosition(playerX, playerY);
            // Console.Write(playerCharacter);
            // Console.SetCursorPosition(cursorPos.Left, cursorPos.Top);

            // __________________________________________________________

            DrawPlayer();

            Console.ReadLine();
        }

        public void WelcomeMessage()
        {
            Console.WriteLine(" ▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄    ▄▄▄▄▄▄   ▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄ ▄▄   ▄▄ \r\n█       █       █       █       █       █       █  █   ▄  █ █       █       █  █▄█  █\r\n█    ▄▄▄█  ▄▄▄▄▄█       █   ▄   █    ▄  █    ▄▄▄█  █  █ █ █ █   ▄   █   ▄   █       █\r\n█   █▄▄▄█ █▄▄▄▄▄█     ▄▄█  █▄█  █   █▄█ █   █▄▄▄   █   █▄▄█▄█  █ █  █  █ █  █       █\r\n█    ▄▄▄█▄▄▄▄▄  █    █  █       █    ▄▄▄█    ▄▄▄█  █    ▄▄  █  █▄█  █  █▄█  █       █\r\n█   █▄▄▄ ▄▄▄▄▄█ █    █▄▄█   ▄   █   █   █   █▄▄▄   █   █  █ █       █       █ ██▄██ █\r\n█▄▄▄▄▄▄▄█▄▄▄▄▄▄▄█▄▄▄▄▄▄▄█▄▄█ █▄▄█▄▄▄█   █▄▄▄▄▄▄▄█  █▄▄▄█  █▄█▄▄▄▄▄▄▄█▄▄▄▄▄▄▄█▄█   █▄█\r\n");
            Console.WriteLine("Hello and Welcome to my Escape Room");
            Console.ReadKey();
            Console.Clear();
        }

        public void UserInputMapSize()
        {

        }

        public void DrawMap()
            // Komplette Initialisierung der Map
        {
            map = new int[MAP_SIZE, MAP_SIZE];
            for (int y = 0; y < MAP_SIZE; y++)
            {
                for (int x = 0; x < MAP_SIZE; x++)
                {
                    if(y == 0 || x == 0 || y == MAP_SIZE -1 || x == MAP_SIZE -1)
                    {
                        map[x, y] = (int)EMapTiles.wall;
                    }
                    else
                    {
                        map[x, y] = (int)EMapTiles.free;
                    }
                }
            }
            playerX = MAP_SIZE / 2;
            playerY = MAP_SIZE / 2;

            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                PrintMap();
                ConsoleKeyInfo keyInput = Console.ReadKey();
                switch (keyInput.Key)
                {
                    case ConsoleKey.Escape:
                        isRunning = false;
                        break;
                    case ConsoleKey.W:
                        break;
                    case ConsoleKey.A:
                        break;
                    case ConsoleKey.S:
                        break;
                    case ConsoleKey.D:
                        break;
                    case ConsoleKey.UpArrow:
                        break;
                    case ConsoleKey.LeftArrow:
                        break;
                    case ConsoleKey.DownArrow:
                        break;
                    case ConsoleKey.RightArrow:
                        break;
                }
        }

        private static void PrintMap()
        {
            for (int y = 0; y < MAP_SIZE; y++)
            {
                for(int x = 0; x < MAP_SIZE; x++)
                {
                    if(y == playerY && x == playerX)
                    {
                        Console.Write(playerCharacter + "");
                    }
                    else
                    {
                        int mapValue = map[x, y];
                        Console.Write(mapTileChar[mapValue + 1]);
                    }
                }

                Console.WriteLine();
            }
        }

        public void DrawPlayer()
        {

        }
    }
}
