using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room_SAE
{
    internal class Game
    {
        // Variablen für die Map
        private static int MAP_SIZE;
        private static int[,] map;

        // Variablen für die Eingabe und Handlung des Spielers
        private int userInput;
        private bool isValidInput = false;
        private bool isRunning = true;
        private bool isKeyCollected = false;
        private bool hasExitedDoor = false;

        // Variablen für den Character
        private static int playerX;
        private static int playerY;
        private static string playerChar = ":)";

        private enum EMapTiles
        // Mehr Variablen bzw ein ENUM für die Map
        {
            floor = -1,
            wall,
            key,
            openDoor,
            closedDoor
        }

        private static string[] mapTileChar = new string[]
        // Noch mehr Variablen für die Map. Mensch das hört nicht auf....
        {
            "  ",
            "██",
            "O╣",
            "▒▒",
            "▓▓"
        };

        public void Run()
        // Ersetzt die Main Methode in Program.cs
        {
            WelcomeMessage();
            InstructionMessage();
            MapSize();
            DrawMap();
        }

        private void WelcomeMessage()
        // Bisschen was fürs Auge.
        {
            Console.WriteLine(" _____ ____   ____    _    ____  _____   ____   ___   ___  __  __ \r\n| ____/ ___| / ___|  / \\  |  _ \\| ____| |  _ \\ / _ \\ / _ \\|  \\/  |\r\n|  _| \\___ \\| |     / _ \\ | |_) |  _|   | |_) | | | | | | | |\\/| |\r\n| |___ ___) | |___ / ___ \\|  __/| |___  |  _ <| |_| | |_| | |  | |\r\n|_____|____/ \\____/_/   \\_\\_|   |_____| |_| \\_\\\\___/ \\___/|_|  |_|");
            Console.WriteLine("__        _____ ____  _   _          \r\n\\ \\      / /_ _/ ___|| | | |         \r\n \\ \\ /\\ / / | |\\___ \\| |_| |         \r\n  \\ V  V /  | | ___) |  _  |         \r\n __\\_/\\_/__|___|____/|_|_|_|_  _   _ \r\n| ____|  _ \\_ _|_   _|_ _/ _ \\| \\ | |\r\n|  _| | | | | |  | |  | | | | |  \\| |\r\n| |___| |_| | |  | |  | | |_| | |\\  |\r\n|_____|____/___| |_| |___\\___/|_| \\_|");
            Console.ReadKey();
            Console.Clear();
        }

        private void InstructionMessage()
        // Viel Bla Bla...
        {
            Console.WriteLine("Find the key (O╣) and open the door (▒▒)");
            Console.WriteLine();
            Console.WriteLine("Key assignment");
            Console.WriteLine("Up = \u2191");
            Console.WriteLine("Down = \u2193");
            Console.WriteLine("Left = \u2190");
            Console.WriteLine("Right = \u2192");
            Console.ReadKey();
            Console.Clear();
        }

        private void MapSize()
        // Es kommt nicht auf die Größe an... Hab ich gehört! - Hier wird der Spieler aufgefordert die Map Größe zu bestimmen, ja auch TryParse ist mit drin ^^ weil Doofheit der Menschen und so.
        {
            do
            {
                Console.WriteLine("Please enter a number for the room size. (number between 5-15):");

                if (int.TryParse(Console.ReadLine(), out userInput))
                {
                    if (userInput >= 5 && userInput <= 15)
                    {
                        MAP_SIZE = userInput;
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

        private void DrawMap()
        // Phantasie ist schön aber es zu sehen mach mehr Spaß! Hier wird die Map in die Konsole geprintet (warum heißt die Methode dann eigentlich "Draw" und nicht "Print" o.O), ach ja die Spielerwegung beginnt auch hier. 
        {
            InitializeMap();
            DrawKey();
            DrawDoor();

            while (isRunning)
            {
                PrintMapAndCharacter();

                ConsoleKeyInfo keyInput = Console.ReadKey();

                HandleUserInput(keyInput);
                CheckCharacterPosition();
            }
        }

        private void InitializeMap()
        // Hier bekommt die Map langsam Hand und Fuß ähhh Wand und Boden....
        {
            map = new int[MAP_SIZE, MAP_SIZE];
            for (int y = 0; y < MAP_SIZE; y++)
            {
                for (int x = 0; x < MAP_SIZE; x++)
                {
                    if (y == 0 || x == 0 || y == MAP_SIZE - 1 || x == MAP_SIZE - 1)
                    {
                        map[x, y] = (int)EMapTiles.wall;
                    }
                    else
                    {
                        map[x, y] = (int)EMapTiles.floor;
                    }
                }
            }

            playerX = MAP_SIZE / 2;
            playerY = MAP_SIZE / 2;
        }

        private void HandleUserInput(ConsoleKeyInfo keyInput)
        // Push the Button... Hier werden Nägel mit Köpf... äh knöpfen gemacht, oh und die Spieler Position wird Aktualisiert.
        {
            int prevPlayerX = playerX;
            int prevPlayerY = playerY;

            switch (keyInput.Key)
            {
                case ConsoleKey.Escape:
                    isRunning = false;
                    Console.Clear();
                    break;
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    playerY--;
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    playerX--;
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    playerY++;
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    playerX++;
                    break;
            }

            CheckCharacterPosition();

            HandleKeyCollection();

            if (hasExitedDoor)
            {
                Console.Clear();
                Console.WriteLine("Congratulations! You have escaped the room! ╰(°▽°)╯");
                isRunning = false;
            }
        }

        private void CheckCharacterPosition()
        // Player Position... Check! Hier wird geschaut das der Charackter nicht ausbüchsen kann.
        {
            CheckDoor();


            if (playerX <= 0)
            {
                playerX = 1;
            }
            else if (playerX >= MAP_SIZE - 1)
            {
                playerX = MAP_SIZE - 2;
            }

            if (playerY <= 0)
            {
                playerY = 1;
            }
            else if (playerY >= MAP_SIZE - 1)
            {
                playerY = MAP_SIZE - 2;
            }
        }

        private void CheckDoor()
        {
            hasExitedDoor = isKeyCollected && map[playerX, playerY] == (int)EMapTiles.openDoor;
        }

        private void PrintMapAndCharacter()
        // Ahhhh hier haben wir das Printen der Map und des Characters
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            for (int y = 0; y < MAP_SIZE; y++)
            {
                for (int x = 0; x < MAP_SIZE; x++)
                {
                    if (y == playerY && x == playerX)
                    {
                        Console.Write(playerChar);
                    }
                    else
                    {
                        int mapValue = map[x, y];
                        if (isKeyCollected && mapValue == (int)EMapTiles.closedDoor)
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

        private void DrawKey()
        // Hier wird der Schlüssel zufällig auf der Map gespwant - Hier kein Witz, is ne ernste Sache! ;)
        {
            System.Random rnd = new Random();

            int keyX;
            int keyY;

            do
            {
                keyX = rnd.Next(1, MAP_SIZE - 1);
                keyY = rnd.Next(1, MAP_SIZE - 1);
            } while (map[keyX, keyY] != (int)EMapTiles.floor);

            map[keyX, keyY] = (int)EMapTiles.key;
        }

        private void HandleKeyCollection()
        // Hier wird dafür gesorgt das der Schlüssel auch eine Funktion bekommt - und zwar das Löschen sobald der Character ihn aufsammelt.
        {
            if (map[playerX, playerY] == (int)EMapTiles.key)
            {
                isKeyCollected = true;
                map[playerX, playerY] = (int)EMapTiles.floor;

                OpenDoor();
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
                doorX = rndDoor.Next(0, MAP_SIZE);
                doorY = rndDoor.Next(0, MAP_SIZE);

                // Kurz zur Erklärung: Hier wird überprüft ob die Tür in einer der Ecken erscheint und platziert sie um, wenn es so wäre.
                if ((doorX == 1 && doorY == 1) || (doorX == 1 && doorY == MAP_SIZE - 2) || (doorX == MAP_SIZE - 2 && doorY == 1) || (doorX == MAP_SIZE - 2 && doorY == MAP_SIZE - 2))
                {
                    doorX = doorY = -1;
                }

            } while (doorX == -1 || map[doorX, doorY] != (int)EMapTiles.wall);

            map[doorX, doorY] = (int)EMapTiles.closedDoor;
        }

        private void OpenDoor()
        // Offen sollte sie am ende auch sein... ansonsten GAME OVER!
        {
            for (int x = 0; x < MAP_SIZE; x++)
            {
                for (int y = 0; y < MAP_SIZE; y++)
                {
                    if (map[x, y] == (int)EMapTiles.closedDoor)
                    {
                        map[x, y] = (int)EMapTiles.openDoor;
                        return;
                    }
                }
            }
        }
    }
}
