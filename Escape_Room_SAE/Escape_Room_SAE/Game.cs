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
            wall = 0,
        }
        private const int MAP_SIZE = 10;
        private static int[,] map;

        private static int playerX;
        private static int playerY;

        public void Run() // Neue "Main"
        {
            WelcomeMessage();
            DrawMap();
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

        public void DrawMap()
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
        }

        public void DrawPlayer()
        {

        }
    }
}
