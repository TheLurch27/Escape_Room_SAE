using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room_SAE
{
    class Game
    {
        const int groundSize = 20;
        const int groundYPos = 10;
        const ConsoleColor groundColor = ConsoleColor.Red;
        const ConsoleColor defaultGroundColor = ConsoleColor.Black; 

        const char playerVisuals = 'P';
        int playerXPos, playerYPos;

        public void Run() // Neue "Main"
        {
            // Boden visuell anzeigen
            // Spieler visuell anzeigen
            // Spieler bewegen mit USer Input
            DrawMap();
            DrawPlayer();

            Console.ReadLine();
        }

        public void DrawMap()
        {
            Console.SetCursorPosition(0, groundYPos);
            Console.BackgroundColor = groundColor;
            for (int i = 0; i < groundSize; i++)
            {
                Console.Write(" ");
            }
            Console.BackgroundColor = defaultGroundColor;
        }

        public void DrawPlayer()
        {
            Console.SetCursorPosition(playerXPos, groundYPos - 1);
            Console.Write(playerVisuals);
        }
    }
}
