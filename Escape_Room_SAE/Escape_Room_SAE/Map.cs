using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room_SAE
{
    internal class Map
    {
        // Variablen für die Map
        internal static int[,] map;

        internal static bool hasExitedDoor = false;

        internal enum EMapTiles
        // Mehr Variablen bzw ein ENUM für die Map
        {
            floor = -1,
            wall,
            key,
            openDoor,
            closedDoor
        }

        internal static string[] mapTileChar = new string[]
        // Noch mehr Variablen für die Map. Mensch das hört nicht auf....
        {
            "  ",
            "██",
            "O╣",
            "▒▒",
            "▓▓"
        };

        internal static void InitializeMap()
        // Hier bekommt die Map langsam Hand und Fuß ähhh Wand und Boden....
        {
            map = new int[UserInput.InputMapSize, UserInput.InputMapSize];
            for (int y = 0; y < UserInput.InputMapSize; y++)
            {
                for (int x = 0; x < UserInput.InputMapSize; x++)
                {
                    if (y == 0 || x == 0 || y == UserInput.InputMapSize - 1 || x == UserInput.InputMapSize - 1)
                    // y == 0 (Abfrage: Untere Reihe), x == 0 (Abfrage: Linke Seite), y == mapSize - 1 (Abfrage: Obere Reihe), x == mapSize - 1 (Abfrage: Rechte Seite)
                    {
                        map[x, y] = (int)EMapTiles.wall;
                    }
                    else
                    {
                        map[x, y] = (int)EMapTiles.floor;
                    }
                }
            }

            Player.playerX = UserInput.InputMapSize / 2;
            Player.playerY = UserInput.InputMapSize / 2;
        }

        private void DrawMap()
        // Hier wird die Map in die Konsole geprintet (warum heißt die Methode dann eigentlich "Draw" und nicht "Print" o.O), ach ja die Spielerwegung beginnt auch hier. 
        {
            InitializeMap();
            Collectables.DrawKey();
            DrawDoor();

            while (UserInput.isRunning)
            {
                PrintMapAndCharacter();

                ConsoleKeyInfo keyInput = Console.ReadKey();

                UserInput.HandleUserInput(keyInput);
                Player.CheckCharacterPosition();
            }
        }

        private void PrintMapAndCharacter()
        // Ahhhh hier haben wir das Printen der Map und des Characters
        {
            Console.Clear();
            for (int y = 0; y < UserInput.InputMapSize; y++)
            {
                for (int x = 0; x < UserInput.InputMapSize; x++)
                {
                    if (y == Player.playerY && x == Player.playerX)
                    {
                        Console.Write(Player.playerChar);
                    }
                    else
                    {
                        int mapValue = map[x, y];
                        if (Collectables.isKeyCollected && mapValue == (int)EMapTiles.closedDoor)
                        {
                            Console.Write(mapTileChar[(int)EMapTiles.floor + 1]);
                        }
                        else
                        {
                            Console.Write(mapTileChar[mapValue + 1]);
                        }
                    }
                }

                Console.WriteLine();
            }
        }

        private void DrawDoor()
        // Ein Escape Room ohne Tür? Ist wie Brot ohne Nutella...
        {
            System.Random rndDoor = new Random();

            int doorX;
            int doorY;

            do
            {
                doorX = rndDoor.Next(0, UserInput.InputMapSize);
                doorY = rndDoor.Next(0, UserInput.InputMapSize);

                // Kurz zur Erklärung: Hier wird überprüft ob die Tür in einer der Ecken erscheint und platziert sie um, wenn es so wäre.
                if ((doorX == 1 && doorY == 1) || (doorX == 1 && doorY == UserInput.InputMapSize - 2) || (doorX == UserInput.InputMapSize - 2 && doorY == 1) || (doorX == UserInput.InputMapSize - 2 && doorY == UserInput.InputMapSize - 2))
                {
                    doorX = doorY = -1;
                }

            } while (doorX == -1 || map[doorX, doorY] != (int)EMapTiles.wall);

            map[doorX, doorY] = (int)EMapTiles.closedDoor;
        }

        internal static void OpenDoor()
        // Offen sollte sie am ende auch sein... ansonsten GAME OVER!
        {
            for (int x = 0; x < UserInput.InputMapSize; x++)
            {
                for (int y = 0; y < UserInput.InputMapSize; y++)
                {
                    if (map[x, y] == (int)EMapTiles.closedDoor)
                    {
                        map[x, y] = (int)EMapTiles.openDoor;
                        return;
                    }
                }
            }
        }

        internal static void CheckDoor()
        {
            hasExitedDoor = Collectables.isKeyCollected && map[Player.playerX, Player.playerY] == (int)EMapTiles.openDoor;
        }
    }
}
